/*  GRBL-Plotter. Another GCode sender for GRBL.
    This file is part of the GRBL-Plotter application.
   
    Copyright (C) 2015-2023 Sven Hasemann contact: svenhb@web.de

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/
/* MainFormUpdate
 * Update controls etc.
 * 2021-07-26 new
 * 2021-09-19 line 389 change order of virtualJoystickXY.Enabled
 * 2021-11-18 add processing of accessory D0-D3 from grbl-Mega-5X - line 210
 * 2021-11-22 change reg-key to get data-path from installation
 * 2021-12-14 change log path
 * 2023-01-10 line 132 get user.config path, change from PerUserRoaming to PerUserRoamingAndLocal
 * 2023-03-07 l:480 f:JoystickSetup() set joystick raster; l:560 f:UpdateControlEnablesInvoked show/hide stop
*/

using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace GrblPlotter
{
    public partial class MainForm : Form
    {
        private void UpdateLogging()
        {	// LogEnable { Level1=1, Level2=2, Level3=4, Level4=8, Detailed=16, Coordinates=32, Properties=64, Sort = 128, GroupAllGraphics = 256, ClipCode = 512, PathModification = 1024 }
            logFlags = (uint)Properties.Settings.Default.importLoggerSettings;
            logEnable = Properties.Settings.Default.guiExtendedLoggingEnabled && ((logFlags & (uint)LogEnables.Level4) > 0);
            logDetailed = logEnable && ((logFlags & (uint)LogEnables.PathModification) > 0);
            logStreaming = logEnable && ((logFlags & (uint)LogEnables.ClipCode) > 0);

            Gcode.LoggerTrace = Properties.Settings.Default.guiExtendedLoggingEnabled;
            Gcode.LoggerTraceImport = Gcode.LoggerTrace && Properties.Settings.Default.importGCAddComments;

            if (Gcode.LoggerTrace || Properties.Settings.Default.guiExtendedLoggingCOMEnabled)
            {
                foreach (var rule in NLog.LogManager.Configuration.LoggingRules)
                {
                    rule.EnableLoggingForLevel(NLog.LogLevel.Trace);
                    rule.EnableLoggingForLevel(NLog.LogLevel.Debug);
                }
                NLog.LogManager.ReconfigExistingLoggers();
            }
        }

        private void GetAppDataPath()
        {   // default: System.IO.Path.GetDirectoryName(System.Windows.Forms.Application.CommonAppDataPath); 
            const string reg_key_user = "HKEY_CURRENT_USER\\SOFTWARE\\KPolar";
            const string reg_key_admin = "HKEY_LOCAL_MACHINE\\SOFTWARE\\WOW6432Node\\KPolar";
            const string reg_key_admin2 = "HKEY_LOCAL_MACHINE\\SOFTWARE\\KPolar";
            string newPathUser = "", newPathAdmin = "", newPathAdmin2 = "";
            try
            { newPathUser = (string)Registry.GetValue(reg_key_user, "DataPath", 0); }
            catch { }
            try
            { newPathAdmin = (string)Registry.GetValue(reg_key_admin, "DataPath", 0); }
            catch { }
            try
            { newPathAdmin2 = (string)Registry.GetValue(reg_key_admin2, "DataPath", 0); }
            catch { }

            if (!string.IsNullOrEmpty(newPathUser))
            {
                Datapath.AppDataFolder = newPathUser;                   // get path from registry
                LogAppDataPath(reg_key_user);
                EventCollector.SetInstalled("HKCU");
            }
            else if (!string.IsNullOrEmpty(newPathAdmin))
            {
                Datapath.AppDataFolder = newPathAdmin;                   // get path from registry
                LogAppDataPath(reg_key_admin);
                EventCollector.SetInstalled("HKLM-WOW");
            }
            else if (!string.IsNullOrEmpty(newPathAdmin2))
            {
                Datapath.AppDataFolder = newPathAdmin2;                   // get path from registry
                LogAppDataPath(reg_key_admin2);
                EventCollector.SetInstalled("HKLM");
            }
            else // no setup?
            {
                if (Datapath.Application.StartsWith("C:\\Program"))
                {
                    newPathUser = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\GRBL_Plotter";
                    string oldPathData = Datapath.Application + "\\data";

                    Datapath.AppDataFolder = newPathUser;                   // set path to my documents
                    LogAppDataPath("fall back");
                    Logger.Warn("GetAppDataPath: current path starts with C:\\Program, which is probably write protected: {0}", Datapath.Application);
                    Logger.Warn("GetAppDataPath: switch to new path {0}", newPathUser);

                    DirectoryInfo dir = new DirectoryInfo(newPathUser + "\\data");
                    if (!dir.Exists)
                    {
                        Logger.Warn("GetAppDataPath: copy data-folders from {0} to {1}", oldPathData, newPathUser + "\\data");
                        DirectoryCopy(oldPathData, newPathUser + "\\data", true);
                    }

                    Registry.SetValue(reg_key_user, "DataPath", newPathUser);           // store for next prog-start				
                    EventCollector.SetInstalled("FallBack", true);
                }
                else
                {
                    Datapath.AppDataFolder = Datapath.Application;      // use application path
                    LogAppDataPath("Default");
                    EventCollector.SetInstalled("COPY", true);
                }
            }
        }
        private void LogAppDataPath(string src)
        {
            NLog.LogManager.Configuration.Variables["basedir"] = Datapath.LogFiles;
            Logger.Info("GetAppDataPath from {0}: {1}", src, Datapath.AppDataFolder);
            Logger.Info("Application path: {0}", Datapath.Application);
            Logger.Info("user.config path: {0}", ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoamingAndLocal).FilePath);
        }

        private static void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
        {
            //   Logger.Info("DirectoryCopy {0}  to  {1}", sourceDirName, destDirName);
            // Get the subdirectories for the specified directory.
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);

            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + sourceDirName);
            }

            DirectoryInfo[] dirs = dir.GetDirectories();

            // If the destination directory doesn't exist, create it.       
            Directory.CreateDirectory(destDirName);

            // Get the files in the directory and copy them to the new location.
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                string tempPath = Path.Combine(destDirName, file.Name);
                file.CopyTo(tempPath, false);
            }

            // If copying subdirectories, copy them and their contents to new location.
            if (copySubDirs)
            {
                foreach (DirectoryInfo subdir in dirs)
                {
                    string tempPath = Path.Combine(destDirName, subdir.Name);
                    DirectoryCopy(subdir.FullName, tempPath, copySubDirs);
                }
            }
        }
        private void SetGUISize()
        {
            Size desktopSize = System.Windows.Forms.SystemInformation.PrimaryMonitorSize;
            Location = Properties.Settings.Default.locationMForm;
            if ((Location.X < -20) || (Location.X > (desktopSize.Width - 100)) || (Location.Y < -20) || (Location.Y > (desktopSize.Height - 100))) { this.CenterToScreen(); }
            this.Size = Properties.Settings.Default.mainFormSize;

            this.WindowState = Properties.Settings.Default.mainFormWinState;

            int splitDist = Properties.Settings.Default.mainFormSplitDistance;
            if ((splitDist > splitContainer1.Panel1MinSize) && (splitDist < (splitContainer1.Width - splitContainer1.Panel2MinSize)))
                splitContainer1.SplitterDistance = splitDist;

            this.Text = appName;
            //this.Text = string.Format("{0}", appName, MyApplication.GetVersion());
            //            this.Text = string.Format("{0} Ver. {1}  Date {2}", appName, System.Windows.Forms.Application.ProductVersion.ToString(culture), File.GetCreationTime(System.Reflection.Assembly.GetExecutingAssembly().Location).ToString("yyyy-mm-dd hh:mm:ss"));
            toolTip1.SetToolTip(this, this.Text);

            SplitContainer1_SplitterMoved(null, null);
        }

        private void RemoveCursorNavigation(Control.ControlCollection controls)
        {
            foreach (Control ctrl in controls)
            {
                ctrl.PreviewKeyDown += new PreviewKeyDownEventHandler(MainForm_PreviewKeyDown);
                RemoveCursorNavigation(ctrl.Controls);
            }
        }

        private void SetMenuShortCuts()
        {
            loadToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.O;
            saveToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.S;
            loadMachineParametersToolStripMenuItem.ShortcutKeys = Keys.Alt | Keys.Control | Keys.O;
            saveMachineParametersToolStripMenuItem.ShortcutKeys = Keys.Alt | Keys.Control | Keys.S;

            cmsCodeSelect.ShortcutKeys = Keys.Control | Keys.A;
            cmsCodeCopy.ShortcutKeys = Keys.Control | Keys.C;
            cmsCodePaste.ShortcutKeys = Keys.Control | Keys.V;
            cmsCodeSendLine.ShortcutKeys = Keys.Alt | Keys.Control | Keys.M;


            toggleBlockExpansionToolStripMenuItem.ShortcutKeys = Keys.Alt | Keys.E;
            foldCodeBlocks1stLevelToolStripMenuItem.ShortcutKeys = Keys.Alt | Keys.D2;
            foldCodeBlocks2ndLevelToolStripMenuItem.ShortcutKeys = Keys.Alt | Keys.D3;
            foldCodeBlocks3rdLevelToolStripMenuItem.ShortcutKeys = Keys.Alt | Keys.D4;
            expandCodeBlocksToolStripMenuItem1.ShortcutKeys = Keys.Alt | Keys.D1;

            cmsPicBoxMoveToMarkedPosition.ShortcutKeys = Keys.Control | Keys.M;
            cmsPicBoxPasteFromClipboard.ShortcutKeys = Keys.Control | Keys.V;
            cmsPicBoxReloadFile.ShortcutKeys = Keys.Control | Keys.R;
            cmsPicBoxDuplicatePath.ShortcutKeys = Keys.Control | Keys.D;

            toolStrip_tBRadiusCompValue.Text = string.Format(culture, "{0:0.000}", Properties.Settings.Default.crcValue);

        }

        // load settings
        public void LoadSettings(object sender, EventArgs e)
        {
            Logger.Info("LoadSettings");

            if ((_setup_form != null) && (_setup_form.settingsReloaded))
            {
                _setup_form.settingsReloaded = false;
                SetGUISize();							// if reset ALL settings was pressed (incl. form locations)
            }
            pictureBox1.Invalidate();

            UpdateWholeApplication();

            if (Properties.Settings.Default.guiExtendedLoggingEnabled || Properties.Settings.Default.guiExtendedLoggingCOMEnabled)
                StatusStripSet(0, "Logging enabled", Color.Yellow);
            else
                StatusStripClear(0);

            _projector_form?.Invalidate();
        }

        private void UpdateWholeApplication()	// after ini file, setup change, update controls
        {	// Update everything which could be changed via Setup or INI-file
            Logger.Info("UpdateWholeApplication");
            UpdateLogging();

            showFormInFront = Properties.Settings.Default.guiShowFormInFront;

            fCTBCode.BookmarkColor = Properties.Settings.Default.gui2DColorMarker; ;
            fCTBCode.LineInterval = (int)Properties.Settings.Default.FCTBLineInterval;
            tbFile.Text = Properties.Settings.Default.guiLastFileLoaded;
	
            GraphicPropertiesSetup();			// pen / brush colors
            MenuTranslateSetup();				// set rotary info in menu item 'translate'

            GuiEnableAxisABC();					// enable and resize axis ABC GUI buttons (set 0)
            
            
            
            // 2-D view settings
            toolStripViewMachine.Checked = Properties.Settings.Default.machineLimitsShow;
            toolStripViewTool.Checked = Properties.Settings.Default.gui2DToolTableShow;
            toolStripViewMachineFix.Checked = Properties.Settings.Default.machineLimitsFix;

            

            // grbl communication
            int[] interval = new int[] { 500, 250, 200, 125, 100 };
            int index = Properties.Settings.Default.grblPollIntervalIndex;
            if ((index >= 0) && (index < 5))
                Grbl.pollInterval = interval[index];

            gamePadTimer.Enabled = Properties.Settings.Default.gamePadEnable;
            CheckMachineLimit();
            LoadHotkeys();

            // changed PWM settings			
            GuiVariables.variable["GMIS"] = (double)Properties.Settings.Default.importGCPWMDown;
            GuiVariables.variable["GMAS"] = (double)Properties.Settings.Default.importGCPWMUp;
            GuiVariables.variable["GZES"] = (double)Properties.Settings.Default.importGCPWMZero;
            GuiVariables.variable["GCTS"] = (double)(Properties.Settings.Default.importGCPWMDown + Properties.Settings.Default.importGCPWMUp) / 2;
            GuiVariables.WriteSettingsToRegistry(); // for use within external scripts

            
        }   // end load settings

        private void GuiEnableAxisABC()
        {
            ctrl4thAxis = Properties.Settings.Default.ctrl4thUse;
            ctrl4thName = Properties.Settings.Default.ctrl4thName;
            

            mirrorRotaryToolStripMenuItem.Visible = ctrl4thAxis;
            

           

            
        }
        private void MenuTranslateSetup()
        {
            skaliereXAufDrehachseToolStripMenuItem.Enabled = false;
            skaliereXAufDrehachseToolStripMenuItem.BackColor = SystemColors.Control;
            skaliereXAufDrehachseToolStripMenuItem.ToolTipText = "Enable rotary axis in Setup - Control";
            skaliereAufXUnitsToolStripMenuItem.BackColor = SystemColors.Control;
            skaliereAufXUnitsToolStripMenuItem.ToolTipText = "Enable in Setup - Control";
            skaliereYAufDrehachseToolStripMenuItem.Enabled = false;
            skaliereYAufDrehachseToolStripMenuItem.BackColor = SystemColors.Control;
            skaliereYAufDrehachseToolStripMenuItem.ToolTipText = "Enable rotary axis in Setup - Control";
            skaliereAufYUnitsToolStripMenuItem.BackColor = SystemColors.Control;
            skaliereAufYUnitsToolStripMenuItem.ToolTipText = "Enable in Setup - Control";
            toolStrip_tb_rotary_diameter.Text = string.Format("{0:0.00}", Properties.Settings.Default.rotarySubstitutionDiameter);

            if (Properties.Settings.Default.rotarySubstitutionEnable)
            {
                string tmptxt = string.Format("Calculating rotary angle depending on part diameter ({0:0.00} units) and desired size.\r\nSet part diameter in Setup - Control.", Properties.Settings.Default.rotarySubstitutionDiameter);
                if (Properties.Settings.Default.rotarySubstitutionX)
                {
                    skaliereXAufDrehachseToolStripMenuItem.Enabled = true;
                    skaliereXAufDrehachseToolStripMenuItem.BackColor = Color.Yellow;
                    skaliereAufXUnitsToolStripMenuItem.BackColor = Color.Yellow;
                    skaliereAufXUnitsToolStripMenuItem.ToolTipText = tmptxt;
                    skaliereXAufDrehachseToolStripMenuItem.ToolTipText = "";
                }
                else
                {
                    skaliereYAufDrehachseToolStripMenuItem.Enabled = true;
                    skaliereYAufDrehachseToolStripMenuItem.BackColor = Color.Yellow;
                    skaliereAufYUnitsToolStripMenuItem.BackColor = Color.Yellow;
                    skaliereAufYUnitsToolStripMenuItem.ToolTipText = tmptxt;
                    skaliereYAufDrehachseToolStripMenuItem.ToolTipText = "";
                }
            }
            if (Properties.Settings.Default.rotarySubstitutionEnable && Properties.Settings.Default.rotarySubstitutionSetupEnable)
            {
                string[] commands;
                if (Properties.Settings.Default.rotarySubstitutionEnable)
                { commands = Properties.Settings.Default.rotarySubstitutionSetupOn.Split(';'); }
                else
                { commands = Properties.Settings.Default.rotarySubstitutionSetupOff.Split(';'); }
                Logger.Info("rotarySubstitutionSetupEnable {0} [Setup - Program control - Rotary axis control]", string.Join(";", commands));
                
            }
        }
        

        // update controls on Main form (disable if streaming or no serial)
        // private void UpdateControlEnables()
        private void UpdateControlEnables()
        {
            if (this.InvokeRequired)
            { this.BeginInvoke((MethodInvoker)delegate () { UpdateControlEnablesInvoked(); }); }
            else
            { UpdateControlEnablesInvoked(); }
        }
        private void UpdateControlEnablesInvoked()//bool allowControl)
        {
            bool isConnected = false;
            


            bool allowControl = isStreamingPause;
            Logger.Trace("◯◯◯ updateControls isConnected:{0} isStreaming:{1} streamingAllowControl:{2} source:{3}", isConnected, isStreaming, allowControl, timerUpdateControlSource);
            timerUpdateControlSource = "";

            

           

            btnOffsetApply.Enabled = !isStreaming;
            gCodeToolStripMenuItem.Enabled = !isStreaming;

            
            //    btnReset.Enabled = isConnected;
           

            btnStreamStart.Enabled = false;     // sometimes nok
            btnStreamStart.Enabled = isConnected;// & isFileLoaded;
            btnStreamStop.Enabled = isConnected; // & isFileLoaded;
            

            
            EnableCmsCodeBlocks(VisuGCode.CodeBlocksAvailable());
        }


        #region Custom Buttons


        #endregion


        internal static void SetGcodeVariables()	// applied in MainForm.cs, defined in MainFormObjects.cs
        {
            GuiVariables.variable["GMIX"] = VisuGCode.xyzSize.minx;
            GuiVariables.variable["GMAX"] = VisuGCode.xyzSize.maxx;
            GuiVariables.variable["GCTX"] = (VisuGCode.xyzSize.minx + VisuGCode.xyzSize.maxx) / 2;
            GuiVariables.variable["GMIY"] = VisuGCode.xyzSize.miny;
            GuiVariables.variable["GMAY"] = VisuGCode.xyzSize.maxy;
            GuiVariables.variable["GCTY"] = (VisuGCode.xyzSize.miny + VisuGCode.xyzSize.maxy) / 2;
            GuiVariables.variable["GMIZ"] = VisuGCode.xyzSize.minz;
            GuiVariables.variable["GMAZ"] = VisuGCode.xyzSize.maxz;
            GuiVariables.variable["GCTZ"] = (VisuGCode.xyzSize.minz + VisuGCode.xyzSize.maxz) / 2;
            GuiVariables.variable["GMIS"] = (double)Properties.Settings.Default.importGCPWMDown;
            GuiVariables.variable["GMAS"] = (double)Properties.Settings.Default.importGCPWMUp;
            GuiVariables.variable["GZES"] = (double)Properties.Settings.Default.importGCPWMZero;
            GuiVariables.variable["GCTS"] = (double)(Properties.Settings.Default.importGCPWMDown + Properties.Settings.Default.importGCPWMUp) / 2;
            GuiVariables.WriteDimensionToRegistry();        
        }
    }
}

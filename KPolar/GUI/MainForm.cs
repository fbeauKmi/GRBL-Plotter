/*  GRBL-Plotter. Another GCode sender for GRBL.
    This file is part of the GRBL-Plotter application.
   
    Copyright (C) 2015-2025 Sven Hasemann contact: svenhb@web.de

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
/*  Thanks to https://github.com/PavelTorgashov/FastColoredTextBox
*/
/* 2016-09-18 improve performance for low-performance PC: during streaming show background-image with toolpath
 *            instead of redrawing toolpath with each onPaint.
 *            Joystick-control: adjustable step-width and speed.
 * 2016-12-31 Add GRBL 1.1 function
 * 2017-01-01 check form-location and fix strange location
 * 2017-01-03 Add 'Replace M3 by M4' during GCode file open
 * 2017-06-22 Cleanup transform actions
 * 2018-01-02 Add Override Buttons
 *            Bugfix - no zooming during  streaming - disable background image (XP Problems?)
 * 2018-03-18 Divide this file into several files
 * 2018-12-26 Commits from RasyidUFA via Github
 * 2019-01-01 Pass CustomButton command "($abc)" through DIY-Control "[abc]"
 *            Add variable hotkeys
 * 2019-01-06 Remove feedback-loop at cBSpindle / cBCoolant, save last value for spindle-textbox
 * 2019-01-16 line 922 || !_serial_form.isHeightProbing
 * 2019-03-02 Swap code to MainFormGetCodeTransform
 * 2019-03-05 Add SplitContainer for Editor, resize Joystick controls
 * 2019-03-17 Add custom buttons 13-16, save size of form
 * 2019-04-23 use joyAStep in gamePadTimer_Tick and gamePadGCode line 1360, 1490
 * 2019-05-10 extend override features
 * 2019-10-27 localization of strings
 * 2019-12-22 Line 1891 check if xyWidth < 0;
 * 2020-01-13 convert GCodeVisuAndTransform to a static class
 * 2020-03-10 add gui.variable GMIX,Y,Z GMAX,Y,Z - graphics dimensions
 * 2020-03-12 outsourcing GamePad, SimulatePath
 * 2020-05-06 add status strip info during check for Prog-update
 * 2020-09-18 split
 * 2020-12-28 add Marlin support
 * 2021-01-13 add 3rd serial com
 * 2021-01-20 move code for camera handling from here to 'MainFormGetCodetransform'
 * 2021-02-01 line 802 change 0 to 0.000
 * 2021-02-24 save Pen up/down buttons visibillity status
 * 2021-05-19 processCommands line 975 also load ini file
 * 2021-07-14 code clean up / code quality
 * 2021-11-11 track prog-start and -end
 * 2021-11-17 show path-nodes gui2DShowVertexEnable - will be switched off on prog-start - line 146
 * 2021-11-18 add processing of accessory D0-D3 from grbl-Mega-5X - line 976
 * 2021-12-14 line 613 remove else...
 * 2022-04-19 check  if (toolStripStatusLabel0 == null) 
 * 2023-01-02 CbLaser_CheckedChanged, CbSpindle_CheckedChanged check if Grbl.isConnected
 * 2023-03-07 l:714/786/811 f:VirtualJoystickXY/Z/A_move if index =0 stop Jog -> if (!Grbl.isVersion_0) SendRealtimeCommand(133);
 * 2023-03-09 l:1213 bugfix start streaming
 * 2023-05-30 l:532  f:MainTimer_Tick add _message_form close
 * 2023-09-11 l:270  f:SplashScreenTimer_Tick multiple file import and issue #360 -> new function MainFormLoadFile.cs - LoadFiles(string[] fileList, int minIndex)
 * 2024-05-19 l:1159 f:BtnReset_Click removed StopStreaming to avoid applying code after "stop" from flowControlText
 * 2024-05-28 l:625  f:MainTimer_Tick add delayedHeightMapShow timer

*/

using GrblPlotter.GUI;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.ServiceModel.Channels;
using System.ServiceModel.Configuration;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Interop;
using virtualJoystick;


namespace GrblPlotter
{
    public partial class MainForm : Form
    {
        
        Splashscreen _splashscreen = null;

        MessageForm _message_form = null;

        private const string appName = "KPolar labeller";
        private const string fileLastProcessed = "lastProcessed";
        private XyzPoint posProbe = new XyzPoint(0, 0, 0);
        private double? alternateZ = null;
        internal bool ResetDetected = false;
       

        private bool ctrl4thAxis = false;
        private string ctrl4thName = "A";
        private string lastLoadSource = "Nothing loaded";
        private string lastLoadFile = "Nothing loaded";
        private int coordinateG = 54;
        private readonly string zeroCmd = "G10 L20 P0";      // "G92"
        private ulong mainTimerCount = 0;

        private bool showFormInFront = false;

        // Trace, Debug, Info, Warn, Error, Fatal
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();
        private static readonly CultureInfo culture = CultureInfo.InvariantCulture;
        private static uint logFlags = 0;
        private static bool logEnable = false;
        private static bool logDetailed = false;
        private static readonly bool logPosEvent = false;
        private static bool logStreaming = false;



        public MainForm()
        {   // Use the Constructor in a Windows Form for ensuring that initialization is done properly.
            // Use load event: code that requires the window size and location to be known.

            GetAppDataPath();           // find AppDataPath

            CultureInfo ci = new CultureInfo(Properties.Settings.Default.guiLanguage);
            Localization.UpdateLanguage(Properties.Settings.Default.guiLanguage);
            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;
            UpdateLogging();            // set logging flags

            Logger.Trace("###### START KPolar Ver. {0} {1}  ######", MyApplication.GetVersion(), MyApplication.GetLinkerTimestampUtc(System.Reflection.Assembly.GetExecutingAssembly()).ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss"));
            Logger.Info(culture, "###### START KPolar Ver. {0} {1} Language: {2}   OS: {3} ######", MyApplication.GetVersion(), MyApplication.GetCompilationDate(), ci, System.Environment.OSVersion);
            Logger.Info("Info {0}", Properties.Settings.Default.guiLastEndReason);
            EventCollector.Init();

            InitializeComponent();      // controls
            RemoveCursorNavigation(this.Controls);

            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
            AppDomain currentDomain = AppDomain.CurrentDomain;
            currentDomain.UnhandledException += new UnhandledExceptionEventHandler(Application_UnhandledException);

            this.Icon = Properties.Resources.Icon;  // set icon

            // Attention: no MessageBox during splashScreen: never visible and application waits for action!
            Logger.Info(culture, "++++++ MainForm SplashScreen start");
            _splashscreen = new Splashscreen();		// shows splash screen
            _splashscreen.Show();                   // will be closed if SplashScreenTimer >= 1500

            if (Properties.Settings.Default.ctrlUpgradeRequired)		// check if update of settings are needed
            {
                Logger.Info("MainForm_Load - Properties.Settings.Default.ctrlUpgradeRequired");
                Properties.Settings.Default.Upgrade();
                Properties.Settings.Default.ctrlUpgradeRequired = false;
                Properties.Settings.Default.Save();
            }

            Properties.Settings.Default.gui2DShowVertexEnable = false;              // don't show vertex / path-nodes on program start
                                                                                    //	expandGCode = Properties.Settings.Default.FCTBBlockExpandOnSelect;

            if (Properties.Settings.Default.flowCheckRegistryChange)	// don't load from clipboard on program start
            {
                const string reg_key = "HKEY_CURRENT_USER\\SOFTWARE\\KPolar";
                try
                {
                    Registry.SetValue(reg_key, "update", 0);
                    Registry.SetValue(reg_key, "start", 0);
                    Registry.SetValue(reg_key, "stop", 0);
                    Registry.SetValue(reg_key, "offsetX", "0.0");
                    Registry.SetValue(reg_key, "offsetY", "0.0");
                    Registry.SetValue(reg_key, "rotate", "0.0");
                }
                catch (Exception er) { Logger.Error(er, "MainForm Reading reg-key update "); }
            }

            SetMenuShortCuts();				// Add shortcuts to menu items
            UpdateMenuChecker();

            LoadRecentList();               // open Recent.txt and fill menu
            if (MRUlist.Count > 0)			// add recent list to gui menu
            {
                foreach (string item in MRUlist)
                {
                    ToolStripMenuItem fileRecent = new ToolStripMenuItem(item, null, RecentFile_click);  //create new menu for each item in list
                    toolStripMenuItem2.DropDownItems.Add(fileRecent); //add the menu to "recent" menu
                }
            }
            SetRecentText();

            int toolSelect = Properties.Settings.Default.guiToolSelection;

            LoadExtensionList();			// fill menu with available extension-scripts
            CmsPicBoxEnable(false);			// no graphic - no tasks


            

          
            GbJoggingLarge = false;

            lbDimension.Select(0, 0);       // unselect text Dimension box

            try
            {
                if (ControlGamePad.Initialize())
                    Logger.Info(culture, "GamePad found");
            }
            catch (Exception er) { Logger.Error(er, " MainForm - ControlGamePad.Initialize "); }

            Grbl.Init();                    // load and set grbl messages in grblRelated.cs
            CodeMessage.Init();

            GuiVariables.ResetVariables();	// set variables in MainFormObjects.cs			

            if (Properties.Settings.Default.guiExtendedLoggingEnabled || Properties.Settings.Default.guiExtendedLoggingCOMEnabled)
                StatusStripSet(0, "Logging enabled", Color.Yellow);
        }

        // initialize Main form
        private void MainForm_Load(object sender, EventArgs e)
        {
            // Use the Constructor in a Windows Form for ensuring that initialization is done properly.
            // Use load event: code that requires the window size and location to be known.
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            SetGUISize();               // resize GUI arcodring last size and check if within display in MainFormUpdate.cs

           
            mainTimerCount = 0;
            SplashScreenTimer.Enabled = true;
            SplashScreenTimer.Stop();
            SplashScreenTimer.Start();  // 1st event after 1500
            CbAddGraphic_CheckedChanged(sender, e);
        }

        private void SplashScreenTimer_Tick(object sender, EventArgs e)
        {
            if (_splashscreen != null)          // 2nd occurance, hide splashscreen windows
            {
                this.Opacity = 100;

                //if (_serial_form == null)
                //{
                //    if (Properties.Settings.Default.ctrlUseSerial2)
                //    {
                //        _serial_form2 = new ControlSerialForm("COM Tool changer", 2);
                //        if (showFormInFront) _serial_form2.Show(this);
                //        else _serial_form2.Show();
                //    }
                //    if (Properties.Settings.Default.ctrlUseSerial3)
                //    {
                //        _serial_form3 = new SimpleSerialForm();// "COM simple", 3);
                //        if (showFormInFront) _serial_form3.Show(this);
                //        else _serial_form3.Show();
                //    }
                //    _serial_form = new ControlSerialForm("COM CNC", 1, _serial_form2, _serial_form3);
                //    if (showFormInFront) _serial_form.Show(this);
                //    else _serial_form.Show();

                //    _serial_form.RaisePosEvent += OnRaisePosEvent;
                //    _serial_form.RaiseStreamEvent += OnRaiseStreamEvent;
                //}

                if (_splashscreen != null)
                {
                    _splashscreen.Close();
                    _splashscreen.Dispose();
                }
                _splashscreen = null;
                Logger.Info(culture, "++++++ MainForm SplashScreen closed          -> mainTimer:{0}", mainTimerCount);

                string[] args = Environment.GetCommandLineArgs();

                if (args.Length > 1)
                    LoadFiles(args, 1);

                SplashScreenTimer.Stop();
                SplashScreenTimer.Interval = 2000;
                SplashScreenTimer.Start();
               
                timerUpdateControls = true;
                Properties.Settings.Default.guiLastStart = DateTime.Now.Ticks;
                Properties.Settings.Default.guiLastEndReason = "";

                if (Properties.Settings.Default.processOpenOnProgStart)
                { ProcessAutomationFormOpen(sender, e); }

                CheckProgramFiles();
            }
            else
            {
                SplashScreenTimer.Enabled = false;      // 1st occurance, show splashscreen windows
                                                        //    StatusStripClear(2, 2);
                Logger.Info(culture, "++++++ MainForm SplashScreen Timer disabled  -> mainTimer:{0}", mainTimerCount);
                timerUpdateControlSource = "SplashScreenTimer_Tick";
                MainTimer.Stop();
                MainTimer.Start();
            }
        }

        // close Main form
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {   // Note all other forms will be closed, before reaching following code...
            Logger.Info("###### FormClosing ");
            if (isStreaming)
                EventCollector.SetStreaming("CLOST");
            else
                EventCollector.SetStreaming("CLOSE");

            loadTimer.Stop();
            Properties.Settings.Default.mainFormWinState = WindowState;
            WindowState = FormWindowState.Normal;
            Properties.Settings.Default.mainFormSize = Size;
            Properties.Settings.Default.locationMForm = Location;
            ControlPowerSaving.EnableStandby();
            Properties.Settings.Default.mainFormSplitDistance = splitContainer1.SplitterDistance;
            

            Properties.Settings.Default.guiLastEnd = DateTime.Now.Ticks;

            SaveSettings();
            Logger.Info("###### KPolar STOP ######");
        }
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Logger.Info("###+++ KPolar FormClosed +++###");
            if (System.Windows.Forms.Application.MessageLoop)
            {
                // Use this since we are a WinForms app
                System.Windows.Forms.Application.Exit();
            }
            else
            {
                // Use this since we are a console app
                System.Environment.Exit(1);
            }
            EventCollector.SetEnd();
            Logger.Info("EventCollector: {0}", Properties.Settings.Default.guiLastEndReason);
        }
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Logger.Trace("##**** KPolar EXIT");
            this.Close();
        }


        


        private void SendCommands(string txt, bool jogging = false)
        {
            if (txt.Contains(";"))
            {
                string[] commands = txt.Split(';');
                foreach (string cmd in commands)
                { if (cmd.Length > 0) SendCommand(cmd.Trim(), jogging); }
            }
            else
                SendCommand(txt, jogging);
        }

        private void SendCommand(string txt, bool jogging = false)
        {
            if (!Grbl.isConnected)
            { Logger.Warn("SendCommand txt:{0}  jog:{1}  - not connected", txt, jogging); }

            if ((jogging) && (Grbl.isVersion_0 == false))   // includes (grbl.isMarlin == false) https://github.com/gnea/grbl/wiki/Grbl-v1.1-Jogging
            {
                string[] stringArray = { "G90", "G91", "G20", "G21", "G53" };
                if (txt.Contains("X") || txt.Contains("Y") || txt.Contains("Z") || txt.Contains("A") || txt.Contains("B") || txt.Contains("C"))
                {
                    foreach (string x in stringArray)
                    {
                        if (txt.Contains(x))
                        {
                            txt = "$J=" + txt;
                            break;
                        }
                    }
                }
            }
            txt = GuiVariables.InsertVariable(txt);			// will be filled in MainFormLoadFile.cs 1617, defined in MainFormObjects.cs
           

            
        }


        // update 500ms
        private void MainTimer_Tick(object sender, EventArgs e)
        {
            if (timerUpdateControls)    // streaming reset, finish, pause, toolchange, stop
            {
                timerUpdateControls = false;
                Logger.Trace(culture, "MainTimer_Tick - timerUpdateControls {0}", timerUpdateControlSource);
                UpdateWholeApplication();
                UpdateControlEnables();       // enable controls if serial connected
                                              //                resizeJoystick();       // shows / hide A,B,C joystick controls
                Invalidate();
            }
            const string reg_key = "HKEY_CURRENT_USER\\SOFTWARE\\KPolar";

            if (isStreaming)
            {
                elapsed = DateTime.UtcNow - timeInit;


                if (signalShowToolExchangeMessage)
                {
                    signalShowToolExchangeMessage = false;
                    ShowToolChangeMessage();
                }
                if (Properties.Settings.Default.flowCheckRegistryChange)
                {
                    int start = 0, stop = 0;
                    

                    try
                    {
                        start = (int)Registry.GetValue(reg_key, "start", 0);
                        Registry.SetValue(reg_key, "start", 0);
                        stop = (int)Registry.GetValue(reg_key, "stop", 0);
                        Registry.SetValue(reg_key, "stop", 0);
                    }
                    catch (Exception er) { Logger.Error(er, "MainTimer_Tick stream Reading reg-key update "); }

                    if (start != 0)
                    {
                        Logger.Trace("MainTimer_Tick Pause streaming");
                        StartStreaming(0, fCTBCode.LinesCount - 1);   // btnStreamStart.PerformClick(); 
                    }
                    if (stop != 0)
                    {
                        Logger.Trace("MainTimer_Tick Stop streaming");

                    }
                }
            }
            else
            {
                if (updateDrawingPath && VisuGCode.ContainsG91Command())
                {
                    pictureBox1.Invalidate(); // will be called by parent function
                }
                updateDrawingPath = false;

                if (Properties.Settings.Default.flowCheckRegistryChange)
                {
                    int update = 0, start = 0;
                    double offX = 0;
                    double offY = 0;
                    double rotate = 0;
                    
                    try
                    {
                        update = (int)Registry.GetValue(reg_key, "update", 0);
                        Registry.SetValue(reg_key, "update", 0);

                        if (double.TryParse((string)Registry.GetValue(reg_key, "offsetX", "0.0"), out double ox)) { offX = ox; }
                        if (double.TryParse((string)Registry.GetValue(reg_key, "offsetY", "0.0"), out double oy)) { offY = oy; }
                        if (double.TryParse((string)Registry.GetValue(reg_key, "rotate", "0.0"), out double r)) { rotate = r; }
                        Registry.SetValue(reg_key, "offsetX", "0.0");
                        Registry.SetValue(reg_key, "offsetY", "0.0");
                        Registry.SetValue(reg_key, "rotate", "0.0");

                        start = (int)Registry.GetValue(reg_key, "start", 0);
                        Registry.SetValue(reg_key, "start", 0);
                    }
                    catch (Exception er) { Logger.Error(er, "Reading reg-key update"); }

                    if (update > 0)
                    {
                        Logger.Trace("MainTimer_Tick Automatic update from clipboard");
                        LoadFromClipboard();
                        EnableCmsCodeBlocks(VisuGCode.CodeBlocksAvailable());
                        Properties.Settings.Default.counterImportExtension += 1;
                    }

                    if ((offX != 0) || (offY != 0))
                    {
                        Logger.Trace("MainTimer_Tick OffX:{0}  OffY:{1}", offX, offY);
                        TransformStart("Offset Reg");
                        fCTBCode.Text = VisuGCode.TransformGCodeOffset(-offX, -offY, 0);// VisuGCode.Translate.Offset1);                    
                        TransformEnd();
                    }

                    if (rotate != 0)
                    {
                        Logger.Trace("MainTimer_Tick Rotate:{0}", rotate);
                        TransformStart("Rotate Reg");
                        fCTBCode.Text = VisuGCode.TransformGCodeRotate(rotate, 1, new XyPoint(0, 0));
                        TransformEnd();
                    }

                    if (start != 0)
                    {
                        Logger.Trace("MainTimer_Tick Start streaming", rotate);
                        StartStreaming(0, fCTBCode.LinesCount - 1);   // (); btnStreamStart.PerformClick();
                    }
                }

                if (loadTimerStep == 0)
                {
                    pictureBox1.Invalidate();   // vector graphic is loading
                    Application.DoEvents();
                }
            }
            if (signalPlay > 0) // activate blinking buttob
            {
                if ((signalPlay++ % 2) > 0) btnStreamStart.BackColor = Color.Yellow;
                else btnStreamStart.BackColor = SystemColors.Control;
            }
           

            ShowGrblLastMessage();

            if (timerShowGCodeError)
            {
                timerShowGCodeError = false;
                ShowGCodeErrors();
            }

            if (delayedStatusStripClear0 > 0)
            {
                if (delayedStatusStripClear0-- == 1)
                { StatusStripClear(0); }
            }
            if (delayedStatusStripClear1 > 0)
            {
                if (delayedStatusStripClear1-- == 1)
                { StatusStripClear(1); }
            }
            if (delayedStatusStripClear2 > 0)
            {
                if (delayedStatusStripClear2-- == 1)
                { StatusStripClear(2); }
            }
            if (delayedMessageFormClose > 0)
            {
                if (delayedMessageFormClose-- == 1)
                {
                    if (!CloseMessageForm(true))
                        delayedMessageFormClose++;

                    //    Logger.Trace("delayedMessageFormClose {0}", delayedMessageFormClose);
                }
            }
            if (delayedHeightMapShow > 0)
            {
                if (delayedHeightMapShow-- == 1)
                { LoadHeightMap(); }
            }

            mainTimerCount++;
        }

        private bool CloseMessageForm(bool keepOpen = false)
        {
            if (_message_form != null)
            {
                if (keepOpen && _message_form.DontClose)
                    return false;
                _message_form.Close();
                _message_form = null;
            }
            return true;
        }

        private void ShowGrblLastMessage()
        {
            if (Grbl.lastMessage.Length > 3)
            {
                if (Grbl.lastMessage.ToLower(culture).Contains("missing"))
                {
                    StatusStripClear();
                    StatusStripSet(1, Grbl.lastMessage, Color.Fuchsia);
                    StatusStripSet(2, Localization.GetString("statusStripeResetNeeded"), Color.Yellow);
                }
                else if (Grbl.lastMessage.ToLower(culture).Contains("reset"))
                {
                    StatusStripClear(2); // MainTimer_Tick

                    if (Grbl.lastMessage.ToLower(culture).Contains("streaming"))
                        StatusStripSet(1, Grbl.lastMessage, Color.Fuchsia);
                    else
                        StatusStripSet(1, Grbl.lastMessage, Color.Yellow);

                    if (Grbl.lastMessage.ToLower(culture).Contains("hard"))
                        StatusStripSet(2, Localization.GetString("statusStripeGrblResetNeeded"), Color.Yellow);
                }
                else
                    StatusStripSet(1, Grbl.lastMessage, Color.Yellow);
                Grbl.lastMessage = "";
            }
        }


        #region GUI Objects

        // Setup Custom Buttons during loadSettings()
        private readonly string[] btnCustomCommand = new string[33];
        private int SetCustomButton(Button btn, string text)//, int cnt)
        {
            int index;
            try
            {
                index = Convert.ToUInt16(btn.Name.Substring("btnCustom".Length), culture);
            }
            catch (Exception err) { Logger.Error(err, "SetCustomButton {0}", btn.Name); return 0; }

            if (text.Contains("|") && (index >= 0) && (index < btnCustomCommand.Length))		// < 32
            {
                string[] parts = text.Split('|');
                Color btnColor = Control.DefaultBackColor;
                btn.Text = parts[0];
                if (parts.Length > 2)
                {
                    if (parts[2].Length > 3)
                    {
                        Color tmp = SystemColors.Control;
                        try
                        { tmp = ColorTranslator.FromHtml(parts[2]); }
                        catch (Exception err)
                        { Logger.Error(err, "SetCustomButton with {0} from {1}", parts[2], text); }
                        btnColor = tmp;
                    }
                }
                SetButtonColors(btn, btnColor);

                if (parts[1].Length > 1)
                {
                    if ((parts[1].Length > 4) && File.Exists(parts[1]))
                    {
                        string[] lines = File.ReadAllLines(parts[1]);
                        string output = "";
                        int max = 10;
                        foreach (string line in lines)
                        { output += line + "\r\n"; if (max-- <= 0) break; }
                        toolTip1.SetToolTip(btn, parts[0] + "\r\nFile: " + parts[1] + "\r\n" + output);
                    }
                    else
                    { toolTip1.SetToolTip(btn, parts[0] + "\r\n" + parts[1].Replace(";", "\r\n")); }
                }
                else
                {
                    toolTip1.SetToolTip(btn, "Right click to change content");
                }

                btnCustomCommand[index] = parts[1];
                return parts[0].Trim().Length;// + parts[1].Trim().Length;
            }
            return 0;
        }
        private static void SetButtonColors(Button btn, Color col)
        {
            btn.BackColor = col;
            btn.ForeColor = ContrastColor(col);
            if (col == Control.DefaultBackColor)
                btn.UseVisualStyleBackColor = true;
        }
        private static Color ContrastColor(Color color)
        {
            int d;
            // Counting the perceptive luminance - human eye favors green color... 
            double a = 1 - (0.299 * color.R + 0.587 * color.G + 0.114 * color.B) / 255;
            if (a < 0.5)
                d = 0; // bright colors - black font
            else
                d = 255; // dark colors - white font
            return Color.FromArgb(d, d, d);
        }


        private static HttpClient shareclient = new HttpClient();

        private async void Export_Gcode_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(serverIP.Text) && !(string.IsNullOrEmpty(saveName)))
            {
                string serverIPAddress = serverIP.Text;
                string filename = saveName + ".gcode";
                IList<string> temp = fCTBCode.Lines;
                // remove any brackets, comments
                string comments = "";
                temp = new List<string>();
                int pos;
                foreach (string line in fCTBCode.Lines)
                {
                    if (line.StartsWith("("))
                        continue;
                    pos = line.IndexOf("(");
                    if (pos > 0)
                        temp.Add(line.Substring(0, pos));
                    else
                        temp.Add(line);
                }
                int encodeIndex = Properties.Settings.Default.FCTBSaveEncodingIndex;
                if ((encodeIndex < 0) || (encodeIndex >= GuiVariables.SaveEncoding.Length))
                    encodeIndex = 0;

                string encoding = GuiVariables.SaveEncoding[encodeIndex].BodyName;

                var isPrintEnabled = new StringContent("true");
                //string message = filename + " is ready to upload\n    Press [Yes] to upload and print,\n     [No] to upload.";
                //string caption = "Error Detected in Input";
                //MessageBoxButtons buttons = MessageBoxButtons.YesNoCancel;
                //DialogResult result = MessageBox.Show(message, caption, buttons);
                //if (result == DialogResult.Yes)
                //    isPrintEnabled = new StringContent("true");
                //else if (result == DialogResult.No)
                //    isPrintEnabled = new StringContent("false");
                //else
                //{
                //    return;
                //}
                var dialog = new CustomDialog(filename + " is ready to upload", "Upload GCode", this);
                dialog.ShowDialog();
                if ( dialog.Result != CustomDialog.DialogResult.Cancel)
                {
                    isPrintEnabled = new StringContent(dialog.Result == CustomDialog.DialogResult.UploadAndPrint ? "true" : "false");
                }
                else
                {
                    return;
                }
               


                try
                    {
                        using (var form = new MultipartFormDataContent())
                        {
                            var fileContent = new StringContent(string.Join(Environment.NewLine, temp));
                            fileContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");
                            form.Add(fileContent, "file", Path.GetFileName(filename));

                            form.Add(isPrintEnabled, "print");

                            var response = await shareclient.PostAsync($"http://{serverIPAddress}:7125/server/files/upload", form);

                            if (response.IsSuccessStatusCode)
                            {
                                // Save serverIPAddress to config
                                if (Properties.Settings.Default.serverIPAddress != serverIPAddress)
                                {
                                    Properties.Settings.Default.serverIPAddress = serverIPAddress;
                                    Properties.Settings.Default.Save();
                                }

                                MessageBox.Show("File uploaded successfully.");
                            }
                            else
                            {
                                MessageBox.Show($"Failed to upload file. Status code: {response.StatusCode}");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An error occurred: {ex.Message}");
                    }
            }
            else
            {
                string message = "You did not enter the plotter IP or file path.";
                string caption = "Error Detected in Input";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show(message, caption, buttons);
            }
        }
        #endregion



        private void MainForm_Activated(object sender, EventArgs e)
        {
            if (!pictureBox1.Focused)
                pictureBox1.Focus();
        }

        private void PictureBox1_MouseHover(object sender, EventArgs e)
        {
            if (!pictureBox1.Focused && Properties.Settings.Default.guiShowFormInFront)
            {
                //    pictureBox1.Focus();
                markerSize = (float)((double)Properties.Settings.Default.gui2DSizeTool / (picScaling * zoomFactor));
            }
        }

        private void FCTBCode_MouseHover(object sender, EventArgs e)
        {
            if (!fCTBCode.Focused && Properties.Settings.Default.guiShowFormInFront)
                fCTBCode.Focus();
        }


        private void UpdatePathDisplay(object sender, EventArgs e)
        {
            Properties.Settings.Default.gui2DRulerShow = toolStripViewRuler.Checked;
            Properties.Settings.Default.gui2DInfoShow = toolStripViewInfo.Checked;
            Properties.Settings.Default.gui2DPenUpShow = toolStripViewPenUp.Checked;
            Properties.Settings.Default.machineLimitsShow = toolStripViewMachine.Checked;
            Properties.Settings.Default.gui2DToolTableShow = toolStripViewTool.Checked;
            Properties.Settings.Default.guiDimensionShow = toolStripViewDimension.Checked;
            Properties.Settings.Default.guiBackgroundShow = toolStripViewBackground.Checked;
            Properties.Settings.Default.machineLimitsFix = toolStripViewMachineFix.Checked;
            zoomFactor = 1;
            VisuGCode.DrawMachineLimit();// ToolTable.GetToolCordinates());
            pictureBox1.Invalidate();                                   // resfresh view
        }
        private void UpdateMenuChecker()
        {
            toolStripViewRuler.Checked = Properties.Settings.Default.gui2DRulerShow;
            toolStripViewInfo.Checked = Properties.Settings.Default.gui2DInfoShow;
            toolStripViewPenUp.Checked = Properties.Settings.Default.gui2DPenUpShow;
            toolStripViewMachine.Checked = Properties.Settings.Default.machineLimitsShow;
            toolStripViewTool.Checked = Properties.Settings.Default.gui2DToolTableShow;
            toolStripViewDimension.Checked = Properties.Settings.Default.guiDimensionShow;
            toolStripViewBackground.Checked = Properties.Settings.Default.guiBackgroundShow;
            toolStripViewMachineFix.Checked = Properties.Settings.Default.machineLimitsFix;
        }
        private void MainForm_Resize(object sender, EventArgs e)
        {

            //    StatusStripSet(0, string.Format("New size X:{0}  Y:{1}",Width, Height), Color.White);
        }


        // adapt size of controls
        private void SplitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {
            int add = splitContainer1.Panel1.Width - 296;
            
            lbDimension.Width = 130 + add;
            btnLimitExceed.Left = 112 + add;
            groupBox4.Left = 133 + add;
        }

        private bool gBoxDROShowSetCoord = false;
        private void GrpBoxDRO_Click(object sender, EventArgs e)
        {
            gBoxDROShowSetCoord = !gBoxDROShowSetCoord;
        }

        private bool gBoxOverrideLarge = false;
        
        private bool GbJoggingLarge = false;
        

        internal void SetUndoText(string txt)
        {
            if (txt == null) txt = "";
            if (txt.Length > 1)
            {
                unDoToolStripMenuItem.Text = txt;
                unDoToolStripMenuItem.Enabled = true;
                unDo2ToolStripMenuItem.Text = txt;
                unDo2ToolStripMenuItem.Enabled = true;
                unDo3ToolStripMenuItem.Text = txt;
                unDo3ToolStripMenuItem.Enabled = true;
            }
            else
            {
                unDoToolStripMenuItem.Text = Localization.GetString("mainInfoUndo");    // "Undo last action";
                unDoToolStripMenuItem.Enabled = false;
                unDo2ToolStripMenuItem.Text = Localization.GetString("mainInfoUndo");    //"Undo last action";
                unDo2ToolStripMenuItem.Enabled = false;
                unDo3ToolStripMenuItem.Text = Localization.GetString("mainInfoUndo");    //"Undo last action";
                unDo3ToolStripMenuItem.Enabled = false;
            }
        }

        /* StatusStripSet messages:
         * 0: import, loggingEnabled, start import
         * 1: Key-usage, grblLastMessage, importOptions, setEditMode, fileLoading
         * 2: Exception, Marked group, Toggle penup, conversionInfo, clrEditmode
         */
        private void StatusStripSet(int nr, string text, Color color)
        {
            try
            {
                if (nr == 0)
                {
                    if (toolStripStatusLabel0 == null) return;
                    if (toolStripStatusLabel0.GetCurrentParent() == null) return;
                    if (toolStripStatusLabel0.GetCurrentParent().InvokeRequired)
                    { toolStripStatusLabel0.GetCurrentParent().BeginInvoke((MethodInvoker)delegate () { toolStripStatusLabel0.Text = "[ " + text + " ]"; toolStripStatusLabel0.BackColor = color; }); }
                    else
                    { toolStripStatusLabel0.Text = "[ " + text + " ]"; toolStripStatusLabel0.BackColor = color; }
                }
                else if (nr == 1)
                {
                    if (toolStripStatusLabel1 == null) return;
                    if (toolStripStatusLabel1.GetCurrentParent() == null) return;
                    if (toolStripStatusLabel1.GetCurrentParent().InvokeRequired)
                    { toolStripStatusLabel1.GetCurrentParent().BeginInvoke((MethodInvoker)delegate () { toolStripStatusLabel1.Text = "[ " + text + " ]"; toolStripStatusLabel1.BackColor = color; }); }
                    else
                    { toolStripStatusLabel1.Text = "[ " + text + " ]"; toolStripStatusLabel1.BackColor = color; }
                }
                else if (nr == 2)
                {
                    if (toolStripStatusLabel2 == null) return;
                    if (toolStripStatusLabel2.GetCurrentParent() == null) return;
                    if (toolStripStatusLabel2.GetCurrentParent().InvokeRequired)
                    { toolStripStatusLabel2.GetCurrentParent().BeginInvoke((MethodInvoker)delegate () { toolStripStatusLabel2.Text = "[ " + text + " ]"; toolStripStatusLabel2.BackColor = color; }); }
                    else
                    { toolStripStatusLabel2.Text = "[ " + text + " ]"; toolStripStatusLabel2.BackColor = color; }
                }
            }
            catch (Exception err)
            { Logger.Error(err, "StatusStripSet nr:{0}, text:'{1}', color:{2}", nr, text, color.ToString()); }
        }

        private void StatusStripColor(int nr, Color color)
        {
            try
            {
                if (nr == 0)
                {
                    if (toolStripStatusLabel0 == null) return;
                    if (toolStripStatusLabel0.GetCurrentParent() == null) return;
                    if (toolStripStatusLabel0.GetCurrentParent().InvokeRequired)
                    { toolStripStatusLabel0.GetCurrentParent().BeginInvoke((MethodInvoker)delegate () { toolStripStatusLabel0.BackColor = color; }); }
                    else
                    { toolStripStatusLabel0.BackColor = color; }
                }
                else if (nr == 1)
                {
                    if (toolStripStatusLabel1 == null) return;
                    if (toolStripStatusLabel1.GetCurrentParent() == null) return;
                    if (toolStripStatusLabel1.GetCurrentParent().InvokeRequired)
                    { toolStripStatusLabel1.GetCurrentParent().BeginInvoke((MethodInvoker)delegate () { toolStripStatusLabel1.BackColor = color; }); }
                    else
                    { toolStripStatusLabel1.BackColor = color; }
                }
                else if (nr == 2)
                {
                    if (toolStripStatusLabel2 == null) return;
                    if (toolStripStatusLabel2.GetCurrentParent() == null) return;
                    if (toolStripStatusLabel2.GetCurrentParent().InvokeRequired)
                    { toolStripStatusLabel2.GetCurrentParent().BeginInvoke((MethodInvoker)delegate () { toolStripStatusLabel2.BackColor = color; }); }
                    else
                    { toolStripStatusLabel2.BackColor = color; }
                }
            }
            catch (Exception err)
            { Logger.Error(err, "StatusStripColor nr:{0}, color:{1}", nr, color.ToString()); }
        }

        private void StatusStripClear(int nr1, int nr2 = -1)//, string rem="")
        {
            if ((nr1 == 0) || (nr2 == 0))
            {
                if (toolStripStatusLabel0 == null) return;
                toolStripStatusLabel0.Text = ""; toolStripStatusLabel0.BackColor = SystemColors.Control; toolStripStatusLabel0.ToolTipText = "";
            }
            if ((nr1 == 1) || (nr2 == 1))
            {
                if (toolStripStatusLabel1 == null) return;
                toolStripStatusLabel1.Text = ""; toolStripStatusLabel1.BackColor = SystemColors.Control; toolStripStatusLabel1.ToolTipText = "";
            }
            if ((nr1 == 2) || (nr2 == 2))
            {
                if (toolStripStatusLabel2 == null) return;
                toolStripStatusLabel2.Text = ""; toolStripStatusLabel2.BackColor = SystemColors.Control; toolStripStatusLabel2.ToolTipText = "";
            }
        }
        private void StatusStripClear()
        {
            toolStripStatusLabel0.Text = toolStripStatusLabel1.Text = toolStripStatusLabel2.Text = "";
            toolStripStatusLabel0.BackColor = toolStripStatusLabel1.BackColor = toolStripStatusLabel2.BackColor = SystemColors.Control;
        }

        private void CopyContentToClipboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Image img = new Bitmap(pictureBox1.Width, pictureBox1.Height);

            Graphics g = Graphics.FromImage(img);
            Point pB1 = PointToScreen(pictureBox1.Location);
            Point pB2 = new Point(pB1.X + splitContainer1.Panel2.Left + tLPRechtsUnten.Left + 6, pB1.Y + tLPRechts.Location.Y + splitContainer1.Panel2.Top + tLPRechtsUnten.Top + 30);
            g.CopyFromScreen(pB2, new Point(0, 0), new Size(pictureBox1.Width, pictureBox1.Height));

            Clipboard.SetImage(img);
            img.Dispose();
            g.Dispose();
        }

        private void MainForm_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (pictureBox1.Focused && ((e.KeyCode == Keys.Right) || (e.KeyCode == Keys.Left) || (e.KeyCode == Keys.Up) || (e.KeyCode == Keys.Down) ||
                (e.KeyCode == Keys.Alt) || (e.KeyCode == Keys.Shift) || (e.KeyCode == Keys.Control)))
            { e.IsInputKey = true; }
        }

        private void ShowFormsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            if (_text_form != null) { _text_form.WindowState = FormWindowState.Normal; _text_form.BringToFront(); }
            if (_image_form != null) { _image_form.WindowState = FormWindowState.Normal; _image_form.BringToFront(); }
            if (_shape_form != null) { _shape_form.WindowState = FormWindowState.Normal; _shape_form.BringToFront(); }
            if (_wireCutter_form != null) { _wireCutter_form.WindowState = FormWindowState.Normal; _wireCutter_form.BringToFront(); }
            if (_barcode_form != null) { _barcode_form.WindowState = FormWindowState.Normal; _barcode_form.BringToFront(); }

            if (_setup_form != null) { _setup_form.WindowState = FormWindowState.Normal; _setup_form.BringToFront(); }
           
           
            if (_heightmap_form != null) { _heightmap_form.WindowState = FormWindowState.Normal; _heightmap_form.BringToFront(); }
           
            if (_process_form != null) { _process_form.WindowState = FormWindowState.Normal; _process_form.BringToFront(); }
            //   _streaming_form.SendToBack();
        }

        private void CbAddGraphic_CheckedChanged(object sender, EventArgs e)
        {
            if (CbAddGraphic.Checked)
                CbAddGraphic.BackColor = Color.Yellow;
            else
                CbAddGraphic.BackColor = Color.Transparent;
        }


        private void Enable_btnExpGcode(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(serverIP.Text) && !string.IsNullOrEmpty(saveName))
            {
                btnExpGcode.Enabled = true;
            }
            else
            {
                btnExpGcode.Enabled = false;
            }
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            BtnOpenFile_Click(sender, e);
        }
    }
}


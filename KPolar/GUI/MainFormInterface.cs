/*  GRBL-Plotter. Another GCode sender for GRBL.
    This file is part of the GRBL-Plotter application.
   
    Copyright (C) 2015-2024 Sven Hasemann contact: svenhb@web.de

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
/* 
 * 2020-09-18 split file
 * 2020-12-28 add Marlin support (replace commands)
 * 2021-07-02 code clean up / code quality
 * 2021-09-29 update Grbl.Status line 60
 * 2021-09-30 no VisuGCode.ProcessedPath.ProcessedPathDraw if VisuGCode.largeDataAmount
 * 2021-11-18 add processing of accessory D0-D3 from grbl-Mega-5X - line 139
 * 2022-02-24
 * 2023-03-09 simplify NULL check; case GrblState.unknown: UpdateControlEnables();
 * 2024-02-14 l:160 f:ProcessStatusMessage add grblDigialIn -Out
 * 2024-02-24 l:61 f:OnRaisePosEvent submit Grbl.StatMsg
*/

using System;
using System.Drawing;
using System.Windows.Forms;

namespace GrblPlotter
{
    public partial class MainForm : Form
    {

        private string oldRaw = "";
        private GrblState lastMachineStatus = GrblState.unknown;
        private string lastInfoText = "";
        private string lastLabelInfoText = "";
        private bool updateDrawingPath = false;
        private GrblState machineStatus;

        private string actualFR = "";
        private string actualSS = "";

        private bool timerUpdateControls = false;
        private string timerUpdateControlSource = "";

        /************************************************************
         * handle status report and position event from serial form
         * processStatus()
         ************************************************************/
        private void OnRaisePosEvent(object sender, PosEventArgs e)
        {
            //  if (logPosEvent)  Logger.Trace("OnRaisePosEvent  {0}  connect {1}  status {2}", e.Status.ToString(), _serial_form.serialPortOpen, e.Status.ToString());
            Grbl.Status = machineStatus = e.Status;
            Grbl.StatMsg = e.StatMsg;

            /***** Restore saved position after reset and set initial feed rate: *****/
            

            /***** process grblState {idle, run, hold, home, alarm, check, door} *****/
            ProcessStatus(e.Raw);

            /***** check and submit override values, set labels, checkbox *****/
            ProcessStatusMessage(e.StatMsg);

            /***** set DRO digital-read-out labels with machine and work coordinates *****/
            
            /***** parser state Spinde/Coolant on/off, on other Forms: FeedRate, SpindleSpeed, G54-Coord *****/
           

            /***** update 2D view *****/
            if (Grbl.posChanged)
            {
                VisuGCode.CreateMarkerPath();
                VisuGCode.UpdatePathPositions();
                CheckMachineLimit();
                pictureBox1.Invalidate();
                if (Properties.Settings.Default.flowCheckRegistryChange && !isStreaming)
                    GuiVariables.WritePositionToRegistry();
                Grbl.posChanged = false;
            }
            if (Grbl.wcoChanged)
            {
                CheckMachineLimit();
                Grbl.wcoChanged = false;
            }

            if (isStreaming && Properties.Settings.Default.guiProgressShow && !VisuGCode.largeDataAmount)
                VisuGCode.ProcessedPath.ProcessedPathDraw(Grbl.posWork);


           
        }

        private void ProcessStatusMessage(ModState StatMsg)
        {
            if (logPosEvent) Logger.Trace("processStatusMessage  ");
            
            

            /***** if no Accessory State character is given, no accessory is set and D is 0000 *****/
            
        

            

            if (Properties.Settings.Default.grblDescriptionDxEnable)
            {
                if (StatMsg.A.Contains("D"))
                {
                    string digits = StatMsg.A.Substring(StatMsg.A.IndexOf("D") + 1);     // Digital pins in order '3210'
                    int din = 0;
                    int dout = 0;
                    
                    Grbl.grblDigitalIn = (byte)din;
                    Grbl.grblDigitalOut = (byte)dout;
                }
            }

           

        }
        private void SetAccessoryButton(Button Btn, bool setOn)
        {
            if (setOn)
            { Btn.Image = Properties.Resources.led_on; Btn.Tag = "on"; }
            else
            { Btn.Image = Properties.Resources.led_off; ; Btn.Tag = "off"; }
        }
        

        


        /***************************************************************
         * handle status events from serial form
         * {idle, run, hold, home, alarm, check, door}
         * only action on status change
         ***************************************************************/
        private void ProcessStatus(string msg)
        {
            string lblInfoText = "";	// rename
            Color lblInfoColor = Color.Black;
            if (logPosEvent)
                Logger.Trace("processStatus  Status:{0}", machineStatus.ToString());
            if ((machineStatus != lastMachineStatus) || (Grbl.lastMessage.Length > 5))
            {

                switch (machineStatus)
                {
                    case GrblState.idle:
                        if ((lastMachineStatus == GrblState.hold) || (lastMachineStatus == GrblState.alarm))
                        {
                            StatusStripClear(1, 2);//, "grblState.idle");
                           

                           
                        }
                        signalResume = 0;
                       
                       
                       
                        if (!isStreaming)                       // update drawing if G91 is used
                            updateDrawingPath = true;

                        Grbl.lastMessage = "";
                        break;

                    case GrblState.run:
                       
                        signalResume = 0;
                       
                        break;

                    case GrblState.hold:
                        
                        lblInfoText = Localization.GetString("mainInfoResume");     //"Press 'Resume' to proceed";

                        if (Grbl.lastErrorNr > 0)
                            lblInfoColor = Color.Fuchsia;
                        else
                            lblInfoColor = Color.Yellow;

                       

                        StatusStripSet(1, Grbl.StatusToText(machineStatus), Grbl.GrblStateColor(machineStatus));
                        StatusStripSet(2, lblInfoText, lblInfoColor);
                        if (signalResume == 0) { signalResume = 1; }
                        break;

                    case GrblState.home:
                        break;

                    case GrblState.alarm:
                        signalLock = 1;
                      
                        lblInfoText = Localization.GetString("mainInfoKill");     //"Press 'Kill Alarm' to proceed";
                       

                        StatusStripSet(1, Grbl.StatusToText(machineStatus) + " " + Grbl.lastMessage, Grbl.GrblStateColor(machineStatus));
                        StatusStripSet(2, lblInfoText, Color.Yellow);
                        Grbl.lastMessage = "";
                        _heightmap_form?.StopScan();
                        break;

                    case GrblState.check:
                        break;

                    case GrblState.door:
                        
                        lblInfoText = Localization.GetString("mainInfoResume");     //"Press 'Resume' to proceed";
                        

                        StatusStripSet(1, Grbl.StatusToText(machineStatus), Grbl.GrblStateColor(machineStatus));
                        StatusStripSet(2, lblInfoText, Color.Yellow);
                        if (signalResume == 0) { signalResume = 1; }
                        break;

                    case GrblState.probe:
                       
                        if (_heightmap_form != null)
                            _heightmap_form.SetPosProbe = posProbe;


                        break;

                    case GrblState.unknown:
                        UpdateControlEnables();
                        break;

                    case GrblState.notConnected:
                        
                        StatusStripSet(1, "No connection - press 'RESET'", Color.Fuchsia);
                        StatusStripSet(2, msg, Color.Fuchsia);
                        isStreaming = false;
                        UpdateControlEnables();
                        break;

                    default:
                        break;
                }
                

            }
            lastMachineStatus = machineStatus;
        }

        
        

        private void SetGRBLBuffer()
        {
            if (!Grbl.axisUpdate && (Grbl.axisCount > 0))
            {
                Grbl.axisUpdate = true;
                if (Properties.Settings.Default.grblBufferAutomatic)
                {
                    if (Grbl.bufferSize > 0)
                    {
                        Grbl.RX_BUFFER_SIZE = (Grbl.bufferSize != 128) ? Grbl.bufferSize : 127;
                       
                        Logger.Info("Read buffer size of {0} [Setup - Flow control - grbl buffer size]   Grbl.axisCount:{1}", Grbl.RX_BUFFER_SIZE, Grbl.axisCount);
                    }
                    else
                    {
                        if (Grbl.axisCount > 3)
                            Grbl.RX_BUFFER_SIZE = 255;
                        else
                            Grbl.RX_BUFFER_SIZE = 127;

                       
                        Logger.Info("Assume buffer size of {0} [Setup - Flow control - grbl buffer size]   Grbl.axisCount:{1}", Grbl.RX_BUFFER_SIZE, Grbl.axisCount);
                    }
                }
                else
                {  //if (grbl.RX_BUFFER_SIZE != 127)
                   
                    Logger.Info("Buffer size was set manually to {0} [Setup - Flow control - grbl buffer size]  Grbl.axisCount:{1}", Grbl.RX_BUFFER_SIZE, Grbl.axisCount);
                }
                StatusStripClear(0);
                

                delayedStatusStripClear1 = 8;
            }
        }


        private void SetTextThreadSave(Label label, string txt, Color bcolor)
        {
            SetTextThreadSave(label, txt);
            label.BackColor = bcolor;
        }
        private void SetTextThreadSave(Label label, string txt)
        {
            if (label.InvokeRequired)
            { label.BeginInvoke((MethodInvoker)delegate () { label.Text = txt; }); }
            else
            { label.Text = txt; }
        }

        
    }
}
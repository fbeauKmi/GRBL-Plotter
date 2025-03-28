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
        //private GrblState machineStatus;

        private string actualFR = "";
        private string actualSS = "";

        private bool timerUpdateControls = false;
        private string timerUpdateControlSource = "";

       

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
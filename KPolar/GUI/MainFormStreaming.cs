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
/*
 * 2020-09-13 split file
 * 2020-12-03 Bug fix invoke required in line 59
 * 2020-12-16 line 183 remove lock
 * 2020-12-23 adjust notifier handling: only notify if estimated process time > notifier intervall
 * 2021-03-05 line 118 error handling
 * 2021-07-02 code clean up / code quality
 * 2021-09-03 BtnStreamStart_Click switch from click to mouseUp event
 * 2021-11-23 line 121, 403, 406 add try/catch
 * 2021-11-30 check lineIsInRange(fCTBCodeClickedLineNow)
 * 2021-12-10 line 122 check if (e.CodeLineSent >= fCTBCode.LinesCount); line 340 = fCTBCode.LinesCount - 1;
 * 2022-01-05 bug fix GrblStreaming.pause: show tool change message
 * 2022-04-06 line 485 also PathId
 * 2022-06-28 line 132 don't update marker on line-nr if e.Status == GrblStreaming.setting
 * 2022-11-03 line 245 check InvoeRequired
 * 2023-01-04 add _process_form.Feedback
 * 2023-01-06 line 579 error handling - check if line is in range
 * 2023-01-29 line 182 ProcessedPathLine(actualCodeLine);//.CodeLineConfirmed);
 *            line 153 removed line selection (to hoghlight line)
 * 2023-03-09 simplify NULL check
 * 2023-03-30 l:360 f:OnRaiseStreamEvent GrblStreaming.pause: add message also on TxM06
 * 2023-03-31 l:504 f:StartStreaming SetEditMode(false)
 * 2023-04-07 l:368 f:OnRaiseStreamEvent check for "tool" in different languages (de, fr, it) 
 * 2023-04-10 l:368 f:OnRaiseStreamEvent check LineIsInRange(tmpLine) first
*/

using GrblPlotter.GUI;
using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace GrblPlotter
{
    public partial class MainForm : Form
    {
        #region Streaming

        TimeSpan elapsed;               //elapsed time 
        DateTime timeInit;              //time start 

        private uint signalResume = 0;   // blinking button
        private uint signalLock = 0;     // blinking button
        private uint signalPlay = 0;     // blinking button
        private uint delayedSend = 0;
        private uint delayedStatusStripClear0 = 0;
        private uint delayedStatusStripClear1 = 0;
        private uint delayedStatusStripClear2 = 0;
        private uint delayedMessageFormClose = 0;

        private bool isStreaming = false;
        private bool isStreamingPause = false;
        private bool isStreamingCheck = false;
        //   private bool isStreamingRequestStop = false;
        private bool isStreamingOk = true;
        private string lblInfoOkString = "Send G-Code";

        /***** thread save update *****/
       

        private static string GetTimeStampString()
        { return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"); }

        /***** Receive streaming status from serial COM *****/
        private bool notifierUpdateFlag = false;
        private bool notifierUpdateMarkerFinish = false;
        private bool loggerUpdateMarker = false;
        private int lastErrorLine = 0;
        private void OnRaiseStreamEvent(object sender, StreamEventArgs e)
        {
            // only notify if estimated process-time > notifier intervall
            bool notifierEnable = ((double)Properties.Settings.Default.notifierMessageProgressInterval < VisuGCode.gcodeMinutes);
            if (isStreaming)
            {
                

                if ((e.CodeProgress % 5) == 0)
                {
                    if (loggerUpdateMarker)
                    {
                        loggerUpdateMarker = false;
                        Logger.Info("●●● OnRaiseStreamEvent Progress:{0,3}%  Duration:{1}  Line:{2,5}   Status:{3,6}   WCO.X:{4:0000.000}  Y:{5:0000.000}  Z:{6:0000.000}  A:{6:0000.000}  B:{6:0000.000}  C:{6:0000.000}", e.CodeProgress, elapsed.ToString(@"hh\:mm\:ss"), e.CodeLineSent, e.Status, Grbl.posWork.X, Grbl.posWork.Y, Grbl.posWork.Z, Grbl.posWork.A, Grbl.posWork.B, Grbl.posWork.C);
                    }
                }
                else { loggerUpdateMarker = true; }

                if (notifierEnable && Properties.Settings.Default.notifierMessageProgressEnable)
                {
                    if ((elapsed.Seconds % (int)(60 * Properties.Settings.Default.notifierMessageProgressInterval)) == 5) // offset 5 sec. to get message at start
                    {
                        if (notifierUpdateFlag)
                        {
                            notifierUpdateFlag = false;
                            string etime = string.Format("{0:00}:{1:00} hrs", elapsed.Hours, elapsed.Minutes);
                            string msg = string.Format("{0}Duration   : {1} \r\nCode line  : {2,6}\r\nProcessed: {3,4:0.0} %\r\nGrbl Buffer: {4,3:0} %\r\nTime stamp: {5}", "", etime, e.CodeLineSent, e.CodeProgress, e.BuffProgress, GetTimeStampString());//Properties.Settings.Default.notifierMessageProgress
                            if (Properties.Settings.Default.notifierMessageProgressTitle)
                                Notifier.SendMessage(msg, string.Format("{0,4:0.0} %", e.CodeProgress));
                            else
                                Notifier.SendMessage(msg);
                        }
                    }
                    else
                        notifierUpdateFlag = true;
                }
            }

            int actualCodeLine = e.CodeLineSent;
            if (e.Status != GrblStreaming.setting)      // if setting, e.CodeLineSent contains $$-nr, not line-nr.
            {
                if (actualCodeLine < 0) actualCodeLine = 0;
                if (e.CodeLineSent >= fCTBCode.LinesCount)
                    actualCodeLine = fCTBCode.LinesCount - 1;

                /*   try   // disabled in 1.6.8.4 2023-01-29
                   { fCTBCode.Selection = fCTBCode.GetLine(actualCodeLine); }
                   catch (Exception err) 
                   { 	Logger.Error(err, "OnRaiseStreamEvent - fCTBCode.Selection = fCTBCode.GetLine(actualCodeLine)"); 
                       EventCollector.SetStreaming("Sfctb0");
                   }*/

                fCTBCodeClickedLineNow = actualCodeLine - 1;
                if (fCTBCodeClickedLineNow < 0) fCTBCodeClickedLineNow = 0;

                FctbSetBookmark();         // set Bookmark and marker in 2D-View
                VisuGCode.SetPosMarkerLine(fCTBCodeClickedLineNow, false);

                /*    try   // disabled in 1.6.8.4 2023-01-29
                    {
                        if (this.fCTBCode.InvokeRequired)
                        { this.fCTBCode.BeginInvoke((MethodInvoker)delegate () { this.fCTBCode.DoCaretVisible(); }); }
                        else
                        { this.fCTBCode.DoCaretVisible(); }
                    }
                    catch (Exception er)
                    {
                        Logger.Error(er, "OnRaiseStreamEvent fCTBCode.InvokeRequired ");
                        EventCollector.SetStreaming("Sfctb1");
                    }*/
            }

         

            VisuGCode.ProcessedPath.ProcessedPathLine(actualCodeLine);//.CodeLineConfirmed);		// in GCodeSimulate.cs

            if (logStreaming)
                Logger.Trace("### OnRaiseStreamEvent  {0}  line {1} ", e.Status.ToString(), e.CodeLineSent);

            switch (e.Status)
            {
                
               case GrblStreaming.reset:
                    Logger.Info("### OnRaiseStreamEvent - GrblStreaming.reset  '{0}'", Grbl.lastMessage);
                    ResetDetected = true;
                    lastErrorLine = 0;
                    ShowGrblLastMessage();
                    SaveStreamingStatus(e.CodeLineSent, "Reset", "");
                   
                    
                    timerUpdateControls = true; timerUpdateControlSource = "grblStreaming.reset";//updateControls();
                   

                    ControlPowerSaving.EnableStandby();
                    VisuGCode.ProcessedPath.ProcessedPathClear();
                    //        SetGRBLBuffer();

                    _process_form?.Feedback("G-Code Stream", "reset", false);

                    break;

                case GrblStreaming.error:
                    string tmpMessage = Grbl.lastMessage;
                    Logger.Info("streaming error at line:{0}  last:{1}   message:{2}", e.CodeLineConfirmed, lastErrorLine, tmpMessage);
                    EventCollector.SetStreaming("Serr" + Grbl.lastErrorNr.ToString());
                    StatusStripSet(0, Grbl.lastMessage, Color.Fuchsia);
                   

                    if (tmpMessage.StartsWith("Lost connection"))
                    {
                        isStreaming = false;
                        UpdateControlEnables();
                    }

                    if (lastErrorLine != e.CodeLineConfirmed)
                    {
                        SaveStreamingStatus(e.CodeLineSent, "Streaming error", tmpMessage);

                        int errorLine = e.CodeLineConfirmed - 1;
                        if (isStreamingCheck)
                            errorLine = e.CodeLineConfirmed - 2;
                        ErrorLines.Add(errorLine);
                        MarkErrorLine(errorLine);

                        
                        try
                        {
                            //   if (actualCodeLine < fCTBCode.LinesCount)
                            if (LineIsInRange(actualCodeLine - 1))
                            {    //fCTBCode.BookmarkLine(actualCodeLine - 1);
                                if (this.fCTBCode.InvokeRequired)
                                { this.fCTBCode.BeginInvoke((MethodInvoker)delegate () { this.fCTBCode.BookmarkLine(actualCodeLine - 1); }); }
                                else
                                { this.fCTBCode.BookmarkLine(actualCodeLine - 1); }
                            }
                            //fCTBCode.DoSelectionVisible();
                            if (this.fCTBCode.InvokeRequired)
                            { this.fCTBCode.BeginInvoke((MethodInvoker)delegate () { this.fCTBCode.DoSelectionVisible(); }); }
                            else
                            { this.fCTBCode.DoSelectionVisible(); }
                        }
                        catch (Exception er)
                        {
                            Logger.Error(er, "OnRaiseStreamEvent fCTBCode GrblStreaming.error ");
                            EventCollector.SetStreaming("Sfctb2");
                        }

                    }
                    lastErrorLine = e.CodeLineConfirmed;

                    if (notifierEnable) Notifier.SendMessage(string.Format("Streaming error at line {0}\r\nTime stamp: {1}", e.CodeLineConfirmed, GetTimeStampString()), "Error");

                   
                    _process_form?.Feedback("G-Code Stream", "error", false);

                    break;

                case GrblStreaming.ok:
                    if (!isStreamingCheck)
                    {
                        if (Grbl.lastErrorNr <= 0)
                        {
                            
                            signalPlay = 0;
                            btnStreamStart.BackColor = SystemColors.Control;
                        }
                    }
                    lastErrorLine = 0;
                    break;

                case GrblStreaming.finish:
                    Logger.Info("streaming finished ok {0}", isStreamingOk);
                    EventCollector.SetStreaming("Sfin");
                    
                    StatusStripSet(1, string.Format("{0} {1}: {2}", DateTime.Now.ToString("HH:mm:ss"), Localization.GetString("statusStripeStreamingFinish"), elapsed.ToString(@"hh\:mm\:ss")), Color.Lime);    // Streaming FINISHED after
                    StatusStripColor(0, Color.White);

                    MainTimer.Stop();
                    MainTimer.Start();
                    timerUpdateControls = true; timerUpdateControlSource = "grblStreaming.finish";//updateControls();
                    SaveStreamingStatus(0, "", "");
                    showPicBoxBgImage = false;                     // don't show background image anymore
                    pictureBox1.BackgroundImage = null;
                   

                    if (notifierEnable && !notifierUpdateMarkerFinish)    // just notify once
                    {
                        notifierUpdateMarkerFinish = true;
                        string msg = string.Format("{0}\r\nDuration  : {1} (hh:mm:ss)\r\nCode line : {2}\r\nTime stamp: {3}", Properties.Settings.Default.notifierMessageFinish, elapsed.ToString(@"hh\:mm\:ss"), fCTBCode.LinesCount, GetTimeStampString());
                        if (Properties.Settings.Default.notifierMessageProgressTitle)
                            Notifier.SendMessage(msg, "100 %");
                        else
                            Notifier.SendMessage(msg);
                    }
                    _process_form?.Feedback("G-Code Stream", elapsed.ToString(@"hh\:mm\:ss"), true);
                    break;

                
               

                default:
                    break;
            }

            
        }
        internal delegate void Del();

        bool signalShowToolExchangeMessage = false;
        int signalShowToolExchangeLine = 0;
        private void ShowToolChangeMessage()		// triggert by signalShowToolExchangeMessage at GrblStreaming.pause
        {
            if (logStreaming) Logger.Trace("showToolChangeMessage");
            Console.Beep();
            using (MessageForm f = new MessageForm())
            {
				string tool = "No tool information";
				string toolHtml = "<table width='100%' border>";
				string HtmlMessage = MessageText.HtmlHeader;
				HtmlMessage += "<body class='highlightInfo'>\r\n";
				HtmlMessage += string.Format("<h2 class='highlightInfo'>{0}</h2>\r\n",Localization.GetString("mainToolChange1"));

                if (LineIsInRange(signalShowToolExchangeLine))
                {   
					tool = fCTBCode.Lines[signalShowToolExchangeLine];  // "M0 (Tool:46  Color:Black (46)=[000000])"
					int c1 = tool.IndexOf('(');
					if ((c1 > 0) && (c1 < (tool.Length - 1)))
					{
						tool = tool.Substring(c1 + 1);
						tool = tool.Substring(0, tool.Length - 1);
						if (tool.Contains("Color"))
						{
					//		var parts = tool.Split("Color");
							
						}
                        //	tool = tool.Replace("Color", "\r  Color");
                        toolHtml += "<tr><td>" + tool + "</td></tr>";
                    }
					else
					{	toolHtml += "<tr><td>" + tool + "</td></tr>";}

					int r1 = tool.IndexOf('[');
					int r2 = tool.IndexOf(']');
					if ((r1 > 0) && (r2 > r1))
					{
						string hex = tool.Substring(r1 + 1, r2 - r1 - 1);
                        tool = tool.Substring(0, r1) + tool.Substring(r2 + 1);

						if (Int32.TryParse(hex, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out int numericValue))
						{ hex = "#" + hex; }        // then # is missing

					//	LblHex.Text = hex;
						try
						{
							Color BackColor = System.Drawing.ColorTranslator.FromHtml(hex);
							Color ForeColor = ContrastColor(System.Drawing.ColorTranslator.FromHtml(hex));
							toolHtml += "<tr style='background-color:"+ColorTranslator.ToHtml(BackColor)+";'><td>" +
								"<span style='background-color:"+ColorTranslator.ToHtml(BackColor) + ";color:"+ColorTranslator.ToHtml(ForeColor)+";'>" + hex+"</span></td></tr>";
						}
						catch { }
					}
				
				
				}
				else
				{	toolHtml += "<tr><td>Line out of range</td></tr>";}

                HtmlMessage += toolHtml;
                HtmlMessage += "</body></html>\r\n";

                Logger.Info("ShowToolChangeMessage: {0}", tool);
                string msg = Localization.GetString("mainToolChange1") + "  " + tool + "\r" + Localization.GetString("mainToolChange2");
                Notifier.SendMessage(msg, "Tool change");
                f.ShowMessage(300, 240, Localization.GetString("mainToolChange"), HtmlMessage, 2);	// Tool change message ShowDialog
                var result = f.ShowDialog(this);
                if (result == DialogResult.Yes)
                { StartStreaming(0, fCTBCode.LinesCount - 1); }


/*                string tool = "unknown";
                if (LineIsInRange(signalShowToolExchangeLine))
                    tool = fCTBCode.Lines[signalShowToolExchangeLine];  // "M0 (Tool:46  Color:Black (46) = 000000)"
                int c1 = tool.IndexOf('(');
                if ((c1 > 0) && (c1 < (tool.Length - 1)))
                {
                    tool = tool.Substring(c1 + 1);
                    tool = tool.Substring(0, tool.Length - 1);
                    tool = tool.Replace("Color", "\r  Color");
                }
                string msg = Localization.GetString("mainToolChange1") + "  " + tool + "\r" + Localization.GetString("mainToolChange2");
                Logger.Info("ShowToolChangeMessage: {0}", msg.Replace("\r", ";").Replace("\n", ""));
                Notifier.SendMessage(msg, "Tool change");
                f.ShowMessage(Localization.GetString("mainToolChange"), msg, 2);
                var result = f.ShowDialog(this);
                if (result == DialogResult.Yes)
                { StartStreaming(0, fCTBCode.LinesCount - 1); }*/
            }
        }

        private void BtnStreamStart_Click(object sender, MouseEventArgs e)
        {
            UpdateLogging();
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            { StreamSection(); }
            else
            { StartStreaming(0, fCTBCode.LinesCount - 1); }
        }

        private void StreamSection()
        {
            if (fCTBCodeClickedLineNow < 0)
                fCTBCodeClickedLineNow = 0;

            int lineStart = fCTBCodeClickedLineNow;
            int lineEnd = fCTBCode.LinesCount - 1;
            int selStart = fCTBCode.Selection.FromLine;
            int selEnd = fCTBCode.Selection.ToLine;

            if (selStart < selEnd)
            {
                lineStart = selStart;
                lineEnd = selEnd;
            }

            using (MainFormStreamSection f = new MainFormStreamSection())
            {
                f.LineMax = fCTBCode.LinesCount - 1;
                f.LineStart = lineStart + 1;    // Editor starts at 1
                f.LineEnd = lineEnd + 1;        // Editor starts at 1
                f.Parser = VisuGCode.GetParserState(lineStart);
                f.Position = VisuGCode.GetActualPosition(f.LineStart);
                var result = f.ShowDialog(this);
                if (result == DialogResult.OK)
                {
                    fCTBCodeClickedLineNow = f.LineStart;
                    string parserState = VisuGCode.GetParserState(f.LineStart - 1);
                    XyzPoint tmpPos = VisuGCode.GetActualPosition(f.LineStart - 1); ;
                    Logger.Info("StreamSection start:{0} stop:{1}  state:{2} posX:{0:0.000} posY:{0:0.000} posZ:{0:0.000}", f.LineStart, f.LineEnd, parserState, tmpPos.X, tmpPos.Y, tmpPos.Z);
                    FctbSetBookmark();
                    VisuGCode.SetPosMarkerLine(fCTBCodeClickedLineNow, false);
                   
                    StartStreaming(f.LineStart, f.LineEnd);
                }
            }
        }

        // if startline > 0 start with pause
        private void StartStreaming(int startLine, int endLine)
        {
           
            lblInfoOkString = Localization.GetString("mainInfoSendCode");
            notifierUpdateFlag = false;
            notifierUpdateMarkerFinish = false;
            SelectionHandle.ClearSelected();
            if (fCTBCode.LinesCount > 1)
            {
                if (Grbl.Status == GrblState.alarm)
                {
                    MessageBox.Show("Press 'Kill Alarm'! Otherwise no streaming is possible.");
                    return;
                }

                if (!isStreaming)
                {
                    ClearErrorLines();
					SetEditMode(false);
                    Logger.Info("►►►►  Start streaming at line:{0} to line:{1} showProgress:{2}  backgroundImage:{3}", startLine, endLine, Properties.Settings.Default.guiProgressShow, Properties.Settings.Default.guiBackgroundImageEnable);
                    StatusStripSet(0, string.Format("{0} {1}: {2} to {3}", DateTime.Now.ToString("HH:mm:ss"), Localization.GetString("statusStripeStreamingStart"), startLine, endLine), Color.Lime);   // Streaming START from line
                    StatusStripClear(1, 2);

                    EventCollector.SetStreaming("Strt");
                    // ExpandCodeBlocksToolStripMenuItem_Click(null, null);
                    try { fCTBCode.ExpandAllFoldingBlocks(); foldLevel = 0; fCTBCode.DoCaretVisible(); }
                    catch (Exception err) { Logger.Error(err, "StartStreaming  ExpandAllFoldingBlocks"); }

                    VisuGCode.ProcessedPath.ProcessedPathClear();
                    MainTimer.Stop();
                    MainTimer.Start();

                    isStreaming = true;
                    isStreamingPause = false;
                    isStreamingCheck = false;
                    isStreamingOk = true;
                    

                    VisuGCode.MarkSelectedFigure(0);
                    if (startLine > 0)
                    {
                        btnStreamStart.Image = Properties.Resources.btn_pause;
                    }

                   

                    timerUpdateControlSource = "startStreaming";
                    UpdateControlEnables();
                    timeInit = DateTime.UtcNow;
                    elapsed = TimeSpan.Zero;
                   
                    for (int i = 0; i < fCTBCode.LinesCount; i++)
                        fCTBCode.UnbookmarkLine(i);

                    //save gcode
                    string file1stName = Datapath.AppDataFolder + "\\" + fileLastProcessed; // in MainForm.cs = "lastProcessed";
                    string fileName = "fN";
                    string txt = fCTBCode.Text;

                    try
                    {
                        fileName = file1stName + ".xml";
                        if (File.Exists(fileName)) 						// remove old process-state
                            File.Delete(fileName);

                        fileName = file1stName + ".nc";
                       // File.WriteAllText(fileName, txt);               // save current GCode		
                                                                        //
                        int encodeIndex = Properties.Settings.Default.FCTBSaveEncodingIndex;
                        if ((encodeIndex < 0) || (encodeIndex >= GuiVariables.SaveEncoding.Length))
                            encodeIndex = 0;

                        string encoding = GuiVariables.SaveEncoding[encodeIndex].BodyName;
                        try
                        {
                            System.IO.File.WriteAllLines(fileName, fCTBCode.Lines, GuiVariables.SaveEncoding[encodeIndex]);
                        }
                        catch (Exception err)
                        {
                            Logger.Error(err, "StartStreaming save code ");
                            MessageBox.Show("Could not save the file: \r\n" + err.Message, "Error");
                        }

                        SaveRecentFile(fileLastProcessed + ".nc");      // update last processed file
                        SetLastLoadedFile("Start streaming", fileName);
                    }
                    catch (IOException err)
                    {
                        EventCollector.StoreException("StartStreaming: IOEx-folder: " + Datapath.AppDataFolder + " ");
                        Datapath.AppDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                        Logger.Error(err, "StartStreaming fileName: {0}, new Datapath.AppDataFolder: {1} ", fileName, Datapath.AppDataFolder);
                        MessageBox.Show("Path does not exist and could not be created to save: " + fileName + "\r\nPath will be modified to " + Datapath.AppDataFolder, "Error");
                    }
                    catch (Exception err)
                    {
                        EventCollector.StoreException("StartStreaming: " + err.Message + "  " + fileName + " ");
                        Logger.Error(err, "StartStreaming fileName: {0}, new Datapath.AppDataFolder: {1} ", fileName, Datapath.AppDataFolder);
                        MessageBox.Show("'last processed' file could not be created: " + fileName + "\r\nError: " + err.Message, "Error");
                        //  throw;		// unknown exception...  access denied 
                    }

                    bool removeFiducials = (Properties.Settings.Default.importFiducialSkipCode && (VisuGCode.fiducialsCenter.Count > 0));
                //    bool removeHatchFill = (Properties.Settings.Default.importGraphicHatchFillOnlyShow );
                    if (removeFiducials)// || removeHatchFill)    // copy code
                    {
                        UnDo.SetCode(fCTBCode.Text, removeFiducials? "remove fiducials":"remove hatch fill", this);
                        string fiducialLabel = Properties.Settings.Default.importFiducialLabel;
                        fCTBCode.TextChanged -= FctbCode_TextChanged;       // disable textChanged events
                        foreach (XmlMarker.BlockData tmp in XmlMarker.listFigures)
                        {
                            if (removeFiducials && ((tmp.Layer.IndexOf(fiducialLabel) >= 0) || (tmp.PathId.IndexOf(fiducialLabel) >= 0))) //||
                             //   (removeHatchFill && tmp.Geometry.IndexOf("hatch_fill_") >= 0))
                            {
                                Logger.Info("StartStreaming fiducials: exclude line:{0} to:{1}", tmp.LineStart, tmp.LineEnd);
                                for (int lnr = tmp.LineStart; lnr <= tmp.LineEnd; lnr++)
                                {
                                    if (LineIsInRange(lnr))
                                    {
                                        Logger.Trace(" - {0}", fCTBCode.GetLineText(lnr));
                                        fCTBCode.Selection = fCTBCode.GetLine(lnr);
                                        fCTBCode.SelectedText = "(" + fCTBCode.GetLineText(lnr) + ")";  // remove fiducial code
                                    }
                                    else
                                    { Logger.Error("StartStreaming, remove fiducials at line {0}", lnr); }
                                }
                            }
                        }
                        fCTBCode.TextChanged += FctbCode_TextChanged;       // enable textChanged events
                    }

                   
                    if (removeFiducials)    // restore original code with fiducials
                    {
                        fCTBCode.Text = UnDo.GetCode();
                    }

                    btnStreamStart.Image = Properties.Resources.btn_pause;
                    
                    OnPaint_setBackground();                // Generante a background-image for pictureBox to avoid frequent drawing of pen-up/down paths
                    VisuGCode.SetPathAsLandMark(false);//clear = false
                    ControlPowerSaving.SuppressStandby();

                    //        this.Icon = Properties.Resources.Icon2;  // set icon
                }
                else
                {
                    if (!isStreamingPause)
                    {
                        Logger.Info("⏸⏸  Pause streaming - pause stream");
                        EventCollector.SetStreaming("Spap");
                        btnStreamStart.Image = Properties.Resources.btn_play;
                       
                        //            isStreamingPause = true;
                        StatusStripSet(2, Localization.GetString("statusStripeStreamingStatusSaved"), Color.LightGreen);
                        StatusStripSet(1, string.Format("{0} {1}", DateTime.Now.ToString("HH:mm:ss"), Localization.GetString("statusStripeStreamingPause")), Color.Yellow);     // Streaming PAUSE
                        StatusStripColor(0, Color.White);
                    }
                    else
                    {
                        Logger.Info("⏸⏸  Pause streaming - continue stream");
                        EventCollector.SetStreaming("Spac");
                        btnStreamStart.Image = Properties.Resources.btn_pause;
                        isStreamingPause = false;
                        StatusStripSet(1, Localization.GetString("statusStripeStreamingContinue"), Color.Lime);         // Continue streaming
                        StatusStripColor(0, Color.White);
                        delayedStatusStripClear1 = 8;
                        
                    }
                }
            }
        }
        private void BtnStreamCheck_Click(object sender, EventArgs e)
        {
            if ((fCTBCode.LinesCount > 1) && (!isStreaming))
            {
                ClearErrorLines();
                Logger.Info("check code");
                StatusStripSet(0, Localization.GetString("statusStripeStreamingCheck"), Color.Lime);        // Check G-Code on grbl controller
                EventCollector.SetStreaming("Schk");
                isStreaming = true;
                isStreamingCheck = true;
                isStreamingOk = true;
                timerUpdateControlSource = "btnStreamCheck_Click";
                UpdateControlEnables();
                timeInit = DateTime.UtcNow;
                elapsed = TimeSpan.Zero;
               
                for (int i = 0; i < fCTBCode.LinesCount; i++)
                    fCTBCode.UnbookmarkLine(i);
                
                btnStreamStart.Enabled = false;
                OnPaint_setBackground();
            }
        }
        

        #endregion
    }
}
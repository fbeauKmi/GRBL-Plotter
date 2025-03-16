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
 * 2021-12-10 new
 * 2022-04-01 add UrlEncode line 218
 * 2022-07-29 show abort dialog after 3 exceptions
 * 2023-03-30 l:84 f:ShowException add try catch
*/

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Web;
using System.Windows.Forms;

namespace GrblPlotter
{
    public partial class MainForm : Form
    {
        private void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            QuitSplashScreen();
            if (e != null)
            {
                Exception ex = e.Exception;
                string exKey = ex.Source + "_" + ex.TargetSite;
                bool showAbortMessage = EventCollector.CheckException(exKey);
                ShowException(ex, "ThreadException", showAbortMessage);
            }
            else
            {
                Logger.Error("Application_ThreadException - Exception is NULL");
                EventCollector.StoreException("ThreadException is null");
            }
        }

        private void Application_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            QuitSplashScreen();
            if (e.ExceptionObject != null)
            {
                Exception ex = (Exception)e.ExceptionObject;
                string exKey = ex.Source + "_" + ex.TargetSite;
                bool showAbortMessage = EventCollector.CheckException(exKey);
                ShowException(ex, "UnhandledException", showAbortMessage);
            }
            else
            {
                Logger.Error("Application_UnhandledException - Exception is NULL");
                EventCollector.StoreException("UnhandledException is null");
            }
        }

        private void QuitSplashScreen()
        {
            this.Opacity = 100;
            if (_splashscreen != null)
            {
                _splashscreen.Close();
                _splashscreen.Dispose();
            }
        }

        private void ShowException(Exception ex, string source, bool showAbortMessage)
        {
			try
            {	Logger.Error(ex, "ShowException {0} - Quit GRBL Plotter? ", source);
				if (ex != null)
				{
					MessageBox.Show(ex.Message + "\r\n\r\n" + GetAllFootprints(ex) + "\r\n\r\nCheck " + Datapath.AppDataFolder + "\\logfile.txt", "Main Form " + source);
					EventCollector.StoreException(source + ": " + GetAllFootprints(ex, false));
				}
				else
				{
					Logger.Error("ShowException - Exception is NULL");
					EventCollector.StoreException("Exception is null");
				}
				if (showAbortMessage && MessageBox.Show(Localization.GetString("mainQuit"), Localization.GetString("mainProblem"), MessageBoxButtons.YesNo) == DialogResult.Yes)
				{
					Properties.Settings.Default.guiLastEnd = DateTime.Now.Ticks;
					EventCollector.SetEnd(true);
					Application.Exit();
				}
			}
			catch {}	// caused UnhandledException: Index exceeds array bounds
        }

        private void ShowIoException(string source, string fileName)
        {
            Logger.Error("{0}: LoadFile IOException: {1}", source, fileName);
            int strt = fileName.Length - 50;
            if (strt < 0) { strt = 0; }
            string txt = string.Format("Could not load file ...{0}!!!", fileName.Substring(strt));
            StatusStripSet(2, txt, Color.Fuchsia);
            this.Text = appName + " | " + txt;
            
        }

        public static string GetAllFootprints(Exception except, bool full = true)
        {
            var st = new StackTrace(except, true);
            var frames = st.GetFrames();
            var traceString = new StringBuilder();
            traceString.Append("Except: " + except.Message + " Source: " + except.Source + " Target: " + except.TargetSite);

            try
            {
                if ((frames != null) && (frames.Length > 0))
                {
                    foreach (var frame in frames)
                    {
                        if (frame.GetFileLineNumber() < 1)
                            continue;

                        traceString.Append(", File: " + frame.GetFileName());
                        traceString.Append(", Method:" + frame.GetMethod().Name);
                        traceString.Append(", LineNumber: " + frame.GetFileLineNumber());
                        if (!full)
                            break;
                        traceString.Append("  -->  ");
                    }
                }
                else
                { traceString.Append(" No frames to add"); }
            }
            catch
            {
                traceString.Append(" GAF-except ");
                return traceString.ToString();
            }
            return traceString.ToString();
        }
    }

    public static class EventCollector              // allowed chars: A–Z, a–z, 0–9, - . _ ~
    {
        // collect history of data processing to find error causes
        // -time.msg_
        private static DateTime start = DateTime.Now;
        //    private static string WindowsVersion = "";  // System.Environment.OSVersion
        //    private static string GRBLVersion = "";

        internal static string installed = "";			// Installed? - regkey available
        private static string exception = "";
        private static string import = "";
        private static string stream = "";
        private static string communication = "";
        private static string transform = "";
        private static string openForm = "";
        private static string history = "";
        private static bool errorOccured = false;
        private static string lastStoredException = "";

        private static readonly Dictionary<string, int> ExceptionCount = new Dictionary<string, int>();     // counter for exceptions
        private static readonly int maxExceptionCount = 3;

        public static bool CheckException(string except)
        {
            if (ExceptionCount.ContainsKey(except))
            {
                if (++ExceptionCount[except] >= maxExceptionCount)
                    return true;
            }
            else
            {
                ExceptionCount.Add(except, 1);
            }
            return false;
        }

        public static void Init()
        {
            start = DateTime.Now;
            //    WindowsVersion = System.Environment.OSVersion.ToString();
            //    GRBLVersion= System.Windows.Forms.Application.ProductVersion.ToString();
        }
        public static void SetInstalled(string txt, bool show = false)
        {
            installed = start.ToString("yyyy-MM-dd HH:mm:ss.") + txt;
            if (show) errorOccured = true;          // show switched location
        }

        public static void SetImport(string txt)    // Itxt, Ishp, Ibqr, Iimg, Isvg...	
        {
            import = GetElapsedTime() + txt;
            history += import;      //"." + txt;
        }

        public static void SetStreaming(string txt)	// Sstp, Strt, Schk, Spau, Scnt, Sfin, Serr, 
        {
            stream = GetElapsedTime() + txt;
            history += stream;      //"."+txt;
        }

        public static void SetTransform(string txt) // Tmir, Tscl, Toff, Trot
        {
            transform = GetElapsedTime() + txt;
            history += transform;       //"." + txt;
        }

        public static void SetCommunication(string txt, bool show = false)    // COpS, CLost(show), CRst, CRSa, CRSb, CRE, CSSa, CSEa, CSSb, CSEb - ComSendSerial, ComSendEthernet, ComReceiveSerial
        {
            communication = GetElapsedTime() + txt;
            history += communication;       //"." + txt;
            if (show) errorOccured = true;
        }
        public static void SetOpenForm(string txt) // Ftxt, Fbcd, Fimg, Fsis, Fjog, Fext, Fprb, Fmap, Flas, Fcrd, Fdiy, Fcam, F2nd, F3rd, Fprj
        {
            openForm = GetElapsedTime() + txt;
            history += openForm;       //"." + txt;
        }


        public static void SetEnd(bool show = false)
        {
            if (show) history += GetElapsedTime() + "Abort_";   // quit after Error MessageBox("Close Program")

            string final = installed + "_";
            if (!string.IsNullOrEmpty(communication))
                final += communication + "_";
            if (!string.IsNullOrEmpty(stream))
                final += stream + "_";
            if (!string.IsNullOrEmpty(import))
                final += import + "_";
            if (!string.IsNullOrEmpty(transform))
                final += transform + "_";
            if (!string.IsNullOrEmpty(openForm))
                final += openForm + "_";
            if (!string.IsNullOrEmpty(history))
                final += history + "_";

            if (errorOccured || show)
                Properties.Settings.Default.guiLastEndReason = final + "-" + exception + GetElapsedTime() + "END";
            else
                Properties.Settings.Default.guiLastEndReason = GetElapsedTime() + "END";
            Properties.Settings.Default.Save();
        }

        public static void StoreException(string txt)
        {
            errorOccured = true;
            if (txt != lastStoredException)
            { exception += GetElapsedTime() + HttpUtility.UrlEncode(txt) + "_"; }   // UrlEncode, because exception can contain forbidden chars: ...GrblPlotter.GCodeFromImage.GenerateResultImageGray(Int16[,]& tmpToolNrArray)
            else
            { exception += "and" + GetElapsedTime(); }
            lastStoredException = txt;
        }

        private static string GetElapsedTime()//bool totalSec = false)
        {
            int maxLength = 1000;                   // also shorten history string
            if (history.Length > maxLength)
                history = history.Substring(history.Length - maxLength, maxLength);

            long elapsedTicks = DateTime.Now.Ticks - start.Ticks;
            TimeSpan elapsedSpan = new TimeSpan(elapsedTicks);

            return string.Format("-{0:0.00}.", elapsedSpan.TotalSeconds).Replace(",", ".");
        }
    }
}
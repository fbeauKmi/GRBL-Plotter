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
 * 2021-01-13 add 3rd serial com
 * 2021-07-15 code clean up / code quality
 * 2022-03-06 changed from form.show(this) to .show() to be able to stay behaind main form
 * 2022-04-06 add _projector_form with monitor selection
 * 2023-01-04 add _process_form
 * 2023-01-24 line 369 check if _diyControlPad != null
 * 2023-01-27 processAutomation removed fullScreen on start (like in ProjectorToolStrip)
 * 2023-12-01 l:682 f:OnRaiseProcessEvent add new action "Probing"
 * 2024-02-07 l:698 f:OnRaiseProcessEvent add Barcode, CreatText, 2D-View
 * 2024-02-12 split file, new  MainFormProcessAutomation.cs
*/

using GrblPlotter.MachineControl;
using System;
using System.Windows.Forms;

namespace GrblPlotter
{
    public partial class MainForm : Form
    {

        /********************************************************************
         * Handle additional Forms, which can be opened via Menu strip
         * Handles just open, close, add event handler
         ********************************************************************/
        GCodeFromText _text_form = null;
        GCodeFromImage _image_form = null;
        GCodeFromShape _shape_form = null;
        GCodeForBarcode _barcode_form = null;
        GCodeForWireCutter _wireCutter_form = null;

       
        ControlHeightMapForm _heightmap_form = null;
        ControlSetupForm _setup_form = null;
        ControlJogPathCreator _jogPathCreator_form = null;
        ControlProjector _projector_form = null;
        ProcessAutomation _process_form = null;
        

        private void UpdateIniVariables()
        {
            _text_form?.UpdateIniVariables();
            _barcode_form?.UpdateIniVariables();
            _process_form?.UpdateIniVariables();
        }

        #region MAIN-MENU GCode creation

        /********************************************************************
         * Text
         * _wireCutter_form
         ********************************************************************/
        private void WireCutterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_wireCutter_form == null)
            {
                _wireCutter_form = new GCodeForWireCutter();
                _wireCutter_form.FormClosed += FormClosed_WireCutter;
                _wireCutter_form.btnApply.Click += GetGCodeForWireCutter;      // assign btn-click event
                EventCollector.SetOpenForm("Fwic");
            }
            else
            {
                _wireCutter_form.Visible = false;
            }

            if (showFormInFront) _wireCutter_form.Show(this);
            else _wireCutter_form.Show();  // this);

           
            _wireCutter_form.WindowState = FormWindowState.Normal;
        }
        private void FormClosed_WireCutter(object sender, FormClosedEventArgs e)
        { _wireCutter_form = null; EventCollector.SetOpenForm("FCwic"); }

        /********************************************************************
         * Text
         * _text_form
         ********************************************************************/
        private void TextWizzardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_text_form == null)
            {
                _text_form = new GCodeFromText();
                _text_form.FormClosed += FormClosed_TextToGCode;
                _text_form.btnApply.Click += GetGCodeFromText;      // assign btn-click event
                EventCollector.SetOpenForm("Ftxt");
            }
            else
            {
                _text_form.Visible = false;
            }

            if (showFormInFront) _text_form.Show(this);
            else _text_form.Show();  // this);

      
            _text_form.WindowState = FormWindowState.Normal;
        }
        private void FormClosed_TextToGCode(object sender, FormClosedEventArgs e)
        { _text_form = null; EventCollector.SetOpenForm("FCtxt"); }

        /********************************************************************
         * Image
         * _image_form
         ********************************************************************/
        private void ImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_image_form == null)
            {
                _image_form = new GCodeFromImage();
                _image_form.FormClosed += FormClosed_ImageToGCode;
                _image_form.btnGenerate.Click += GetGCodeFromImage;      // assign btn-click event in MainFormgetCodetransform.cs
                _image_form.BtnReloadPattern.Click += LoadLastGraphic;
                _image_form.CBoxPatternFiles.SelectedIndexChanged += LoadSelectedGraphicImage;
                EventCollector.SetOpenForm("Fimg");
            }
            else
            {
                _image_form.Visible = false;
            }
            if (showFormInFront) _image_form.Show(this);
            else _image_form.Show();

            
            _image_form.WindowState = FormWindowState.Normal;
        }
        private void FormClosed_ImageToGCode(object sender, FormClosedEventArgs e)
        { _image_form = null; EventCollector.SetOpenForm("FCimg"); }

        /********************************************************************
         * Shape
         * _shape_form
         ********************************************************************/
        private void CreateSimpleShapesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_shape_form == null)
            {
                _shape_form = new GCodeFromShape();
                _shape_form.FormClosed += FormClosed_ShapeToGCode;
                _shape_form.btnApply.Click += GetGCodeFromShape;      // assign btn-click event
                EventCollector.SetOpenForm("Fsis");
            }
            else
            {
                _shape_form.Visible = false;
            }

            if (showFormInFront) _shape_form.Show(this);
            else _shape_form.Show(); // this);

           
            _shape_form.WindowState = FormWindowState.Normal;
        }
        private void FormClosed_ShapeToGCode(object sender, FormClosedEventArgs e)
        { _shape_form = null; EventCollector.SetOpenForm("FCsis"); }

        /********************************************************************
         * Barcode
         * _barcode_form
         ********************************************************************/
        private void CreateBarcodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_barcode_form == null)
            {
                _barcode_form = new GCodeForBarcode();
                _barcode_form.FormClosed += FormClosed_BarcodeToGCode;
                _barcode_form.btnGenerateBarcode1D.Click += GetGCodeFromBarcode;      // assign btn-click event
                _barcode_form.btnGenerateBarcode2D.Click += GetGCodeFromBarcode;      // assign btn-click event
                EventCollector.SetOpenForm("Fbcd");
            }
            else
            {
                _barcode_form.Visible = false;
            }

            if (showFormInFront) _barcode_form.Show(this);
            else _barcode_form.Show();   // this);

            
            _barcode_form.WindowState = FormWindowState.Normal;
        }
        private void FormClosed_BarcodeToGCode(object sender, FormClosedEventArgs e)
        { _barcode_form = null; EventCollector.SetOpenForm("FCbcd"); }

        #endregion

        #region MAIN-Menu Control
        
        
        /********************************************************************
        * Camera 
        * _camera_form
        ********************************************************************/
        
        private void OnRaiseCameraProcessEvent(object sender, ProcessEventArgs e)
        {
            if (e.Command == "Fiducial")
            {
                _process_form?.Feedback("Camera Automatic", e.Value, (e.Value == "finished"));
            }
        }


        


       


        /********************************************************************
         * Height map
         * _heightmap_form
         ********************************************************************/
        private void HeightMapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_heightmap_form == null)
            {
                _heightmap_form = new ControlHeightMapForm();
                _heightmap_form.FormClosed += FormClosed_HeightmapForm;
                
                _heightmap_form.loadHeightMapToolStripMenuItem.Click += LoadHeightMap;	// in MainFormGetCodeTransform
                _heightmap_form.btnApply.Click += ApplyHeightMap;						// in MainFormGetCodeTransform
                _heightmap_form.RaiseXyzEvent += OnRaisePositionClickEvent;				// in MainForm
                _heightmap_form.btnGCode.Click += GetGCodeFromHeightMap;                // in MainFormGetCodeTransform
                EventCollector.SetOpenForm("Fmap");
            }
            else
            {
                _heightmap_form.Visible = false;
            }

            if (showFormInFront) _heightmap_form.Show(this);
            else _heightmap_form.Show(); // this);

            
            _heightmap_form.WindowState = FormWindowState.Normal;
           
        }
        private void FormClosed_HeightmapForm(object sender, FormClosedEventArgs e)
        {
            _heightmap_form = null;
            VisuGCode.ClearHeightMap();
            
            EventCollector.SetOpenForm("FCmap");
        }


        /********************************************************************
         * Setup Form
         * _setup_form
         ********************************************************************/
        private void SetupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_setup_form == null)
            {
                _setup_form = new ControlSetupForm();
                _setup_form.FormClosed += FormClosed_SetupForm;
                _setup_form.btnApplyChangings.Click += LoadSettings;
                _setup_form.btnReloadFile.Click += ReStartConvertFileFromSetup;
                _setup_form.btnMoveToolXY.Click += MoveToPickup;
                _setup_form.btnGCPWMUp.Click += MoveToPickup;
                _setup_form.btnGCPWMDown.Click += MoveToPickup;
                _setup_form.btnGCPWMZero.Click += MoveToPickup;
                _setup_form.nUDImportGCPWMP93.ValueChanged += MoveToPickup;
                _setup_form.nUDImportGCPWMP94.ValueChanged += MoveToPickup;
                _setup_form.TbImportGCPWMSlider.ValueChanged += MoveToPickup;
                _setup_form.SetLastLoadedFile(lastLoadSource);
                gamePadTimer.Enabled = false;
                EventCollector.SetOpenForm("Fstp");
            }
            else
            {
                _setup_form.Visible = false;
            }

            if (showFormInFront) _setup_form.Show(this);
            else _setup_form.Show();// null);// this);

           
            _setup_form.WindowState = FormWindowState.Normal;
        }
        private void FormClosed_SetupForm(object sender, FormClosedEventArgs e)
        {
            LoadSettings(sender, e);
            _setup_form = null;
            VisuGCode.DrawMachineLimit();// ToolTable.GetToolCordinates());
            pictureBox1.Invalidate();                                   // resfresh view
            gamePadTimer.Enabled = Properties.Settings.Default.gamePadEnable;
            EventCollector.SetOpenForm("FCstp");
        }

        /********************************************************************
         * Jog Path creator
         * _setup_form
         ********************************************************************/
        private void JogCreatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_jogPathCreator_form == null)
            {
                _jogPathCreator_form = new ControlJogPathCreator();
                _jogPathCreator_form.FormClosed += FormClosed_JogCreator;
                _jogPathCreator_form.btnJogStart.Click += GetGCodeJogCreator;      // assign btn-click event
                _jogPathCreator_form.btnExport.Click += GetGCodeJogCreator2;      // assign btn-click event
                EventCollector.SetOpenForm("Fjog");
            }
            else
            {
                _jogPathCreator_form.Visible = false;
            }
            _jogPathCreator_form.Show(null);// this);
            _jogPathCreator_form.WindowState = FormWindowState.Normal;
        }
        private void FormClosed_JogCreator(object sender, FormClosedEventArgs e)
        { _jogPathCreator_form = null; EventCollector.SetOpenForm("FCjog"); }


        /********************************************************************
         * Projector - a form to be displayed via a projector on the workpiece
         * _projector_form
         ********************************************************************/
        private void ProjectorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_projector_form == null)
            {
                _projector_form = new ControlProjector();
                _projector_form.FormClosed += FormClosed_Projector;
                EventCollector.SetOpenForm("Fprj");
            }
            else
            {
                _projector_form.Visible = false;
            }

            if (Screen.AllScreens.Length > 1)
            {
                if ((int)Properties.Settings.Default.projectorMonitorIndex >= Screen.AllScreens.Length)
                    Properties.Settings.Default.projectorMonitorIndex = Screen.AllScreens.Length - 1;

                _projector_form.StartPosition = FormStartPosition.Manual;
                _projector_form.Location = Screen.AllScreens[(int)Properties.Settings.Default.projectorMonitorIndex].WorkingArea.Location;  // selectable index
                _projector_form.FormBorderStyle = FormBorderStyle.None;     // default = Sizable
                _projector_form.Show();
                _projector_form.WindowState = FormWindowState.Maximized;
            }
            else
            {
                _projector_form.Show(this);
                _projector_form.WindowState = FormWindowState.Normal;
            }
        }
        private void FormClosed_Projector(object sender, FormClosedEventArgs e)
        { _projector_form = null; EventCollector.SetOpenForm("FCprj"); }


        /********************************************************************
        * About Form
        ********************************************************************/
        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmAbout = new AboutForm();
            frmAbout.ShowDialog();
        }
        #endregion
    }
}

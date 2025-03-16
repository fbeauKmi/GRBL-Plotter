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
namespace GrblPlotter
{
    partial class MainForm
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
                if (picBoxBackround != null)
                    picBoxBackround.Dispose();
                StyleComment.Dispose();
                StyleFWord.Dispose();
                StyleGWord.Dispose();
                StyleMWord.Dispose();
                StyleSWord.Dispose();
                StyleTool.Dispose();
                StyleXAxis.Dispose();
                StyleYAxis.Dispose();
                StyleZAxis.Dispose();
                StyleCommentxml.Dispose();
                StyleFail.Dispose();

                penUp.Dispose();
                penDown.Dispose();
                penRotary.Dispose();
                penHeightMap.Dispose();
                penRuler.Dispose();
				penGrid1.Dispose();
				penGrid10.Dispose();
                penGrid100.Dispose();
                penTool.Dispose();
                penMarker.Dispose();
                penLandMark.Dispose();
				penBackgroundPath.Dispose();
				penDimension.Dispose();
                penSimulation.Dispose();

                brushMachineLimit.Dispose();
                brushBackground.Dispose();
				brushBackgroundPath.Dispose();
                StyleAAxis.Dispose();
                StyleLineN.Dispose();
                pBoxOrig.Dispose();
                pBoxTransform.Dispose();

                ErrorStyle.Dispose();
                StyleTT.Dispose();
                Style2nd.Dispose();
				
			/*	_text_form.Dispose();
				_image_form.Dispose();
				_shape_form.Dispose();
				_barcode_form.Dispose();

				_streaming_form.Dispose();
				_streaming_form2.Dispose();
				_serial_form2.Dispose();
				_serial_form3.Dispose();
				_2ndGRBL_form.Dispose();
				_camera_form.Dispose();
				_diyControlPad.Dispose();
				_coordSystem_form.Dispose();
				_laser_form.Dispose();
				_probing_form.Dispose();
				_heightmap_form.Dispose();
				_setup_form.Dispose();
				_jogPathCreator_form.Dispose();*/
				
				myFont7.Dispose();
    			myFont8.Dispose();

                selectionPathOrig.Dispose();
        }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tLPLinks = new System.Windows.Forms.TableLayoutPanel();
            this.fCTBCode = new FastColoredTextBoxNS.FastColoredTextBox();
            this.cmsFCTB = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.unDo3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator13 = new System.Windows.Forms.ToolStripSeparator();
            this.cmsEditorHotkeys = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator19 = new System.Windows.Forms.ToolStripSeparator();
            this.cmsCodeBlocksFold = new System.Windows.Forms.ToolStripMenuItem();
            this.foldCodeBlocks1stLevelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.foldCodeBlocks2ndLevelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.foldCodeBlocks3rdLevelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.expandCodeBlocksToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toggleBlockExpansionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsCodeBlocksMove = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsFCTBMoveSelectedCodeBlockMostUp = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsFCTBMoveSelectedCodeBlockUp = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsFCTBMoveSelectedCodeBlockDown = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsFCTBMoveSelectedCodeBlockMostDown = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsCodeBlocksSort = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsCodeBlocksSortReverse = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsCodeBlocksSortById = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsCodeBlocksSortByColor = new System.Windows.Forms.ToolStripMenuItem();
            this.sortByPenWidthToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sortByLayerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sortByTypeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsCodeBlocksSortByGeometry = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsCodeBlocksSortByToolNr = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsCodeBlocksSortByToolName = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsCodeBlocksSortByCodeSize = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsCodeBlocksSortByCodeArea = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsCodeBlocksSortByDistance = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsCodeBlocksRemoveGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsCodeBlocksRemoveAll = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this.cmsEditMode = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsCodeSelect = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsCodeCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsCodePaste = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsCodePasteSpecial1 = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsCodePasteSpecial2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator14 = new System.Windows.Forms.ToolStripSeparator();
            this.cmsFindDialog = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsReplaceDialog = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
            this.cmsCodeSendLine = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsCommentOut = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsUpdate2DView = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnStreamStop = new System.Windows.Forms.Button();
            this.btnStreamStart = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tBURL = new System.Windows.Forms.TextBox();
            this.CbAddGraphic = new System.Windows.Forms.CheckBox();
            this.serverIP = new System.Windows.Forms.TextBox();
            this.grp1 = new System.Windows.Forms.GroupBox();
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.tbFile = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnExpGcode = new System.Windows.Forms.Button();
            this.gBoxDimension = new System.Windows.Forms.GroupBox();
            this.btnLimitExceed = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnOffsetApply = new System.Windows.Forms.Button();
            this.tbOffsetY = new System.Windows.Forms.TextBox();
            this.tbOffsetX = new System.Windows.Forms.TextBox();
            this.rBOrigin9 = new System.Windows.Forms.RadioButton();
            this.rBOrigin8 = new System.Windows.Forms.RadioButton();
            this.rBOrigin7 = new System.Windows.Forms.RadioButton();
            this.rBOrigin6 = new System.Windows.Forms.RadioButton();
            this.rBOrigin5 = new System.Windows.Forms.RadioButton();
            this.rBOrigin4 = new System.Windows.Forms.RadioButton();
            this.rBOrigin3 = new System.Windows.Forms.RadioButton();
            this.rBOrigin2 = new System.Windows.Forms.RadioButton();
            this.rBOrigin1 = new System.Windows.Forms.RadioButton();
            this.lbDimension = new System.Windows.Forms.TextBox();
            this.tLPRechts = new System.Windows.Forms.TableLayoutPanel();
            this.tLPRechtsUnten = new System.Windows.Forms.TableLayoutPanel();
            this.tLPMitteUnten = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cmsPictureBox = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.unDo2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.applyLastTransformToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator17 = new System.Windows.Forms.ToolStripSeparator();
            this.cmsPicBoxReloadFile = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsPicBoxReloadFile2 = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsPicBoxPasteFromClipboard = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsPicBoxClearWorkspace = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.cmsPicBoxResetZooming = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.cmsPicBoxMoveToMarkedPosition = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsPicBoxZeroXYAtMarkedPosition = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsPicBoxMoveGraphicsOrigin = new System.Windows.Forms.ToolStripMenuItem();
            this.deletenotMarkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.cmsPicBoxMarkFirstPos = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsPicBoxShowProperties = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsPicBoxDuplicatePath = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsPicBoxDeletePath = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsPicBoxCropSelectedPath = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsPicBoxMoveSelectedPathInCode = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsPicBoxReverseSelectedPath = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsPicBoxRotateSelectedPath = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.cmsPicBoxSetGCodeAsBackground = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsPicBoxClearBackground = new System.Windows.Forms.ToolStripMenuItem();
            this.copyContentTroClipboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblRemaining = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.setupToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.saveMachineParametersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadMachineParametersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LanguageToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.englishToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deutschToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pусскийToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.portuguêsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.franzToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.italianoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PolishToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.czechToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.türkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chinesischToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.arabischToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.japanischToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createGCodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textWizzardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createBarcodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createSimpleShapesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wireCutterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createJogPathToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startExtensionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gCodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unDoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator16 = new System.Windows.Forms.ToolStripSeparator();
            this.mirrorXToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mirrorYToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mirrorRotaryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.rotate90ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rotate90ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.rotate180ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rotateFreeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip_tb_rotate = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.sToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip_tb_XY_scale = new System.Windows.Forms.ToolStripTextBox();
            this.skalierenXYToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip_tb_XY_X_scale = new System.Windows.Forms.ToolStripTextBox();
            this.skalierenXYUmXUnitsZuErreichenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip_tb_XY_Y_scale = new System.Windows.Forms.ToolStripTextBox();
            this.skaliereXUmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip_tb_X_scale = new System.Windows.Forms.ToolStripTextBox();
            this.skaliereAufXUnitsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip_tb_X_X_scale = new System.Windows.Forms.ToolStripTextBox();
            this.skaliereYUmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip_tb_Y_scale = new System.Windows.Forms.ToolStripTextBox();
            this.skaliereAufYUnitsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip_tb_Y_Y_scale = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.rotaryDimaeterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip_tb_rotary_diameter = new System.Windows.Forms.ToolStripTextBox();
            this.skaliereXAufDrehachseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip_tb_X_A_scale = new System.Windows.Forms.ToolStripTextBox();
            this.skaliereYAufDrehachseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip_tb_Y_A_scale = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator15 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStrip_RadiusComp = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip_tBRadiusCompValue = new System.Windows.Forms.ToolStripTextBox();
            this.ersetzteG23DurchLinienToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.convertToPolarCoordinatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.convertZToSspindleSpeedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeAnyZMoveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripViewRuler = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripViewInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripViewPenUp = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripViewMachineFix = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripViewMachine = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripViewDimension = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripViewTool = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripViewBackground = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MainTimer = new System.Windows.Forms.Timer(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.gamePadTimer = new System.Windows.Forms.Timer(this.components);
            this.simulationTimer = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel0 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.SplashScreenTimer = new System.Windows.Forms.Timer(this.components);
            this.loadTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tLPLinks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fCTBCode)).BeginInit();
            this.cmsFCTB.SuspendLayout();
            this.grp1.SuspendLayout();
            this.gBoxDimension.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.tLPRechts.SuspendLayout();
            this.tLPRechtsUnten.SuspendLayout();
            this.tLPMitteUnten.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.cmsPictureBox.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.splitContainer1, "splitContainer1");
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tLPLinks);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tLPRechts);
            this.splitContainer1.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.SplitContainer1_SplitterMoved);
            // 
            // tLPLinks
            // 
            resources.ApplyResources(this.tLPLinks, "tLPLinks");
            this.tLPLinks.Controls.Add(this.fCTBCode, 0, 3);
            this.tLPLinks.Controls.Add(this.grp1, 0, 0);
            this.tLPLinks.Controls.Add(this.gBoxDimension, 0, 2);
            this.tLPLinks.Name = "tLPLinks";
            // 
            // fCTBCode
            // 
            this.fCTBCode.AllowMacroRecording = false;
            this.fCTBCode.AutoCompleteBracketsList = new char[] {
        '(',
        ')',
        '{',
        '}',
        '[',
        ']',
        '\"',
        '\"',
        '\'',
        '\''};
            this.fCTBCode.AutoIndent = false;
            this.fCTBCode.AutoIndentCharsPatterns = "\r\n^\\s*[\\w\\.]+\\s*(?<range>=)\\s*(?<range>[^;]+);";
            resources.ApplyResources(this.fCTBCode, "fCTBCode");
            this.fCTBCode.BackBrush = null;
            this.fCTBCode.CharCnWidth = 13;
            this.fCTBCode.CharHeight = 12;
            this.fCTBCode.CharWidth = 7;
            this.fCTBCode.ContextMenuStrip = this.cmsFCTB;
            this.fCTBCode.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.fCTBCode.DelayedTextChangedInterval = 200;
            this.fCTBCode.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.fCTBCode.Hotkeys = resources.GetString("fCTBCode.Hotkeys");
            this.fCTBCode.IsReplaceMode = false;
            this.fCTBCode.Name = "fCTBCode";
            this.fCTBCode.Paddings = new System.Windows.Forms.Padding(0);
            this.fCTBCode.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.fCTBCode.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("fCTBCode.ServiceColors")));
            this.fCTBCode.ShowFoldingLines = true;
            this.fCTBCode.ToolTip = this.toolTip1;
            this.fCTBCode.Zoom = 100;
            this.fCTBCode.ToolTipNeeded += new System.EventHandler<FastColoredTextBoxNS.ToolTipNeededEventArgs>(this.FctbCode_ToolTipNeeded);
            this.fCTBCode.TextChanged += new System.EventHandler<FastColoredTextBoxNS.TextChangedEventArgs>(this.FctbCode_TextChanged);
            this.fCTBCode.TextChangedDelayed += new System.EventHandler<FastColoredTextBoxNS.TextChangedEventArgs>(this.FctbCode_TextChangedDelayed);
            this.fCTBCode.Click += new System.EventHandler(this.FctbCode_Click);
            this.fCTBCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FctbCode_KeyDown);
            this.fCTBCode.MouseHover += new System.EventHandler(this.FCTBCode_MouseHover);
            // 
            // cmsFCTB
            // 
            this.cmsFCTB.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.unDo3ToolStripMenuItem,
            this.toolStripSeparator13,
            this.cmsEditorHotkeys,
            this.toolStripSeparator19,
            this.cmsCodeBlocksFold,
            this.cmsCodeBlocksMove,
            this.cmsCodeBlocksSort,
            this.cmsCodeBlocksRemoveGroup,
            this.cmsCodeBlocksRemoveAll,
            this.toolStripSeparator11,
            this.cmsEditMode,
            this.cmsCodeSelect,
            this.cmsCodeCopy,
            this.cmsCodePaste,
            this.cmsCodePasteSpecial1,
            this.cmsCodePasteSpecial2,
            this.toolStripSeparator14,
            this.cmsFindDialog,
            this.cmsReplaceDialog,
            this.toolStripSeparator12,
            this.cmsCodeSendLine,
            this.cmsCommentOut,
            this.cmsUpdate2DView});
            this.cmsFCTB.Name = "cmsCode";
            this.cmsFCTB.ShowImageMargin = false;
            resources.ApplyResources(this.cmsFCTB, "cmsFCTB");
            this.cmsFCTB.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.CmsFctb_ItemClicked);
            // 
            // unDo3ToolStripMenuItem
            // 
            this.unDo3ToolStripMenuItem.Name = "unDo3ToolStripMenuItem";
            resources.ApplyResources(this.unDo3ToolStripMenuItem, "unDo3ToolStripMenuItem");
            this.unDo3ToolStripMenuItem.Click += new System.EventHandler(this.UnDoToolStripMenuItem_Click);
            // 
            // toolStripSeparator13
            // 
            this.toolStripSeparator13.Name = "toolStripSeparator13";
            resources.ApplyResources(this.toolStripSeparator13, "toolStripSeparator13");
            // 
            // cmsEditorHotkeys
            // 
            resources.ApplyResources(this.cmsEditorHotkeys, "cmsEditorHotkeys");
            this.cmsEditorHotkeys.Name = "cmsEditorHotkeys";
            // 
            // toolStripSeparator19
            // 
            this.toolStripSeparator19.Name = "toolStripSeparator19";
            resources.ApplyResources(this.toolStripSeparator19, "toolStripSeparator19");
            // 
            // cmsCodeBlocksFold
            // 
            resources.ApplyResources(this.cmsCodeBlocksFold, "cmsCodeBlocksFold");
            this.cmsCodeBlocksFold.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.foldCodeBlocks1stLevelToolStripMenuItem,
            this.foldCodeBlocks2ndLevelToolStripMenuItem,
            this.foldCodeBlocks3rdLevelToolStripMenuItem,
            this.expandCodeBlocksToolStripMenuItem1,
            this.toggleBlockExpansionToolStripMenuItem});
            this.cmsCodeBlocksFold.Name = "cmsCodeBlocksFold";
            // 
            // foldCodeBlocks1stLevelToolStripMenuItem
            // 
            this.foldCodeBlocks1stLevelToolStripMenuItem.Name = "foldCodeBlocks1stLevelToolStripMenuItem";
            resources.ApplyResources(this.foldCodeBlocks1stLevelToolStripMenuItem, "foldCodeBlocks1stLevelToolStripMenuItem");
            this.foldCodeBlocks1stLevelToolStripMenuItem.Click += new System.EventHandler(this.FoldBlocks1stToolStripMenuItem1_Click);
            // 
            // foldCodeBlocks2ndLevelToolStripMenuItem
            // 
            this.foldCodeBlocks2ndLevelToolStripMenuItem.Name = "foldCodeBlocks2ndLevelToolStripMenuItem";
            resources.ApplyResources(this.foldCodeBlocks2ndLevelToolStripMenuItem, "foldCodeBlocks2ndLevelToolStripMenuItem");
            this.foldCodeBlocks2ndLevelToolStripMenuItem.Click += new System.EventHandler(this.FoldBlocks2ndToolStripMenuItem1_Click);
            // 
            // foldCodeBlocks3rdLevelToolStripMenuItem
            // 
            this.foldCodeBlocks3rdLevelToolStripMenuItem.Name = "foldCodeBlocks3rdLevelToolStripMenuItem";
            resources.ApplyResources(this.foldCodeBlocks3rdLevelToolStripMenuItem, "foldCodeBlocks3rdLevelToolStripMenuItem");
            this.foldCodeBlocks3rdLevelToolStripMenuItem.Click += new System.EventHandler(this.FoldBlocks3rdToolStripMenuItem1_Click);
            // 
            // expandCodeBlocksToolStripMenuItem1
            // 
            this.expandCodeBlocksToolStripMenuItem1.Name = "expandCodeBlocksToolStripMenuItem1";
            resources.ApplyResources(this.expandCodeBlocksToolStripMenuItem1, "expandCodeBlocksToolStripMenuItem1");
            this.expandCodeBlocksToolStripMenuItem1.Click += new System.EventHandler(this.ExpandCodeBlocksToolStripMenuItem_Click);
            // 
            // toggleBlockExpansionToolStripMenuItem
            // 
            this.toggleBlockExpansionToolStripMenuItem.Checked = true;
            this.toggleBlockExpansionToolStripMenuItem.CheckOnClick = true;
            this.toggleBlockExpansionToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toggleBlockExpansionToolStripMenuItem.Name = "toggleBlockExpansionToolStripMenuItem";
            resources.ApplyResources(this.toggleBlockExpansionToolStripMenuItem, "toggleBlockExpansionToolStripMenuItem");
            // 
            // cmsCodeBlocksMove
            // 
            resources.ApplyResources(this.cmsCodeBlocksMove, "cmsCodeBlocksMove");
            this.cmsCodeBlocksMove.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsFCTBMoveSelectedCodeBlockMostUp,
            this.cmsFCTBMoveSelectedCodeBlockUp,
            this.cmsFCTBMoveSelectedCodeBlockDown,
            this.cmsFCTBMoveSelectedCodeBlockMostDown});
            this.cmsCodeBlocksMove.Name = "cmsCodeBlocksMove";
            // 
            // cmsFCTBMoveSelectedCodeBlockMostUp
            // 
            this.cmsFCTBMoveSelectedCodeBlockMostUp.Name = "cmsFCTBMoveSelectedCodeBlockMostUp";
            resources.ApplyResources(this.cmsFCTBMoveSelectedCodeBlockMostUp, "cmsFCTBMoveSelectedCodeBlockMostUp");
            this.cmsFCTBMoveSelectedCodeBlockMostUp.Click += new System.EventHandler(this.MoveSelectedCodeBlockMostUpToolStripMenuItem_Click);
            // 
            // cmsFCTBMoveSelectedCodeBlockUp
            // 
            this.cmsFCTBMoveSelectedCodeBlockUp.Name = "cmsFCTBMoveSelectedCodeBlockUp";
            resources.ApplyResources(this.cmsFCTBMoveSelectedCodeBlockUp, "cmsFCTBMoveSelectedCodeBlockUp");
            this.cmsFCTBMoveSelectedCodeBlockUp.Click += new System.EventHandler(this.MoveSelectedCodeBlockUpToolStripMenuItem_Click);
            // 
            // cmsFCTBMoveSelectedCodeBlockDown
            // 
            this.cmsFCTBMoveSelectedCodeBlockDown.Name = "cmsFCTBMoveSelectedCodeBlockDown";
            resources.ApplyResources(this.cmsFCTBMoveSelectedCodeBlockDown, "cmsFCTBMoveSelectedCodeBlockDown");
            this.cmsFCTBMoveSelectedCodeBlockDown.Click += new System.EventHandler(this.MoveSelectedCodeBlockDownToolStripMenuItem_Click);
            // 
            // cmsFCTBMoveSelectedCodeBlockMostDown
            // 
            this.cmsFCTBMoveSelectedCodeBlockMostDown.Name = "cmsFCTBMoveSelectedCodeBlockMostDown";
            resources.ApplyResources(this.cmsFCTBMoveSelectedCodeBlockMostDown, "cmsFCTBMoveSelectedCodeBlockMostDown");
            this.cmsFCTBMoveSelectedCodeBlockMostDown.Click += new System.EventHandler(this.MoveSelectedCodeBlockMostDownToolStripMenuItem_Click);
            // 
            // cmsCodeBlocksSort
            // 
            this.cmsCodeBlocksSort.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsCodeBlocksSortReverse,
            this.cmsCodeBlocksSortById,
            this.cmsCodeBlocksSortByColor,
            this.sortByPenWidthToolStripMenuItem,
            this.sortByLayerToolStripMenuItem,
            this.sortByTypeToolStripMenuItem,
            this.cmsCodeBlocksSortByGeometry,
            this.cmsCodeBlocksSortByToolNr,
            this.cmsCodeBlocksSortByToolName,
            this.cmsCodeBlocksSortByCodeSize,
            this.cmsCodeBlocksSortByCodeArea,
            this.cmsCodeBlocksSortByDistance});
            resources.ApplyResources(this.cmsCodeBlocksSort, "cmsCodeBlocksSort");
            this.cmsCodeBlocksSort.Name = "cmsCodeBlocksSort";
            // 
            // cmsCodeBlocksSortReverse
            // 
            this.cmsCodeBlocksSortReverse.CheckOnClick = true;
            this.cmsCodeBlocksSortReverse.Name = "cmsCodeBlocksSortReverse";
            resources.ApplyResources(this.cmsCodeBlocksSortReverse, "cmsCodeBlocksSortReverse");
            // 
            // cmsCodeBlocksSortById
            // 
            this.cmsCodeBlocksSortById.Name = "cmsCodeBlocksSortById";
            resources.ApplyResources(this.cmsCodeBlocksSortById, "cmsCodeBlocksSortById");
            this.cmsCodeBlocksSortById.Click += new System.EventHandler(this.CmsCodeBlocksSortById_Click);
            // 
            // cmsCodeBlocksSortByColor
            // 
            this.cmsCodeBlocksSortByColor.Name = "cmsCodeBlocksSortByColor";
            resources.ApplyResources(this.cmsCodeBlocksSortByColor, "cmsCodeBlocksSortByColor");
            this.cmsCodeBlocksSortByColor.Click += new System.EventHandler(this.CmsCodeBlocksSortByColor_Click);
            // 
            // sortByPenWidthToolStripMenuItem
            // 
            this.sortByPenWidthToolStripMenuItem.Name = "sortByPenWidthToolStripMenuItem";
            resources.ApplyResources(this.sortByPenWidthToolStripMenuItem, "sortByPenWidthToolStripMenuItem");
            this.sortByPenWidthToolStripMenuItem.Click += new System.EventHandler(this.CmsCodeBlocksSortByWidth_Click);
            // 
            // sortByLayerToolStripMenuItem
            // 
            this.sortByLayerToolStripMenuItem.Name = "sortByLayerToolStripMenuItem";
            resources.ApplyResources(this.sortByLayerToolStripMenuItem, "sortByLayerToolStripMenuItem");
            this.sortByLayerToolStripMenuItem.Click += new System.EventHandler(this.CmsCodeBlocksSortByLayer_Click);
            // 
            // sortByTypeToolStripMenuItem
            // 
            this.sortByTypeToolStripMenuItem.Name = "sortByTypeToolStripMenuItem";
            resources.ApplyResources(this.sortByTypeToolStripMenuItem, "sortByTypeToolStripMenuItem");
            this.sortByTypeToolStripMenuItem.Click += new System.EventHandler(this.CmsCodeBlocksSortByType_Click);
            // 
            // cmsCodeBlocksSortByGeometry
            // 
            this.cmsCodeBlocksSortByGeometry.Name = "cmsCodeBlocksSortByGeometry";
            resources.ApplyResources(this.cmsCodeBlocksSortByGeometry, "cmsCodeBlocksSortByGeometry");
            this.cmsCodeBlocksSortByGeometry.Click += new System.EventHandler(this.CmsCodeBlocksSortByGeometry_Click);
            // 
            // cmsCodeBlocksSortByToolNr
            // 
            this.cmsCodeBlocksSortByToolNr.Name = "cmsCodeBlocksSortByToolNr";
            resources.ApplyResources(this.cmsCodeBlocksSortByToolNr, "cmsCodeBlocksSortByToolNr");
            this.cmsCodeBlocksSortByToolNr.Click += new System.EventHandler(this.CmsCodeBlocksSortByToolNr_Click);
            // 
            // cmsCodeBlocksSortByToolName
            // 
            this.cmsCodeBlocksSortByToolName.Name = "cmsCodeBlocksSortByToolName";
            resources.ApplyResources(this.cmsCodeBlocksSortByToolName, "cmsCodeBlocksSortByToolName");
            this.cmsCodeBlocksSortByToolName.Click += new System.EventHandler(this.CmsCodeBlocksSortByToolName_Click);
            // 
            // cmsCodeBlocksSortByCodeSize
            // 
            this.cmsCodeBlocksSortByCodeSize.Name = "cmsCodeBlocksSortByCodeSize";
            resources.ApplyResources(this.cmsCodeBlocksSortByCodeSize, "cmsCodeBlocksSortByCodeSize");
            this.cmsCodeBlocksSortByCodeSize.Click += new System.EventHandler(this.CmsCodeBlocksSortByCodeSize_Click);
            // 
            // cmsCodeBlocksSortByCodeArea
            // 
            this.cmsCodeBlocksSortByCodeArea.Name = "cmsCodeBlocksSortByCodeArea";
            resources.ApplyResources(this.cmsCodeBlocksSortByCodeArea, "cmsCodeBlocksSortByCodeArea");
            this.cmsCodeBlocksSortByCodeArea.Click += new System.EventHandler(this.CmsCodeBlocksSortByCodeArea_Click);
            // 
            // cmsCodeBlocksSortByDistance
            // 
            this.cmsCodeBlocksSortByDistance.Name = "cmsCodeBlocksSortByDistance";
            resources.ApplyResources(this.cmsCodeBlocksSortByDistance, "cmsCodeBlocksSortByDistance");
            this.cmsCodeBlocksSortByDistance.Click += new System.EventHandler(this.CmsCodeBlocksSortByDistance_Click);
            // 
            // cmsCodeBlocksRemoveGroup
            // 
            resources.ApplyResources(this.cmsCodeBlocksRemoveGroup, "cmsCodeBlocksRemoveGroup");
            this.cmsCodeBlocksRemoveGroup.Name = "cmsCodeBlocksRemoveGroup";
            this.cmsCodeBlocksRemoveGroup.Click += new System.EventHandler(this.CmsCodeBlocksRemoveGroup_Click);
            // 
            // cmsCodeBlocksRemoveAll
            // 
            resources.ApplyResources(this.cmsCodeBlocksRemoveAll, "cmsCodeBlocksRemoveAll");
            this.cmsCodeBlocksRemoveAll.Name = "cmsCodeBlocksRemoveAll";
            this.cmsCodeBlocksRemoveAll.Click += new System.EventHandler(this.CmsCodeBlocksRemoveAll_Click);
            // 
            // toolStripSeparator11
            // 
            this.toolStripSeparator11.Name = "toolStripSeparator11";
            resources.ApplyResources(this.toolStripSeparator11, "toolStripSeparator11");
            // 
            // cmsEditMode
            // 
            resources.ApplyResources(this.cmsEditMode, "cmsEditMode");
            this.cmsEditMode.Name = "cmsEditMode";
            // 
            // cmsCodeSelect
            // 
            resources.ApplyResources(this.cmsCodeSelect, "cmsCodeSelect");
            this.cmsCodeSelect.Name = "cmsCodeSelect";
            // 
            // cmsCodeCopy
            // 
            resources.ApplyResources(this.cmsCodeCopy, "cmsCodeCopy");
            this.cmsCodeCopy.Name = "cmsCodeCopy";
            // 
            // cmsCodePaste
            // 
            resources.ApplyResources(this.cmsCodePaste, "cmsCodePaste");
            this.cmsCodePaste.Name = "cmsCodePaste";
            // 
            // cmsCodePasteSpecial1
            // 
            resources.ApplyResources(this.cmsCodePasteSpecial1, "cmsCodePasteSpecial1");
            this.cmsCodePasteSpecial1.Name = "cmsCodePasteSpecial1";
            // 
            // cmsCodePasteSpecial2
            // 
            resources.ApplyResources(this.cmsCodePasteSpecial2, "cmsCodePasteSpecial2");
            this.cmsCodePasteSpecial2.Name = "cmsCodePasteSpecial2";
            // 
            // toolStripSeparator14
            // 
            this.toolStripSeparator14.Name = "toolStripSeparator14";
            resources.ApplyResources(this.toolStripSeparator14, "toolStripSeparator14");
            // 
            // cmsFindDialog
            // 
            resources.ApplyResources(this.cmsFindDialog, "cmsFindDialog");
            this.cmsFindDialog.Name = "cmsFindDialog";
            // 
            // cmsReplaceDialog
            // 
            resources.ApplyResources(this.cmsReplaceDialog, "cmsReplaceDialog");
            this.cmsReplaceDialog.Name = "cmsReplaceDialog";
            // 
            // toolStripSeparator12
            // 
            this.toolStripSeparator12.Name = "toolStripSeparator12";
            resources.ApplyResources(this.toolStripSeparator12, "toolStripSeparator12");
            // 
            // cmsCodeSendLine
            // 
            this.cmsCodeSendLine.Name = "cmsCodeSendLine";
            resources.ApplyResources(this.cmsCodeSendLine, "cmsCodeSendLine");
            // 
            // cmsCommentOut
            // 
            this.cmsCommentOut.Name = "cmsCommentOut";
            resources.ApplyResources(this.cmsCommentOut, "cmsCommentOut");
            // 
            // cmsUpdate2DView
            // 
            resources.ApplyResources(this.cmsUpdate2DView, "cmsUpdate2DView");
            this.cmsUpdate2DView.Name = "cmsUpdate2DView";
            // 
            // btnStreamStop
            // 
            this.btnStreamStop.Image = global::GrblPlotter.Properties.Resources.btn_stop;
            resources.ApplyResources(this.btnStreamStop, "btnStreamStop");
            this.btnStreamStop.Name = "btnStreamStop";
            this.toolTip1.SetToolTip(this.btnStreamStop, resources.GetString("btnStreamStop.ToolTip"));
            this.btnStreamStop.UseVisualStyleBackColor = true;
            // 
            // btnStreamStart
            // 
            this.btnStreamStart.Image = global::GrblPlotter.Properties.Resources.btn_play;
            resources.ApplyResources(this.btnStreamStart, "btnStreamStart");
            this.btnStreamStart.Name = "btnStreamStart";
            this.toolTip1.SetToolTip(this.btnStreamStart, resources.GetString("btnStreamStart.ToolTip"));
            this.btnStreamStart.UseVisualStyleBackColor = true;
            this.btnStreamStart.MouseUp += new System.Windows.Forms.MouseEventHandler(this.BtnStreamStart_Click);
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            this.toolTip1.SetToolTip(this.label6, resources.GetString("label6.ToolTip"));
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            this.toolTip1.SetToolTip(this.label1, resources.GetString("label1.ToolTip"));
            // 
            // tBURL
            // 
            resources.ApplyResources(this.tBURL, "tBURL");
            this.tBURL.Name = "tBURL";
            this.toolTip1.SetToolTip(this.tBURL, resources.GetString("tBURL.ToolTip"));
            this.tBURL.TextChanged += new System.EventHandler(this.TbURL_TextChanged);
            // 
            // CbAddGraphic
            // 
            resources.ApplyResources(this.CbAddGraphic, "CbAddGraphic");
            this.CbAddGraphic.Checked = global::GrblPlotter.Properties.Settings.Default.fromFormInsertEnable;
            this.CbAddGraphic.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::GrblPlotter.Properties.Settings.Default, "fromFormInsertEnable", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.CbAddGraphic.Name = "CbAddGraphic";
            this.toolTip1.SetToolTip(this.CbAddGraphic, resources.GetString("CbAddGraphic.ToolTip"));
            this.CbAddGraphic.UseVisualStyleBackColor = true;
            this.CbAddGraphic.CheckedChanged += new System.EventHandler(this.CbAddGraphic_CheckedChanged);
            // 
            // serverIP
            // 
            resources.ApplyResources(this.serverIP, "serverIP");
            this.serverIP.Name = "serverIP";
            this.serverIP.Text = global::GrblPlotter.Properties.Settings.Default.serverIPAddress;
            this.toolTip1.SetToolTip(this.serverIP, resources.GetString("serverIP.ToolTip"));
            this.serverIP.TextChanged += new System.EventHandler(this.Enable_btnExpGcode);
            // 
            // grp1
            // 
            this.grp1.Controls.Add(this.btnOpenFile);
            this.grp1.Controls.Add(this.tbFile);
            this.grp1.Controls.Add(this.label2);
            this.grp1.Controls.Add(this.serverIP);
            this.grp1.Controls.Add(this.btnExpGcode);
            resources.ApplyResources(this.grp1, "grp1");
            this.grp1.Name = "grp1";
            this.grp1.TabStop = false;
            // 
            // btnOpenFile
            // 
            resources.ApplyResources(this.btnOpenFile, "btnOpenFile");
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.UseVisualStyleBackColor = true;
            this.btnOpenFile.Click += new System.EventHandler(this.BtnOpenFile_Click);
            // 
            // tbFile
            // 
            resources.ApplyResources(this.tbFile, "tbFile");
            this.tbFile.Name = "tbFile";
            this.tbFile.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // btnExpGcode
            // 
            resources.ApplyResources(this.btnExpGcode, "btnExpGcode");
            this.btnExpGcode.Name = "btnExpGcode";
            this.btnExpGcode.UseVisualStyleBackColor = true;
            this.btnExpGcode.Click += new System.EventHandler(this.Export_Gcode_Click);
            // 
            // gBoxDimension
            // 
            this.gBoxDimension.Controls.Add(this.btnLimitExceed);
            this.gBoxDimension.Controls.Add(this.groupBox4);
            this.gBoxDimension.Controls.Add(this.lbDimension);
            resources.ApplyResources(this.gBoxDimension, "gBoxDimension");
            this.gBoxDimension.Name = "gBoxDimension";
            this.gBoxDimension.TabStop = false;
            // 
            // btnLimitExceed
            // 
            this.btnLimitExceed.BackColor = System.Drawing.Color.Yellow;
            resources.ApplyResources(this.btnLimitExceed, "btnLimitExceed");
            this.btnLimitExceed.Name = "btnLimitExceed";
            this.btnLimitExceed.UseVisualStyleBackColor = false;
            this.btnLimitExceed.Click += new System.EventHandler(this.BtnLimitExceed_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnOffsetApply);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.tbOffsetY);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.tbOffsetX);
            this.groupBox4.Controls.Add(this.rBOrigin9);
            this.groupBox4.Controls.Add(this.rBOrigin8);
            this.groupBox4.Controls.Add(this.rBOrigin7);
            this.groupBox4.Controls.Add(this.rBOrigin6);
            this.groupBox4.Controls.Add(this.rBOrigin5);
            this.groupBox4.Controls.Add(this.rBOrigin4);
            this.groupBox4.Controls.Add(this.rBOrigin3);
            this.groupBox4.Controls.Add(this.rBOrigin2);
            this.groupBox4.Controls.Add(this.rBOrigin1);
            resources.ApplyResources(this.groupBox4, "groupBox4");
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.TabStop = false;
            // 
            // btnOffsetApply
            // 
            resources.ApplyResources(this.btnOffsetApply, "btnOffsetApply");
            this.btnOffsetApply.Name = "btnOffsetApply";
            this.btnOffsetApply.UseVisualStyleBackColor = true;
            this.btnOffsetApply.Click += new System.EventHandler(this.BtnOffsetApply_Click);
            // 
            // tbOffsetY
            // 
            resources.ApplyResources(this.tbOffsetY, "tbOffsetY");
            this.tbOffsetY.Name = "tbOffsetY";
            // 
            // tbOffsetX
            // 
            resources.ApplyResources(this.tbOffsetX, "tbOffsetX");
            this.tbOffsetX.Name = "tbOffsetX";
            // 
            // rBOrigin9
            // 
            resources.ApplyResources(this.rBOrigin9, "rBOrigin9");
            this.rBOrigin9.Name = "rBOrigin9";
            this.rBOrigin9.UseVisualStyleBackColor = true;
            // 
            // rBOrigin8
            // 
            resources.ApplyResources(this.rBOrigin8, "rBOrigin8");
            this.rBOrigin8.Name = "rBOrigin8";
            this.rBOrigin8.UseVisualStyleBackColor = true;
            // 
            // rBOrigin7
            // 
            resources.ApplyResources(this.rBOrigin7, "rBOrigin7");
            this.rBOrigin7.Checked = true;
            this.rBOrigin7.Name = "rBOrigin7";
            this.rBOrigin7.TabStop = true;
            this.rBOrigin7.UseVisualStyleBackColor = true;
            // 
            // rBOrigin6
            // 
            resources.ApplyResources(this.rBOrigin6, "rBOrigin6");
            this.rBOrigin6.Name = "rBOrigin6";
            this.rBOrigin6.UseVisualStyleBackColor = true;
            // 
            // rBOrigin5
            // 
            resources.ApplyResources(this.rBOrigin5, "rBOrigin5");
            this.rBOrigin5.Name = "rBOrigin5";
            this.rBOrigin5.UseVisualStyleBackColor = true;
            // 
            // rBOrigin4
            // 
            resources.ApplyResources(this.rBOrigin4, "rBOrigin4");
            this.rBOrigin4.Name = "rBOrigin4";
            this.rBOrigin4.UseVisualStyleBackColor = true;
            // 
            // rBOrigin3
            // 
            resources.ApplyResources(this.rBOrigin3, "rBOrigin3");
            this.rBOrigin3.Name = "rBOrigin3";
            this.rBOrigin3.UseVisualStyleBackColor = true;
            // 
            // rBOrigin2
            // 
            resources.ApplyResources(this.rBOrigin2, "rBOrigin2");
            this.rBOrigin2.Name = "rBOrigin2";
            this.rBOrigin2.UseVisualStyleBackColor = true;
            // 
            // rBOrigin1
            // 
            resources.ApplyResources(this.rBOrigin1, "rBOrigin1");
            this.rBOrigin1.Name = "rBOrigin1";
            this.rBOrigin1.UseVisualStyleBackColor = true;
            // 
            // lbDimension
            // 
            this.lbDimension.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            resources.ApplyResources(this.lbDimension, "lbDimension");
            this.lbDimension.HideSelection = false;
            this.lbDimension.Name = "lbDimension";
            this.lbDimension.ReadOnly = true;
            // 
            // tLPRechts
            // 
            resources.ApplyResources(this.tLPRechts, "tLPRechts");
            this.tLPRechts.Controls.Add(this.tLPRechtsUnten, 0, 1);
            this.tLPRechts.Name = "tLPRechts";
            // 
            // tLPRechtsUnten
            // 
            resources.ApplyResources(this.tLPRechtsUnten, "tLPRechtsUnten");
            this.tLPRechtsUnten.Controls.Add(this.tLPMitteUnten, 0, 0);
            this.tLPRechtsUnten.Name = "tLPRechtsUnten";
            // 
            // tLPMitteUnten
            // 
            resources.ApplyResources(this.tLPMitteUnten, "tLPMitteUnten");
            this.tLPMitteUnten.Controls.Add(this.pictureBox1, 0, 0);
            this.tLPMitteUnten.Controls.Add(this.tBURL, 0, 1);
            this.tLPMitteUnten.Controls.Add(this.CbAddGraphic, 0, 2);
            this.tLPMitteUnten.Name = "tLPMitteUnten";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBox1.BackgroundImage = global::GrblPlotter.Properties.Resources.kplotter_bw;
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.ContextMenuStrip = this.cmsPictureBox;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Cross;
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            this.pictureBox1.SizeChanged += new System.EventHandler(this.PictureBox1_SizeChanged);
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.PictureBox1_Paint);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PictureBox1_MouseDown);
            this.pictureBox1.MouseLeave += new System.EventHandler(this.PictureBox1_MouseLeave);
            this.pictureBox1.MouseHover += new System.EventHandler(this.PictureBox1_MouseHover);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PictureBox1_MouseUp);
            this.pictureBox1.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.PictureBox1_MouseWheel);
            // 
            // cmsPictureBox
            // 
            this.cmsPictureBox.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.unDo2ToolStripMenuItem,
            this.applyLastTransformToolStripMenuItem,
            this.toolStripSeparator17,
            this.cmsPicBoxReloadFile,
            this.cmsPicBoxReloadFile2,
            this.cmsPicBoxPasteFromClipboard,
            this.cmsPicBoxClearWorkspace,
            this.toolStripSeparator9,
            this.cmsPicBoxResetZooming,
            this.toolStripSeparator8,
            this.cmsPicBoxMoveToMarkedPosition,
            this.cmsPicBoxZeroXYAtMarkedPosition,
            this.cmsPicBoxMoveGraphicsOrigin,
            this.deletenotMarkToolStripMenuItem,
            this.toolStripSeparator1,
            this.cmsPicBoxMarkFirstPos,
            this.cmsPicBoxShowProperties,
            this.cmsPicBoxDuplicatePath,
            this.cmsPicBoxDeletePath,
            this.cmsPicBoxCropSelectedPath,
            this.cmsPicBoxMoveSelectedPathInCode,
            this.cmsPicBoxReverseSelectedPath,
            this.cmsPicBoxRotateSelectedPath,
            this.toolStripSeparator10,
            this.cmsPicBoxSetGCodeAsBackground,
            this.cmsPicBoxClearBackground,
            this.copyContentTroClipboardToolStripMenuItem});
            this.cmsPictureBox.Name = "cmsPictureBox";
            this.cmsPictureBox.ShowImageMargin = false;
            resources.ApplyResources(this.cmsPictureBox, "cmsPictureBox");
            this.cmsPictureBox.Opening += new System.ComponentModel.CancelEventHandler(this.CmsPictureBox_Opening);
            // 
            // unDo2ToolStripMenuItem
            // 
            resources.ApplyResources(this.unDo2ToolStripMenuItem, "unDo2ToolStripMenuItem");
            this.unDo2ToolStripMenuItem.Name = "unDo2ToolStripMenuItem";
            this.unDo2ToolStripMenuItem.Click += new System.EventHandler(this.UnDoToolStripMenuItem_Click);
            // 
            // applyLastTransformToolStripMenuItem
            // 
            this.applyLastTransformToolStripMenuItem.Name = "applyLastTransformToolStripMenuItem";
            resources.ApplyResources(this.applyLastTransformToolStripMenuItem, "applyLastTransformToolStripMenuItem");
            this.applyLastTransformToolStripMenuItem.Click += new System.EventHandler(this.ApplyLastTransformToolStripMenuItem_Click);
            // 
            // toolStripSeparator17
            // 
            this.toolStripSeparator17.Name = "toolStripSeparator17";
            resources.ApplyResources(this.toolStripSeparator17, "toolStripSeparator17");
            // 
            // cmsPicBoxReloadFile
            // 
            this.cmsPicBoxReloadFile.Name = "cmsPicBoxReloadFile";
            resources.ApplyResources(this.cmsPicBoxReloadFile, "cmsPicBoxReloadFile");
            this.cmsPicBoxReloadFile.Tag = "";
            this.cmsPicBoxReloadFile.Click += new System.EventHandler(this.CmsPicBoxReloadFile_Click);
            // 
            // cmsPicBoxReloadFile2
            // 
            this.cmsPicBoxReloadFile2.Name = "cmsPicBoxReloadFile2";
            resources.ApplyResources(this.cmsPicBoxReloadFile2, "cmsPicBoxReloadFile2");
            this.cmsPicBoxReloadFile2.Tag = "";
            this.cmsPicBoxReloadFile2.Click += new System.EventHandler(this.CmsPicBoxReloadFile_Click);
            // 
            // cmsPicBoxPasteFromClipboard
            // 
            this.cmsPicBoxPasteFromClipboard.Name = "cmsPicBoxPasteFromClipboard";
            resources.ApplyResources(this.cmsPicBoxPasteFromClipboard, "cmsPicBoxPasteFromClipboard");
            this.cmsPicBoxPasteFromClipboard.Click += new System.EventHandler(this.CmsPicBoxPasteFromClipboard_Click);
            // 
            // cmsPicBoxClearWorkspace
            // 
            this.cmsPicBoxClearWorkspace.Name = "cmsPicBoxClearWorkspace";
            resources.ApplyResources(this.cmsPicBoxClearWorkspace, "cmsPicBoxClearWorkspace");
            this.cmsPicBoxClearWorkspace.Click += new System.EventHandler(this.CmsPicBoxClearWorkspace_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            resources.ApplyResources(this.toolStripSeparator9, "toolStripSeparator9");
            // 
            // cmsPicBoxResetZooming
            // 
            this.cmsPicBoxResetZooming.Name = "cmsPicBoxResetZooming";
            resources.ApplyResources(this.cmsPicBoxResetZooming, "cmsPicBoxResetZooming");
            this.cmsPicBoxResetZooming.Click += new System.EventHandler(this.CmsPicBoxResetZooming_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            resources.ApplyResources(this.toolStripSeparator8, "toolStripSeparator8");
            // 
            // cmsPicBoxMoveToMarkedPosition
            // 
            this.cmsPicBoxMoveToMarkedPosition.Name = "cmsPicBoxMoveToMarkedPosition";
            resources.ApplyResources(this.cmsPicBoxMoveToMarkedPosition, "cmsPicBoxMoveToMarkedPosition");
            this.cmsPicBoxMoveToMarkedPosition.Click += new System.EventHandler(this.CmsPicBoxMoveToMarkedPosition_Click);
            // 
            // cmsPicBoxZeroXYAtMarkedPosition
            // 
            this.cmsPicBoxZeroXYAtMarkedPosition.Name = "cmsPicBoxZeroXYAtMarkedPosition";
            resources.ApplyResources(this.cmsPicBoxZeroXYAtMarkedPosition, "cmsPicBoxZeroXYAtMarkedPosition");
            this.cmsPicBoxZeroXYAtMarkedPosition.Click += new System.EventHandler(this.CmsPicBoxZeroXYAtMarkedPosition_Click);
            // 
            // cmsPicBoxMoveGraphicsOrigin
            // 
            this.cmsPicBoxMoveGraphicsOrigin.Name = "cmsPicBoxMoveGraphicsOrigin";
            resources.ApplyResources(this.cmsPicBoxMoveGraphicsOrigin, "cmsPicBoxMoveGraphicsOrigin");
            this.cmsPicBoxMoveGraphicsOrigin.Click += new System.EventHandler(this.CmsPicBoxMoveGraphicsOrigin_Click);
            // 
            // deletenotMarkToolStripMenuItem
            // 
            resources.ApplyResources(this.deletenotMarkToolStripMenuItem, "deletenotMarkToolStripMenuItem");
            this.deletenotMarkToolStripMenuItem.Name = "deletenotMarkToolStripMenuItem";
            this.deletenotMarkToolStripMenuItem.Click += new System.EventHandler(this.DeletenotMarkToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // cmsPicBoxMarkFirstPos
            // 
            this.cmsPicBoxMarkFirstPos.Name = "cmsPicBoxMarkFirstPos";
            resources.ApplyResources(this.cmsPicBoxMarkFirstPos, "cmsPicBoxMarkFirstPos");
            this.cmsPicBoxMarkFirstPos.Click += new System.EventHandler(this.CmsPicBoxMoveToFirstPos_Click);
            // 
            // cmsPicBoxShowProperties
            // 
            resources.ApplyResources(this.cmsPicBoxShowProperties, "cmsPicBoxShowProperties");
            this.cmsPicBoxShowProperties.Name = "cmsPicBoxShowProperties";
            this.cmsPicBoxShowProperties.Click += new System.EventHandler(this.CmsPicBoxShowProperties_Click);
            // 
            // cmsPicBoxDuplicatePath
            // 
            resources.ApplyResources(this.cmsPicBoxDuplicatePath, "cmsPicBoxDuplicatePath");
            this.cmsPicBoxDuplicatePath.Name = "cmsPicBoxDuplicatePath";
            this.cmsPicBoxDuplicatePath.Click += new System.EventHandler(this.CmsPicBoxDuplicatePath_Click);
            // 
            // cmsPicBoxDeletePath
            // 
            resources.ApplyResources(this.cmsPicBoxDeletePath, "cmsPicBoxDeletePath");
            this.cmsPicBoxDeletePath.Name = "cmsPicBoxDeletePath";
            this.cmsPicBoxDeletePath.Click += new System.EventHandler(this.CmsPicBoxDeletePath_Click);
            // 
            // cmsPicBoxCropSelectedPath
            // 
            resources.ApplyResources(this.cmsPicBoxCropSelectedPath, "cmsPicBoxCropSelectedPath");
            this.cmsPicBoxCropSelectedPath.Name = "cmsPicBoxCropSelectedPath";
            this.cmsPicBoxCropSelectedPath.Click += new System.EventHandler(this.CmsPicBoxCropSelectedPath_Click);
            // 
            // cmsPicBoxMoveSelectedPathInCode
            // 
            resources.ApplyResources(this.cmsPicBoxMoveSelectedPathInCode, "cmsPicBoxMoveSelectedPathInCode");
            this.cmsPicBoxMoveSelectedPathInCode.Name = "cmsPicBoxMoveSelectedPathInCode";
            this.cmsPicBoxMoveSelectedPathInCode.Click += new System.EventHandler(this.CmsPicBoxMoveSelectedPathInCode_Click);
            // 
            // cmsPicBoxReverseSelectedPath
            // 
            resources.ApplyResources(this.cmsPicBoxReverseSelectedPath, "cmsPicBoxReverseSelectedPath");
            this.cmsPicBoxReverseSelectedPath.Name = "cmsPicBoxReverseSelectedPath";
            this.cmsPicBoxReverseSelectedPath.Click += new System.EventHandler(this.CmsPicBoxReverseSelectedPath_Click);
            // 
            // cmsPicBoxRotateSelectedPath
            // 
            resources.ApplyResources(this.cmsPicBoxRotateSelectedPath, "cmsPicBoxRotateSelectedPath");
            this.cmsPicBoxRotateSelectedPath.Name = "cmsPicBoxRotateSelectedPath";
            this.cmsPicBoxRotateSelectedPath.Click += new System.EventHandler(this.CmsPicBoxRotateSelectedPath_Click);
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            resources.ApplyResources(this.toolStripSeparator10, "toolStripSeparator10");
            // 
            // cmsPicBoxSetGCodeAsBackground
            // 
            this.cmsPicBoxSetGCodeAsBackground.Name = "cmsPicBoxSetGCodeAsBackground";
            resources.ApplyResources(this.cmsPicBoxSetGCodeAsBackground, "cmsPicBoxSetGCodeAsBackground");
            this.cmsPicBoxSetGCodeAsBackground.Click += new System.EventHandler(this.CmsPicBoxSetGCodeAsBackground_Click);
            // 
            // cmsPicBoxClearBackground
            // 
            this.cmsPicBoxClearBackground.Name = "cmsPicBoxClearBackground";
            resources.ApplyResources(this.cmsPicBoxClearBackground, "cmsPicBoxClearBackground");
            this.cmsPicBoxClearBackground.Click += new System.EventHandler(this.CmsPicBoxClearBackground_Click);
            // 
            // copyContentTroClipboardToolStripMenuItem
            // 
            this.copyContentTroClipboardToolStripMenuItem.Name = "copyContentTroClipboardToolStripMenuItem";
            resources.ApplyResources(this.copyContentTroClipboardToolStripMenuItem, "copyContentTroClipboardToolStripMenuItem");
            this.copyContentTroClipboardToolStripMenuItem.Click += new System.EventHandler(this.CopyContentToClipboardToolStripMenuItem_Click);
            // 
            // lblRemaining
            // 
            resources.ApplyResources(this.lblRemaining, "lblRemaining");
            this.lblRemaining.Name = "lblRemaining";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.createGCodeToolStripMenuItem,
            this.gCodeToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.aboutToolStripMenuItem,
            this.logToolStripMenuItem});
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Name = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadToolStripMenuItem,
            this.toolStripMenuItem2,
            this.toolStripSeparator2,
            this.saveToolStripMenuItem,
            this.toolStripSeparator3,
            this.setupToolStripMenuItem1,
            this.toolStripSeparator7,
            this.saveMachineParametersToolStripMenuItem,
            this.loadMachineParametersToolStripMenuItem,
            this.LanguageToolStripMenuItem3,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            resources.ApplyResources(this.fileToolStripMenuItem, "fileToolStripMenuItem");
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            resources.ApplyResources(this.loadToolStripMenuItem, "loadToolStripMenuItem");
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.BtnOpenFile_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            resources.ApplyResources(this.toolStripMenuItem2, "toolStripMenuItem2");
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            resources.ApplyResources(this.saveToolStripMenuItem, "saveToolStripMenuItem");
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.BtnSaveFile_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            resources.ApplyResources(this.toolStripSeparator3, "toolStripSeparator3");
            // 
            // setupToolStripMenuItem1
            // 
            this.setupToolStripMenuItem1.Name = "setupToolStripMenuItem1";
            resources.ApplyResources(this.setupToolStripMenuItem1, "setupToolStripMenuItem1");
            this.setupToolStripMenuItem1.Click += new System.EventHandler(this.SetupToolStripMenuItem_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            resources.ApplyResources(this.toolStripSeparator7, "toolStripSeparator7");
            // 
            // saveMachineParametersToolStripMenuItem
            // 
            this.saveMachineParametersToolStripMenuItem.Name = "saveMachineParametersToolStripMenuItem";
            resources.ApplyResources(this.saveMachineParametersToolStripMenuItem, "saveMachineParametersToolStripMenuItem");
            this.saveMachineParametersToolStripMenuItem.Click += new System.EventHandler(this.SaveMachineParametersToolStripMenuItem_Click);
            // 
            // loadMachineParametersToolStripMenuItem
            // 
            this.loadMachineParametersToolStripMenuItem.Name = "loadMachineParametersToolStripMenuItem";
            resources.ApplyResources(this.loadMachineParametersToolStripMenuItem, "loadMachineParametersToolStripMenuItem");
            this.loadMachineParametersToolStripMenuItem.Click += new System.EventHandler(this.LoadMachineParametersToolStripMenuItem_Click);
            // 
            // LanguageToolStripMenuItem3
            // 
            this.LanguageToolStripMenuItem3.AutoToolTip = true;
            this.LanguageToolStripMenuItem3.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.englishToolStripMenuItem,
            this.deutschToolStripMenuItem,
            this.pусскийToolStripMenuItem,
            this.toolStripMenuItem4,
            this.portuguêsToolStripMenuItem,
            this.franzToolStripMenuItem,
            this.italianoToolStripMenuItem,
            this.PolishToolStripMenuItem,
            this.czechToolStripMenuItem,
            this.türkToolStripMenuItem,
            this.chinesischToolStripMenuItem,
            this.arabischToolStripMenuItem,
            this.japanischToolStripMenuItem});
            this.LanguageToolStripMenuItem3.Name = "LanguageToolStripMenuItem3";
            resources.ApplyResources(this.LanguageToolStripMenuItem3, "LanguageToolStripMenuItem3");
            // 
            // englishToolStripMenuItem
            // 
            this.englishToolStripMenuItem.Name = "englishToolStripMenuItem";
            resources.ApplyResources(this.englishToolStripMenuItem, "englishToolStripMenuItem");
            this.englishToolStripMenuItem.Click += new System.EventHandler(this.EnglishToolStripMenuItem_Click);
            // 
            // deutschToolStripMenuItem
            // 
            this.deutschToolStripMenuItem.Name = "deutschToolStripMenuItem";
            resources.ApplyResources(this.deutschToolStripMenuItem, "deutschToolStripMenuItem");
            this.deutschToolStripMenuItem.Click += new System.EventHandler(this.DeutschToolStripMenuItem_Click);
            // 
            // pусскийToolStripMenuItem
            // 
            this.pусскийToolStripMenuItem.Name = "pусскийToolStripMenuItem";
            resources.ApplyResources(this.pусскийToolStripMenuItem, "pусскийToolStripMenuItem");
            this.pусскийToolStripMenuItem.Click += new System.EventHandler(this.RussianToolStripMenuItem_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            resources.ApplyResources(this.toolStripMenuItem4, "toolStripMenuItem4");
            this.toolStripMenuItem4.Click += new System.EventHandler(this.SpanToolStripMenuItem_Click);
            // 
            // portuguêsToolStripMenuItem
            // 
            this.portuguêsToolStripMenuItem.Name = "portuguêsToolStripMenuItem";
            resources.ApplyResources(this.portuguêsToolStripMenuItem, "portuguêsToolStripMenuItem");
            this.portuguêsToolStripMenuItem.Click += new System.EventHandler(this.PortugisischToolStripMenuItem_Click);
            // 
            // franzToolStripMenuItem
            // 
            this.franzToolStripMenuItem.Name = "franzToolStripMenuItem";
            resources.ApplyResources(this.franzToolStripMenuItem, "franzToolStripMenuItem");
            this.franzToolStripMenuItem.Click += new System.EventHandler(this.FranzToolStripMenuItem_Click);
            // 
            // italianoToolStripMenuItem
            // 
            this.italianoToolStripMenuItem.Name = "italianoToolStripMenuItem";
            resources.ApplyResources(this.italianoToolStripMenuItem, "italianoToolStripMenuItem");
            this.italianoToolStripMenuItem.Click += new System.EventHandler(this.ItalianToolStripMenuItem_Click);
            // 
            // PolishToolStripMenuItem
            // 
            this.PolishToolStripMenuItem.Name = "PolishToolStripMenuItem";
            resources.ApplyResources(this.PolishToolStripMenuItem, "PolishToolStripMenuItem");
            this.PolishToolStripMenuItem.Click += new System.EventHandler(this.PolishToolStripMenuItem_Click);
            // 
            // czechToolStripMenuItem
            // 
            this.czechToolStripMenuItem.Name = "czechToolStripMenuItem";
            resources.ApplyResources(this.czechToolStripMenuItem, "czechToolStripMenuItem");
            this.czechToolStripMenuItem.Click += new System.EventHandler(this.CzechToolStripMenuItem_Click);
            // 
            // türkToolStripMenuItem
            // 
            this.türkToolStripMenuItem.Name = "türkToolStripMenuItem";
            resources.ApplyResources(this.türkToolStripMenuItem, "türkToolStripMenuItem");
            this.türkToolStripMenuItem.Click += new System.EventHandler(this.TürkToolStripMenuItem_Click);
            // 
            // chinesischToolStripMenuItem
            // 
            this.chinesischToolStripMenuItem.Name = "chinesischToolStripMenuItem";
            resources.ApplyResources(this.chinesischToolStripMenuItem, "chinesischToolStripMenuItem");
            this.chinesischToolStripMenuItem.Click += new System.EventHandler(this.ChinesischToolStripMenuItem_Click);
            // 
            // arabischToolStripMenuItem
            // 
            this.arabischToolStripMenuItem.Name = "arabischToolStripMenuItem";
            resources.ApplyResources(this.arabischToolStripMenuItem, "arabischToolStripMenuItem");
            this.arabischToolStripMenuItem.Click += new System.EventHandler(this.ArabischToolStripMenuItem_Click);
            // 
            // japanischToolStripMenuItem
            // 
            this.japanischToolStripMenuItem.Name = "japanischToolStripMenuItem";
            resources.ApplyResources(this.japanischToolStripMenuItem, "japanischToolStripMenuItem");
            this.japanischToolStripMenuItem.Click += new System.EventHandler(this.JapanischToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            resources.ApplyResources(this.exitToolStripMenuItem, "exitToolStripMenuItem");
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // createGCodeToolStripMenuItem
            // 
            this.createGCodeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.textWizzardToolStripMenuItem,
            this.createBarcodeToolStripMenuItem,
            this.imageToolStripMenuItem,
            this.createSimpleShapesToolStripMenuItem,
            this.wireCutterToolStripMenuItem,
            this.createJogPathToolStripMenuItem,
            this.startExtensionToolStripMenuItem});
            this.createGCodeToolStripMenuItem.Name = "createGCodeToolStripMenuItem";
            resources.ApplyResources(this.createGCodeToolStripMenuItem, "createGCodeToolStripMenuItem");
            // 
            // textWizzardToolStripMenuItem
            // 
            this.textWizzardToolStripMenuItem.Name = "textWizzardToolStripMenuItem";
            resources.ApplyResources(this.textWizzardToolStripMenuItem, "textWizzardToolStripMenuItem");
            this.textWizzardToolStripMenuItem.Click += new System.EventHandler(this.TextWizzardToolStripMenuItem_Click);
            // 
            // createBarcodeToolStripMenuItem
            // 
            this.createBarcodeToolStripMenuItem.Name = "createBarcodeToolStripMenuItem";
            resources.ApplyResources(this.createBarcodeToolStripMenuItem, "createBarcodeToolStripMenuItem");
            this.createBarcodeToolStripMenuItem.Click += new System.EventHandler(this.CreateBarcodeToolStripMenuItem_Click);
            // 
            // imageToolStripMenuItem
            // 
            this.imageToolStripMenuItem.Name = "imageToolStripMenuItem";
            resources.ApplyResources(this.imageToolStripMenuItem, "imageToolStripMenuItem");
            this.imageToolStripMenuItem.Click += new System.EventHandler(this.ImageToolStripMenuItem_Click);
            // 
            // createSimpleShapesToolStripMenuItem
            // 
            this.createSimpleShapesToolStripMenuItem.Name = "createSimpleShapesToolStripMenuItem";
            resources.ApplyResources(this.createSimpleShapesToolStripMenuItem, "createSimpleShapesToolStripMenuItem");
            this.createSimpleShapesToolStripMenuItem.Click += new System.EventHandler(this.CreateSimpleShapesToolStripMenuItem_Click);
            // 
            // wireCutterToolStripMenuItem
            // 
            this.wireCutterToolStripMenuItem.Name = "wireCutterToolStripMenuItem";
            resources.ApplyResources(this.wireCutterToolStripMenuItem, "wireCutterToolStripMenuItem");
            this.wireCutterToolStripMenuItem.Click += new System.EventHandler(this.WireCutterToolStripMenuItem_Click);
            // 
            // createJogPathToolStripMenuItem
            // 
            this.createJogPathToolStripMenuItem.Name = "createJogPathToolStripMenuItem";
            resources.ApplyResources(this.createJogPathToolStripMenuItem, "createJogPathToolStripMenuItem");
            this.createJogPathToolStripMenuItem.Click += new System.EventHandler(this.JogCreatorToolStripMenuItem_Click);
            // 
            // startExtensionToolStripMenuItem
            // 
            this.startExtensionToolStripMenuItem.Name = "startExtensionToolStripMenuItem";
            resources.ApplyResources(this.startExtensionToolStripMenuItem, "startExtensionToolStripMenuItem");
            // 
            // gCodeToolStripMenuItem
            // 
            this.gCodeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.unDoToolStripMenuItem,
            this.toolStripSeparator16,
            this.mirrorXToolStripMenuItem,
            this.mirrorYToolStripMenuItem,
            this.mirrorRotaryToolStripMenuItem,
            this.toolStripSeparator4,
            this.rotate90ToolStripMenuItem,
            this.rotate90ToolStripMenuItem1,
            this.rotate180ToolStripMenuItem,
            this.rotateFreeToolStripMenuItem,
            this.toolStripSeparator5,
            this.sToolStripMenuItem,
            this.skalierenXYToolStripMenuItem,
            this.skalierenXYUmXUnitsZuErreichenToolStripMenuItem,
            this.skaliereXUmToolStripMenuItem,
            this.skaliereAufXUnitsToolStripMenuItem,
            this.skaliereYUmToolStripMenuItem,
            this.skaliereAufYUnitsToolStripMenuItem,
            this.toolStripSeparator6,
            this.rotaryDimaeterToolStripMenuItem,
            this.skaliereXAufDrehachseToolStripMenuItem,
            this.skaliereYAufDrehachseToolStripMenuItem,
            this.toolStripSeparator15,
            this.toolStrip_RadiusComp,
            this.ersetzteG23DurchLinienToolStripMenuItem,
            this.convertToPolarCoordinatesToolStripMenuItem,
            this.convertZToSspindleSpeedToolStripMenuItem,
            this.removeAnyZMoveToolStripMenuItem});
            this.gCodeToolStripMenuItem.Name = "gCodeToolStripMenuItem";
            resources.ApplyResources(this.gCodeToolStripMenuItem, "gCodeToolStripMenuItem");
            // 
            // unDoToolStripMenuItem
            // 
            resources.ApplyResources(this.unDoToolStripMenuItem, "unDoToolStripMenuItem");
            this.unDoToolStripMenuItem.Name = "unDoToolStripMenuItem";
            this.unDoToolStripMenuItem.Click += new System.EventHandler(this.UnDoToolStripMenuItem_Click);
            // 
            // toolStripSeparator16
            // 
            this.toolStripSeparator16.Name = "toolStripSeparator16";
            resources.ApplyResources(this.toolStripSeparator16, "toolStripSeparator16");
            // 
            // mirrorXToolStripMenuItem
            // 
            this.mirrorXToolStripMenuItem.Name = "mirrorXToolStripMenuItem";
            resources.ApplyResources(this.mirrorXToolStripMenuItem, "mirrorXToolStripMenuItem");
            this.mirrorXToolStripMenuItem.Click += new System.EventHandler(this.MirrorXToolStripMenuItem_Click);
            // 
            // mirrorYToolStripMenuItem
            // 
            this.mirrorYToolStripMenuItem.Name = "mirrorYToolStripMenuItem";
            resources.ApplyResources(this.mirrorYToolStripMenuItem, "mirrorYToolStripMenuItem");
            this.mirrorYToolStripMenuItem.Click += new System.EventHandler(this.MirrorYToolStripMenuItem_Click);
            // 
            // mirrorRotaryToolStripMenuItem
            // 
            this.mirrorRotaryToolStripMenuItem.Name = "mirrorRotaryToolStripMenuItem";
            resources.ApplyResources(this.mirrorRotaryToolStripMenuItem, "mirrorRotaryToolStripMenuItem");
            this.mirrorRotaryToolStripMenuItem.Click += new System.EventHandler(this.MirrorRotaryToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            resources.ApplyResources(this.toolStripSeparator4, "toolStripSeparator4");
            // 
            // rotate90ToolStripMenuItem
            // 
            this.rotate90ToolStripMenuItem.Name = "rotate90ToolStripMenuItem";
            resources.ApplyResources(this.rotate90ToolStripMenuItem, "rotate90ToolStripMenuItem");
            this.rotate90ToolStripMenuItem.Click += new System.EventHandler(this.Rotate90ToolStripMenuItem_Click);
            // 
            // rotate90ToolStripMenuItem1
            // 
            this.rotate90ToolStripMenuItem1.Name = "rotate90ToolStripMenuItem1";
            resources.ApplyResources(this.rotate90ToolStripMenuItem1, "rotate90ToolStripMenuItem1");
            this.rotate90ToolStripMenuItem1.Click += new System.EventHandler(this.Rotate90ToolStripMenuItem1_Click);
            // 
            // rotate180ToolStripMenuItem
            // 
            this.rotate180ToolStripMenuItem.Name = "rotate180ToolStripMenuItem";
            resources.ApplyResources(this.rotate180ToolStripMenuItem, "rotate180ToolStripMenuItem");
            this.rotate180ToolStripMenuItem.Click += new System.EventHandler(this.Rotate180ToolStripMenuItem_Click);
            // 
            // rotateFreeToolStripMenuItem
            // 
            this.rotateFreeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStrip_tb_rotate});
            this.rotateFreeToolStripMenuItem.Name = "rotateFreeToolStripMenuItem";
            resources.ApplyResources(this.rotateFreeToolStripMenuItem, "rotateFreeToolStripMenuItem");
            // 
            // toolStrip_tb_rotate
            // 
            resources.ApplyResources(this.toolStrip_tb_rotate, "toolStrip_tb_rotate");
            this.toolStrip_tb_rotate.Name = "toolStrip_tb_rotate";
            this.toolStrip_tb_rotate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ToolStrip_tb_rotate_KeyDown);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            resources.ApplyResources(this.toolStripSeparator5, "toolStripSeparator5");
            // 
            // sToolStripMenuItem
            // 
            this.sToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStrip_tb_XY_scale});
            this.sToolStripMenuItem.Name = "sToolStripMenuItem";
            resources.ApplyResources(this.sToolStripMenuItem, "sToolStripMenuItem");
            // 
            // toolStrip_tb_XY_scale
            // 
            resources.ApplyResources(this.toolStrip_tb_XY_scale, "toolStrip_tb_XY_scale");
            this.toolStrip_tb_XY_scale.Name = "toolStrip_tb_XY_scale";
            this.toolStrip_tb_XY_scale.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ToolStrip_tb_XY_scale_KeyDown);
            // 
            // skalierenXYToolStripMenuItem
            // 
            this.skalierenXYToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStrip_tb_XY_X_scale});
            this.skalierenXYToolStripMenuItem.Name = "skalierenXYToolStripMenuItem";
            resources.ApplyResources(this.skalierenXYToolStripMenuItem, "skalierenXYToolStripMenuItem");
            // 
            // toolStrip_tb_XY_X_scale
            // 
            resources.ApplyResources(this.toolStrip_tb_XY_X_scale, "toolStrip_tb_XY_X_scale");
            this.toolStrip_tb_XY_X_scale.Name = "toolStrip_tb_XY_X_scale";
            this.toolStrip_tb_XY_X_scale.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ToolStrip_tb_XY_X_scale_KeyDown);
            // 
            // skalierenXYUmXUnitsZuErreichenToolStripMenuItem
            // 
            this.skalierenXYUmXUnitsZuErreichenToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStrip_tb_XY_Y_scale});
            this.skalierenXYUmXUnitsZuErreichenToolStripMenuItem.Name = "skalierenXYUmXUnitsZuErreichenToolStripMenuItem";
            resources.ApplyResources(this.skalierenXYUmXUnitsZuErreichenToolStripMenuItem, "skalierenXYUmXUnitsZuErreichenToolStripMenuItem");
            // 
            // toolStrip_tb_XY_Y_scale
            // 
            resources.ApplyResources(this.toolStrip_tb_XY_Y_scale, "toolStrip_tb_XY_Y_scale");
            this.toolStrip_tb_XY_Y_scale.Name = "toolStrip_tb_XY_Y_scale";
            this.toolStrip_tb_XY_Y_scale.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ToolStrip_tb_XY_Y_scale_KeyDown);
            // 
            // skaliereXUmToolStripMenuItem
            // 
            this.skaliereXUmToolStripMenuItem.AutoToolTip = true;
            this.skaliereXUmToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStrip_tb_X_scale});
            this.skaliereXUmToolStripMenuItem.Name = "skaliereXUmToolStripMenuItem";
            resources.ApplyResources(this.skaliereXUmToolStripMenuItem, "skaliereXUmToolStripMenuItem");
            // 
            // toolStrip_tb_X_scale
            // 
            resources.ApplyResources(this.toolStrip_tb_X_scale, "toolStrip_tb_X_scale");
            this.toolStrip_tb_X_scale.Name = "toolStrip_tb_X_scale";
            this.toolStrip_tb_X_scale.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ToolStrip_tb_X_scale_KeyDown);
            // 
            // skaliereAufXUnitsToolStripMenuItem
            // 
            this.skaliereAufXUnitsToolStripMenuItem.AutoToolTip = true;
            this.skaliereAufXUnitsToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control;
            this.skaliereAufXUnitsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStrip_tb_X_X_scale});
            this.skaliereAufXUnitsToolStripMenuItem.Name = "skaliereAufXUnitsToolStripMenuItem";
            resources.ApplyResources(this.skaliereAufXUnitsToolStripMenuItem, "skaliereAufXUnitsToolStripMenuItem");
            // 
            // toolStrip_tb_X_X_scale
            // 
            resources.ApplyResources(this.toolStrip_tb_X_X_scale, "toolStrip_tb_X_X_scale");
            this.toolStrip_tb_X_X_scale.Name = "toolStrip_tb_X_X_scale";
            this.toolStrip_tb_X_X_scale.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ToolStrip_tb_X_X_scale_KeyDown);
            // 
            // skaliereYUmToolStripMenuItem
            // 
            this.skaliereYUmToolStripMenuItem.AutoToolTip = true;
            this.skaliereYUmToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStrip_tb_Y_scale});
            this.skaliereYUmToolStripMenuItem.Name = "skaliereYUmToolStripMenuItem";
            resources.ApplyResources(this.skaliereYUmToolStripMenuItem, "skaliereYUmToolStripMenuItem");
            // 
            // toolStrip_tb_Y_scale
            // 
            resources.ApplyResources(this.toolStrip_tb_Y_scale, "toolStrip_tb_Y_scale");
            this.toolStrip_tb_Y_scale.Name = "toolStrip_tb_Y_scale";
            this.toolStrip_tb_Y_scale.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ToolStrip_tb_Y_scale_KeyDown);
            // 
            // skaliereAufYUnitsToolStripMenuItem
            // 
            this.skaliereAufYUnitsToolStripMenuItem.AutoToolTip = true;
            this.skaliereAufYUnitsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStrip_tb_Y_Y_scale});
            this.skaliereAufYUnitsToolStripMenuItem.Name = "skaliereAufYUnitsToolStripMenuItem";
            resources.ApplyResources(this.skaliereAufYUnitsToolStripMenuItem, "skaliereAufYUnitsToolStripMenuItem");
            // 
            // toolStrip_tb_Y_Y_scale
            // 
            resources.ApplyResources(this.toolStrip_tb_Y_Y_scale, "toolStrip_tb_Y_Y_scale");
            this.toolStrip_tb_Y_Y_scale.Name = "toolStrip_tb_Y_Y_scale";
            this.toolStrip_tb_Y_Y_scale.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ToolStrip_tb_Y_Y_scale_KeyDown);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            resources.ApplyResources(this.toolStripSeparator6, "toolStripSeparator6");
            // 
            // rotaryDimaeterToolStripMenuItem
            // 
            this.rotaryDimaeterToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStrip_tb_rotary_diameter});
            this.rotaryDimaeterToolStripMenuItem.Name = "rotaryDimaeterToolStripMenuItem";
            resources.ApplyResources(this.rotaryDimaeterToolStripMenuItem, "rotaryDimaeterToolStripMenuItem");
            // 
            // toolStrip_tb_rotary_diameter
            // 
            resources.ApplyResources(this.toolStrip_tb_rotary_diameter, "toolStrip_tb_rotary_diameter");
            this.toolStrip_tb_rotary_diameter.Name = "toolStrip_tb_rotary_diameter";
            this.toolStrip_tb_rotary_diameter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ToolStrip_tb_rotary_diameter_KeyDown);
            // 
            // skaliereXAufDrehachseToolStripMenuItem
            // 
            this.skaliereXAufDrehachseToolStripMenuItem.AutoToolTip = true;
            this.skaliereXAufDrehachseToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStrip_tb_X_A_scale});
            this.skaliereXAufDrehachseToolStripMenuItem.Name = "skaliereXAufDrehachseToolStripMenuItem";
            resources.ApplyResources(this.skaliereXAufDrehachseToolStripMenuItem, "skaliereXAufDrehachseToolStripMenuItem");
            // 
            // toolStrip_tb_X_A_scale
            // 
            resources.ApplyResources(this.toolStrip_tb_X_A_scale, "toolStrip_tb_X_A_scale");
            this.toolStrip_tb_X_A_scale.Name = "toolStrip_tb_X_A_scale";
            this.toolStrip_tb_X_A_scale.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ToolStrip_tb_X_A_scale_KeyDown);
            // 
            // skaliereYAufDrehachseToolStripMenuItem
            // 
            this.skaliereYAufDrehachseToolStripMenuItem.AutoToolTip = true;
            this.skaliereYAufDrehachseToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStrip_tb_Y_A_scale});
            this.skaliereYAufDrehachseToolStripMenuItem.Name = "skaliereYAufDrehachseToolStripMenuItem";
            resources.ApplyResources(this.skaliereYAufDrehachseToolStripMenuItem, "skaliereYAufDrehachseToolStripMenuItem");
            // 
            // toolStrip_tb_Y_A_scale
            // 
            resources.ApplyResources(this.toolStrip_tb_Y_A_scale, "toolStrip_tb_Y_A_scale");
            this.toolStrip_tb_Y_A_scale.Name = "toolStrip_tb_Y_A_scale";
            this.toolStrip_tb_Y_A_scale.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ToolStrip_tb_Y_A_scale_KeyDown);
            // 
            // toolStripSeparator15
            // 
            this.toolStripSeparator15.Name = "toolStripSeparator15";
            resources.ApplyResources(this.toolStripSeparator15, "toolStripSeparator15");
            // 
            // toolStrip_RadiusComp
            // 
            this.toolStrip_RadiusComp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStrip_tBRadiusCompValue});
            this.toolStrip_RadiusComp.Name = "toolStrip_RadiusComp";
            resources.ApplyResources(this.toolStrip_RadiusComp, "toolStrip_RadiusComp");
            // 
            // toolStrip_tBRadiusCompValue
            // 
            resources.ApplyResources(this.toolStrip_tBRadiusCompValue, "toolStrip_tBRadiusCompValue");
            this.toolStrip_tBRadiusCompValue.Name = "toolStrip_tBRadiusCompValue";
            this.toolStrip_tBRadiusCompValue.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ToolStrip_tBRadiusCompValue_KeyDown);
            // 
            // ersetzteG23DurchLinienToolStripMenuItem
            // 
            this.ersetzteG23DurchLinienToolStripMenuItem.Name = "ersetzteG23DurchLinienToolStripMenuItem";
            resources.ApplyResources(this.ersetzteG23DurchLinienToolStripMenuItem, "ersetzteG23DurchLinienToolStripMenuItem");
            this.ersetzteG23DurchLinienToolStripMenuItem.Click += new System.EventHandler(this.ErsetzteG23DurchLinienToolStripMenuItem_Click);
            // 
            // convertToPolarCoordinatesToolStripMenuItem
            // 
            this.convertToPolarCoordinatesToolStripMenuItem.Name = "convertToPolarCoordinatesToolStripMenuItem";
            resources.ApplyResources(this.convertToPolarCoordinatesToolStripMenuItem, "convertToPolarCoordinatesToolStripMenuItem");
            this.convertToPolarCoordinatesToolStripMenuItem.Click += new System.EventHandler(this.ConvertToPolarCoordinatesToolStripMenuItem_Click);
            // 
            // convertZToSspindleSpeedToolStripMenuItem
            // 
            this.convertZToSspindleSpeedToolStripMenuItem.Name = "convertZToSspindleSpeedToolStripMenuItem";
            resources.ApplyResources(this.convertZToSspindleSpeedToolStripMenuItem, "convertZToSspindleSpeedToolStripMenuItem");
            this.convertZToSspindleSpeedToolStripMenuItem.Click += new System.EventHandler(this.ConvertZToSspindleSpeedToolStripMenuItem_Click);
            // 
            // removeAnyZMoveToolStripMenuItem
            // 
            this.removeAnyZMoveToolStripMenuItem.Name = "removeAnyZMoveToolStripMenuItem";
            resources.ApplyResources(this.removeAnyZMoveToolStripMenuItem, "removeAnyZMoveToolStripMenuItem");
            this.removeAnyZMoveToolStripMenuItem.Click += new System.EventHandler(this.RemoveAnyZMoveToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripViewRuler,
            this.toolStripViewInfo,
            this.toolStripViewPenUp,
            this.toolStripViewMachineFix,
            this.toolStripViewMachine,
            this.toolStripViewDimension,
            this.toolStripViewTool,
            this.toolStripViewBackground});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            resources.ApplyResources(this.viewToolStripMenuItem, "viewToolStripMenuItem");
            // 
            // toolStripViewRuler
            // 
            this.toolStripViewRuler.Checked = global::GrblPlotter.Properties.Settings.Default.gui2DRulerShow;
            this.toolStripViewRuler.CheckOnClick = true;
            this.toolStripViewRuler.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripViewRuler.Name = "toolStripViewRuler";
            resources.ApplyResources(this.toolStripViewRuler, "toolStripViewRuler");
            this.toolStripViewRuler.Click += new System.EventHandler(this.UpdatePathDisplay);
            // 
            // toolStripViewInfo
            // 
            this.toolStripViewInfo.Checked = global::GrblPlotter.Properties.Settings.Default.gui2DInfoShow;
            this.toolStripViewInfo.CheckOnClick = true;
            this.toolStripViewInfo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripViewInfo.Name = "toolStripViewInfo";
            resources.ApplyResources(this.toolStripViewInfo, "toolStripViewInfo");
            this.toolStripViewInfo.Click += new System.EventHandler(this.UpdatePathDisplay);
            // 
            // toolStripViewPenUp
            // 
            this.toolStripViewPenUp.Checked = global::GrblPlotter.Properties.Settings.Default.gui2DPenUpShow;
            this.toolStripViewPenUp.CheckOnClick = true;
            this.toolStripViewPenUp.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripViewPenUp.Name = "toolStripViewPenUp";
            resources.ApplyResources(this.toolStripViewPenUp, "toolStripViewPenUp");
            this.toolStripViewPenUp.Click += new System.EventHandler(this.UpdatePathDisplay);
            // 
            // toolStripViewMachineFix
            // 
            this.toolStripViewMachineFix.CheckOnClick = true;
            this.toolStripViewMachineFix.Name = "toolStripViewMachineFix";
            resources.ApplyResources(this.toolStripViewMachineFix, "toolStripViewMachineFix");
            this.toolStripViewMachineFix.Click += new System.EventHandler(this.UpdatePathDisplay);
            // 
            // toolStripViewMachine
            // 
            this.toolStripViewMachine.Checked = true;
            this.toolStripViewMachine.CheckOnClick = true;
            this.toolStripViewMachine.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripViewMachine.Name = "toolStripViewMachine";
            resources.ApplyResources(this.toolStripViewMachine, "toolStripViewMachine");
            this.toolStripViewMachine.Click += new System.EventHandler(this.UpdatePathDisplay);
            // 
            // toolStripViewDimension
            // 
            this.toolStripViewDimension.Checked = true;
            this.toolStripViewDimension.CheckOnClick = true;
            this.toolStripViewDimension.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripViewDimension.Name = "toolStripViewDimension";
            resources.ApplyResources(this.toolStripViewDimension, "toolStripViewDimension");
            this.toolStripViewDimension.Click += new System.EventHandler(this.UpdatePathDisplay);
            // 
            // toolStripViewTool
            // 
            this.toolStripViewTool.Checked = global::GrblPlotter.Properties.Settings.Default.gui2DToolTableShow;
            this.toolStripViewTool.CheckOnClick = true;
            this.toolStripViewTool.Name = "toolStripViewTool";
            resources.ApplyResources(this.toolStripViewTool, "toolStripViewTool");
            this.toolStripViewTool.Click += new System.EventHandler(this.UpdatePathDisplay);
            // 
            // toolStripViewBackground
            // 
            this.toolStripViewBackground.Checked = global::GrblPlotter.Properties.Settings.Default.guiBackgroundShow;
            this.toolStripViewBackground.CheckOnClick = true;
            this.toolStripViewBackground.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripViewBackground.Name = "toolStripViewBackground";
            resources.ApplyResources(this.toolStripViewBackground, "toolStripViewBackground");
            this.toolStripViewBackground.Click += new System.EventHandler(this.UpdatePathDisplay);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            resources.ApplyResources(this.aboutToolStripMenuItem, "aboutToolStripMenuItem");
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItem_Click);
            // 
            // logToolStripMenuItem
            // 
            this.logToolStripMenuItem.Name = "logToolStripMenuItem";
            resources.ApplyResources(this.logToolStripMenuItem, "logToolStripMenuItem");
            // 
            // MainTimer
            // 
            this.MainTimer.Enabled = true;
            this.MainTimer.Interval = 500;
            this.MainTimer.Tick += new System.EventHandler(this.MainTimer_Tick);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel0,
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2});
            resources.ApplyResources(this.statusStrip1, "statusStrip1");
            this.statusStrip1.Name = "statusStrip1";
            // 
            // toolStripStatusLabel0
            // 
            this.toolStripStatusLabel0.AutoToolTip = true;
            this.toolStripStatusLabel0.Name = "toolStripStatusLabel0";
            resources.ApplyResources(this.toolStripStatusLabel0, "toolStripStatusLabel0");
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.AutoToolTip = true;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            resources.ApplyResources(this.toolStripStatusLabel1, "toolStripStatusLabel1");
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.AutoToolTip = true;
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            resources.ApplyResources(this.toolStripStatusLabel2, "toolStripStatusLabel2");
            // 
            // SplashScreenTimer
            // 
            this.SplashScreenTimer.Interval = 1500;
            this.SplashScreenTimer.Tick += new System.EventHandler(this.SplashScreenTimer_Tick);
            // 
            // loadTimer
            // 
            this.loadTimer.Interval = 200;
            this.loadTimer.Tick += new System.EventHandler(this.LoadTimer_Tick);
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Opacity = 0D;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.toolTip1.SetToolTip(this, resources.GetString("$this.ToolTip"));
            this.Activated += new System.EventHandler(this.MainForm_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResizeEnd += new System.EventHandler(this.MainForm_Resize);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.MainForm_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.MainForm_DragEnter);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyUp);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.MainForm_PreviewKeyDown);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tLPLinks.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fCTBCode)).EndInit();
            this.cmsFCTB.ResumeLayout(false);
            this.grp1.ResumeLayout(false);
            this.grp1.PerformLayout();
            this.gBoxDimension.ResumeLayout(false);
            this.gBoxDimension.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.tLPRechts.ResumeLayout(false);
            this.tLPRechtsUnten.ResumeLayout(false);
            this.tLPRechtsUnten.PerformLayout();
            this.tLPMitteUnten.ResumeLayout(false);
            this.tLPMitteUnten.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.cmsPictureBox.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.Timer MainTimer;
        private System.Windows.Forms.GroupBox grp1;
        private System.Windows.Forms.Button btnStreamStart;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label lblRemaining;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ContextMenuStrip cmsFCTB;
        private System.Windows.Forms.ToolStripMenuItem cmsCodeSelect;
        private System.Windows.Forms.ToolStripMenuItem cmsCodeCopy;
        private System.Windows.Forms.ToolStripMenuItem cmsCodeSendLine;
        private System.Windows.Forms.ToolStripMenuItem cmsCodePaste;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TableLayoutPanel tLPLinks;
        private System.Windows.Forms.TableLayoutPanel tLPRechts;
        private System.Windows.Forms.TableLayoutPanel tLPRechtsUnten;
        private FastColoredTextBoxNS.FastColoredTextBox fCTBCode;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tLPMitteUnten;
        private System.Windows.Forms.TextBox tBURL;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Button btnStreamStop;
        private System.Windows.Forms.ContextMenuStrip cmsPictureBox;
        private System.Windows.Forms.ToolStripMenuItem cmsPicBoxMarkFirstPos;
        private System.Windows.Forms.ToolStripMenuItem cmsPicBoxDeletePath;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem deletenotMarkToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem createGCodeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem textWizzardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem imageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createSimpleShapesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveMachineParametersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadMachineParametersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem LanguageToolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem englishToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deutschToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gCodeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mirrorXToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mirrorYToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem rotate90ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rotate90ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem rotateFreeToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox toolStrip_tb_rotate;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem sToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox toolStrip_tb_XY_scale;
        private System.Windows.Forms.ToolStripMenuItem skalierenXYToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox toolStrip_tb_XY_X_scale;
        private System.Windows.Forms.ToolStripMenuItem skalierenXYUmXUnitsZuErreichenToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox toolStrip_tb_XY_Y_scale;
        private System.Windows.Forms.ToolStripMenuItem skaliereXUmToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox toolStrip_tb_X_scale;
        private System.Windows.Forms.ToolStripMenuItem skaliereAufXUnitsToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox toolStrip_tb_X_X_scale;
        private System.Windows.Forms.ToolStripMenuItem skaliereXAufDrehachseToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox toolStrip_tb_X_A_scale;
        private System.Windows.Forms.ToolStripMenuItem skaliereYUmToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox toolStrip_tb_Y_scale;
        private System.Windows.Forms.ToolStripMenuItem skaliereAufYUnitsToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox toolStrip_tb_Y_Y_scale;
        private System.Windows.Forms.ToolStripMenuItem skaliereYAufDrehachseToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox toolStrip_tb_Y_A_scale;
        private System.Windows.Forms.TextBox lbDimension;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton rBOrigin9;
        private System.Windows.Forms.RadioButton rBOrigin8;
        private System.Windows.Forms.RadioButton rBOrigin7;
        private System.Windows.Forms.RadioButton rBOrigin6;
        private System.Windows.Forms.RadioButton rBOrigin5;
        private System.Windows.Forms.RadioButton rBOrigin4;
        private System.Windows.Forms.RadioButton rBOrigin3;
        private System.Windows.Forms.RadioButton rBOrigin2;
        private System.Windows.Forms.RadioButton rBOrigin1;
        private System.Windows.Forms.Button btnOffsetApply;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbOffsetY;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbOffsetX;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem rotaryDimaeterToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox toolStrip_tb_rotary_diameter;
        private System.Windows.Forms.ToolStripMenuItem setupToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem ersetzteG23DurchLinienToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cmsPicBoxResetZooming;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripMenuItem cmsPicBoxPasteFromClipboard;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripMenuItem cmsCommentOut;
        private System.Windows.Forms.Timer gamePadTimer;
        private System.Windows.Forms.ToolStripMenuItem cmsPicBoxMoveToMarkedPosition;
        private System.Windows.Forms.ToolStripMenuItem cmsPicBoxReloadFile;
        private System.Windows.Forms.Button btnLimitExceed;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripViewMachine;
        private System.Windows.Forms.ToolStripMenuItem toolStripViewTool;
        private System.Windows.Forms.ToolStripMenuItem cmsPicBoxSetGCodeAsBackground;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private System.Windows.Forms.ToolStripMenuItem cmsPicBoxClearBackground;
        private System.Windows.Forms.ToolStripMenuItem toolStripViewBackground;
        private System.Windows.Forms.ToolStripMenuItem logToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripViewMachineFix;
        private System.Windows.Forms.ToolStripMenuItem cmsPicBoxZeroXYAtMarkedPosition;
        private System.Windows.Forms.ToolStripMenuItem removeAnyZMoveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cmsUpdate2DView;
        private System.Windows.Forms.ToolStripMenuItem cmsEditorHotkeys;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator11;
        private System.Windows.Forms.ToolStripMenuItem cmsReplaceDialog;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator12;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator14;
        private System.Windows.Forms.ToolStripMenuItem cmsFindDialog;
        private System.Windows.Forms.ToolStripMenuItem mirrorRotaryToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator15;
        private System.Windows.Forms.ToolStripMenuItem convertZToSspindleSpeedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rotate180ToolStripMenuItem;
        private System.Windows.Forms.GroupBox gBoxDimension;
        private System.Windows.Forms.ToolStripMenuItem cmsPicBoxCropSelectedPath;
        private System.Windows.Forms.ToolStripMenuItem unDoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator16;
        private System.Windows.Forms.ToolStripMenuItem unDo2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator17;
        private System.Windows.Forms.ToolStripMenuItem toolStrip_RadiusComp;
        private System.Windows.Forms.ToolStripTextBox toolStrip_tBRadiusCompValue;
        private System.Windows.Forms.ToolStripMenuItem cmsCodePasteSpecial1;
        private System.Windows.Forms.ToolStripMenuItem cmsCodePasteSpecial2;
        private System.Windows.Forms.ToolStripMenuItem pусскийToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem franzToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chinesischToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripViewPenUp;
        private System.Windows.Forms.ToolStripMenuItem cmsPicBoxMoveSelectedPathInCode;
        private System.Windows.Forms.ToolStripMenuItem toolStripViewRuler;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator19;
        private System.Windows.Forms.ToolStripMenuItem cmsCodeBlocksFold;
        private System.Windows.Forms.ToolStripMenuItem foldCodeBlocks1stLevelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem foldCodeBlocks2ndLevelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem foldCodeBlocks3rdLevelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem expandCodeBlocksToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripViewInfo;
        private System.Windows.Forms.ToolStripMenuItem portuguêsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem arabischToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem japanischToolStripMenuItem;
        private System.Windows.Forms.Timer simulationTimer;
        private System.Windows.Forms.ToolStripMenuItem startExtensionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripViewDimension;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel0;
        private System.Windows.Forms.ToolStripMenuItem cmsEditMode;
        private System.Windows.Forms.ToolStripMenuItem cmsPicBoxMoveGraphicsOrigin;
        private System.Windows.Forms.ToolStripMenuItem cmsCodeBlocksMove;
        private System.Windows.Forms.ToolStripMenuItem cmsFCTBMoveSelectedCodeBlockMostUp;
        private System.Windows.Forms.ToolStripMenuItem cmsFCTBMoveSelectedCodeBlockUp;
        private System.Windows.Forms.ToolStripMenuItem cmsFCTBMoveSelectedCodeBlockDown;
        private System.Windows.Forms.ToolStripMenuItem cmsFCTBMoveSelectedCodeBlockMostDown;
        private System.Windows.Forms.ToolStripMenuItem cmsCodeBlocksRemoveAll;
        private System.Windows.Forms.ToolStripMenuItem cmsCodeBlocksSort;
        private System.Windows.Forms.ToolStripMenuItem unDo3ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator13;
        private System.Windows.Forms.ToolStripMenuItem cmsCodeBlocksRemoveGroup;
        private System.Windows.Forms.ToolStripMenuItem cmsCodeBlocksSortById;
        private System.Windows.Forms.ToolStripMenuItem cmsCodeBlocksSortReverse;
        private System.Windows.Forms.ToolStripMenuItem cmsCodeBlocksSortByGeometry;
        private System.Windows.Forms.ToolStripMenuItem cmsCodeBlocksSortByToolNr;
        private System.Windows.Forms.ToolStripMenuItem cmsCodeBlocksSortByToolName;
        private System.Windows.Forms.ToolStripMenuItem cmsCodeBlocksSortByColor;
        private System.Windows.Forms.ToolStripMenuItem cmsCodeBlocksSortByCodeSize;
        private System.Windows.Forms.ToolStripMenuItem cmsCodeBlocksSortByCodeArea;
        private System.Windows.Forms.Timer SplashScreenTimer;
        private System.Windows.Forms.ToolStripMenuItem cmsCodeBlocksSortByDistance;
        private System.Windows.Forms.ToolStripMenuItem copyContentTroClipboardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createBarcodeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cmsPicBoxReverseSelectedPath;
        private System.Windows.Forms.ToolStripMenuItem sortByLayerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sortByPenWidthToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sortByTypeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Timer loadTimer;
        private System.Windows.Forms.ToolStripMenuItem createJogPathToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cmsPicBoxRotateSelectedPath;
        private System.Windows.Forms.ToolStripMenuItem czechToolStripMenuItem;
        private System.Windows.Forms.CheckBox CbAddGraphic;
        private System.Windows.Forms.ToolStripMenuItem cmsPicBoxDuplicatePath;
        private System.Windows.Forms.ToolStripMenuItem cmsPicBoxShowProperties;
        private System.Windows.Forms.ToolStripMenuItem toggleBlockExpansionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem italianoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem türkToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem PolishToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cmsPicBoxClearWorkspace;
        private System.Windows.Forms.ToolStripMenuItem cmsPicBoxReloadFile2;
        private System.Windows.Forms.ToolStripMenuItem convertToPolarCoordinatesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem applyLastTransformToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wireCutterToolStripMenuItem;
        private System.Windows.Forms.Button btnExpGcode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox serverIP;
        private System.Windows.Forms.TextBox tbFile;
        private System.Windows.Forms.Button btnOpenFile;
    }
}


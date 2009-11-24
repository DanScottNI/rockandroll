namespace RockAndRoll
{
    partial class frmPreferences
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnBeamdownColour = new System.Windows.Forms.Button();
            this.picBeamdownColour = new System.Windows.Forms.PictureBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnSpecObjColour = new System.Windows.Forms.Button();
            this.btnEnemyColour = new System.Windows.Forms.Button();
            this.picEnemyColour = new System.Windows.Forms.PictureBox();
            this.picSpecObjColour = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnMiddleColour = new System.Windows.Forms.Button();
            this.btnLeftColour = new System.Windows.Forms.Button();
            this.picLeftColour = new System.Windows.Forms.PictureBox();
            this.picMiddleColour = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.clrDialog = new System.Windows.Forms.ColorDialog();
            this.chkNoEditsOutsideLevel = new System.Windows.Forms.CheckBox();
            this.chkUseBackups = new System.Windows.Forms.CheckBox();
            this.chkGotoObjMode = new System.Windows.Forms.CheckBox();
            this.chkDisableDeleteEnemy = new System.Windows.Forms.CheckBox();
            this.grpMapperChecks = new System.Windows.Forms.GroupBox();
            this.rbMapperChecksDontLoad = new System.Windows.Forms.RadioButton();
            this.rbMapperChecksPrompt = new System.Windows.Forms.RadioButton();
            this.rbMapperChecksIgnore = new System.Windows.Forms.RadioButton();
            this.cbDataFile = new System.Windows.Forms.ComboBox();
            this.cbPalette = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtUnmodifiedROM = new System.Windows.Forms.TextBox();
            this.btnBrowseUnmodified = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.txtEmuFilename = new System.Windows.Forms.TextBox();
            this.btnBrowseEmulator = new System.Windows.Forms.Button();
            this.grpEmulatorFilenames = new System.Windows.Forms.GroupBox();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.radioButton5 = new System.Windows.Forms.RadioButton();
            this.radioButton6 = new System.Windows.Forms.RadioButton();
            this.chkDisplayEmuSaveWarning = new System.Windows.Forms.CheckBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBeamdownColour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEnemyColour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSpecObjColour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLeftColour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMiddleColour)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.grpMapperChecks.SuspendLayout();
            this.grpEmulatorFilenames.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(545, 267);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.cbPalette);
            this.tabPage1.Controls.Add(this.cbDataFile);
            this.tabPage1.Controls.Add(this.grpMapperChecks);
            this.tabPage1.Controls.Add(this.chkDisableDeleteEnemy);
            this.tabPage1.Controls.Add(this.chkGotoObjMode);
            this.tabPage1.Controls.Add(this.chkUseBackups);
            this.tabPage1.Controls.Add(this.chkNoEditsOutsideLevel);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(537, 241);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "General";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Palette:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Default Data File:";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnBeamdownColour);
            this.tabPage2.Controls.Add(this.picBeamdownColour);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.btnSpecObjColour);
            this.tabPage2.Controls.Add(this.btnEnemyColour);
            this.tabPage2.Controls.Add(this.picEnemyColour);
            this.tabPage2.Controls.Add(this.picSpecObjColour);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.btnMiddleColour);
            this.tabPage2.Controls.Add(this.btnLeftColour);
            this.tabPage2.Controls.Add(this.picLeftColour);
            this.tabPage2.Controls.Add(this.picMiddleColour);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(537, 241);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Display Options";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnBeamdownColour
            // 
            this.btnBeamdownColour.Location = new System.Drawing.Point(181, 121);
            this.btnBeamdownColour.Name = "btnBeamdownColour";
            this.btnBeamdownColour.Size = new System.Drawing.Size(30, 20);
            this.btnBeamdownColour.TabIndex = 9;
            this.btnBeamdownColour.Text = "...";
            this.btnBeamdownColour.UseVisualStyleBackColor = true;
            this.btnBeamdownColour.Click += new System.EventHandler(this.btnBeamdownColour_Click);
            // 
            // picBeamdownColour
            // 
            this.picBeamdownColour.Location = new System.Drawing.Point(150, 121);
            this.picBeamdownColour.Name = "picBeamdownColour";
            this.picBeamdownColour.Size = new System.Drawing.Size(25, 20);
            this.picBeamdownColour.TabIndex = 15;
            this.picBeamdownColour.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 121);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(124, 13);
            this.label8.TabIndex = 8;
            this.label8.Text = "Beamdown Point Colour:";
            // 
            // btnSpecObjColour
            // 
            this.btnSpecObjColour.Location = new System.Drawing.Point(181, 95);
            this.btnSpecObjColour.Name = "btnSpecObjColour";
            this.btnSpecObjColour.Size = new System.Drawing.Size(30, 20);
            this.btnSpecObjColour.TabIndex = 7;
            this.btnSpecObjColour.Text = "...";
            this.btnSpecObjColour.UseVisualStyleBackColor = true;
            this.btnSpecObjColour.Click += new System.EventHandler(this.btnSpecObjColour_Click);
            // 
            // btnEnemyColour
            // 
            this.btnEnemyColour.Location = new System.Drawing.Point(181, 68);
            this.btnEnemyColour.Name = "btnEnemyColour";
            this.btnEnemyColour.Size = new System.Drawing.Size(30, 20);
            this.btnEnemyColour.TabIndex = 5;
            this.btnEnemyColour.Text = "...";
            this.btnEnemyColour.UseVisualStyleBackColor = true;
            this.btnEnemyColour.Click += new System.EventHandler(this.btnEnemyColour_Click);
            // 
            // picEnemyColour
            // 
            this.picEnemyColour.Location = new System.Drawing.Point(150, 68);
            this.picEnemyColour.Name = "picEnemyColour";
            this.picEnemyColour.Size = new System.Drawing.Size(25, 20);
            this.picEnemyColour.TabIndex = 9;
            this.picEnemyColour.TabStop = false;
            // 
            // picSpecObjColour
            // 
            this.picSpecObjColour.Location = new System.Drawing.Point(150, 95);
            this.picSpecObjColour.Name = "picSpecObjColour";
            this.picSpecObjColour.Size = new System.Drawing.Size(25, 20);
            this.picSpecObjColour.TabIndex = 8;
            this.picSpecObjColour.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 95);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(113, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Special Object Colour:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 68);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Enemy Colour:";
            // 
            // btnMiddleColour
            // 
            this.btnMiddleColour.Location = new System.Drawing.Point(181, 43);
            this.btnMiddleColour.Name = "btnMiddleColour";
            this.btnMiddleColour.Size = new System.Drawing.Size(30, 20);
            this.btnMiddleColour.TabIndex = 3;
            this.btnMiddleColour.Text = "...";
            this.btnMiddleColour.UseVisualStyleBackColor = true;
            this.btnMiddleColour.Click += new System.EventHandler(this.btnMiddleColour_Click);
            // 
            // btnLeftColour
            // 
            this.btnLeftColour.Location = new System.Drawing.Point(181, 16);
            this.btnLeftColour.Name = "btnLeftColour";
            this.btnLeftColour.Size = new System.Drawing.Size(30, 20);
            this.btnLeftColour.TabIndex = 1;
            this.btnLeftColour.Text = "...";
            this.btnLeftColour.UseVisualStyleBackColor = true;
            this.btnLeftColour.Click += new System.EventHandler(this.btnLeftColour_Click);
            // 
            // picLeftColour
            // 
            this.picLeftColour.Location = new System.Drawing.Point(150, 16);
            this.picLeftColour.Name = "picLeftColour";
            this.picLeftColour.Size = new System.Drawing.Size(25, 20);
            this.picLeftColour.TabIndex = 3;
            this.picLeftColour.TabStop = false;
            // 
            // picMiddleColour
            // 
            this.picMiddleColour.Location = new System.Drawing.Point(150, 43);
            this.picMiddleColour.Name = "picMiddleColour";
            this.picMiddleColour.Size = new System.Drawing.Size(25, 20);
            this.picMiddleColour.TabIndex = 2;
            this.picMiddleColour.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(138, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Middle Selected Tile Colour:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Left Selected Tile Colour:";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.chkDisplayEmuSaveWarning);
            this.tabPage3.Controls.Add(this.grpEmulatorFilenames);
            this.tabPage3.Controls.Add(this.btnBrowseEmulator);
            this.tabPage3.Controls.Add(this.txtEmuFilename);
            this.tabPage3.Controls.Add(this.label9);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(537, 241);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Emulator Settings";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.btnBrowseUnmodified);
            this.tabPage4.Controls.Add(this.txtUnmodifiedROM);
            this.tabPage4.Controls.Add(this.label7);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(537, 241);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Patching";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(482, 285);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(401, 285);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // chkNoEditsOutsideLevel
            // 
            this.chkNoEditsOutsideLevel.AutoSize = true;
            this.chkNoEditsOutsideLevel.Location = new System.Drawing.Point(9, 94);
            this.chkNoEditsOutsideLevel.Name = "chkNoEditsOutsideLevel";
            this.chkNoEditsOutsideLevel.Size = new System.Drawing.Size(239, 17);
            this.chkNoEditsOutsideLevel.TabIndex = 2;
            this.chkNoEditsOutsideLevel.Text = "Don\'t allow edits on screens not part of level";
            this.chkNoEditsOutsideLevel.UseVisualStyleBackColor = true;
            // 
            // chkUseBackups
            // 
            this.chkUseBackups.AutoSize = true;
            this.chkUseBackups.Location = new System.Drawing.Point(9, 71);
            this.chkUseBackups.Name = "chkUseBackups";
            this.chkUseBackups.Size = new System.Drawing.Size(150, 17);
            this.chkUseBackups.TabIndex = 3;
            this.chkUseBackups.Text = "Backup Files When Saving";
            this.chkUseBackups.UseVisualStyleBackColor = true;
            // 
            // chkGotoObjMode
            // 
            this.chkGotoObjMode.AutoSize = true;
            this.chkGotoObjMode.Location = new System.Drawing.Point(9, 140);
            this.chkGotoObjMode.Name = "chkGotoObjMode";
            this.chkGotoObjMode.Size = new System.Drawing.Size(340, 17);
            this.chkGotoObjMode.TabIndex = 5;
            this.chkGotoObjMode.Text = "Automatically go to object mode, when adding new enemy/object";
            this.chkGotoObjMode.UseVisualStyleBackColor = true;
            // 
            // chkDisableDeleteEnemy
            // 
            this.chkDisableDeleteEnemy.AutoSize = true;
            this.chkDisableDeleteEnemy.Location = new System.Drawing.Point(9, 117);
            this.chkDisableDeleteEnemy.Name = "chkDisableDeleteEnemy";
            this.chkDisableDeleteEnemy.Size = new System.Drawing.Size(166, 17);
            this.chkDisableDeleteEnemy.TabIndex = 6;
            this.chkDisableDeleteEnemy.Text = "Disable Delete Enemy Prompt";
            this.chkDisableDeleteEnemy.UseVisualStyleBackColor = true;
            // 
            // grpMapperChecks
            // 
            this.grpMapperChecks.Controls.Add(this.rbMapperChecksIgnore);
            this.grpMapperChecks.Controls.Add(this.rbMapperChecksPrompt);
            this.grpMapperChecks.Controls.Add(this.rbMapperChecksDontLoad);
            this.grpMapperChecks.Location = new System.Drawing.Point(9, 163);
            this.grpMapperChecks.Name = "grpMapperChecks";
            this.grpMapperChecks.Size = new System.Drawing.Size(522, 53);
            this.grpMapperChecks.TabIndex = 7;
            this.grpMapperChecks.TabStop = false;
            this.grpMapperChecks.Text = "When Mapper and PRG counts don\'t match:";
            // 
            // rbMapperChecksDontLoad
            // 
            this.rbMapperChecksDontLoad.AutoSize = true;
            this.rbMapperChecksDontLoad.Location = new System.Drawing.Point(6, 20);
            this.rbMapperChecksDontLoad.Name = "rbMapperChecksDontLoad";
            this.rbMapperChecksDontLoad.Size = new System.Drawing.Size(99, 17);
            this.rbMapperChecksDontLoad.TabIndex = 0;
            this.rbMapperChecksDontLoad.Text = "Don\'t load ROM";
            this.rbMapperChecksDontLoad.UseVisualStyleBackColor = true;
            // 
            // rbMapperChecksPrompt
            // 
            this.rbMapperChecksPrompt.AutoSize = true;
            this.rbMapperChecksPrompt.Checked = true;
            this.rbMapperChecksPrompt.Location = new System.Drawing.Point(251, 20);
            this.rbMapperChecksPrompt.Name = "rbMapperChecksPrompt";
            this.rbMapperChecksPrompt.Size = new System.Drawing.Size(59, 17);
            this.rbMapperChecksPrompt.TabIndex = 1;
            this.rbMapperChecksPrompt.TabStop = true;
            this.rbMapperChecksPrompt.Text = "Prompt";
            this.rbMapperChecksPrompt.UseVisualStyleBackColor = true;
            // 
            // rbMapperChecksIgnore
            // 
            this.rbMapperChecksIgnore.AutoSize = true;
            this.rbMapperChecksIgnore.Location = new System.Drawing.Point(456, 20);
            this.rbMapperChecksIgnore.Name = "rbMapperChecksIgnore";
            this.rbMapperChecksIgnore.Size = new System.Drawing.Size(57, 17);
            this.rbMapperChecksIgnore.TabIndex = 2;
            this.rbMapperChecksIgnore.Text = "Ignore";
            this.rbMapperChecksIgnore.UseVisualStyleBackColor = true;
            // 
            // cbDataFile
            // 
            this.cbDataFile.FormattingEnabled = true;
            this.cbDataFile.Location = new System.Drawing.Point(103, 16);
            this.cbDataFile.Name = "cbDataFile";
            this.cbDataFile.Size = new System.Drawing.Size(428, 21);
            this.cbDataFile.TabIndex = 8;
            // 
            // cbPalette
            // 
            this.cbPalette.FormattingEnabled = true;
            this.cbPalette.Location = new System.Drawing.Point(103, 44);
            this.cbPalette.Name = "cbPalette";
            this.cbPalette.Size = new System.Drawing.Size(428, 21);
            this.cbPalette.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 15);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Unmodified ROM:";
            // 
            // txtUnmodifiedROM
            // 
            this.txtUnmodifiedROM.Location = new System.Drawing.Point(102, 15);
            this.txtUnmodifiedROM.Name = "txtUnmodifiedROM";
            this.txtUnmodifiedROM.Size = new System.Drawing.Size(379, 21);
            this.txtUnmodifiedROM.TabIndex = 1;
            // 
            // btnBrowseUnmodified
            // 
            this.btnBrowseUnmodified.Location = new System.Drawing.Point(487, 15);
            this.btnBrowseUnmodified.Name = "btnBrowseUnmodified";
            this.btnBrowseUnmodified.Size = new System.Drawing.Size(30, 21);
            this.btnBrowseUnmodified.TabIndex = 2;
            this.btnBrowseUnmodified.Text = "...";
            this.btnBrowseUnmodified.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 13);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(98, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Emulator Filename:";
            // 
            // txtEmuFilename
            // 
            this.txtEmuFilename.Location = new System.Drawing.Point(110, 13);
            this.txtEmuFilename.Name = "txtEmuFilename";
            this.txtEmuFilename.Size = new System.Drawing.Size(382, 21);
            this.txtEmuFilename.TabIndex = 1;
            // 
            // btnBrowseEmulator
            // 
            this.btnBrowseEmulator.Location = new System.Drawing.Point(498, 13);
            this.btnBrowseEmulator.Name = "btnBrowseEmulator";
            this.btnBrowseEmulator.Size = new System.Drawing.Size(30, 21);
            this.btnBrowseEmulator.TabIndex = 3;
            this.btnBrowseEmulator.Text = "...";
            this.btnBrowseEmulator.UseVisualStyleBackColor = true;
            // 
            // grpEmulatorFilenames
            // 
            this.grpEmulatorFilenames.Controls.Add(this.radioButton6);
            this.grpEmulatorFilenames.Controls.Add(this.radioButton5);
            this.grpEmulatorFilenames.Controls.Add(this.radioButton4);
            this.grpEmulatorFilenames.Location = new System.Drawing.Point(9, 40);
            this.grpEmulatorFilenames.Name = "grpEmulatorFilenames";
            this.grpEmulatorFilenames.Size = new System.Drawing.Size(519, 100);
            this.grpEmulatorFilenames.TabIndex = 4;
            this.grpEmulatorFilenames.TabStop = false;
            this.grpEmulatorFilenames.Text = "Emulator Filename Settings";
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Checked = true;
            this.radioButton4.Location = new System.Drawing.Point(6, 66);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(128, 17);
            this.radioButton4.TabIndex = 0;
            this.radioButton4.TabStop = true;
            this.radioButton4.Text = "Surround with quotes";
            this.radioButton4.UseVisualStyleBackColor = true;
            // 
            // radioButton5
            // 
            this.radioButton5.AutoSize = true;
            this.radioButton5.Location = new System.Drawing.Point(6, 43);
            this.radioButton5.Name = "radioButton5";
            this.radioButton5.Size = new System.Drawing.Size(131, 17);
            this.radioButton5.TabIndex = 1;
            this.radioButton5.Text = "Use 8.3 DOS Filename";
            this.radioButton5.UseVisualStyleBackColor = true;
            // 
            // radioButton6
            // 
            this.radioButton6.AutoSize = true;
            this.radioButton6.Location = new System.Drawing.Point(6, 20);
            this.radioButton6.Name = "radioButton6";
            this.radioButton6.Size = new System.Drawing.Size(58, 17);
            this.radioButton6.TabIndex = 2;
            this.radioButton6.Text = "Normal";
            this.radioButton6.UseVisualStyleBackColor = true;
            // 
            // chkDisplayEmuSaveWarning
            // 
            this.chkDisplayEmuSaveWarning.AutoSize = true;
            this.chkDisplayEmuSaveWarning.Location = new System.Drawing.Point(9, 146);
            this.chkDisplayEmuSaveWarning.Name = "chkDisplayEmuSaveWarning";
            this.chkDisplayEmuSaveWarning.Size = new System.Drawing.Size(175, 17);
            this.chkDisplayEmuSaveWarning.TabIndex = 5;
            this.chkDisplayEmuSaveWarning.Text = "Display Emulator Save Warning";
            this.chkDisplayEmuSaveWarning.UseVisualStyleBackColor = true;
            // 
            // frmPreferences
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(567, 320);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPreferences";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Preferences";
            this.Load += new System.EventHandler(this.frmPreferences_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBeamdownColour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEnemyColour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSpecObjColour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLeftColour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMiddleColour)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.grpMapperChecks.ResumeLayout(false);
            this.grpMapperChecks.PerformLayout();
            this.grpEmulatorFilenames.ResumeLayout(false);
            this.grpEmulatorFilenames.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnMiddleColour;
        private System.Windows.Forms.Button btnLeftColour;
        private System.Windows.Forms.PictureBox picLeftColour;
        private System.Windows.Forms.PictureBox picMiddleColour;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.ColorDialog clrDialog;
        private System.Windows.Forms.Button btnBeamdownColour;
        private System.Windows.Forms.PictureBox picBeamdownColour;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnSpecObjColour;
        private System.Windows.Forms.Button btnEnemyColour;
        private System.Windows.Forms.PictureBox picEnemyColour;
        private System.Windows.Forms.PictureBox picSpecObjColour;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbPalette;
        private System.Windows.Forms.ComboBox cbDataFile;
        private System.Windows.Forms.GroupBox grpMapperChecks;
        private System.Windows.Forms.RadioButton rbMapperChecksIgnore;
        private System.Windows.Forms.RadioButton rbMapperChecksPrompt;
        private System.Windows.Forms.RadioButton rbMapperChecksDontLoad;
        private System.Windows.Forms.CheckBox chkDisableDeleteEnemy;
        private System.Windows.Forms.CheckBox chkGotoObjMode;
        private System.Windows.Forms.CheckBox chkUseBackups;
        private System.Windows.Forms.CheckBox chkNoEditsOutsideLevel;
        private System.Windows.Forms.TextBox txtEmuFilename;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnBrowseUnmodified;
        private System.Windows.Forms.TextBox txtUnmodifiedROM;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox chkDisplayEmuSaveWarning;
        private System.Windows.Forms.GroupBox grpEmulatorFilenames;
        private System.Windows.Forms.RadioButton radioButton6;
        private System.Windows.Forms.RadioButton radioButton5;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.Button btnBrowseEmulator;
    }
}
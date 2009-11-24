namespace RockAndRoll
{
    partial class frmPaletteEditor
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
            this.tbcPalettes = new System.Windows.Forms.TabControl();
            this.tabCurrentLevel = new System.Windows.Forms.TabPage();
            this.btnMatchLevelPalettes = new System.Windows.Forms.Button();
            this.lblAfterDoors = new System.Windows.Forms.Label();
            this.lblBeforeDoors = new System.Windows.Forms.Label();
            this.picAfterDoorsBG = new System.Windows.Forms.PictureBox();
            this.picSpr = new System.Windows.Forms.PictureBox();
            this.picBG = new System.Windows.Forms.PictureBox();
            this.tabWeaponPalette = new System.Windows.Forms.TabPage();
            this.btnMatchPalettes = new System.Windows.Forms.Button();
            this.lblCutsman = new System.Windows.Forms.Label();
            this.lblAfterDeath = new System.Windows.Forms.Label();
            this.lblFire = new System.Windows.Forms.Label();
            this.lblM = new System.Windows.Forms.Label();
            this.lblBomb = new System.Windows.Forms.Label();
            this.lblElec = new System.Windows.Forms.Label();
            this.lblGuts = new System.Windows.Forms.Label();
            this.lblIceman = new System.Windows.Forms.Label();
            this.lblNormal = new System.Windows.Forms.Label();
            this.picWM = new System.Windows.Forms.PictureBox();
            this.picWAfterDeath = new System.Windows.Forms.PictureBox();
            this.picWFire = new System.Windows.Forms.PictureBox();
            this.picWElec = new System.Windows.Forms.PictureBox();
            this.picWCuts = new System.Windows.Forms.PictureBox();
            this.picWGuts = new System.Windows.Forms.PictureBox();
            this.picWBomb = new System.Windows.Forms.PictureBox();
            this.picWIce = new System.Windows.Forms.PictureBox();
            this.picWStandard = new System.Windows.Forms.PictureBox();
            this.tabPaletteCycles = new System.Windows.Forms.TabPage();
            this.picPaletteCycling = new System.Windows.Forms.PictureBox();
            this.lblCycleDesc = new System.Windows.Forms.Label();
            this.picNESPal = new System.Windows.Forms.PictureBox();
            this.lbl000F = new System.Windows.Forms.Label();
            this.lbl101F = new System.Windows.Forms.Label();
            this.lbl202F = new System.Windows.Forms.Label();
            this.lbl303F = new System.Windows.Forms.Label();
            this.lblMousePal = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.tbcPalettes.SuspendLayout();
            this.tabCurrentLevel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAfterDoorsBG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSpr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBG)).BeginInit();
            this.tabWeaponPalette.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picWM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWAfterDeath)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWFire)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWElec)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWCuts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWGuts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWBomb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWIce)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWStandard)).BeginInit();
            this.tabPaletteCycles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPaletteCycling)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picNESPal)).BeginInit();
            this.SuspendLayout();
            // 
            // tbcPalettes
            // 
            this.tbcPalettes.Controls.Add(this.tabCurrentLevel);
            this.tbcPalettes.Controls.Add(this.tabWeaponPalette);
            this.tbcPalettes.Controls.Add(this.tabPaletteCycles);
            this.tbcPalettes.Location = new System.Drawing.Point(12, 104);
            this.tbcPalettes.Name = "tbcPalettes";
            this.tbcPalettes.SelectedIndex = 0;
            this.tbcPalettes.Size = new System.Drawing.Size(423, 182);
            this.tbcPalettes.TabIndex = 0;
            // 
            // tabCurrentLevel
            // 
            this.tabCurrentLevel.Controls.Add(this.btnMatchLevelPalettes);
            this.tabCurrentLevel.Controls.Add(this.lblAfterDoors);
            this.tabCurrentLevel.Controls.Add(this.lblBeforeDoors);
            this.tabCurrentLevel.Controls.Add(this.picAfterDoorsBG);
            this.tabCurrentLevel.Controls.Add(this.picSpr);
            this.tabCurrentLevel.Controls.Add(this.picBG);
            this.tabCurrentLevel.Location = new System.Drawing.Point(4, 22);
            this.tabCurrentLevel.Name = "tabCurrentLevel";
            this.tabCurrentLevel.Padding = new System.Windows.Forms.Padding(3);
            this.tabCurrentLevel.Size = new System.Drawing.Size(415, 156);
            this.tabCurrentLevel.TabIndex = 0;
            this.tabCurrentLevel.Text = "Level Palettes";
            this.tabCurrentLevel.UseVisualStyleBackColor = true;
            // 
            // btnMatchLevelPalettes
            // 
            this.btnMatchLevelPalettes.Location = new System.Drawing.Point(275, 125);
            this.btnMatchLevelPalettes.Name = "btnMatchLevelPalettes";
            this.btnMatchLevelPalettes.Size = new System.Drawing.Size(131, 23);
            this.btnMatchLevelPalettes.TabIndex = 14;
            this.btnMatchLevelPalettes.Text = "Match Level Palettes";
            this.btnMatchLevelPalettes.UseVisualStyleBackColor = true;
            // 
            // lblAfterDoors
            // 
            this.lblAfterDoors.AutoSize = true;
            this.lblAfterDoors.Location = new System.Drawing.Point(6, 78);
            this.lblAfterDoors.Name = "lblAfterDoors";
            this.lblAfterDoors.Size = new System.Drawing.Size(63, 13);
            this.lblAfterDoors.TabIndex = 13;
            this.lblAfterDoors.Text = "After Doors";
            // 
            // lblBeforeDoors
            // 
            this.lblBeforeDoors.AutoSize = true;
            this.lblBeforeDoors.Location = new System.Drawing.Point(6, 3);
            this.lblBeforeDoors.Name = "lblBeforeDoors";
            this.lblBeforeDoors.Size = new System.Drawing.Size(70, 13);
            this.lblBeforeDoors.TabIndex = 12;
            this.lblBeforeDoors.Text = "Before Doors";
            // 
            // picAfterDoorsBG
            // 
            this.picAfterDoorsBG.Location = new System.Drawing.Point(6, 94);
            this.picAfterDoorsBG.Name = "picAfterDoorsBG";
            this.picAfterDoorsBG.Size = new System.Drawing.Size(400, 25);
            this.picAfterDoorsBG.TabIndex = 8;
            this.picAfterDoorsBG.TabStop = false;
            // 
            // picSpr
            // 
            this.picSpr.Location = new System.Drawing.Point(6, 50);
            this.picSpr.Name = "picSpr";
            this.picSpr.Size = new System.Drawing.Size(400, 25);
            this.picSpr.TabIndex = 4;
            this.picSpr.TabStop = false;
            // 
            // picBG
            // 
            this.picBG.Location = new System.Drawing.Point(6, 19);
            this.picBG.Name = "picBG";
            this.picBG.Size = new System.Drawing.Size(400, 25);
            this.picBG.TabIndex = 0;
            this.picBG.TabStop = false;
            // 
            // tabWeaponPalette
            // 
            this.tabWeaponPalette.Controls.Add(this.btnMatchPalettes);
            this.tabWeaponPalette.Controls.Add(this.lblCutsman);
            this.tabWeaponPalette.Controls.Add(this.lblAfterDeath);
            this.tabWeaponPalette.Controls.Add(this.lblFire);
            this.tabWeaponPalette.Controls.Add(this.lblM);
            this.tabWeaponPalette.Controls.Add(this.lblBomb);
            this.tabWeaponPalette.Controls.Add(this.lblElec);
            this.tabWeaponPalette.Controls.Add(this.lblGuts);
            this.tabWeaponPalette.Controls.Add(this.lblIceman);
            this.tabWeaponPalette.Controls.Add(this.lblNormal);
            this.tabWeaponPalette.Controls.Add(this.picWM);
            this.tabWeaponPalette.Controls.Add(this.picWAfterDeath);
            this.tabWeaponPalette.Controls.Add(this.picWFire);
            this.tabWeaponPalette.Controls.Add(this.picWElec);
            this.tabWeaponPalette.Controls.Add(this.picWCuts);
            this.tabWeaponPalette.Controls.Add(this.picWGuts);
            this.tabWeaponPalette.Controls.Add(this.picWBomb);
            this.tabWeaponPalette.Controls.Add(this.picWIce);
            this.tabWeaponPalette.Controls.Add(this.picWStandard);
            this.tabWeaponPalette.Location = new System.Drawing.Point(4, 22);
            this.tabWeaponPalette.Name = "tabWeaponPalette";
            this.tabWeaponPalette.Padding = new System.Windows.Forms.Padding(3);
            this.tabWeaponPalette.Size = new System.Drawing.Size(415, 156);
            this.tabWeaponPalette.TabIndex = 1;
            this.tabWeaponPalette.Text = "Weapon Palettes";
            this.tabWeaponPalette.UseVisualStyleBackColor = true;
            // 
            // btnMatchPalettes
            // 
            this.btnMatchPalettes.Location = new System.Drawing.Point(260, 99);
            this.btnMatchPalettes.Name = "btnMatchPalettes";
            this.btnMatchPalettes.Size = new System.Drawing.Size(143, 23);
            this.btnMatchPalettes.TabIndex = 18;
            this.btnMatchPalettes.Text = "Match Megaman Palettes";
            this.btnMatchPalettes.UseVisualStyleBackColor = true;
            // 
            // lblCutsman
            // 
            this.lblCutsman.AutoSize = true;
            this.lblCutsman.Location = new System.Drawing.Point(175, 6);
            this.lblCutsman.Name = "lblCutsman";
            this.lblCutsman.Size = new System.Drawing.Size(33, 13);
            this.lblCutsman.TabIndex = 17;
            this.lblCutsman.Text = "Cuts:";
            // 
            // lblAfterDeath
            // 
            this.lblAfterDeath.AutoSize = true;
            this.lblAfterDeath.Location = new System.Drawing.Point(279, 68);
            this.lblAfterDeath.Name = "lblAfterDeath";
            this.lblAfterDeath.Size = new System.Drawing.Size(68, 13);
            this.lblAfterDeath.TabIndex = 16;
            this.lblAfterDeath.Text = "After Death:";
            // 
            // lblFire
            // 
            this.lblFire.AutoSize = true;
            this.lblFire.Location = new System.Drawing.Point(175, 37);
            this.lblFire.Name = "lblFire";
            this.lblFire.Size = new System.Drawing.Size(29, 13);
            this.lblFire.TabIndex = 15;
            this.lblFire.Text = "Fire:";
            // 
            // lblM
            // 
            this.lblM.AutoSize = true;
            this.lblM.Location = new System.Drawing.Point(175, 68);
            this.lblM.Name = "lblM";
            this.lblM.Size = new System.Drawing.Size(19, 13);
            this.lblM.TabIndex = 14;
            this.lblM.Text = "M:";
            // 
            // lblBomb
            // 
            this.lblBomb.AutoSize = true;
            this.lblBomb.Location = new System.Drawing.Point(6, 37);
            this.lblBomb.Name = "lblBomb";
            this.lblBomb.Size = new System.Drawing.Size(37, 13);
            this.lblBomb.TabIndex = 13;
            this.lblBomb.Text = "Bomb:";
            // 
            // lblElec
            // 
            this.lblElec.AutoSize = true;
            this.lblElec.Location = new System.Drawing.Point(321, 37);
            this.lblElec.Name = "lblElec";
            this.lblElec.Size = new System.Drawing.Size(30, 13);
            this.lblElec.TabIndex = 12;
            this.lblElec.Text = "Elec:";
            // 
            // lblGuts
            // 
            this.lblGuts.AutoSize = true;
            this.lblGuts.Location = new System.Drawing.Point(6, 68);
            this.lblGuts.Name = "lblGuts";
            this.lblGuts.Size = new System.Drawing.Size(33, 13);
            this.lblGuts.TabIndex = 11;
            this.lblGuts.Text = "Guts:";
            // 
            // lblIceman
            // 
            this.lblIceman.AutoSize = true;
            this.lblIceman.Location = new System.Drawing.Point(321, 6);
            this.lblIceman.Name = "lblIceman";
            this.lblIceman.Size = new System.Drawing.Size(26, 13);
            this.lblIceman.TabIndex = 10;
            this.lblIceman.Text = "Ice:";
            // 
            // lblNormal
            // 
            this.lblNormal.AutoSize = true;
            this.lblNormal.Location = new System.Drawing.Point(6, 6);
            this.lblNormal.Name = "lblNormal";
            this.lblNormal.Size = new System.Drawing.Size(55, 13);
            this.lblNormal.TabIndex = 9;
            this.lblNormal.Text = "Standard:";
            // 
            // picWM
            // 
            this.picWM.Location = new System.Drawing.Point(210, 68);
            this.picWM.Name = "picWM";
            this.picWM.Size = new System.Drawing.Size(50, 25);
            this.picWM.TabIndex = 8;
            this.picWM.TabStop = false;
            // 
            // picWAfterDeath
            // 
            this.picWAfterDeath.Location = new System.Drawing.Point(353, 68);
            this.picWAfterDeath.Name = "picWAfterDeath";
            this.picWAfterDeath.Size = new System.Drawing.Size(50, 25);
            this.picWAfterDeath.TabIndex = 7;
            this.picWAfterDeath.TabStop = false;
            // 
            // picWFire
            // 
            this.picWFire.Location = new System.Drawing.Point(210, 37);
            this.picWFire.Name = "picWFire";
            this.picWFire.Size = new System.Drawing.Size(50, 25);
            this.picWFire.TabIndex = 6;
            this.picWFire.TabStop = false;
            // 
            // picWElec
            // 
            this.picWElec.Location = new System.Drawing.Point(353, 37);
            this.picWElec.Name = "picWElec";
            this.picWElec.Size = new System.Drawing.Size(50, 25);
            this.picWElec.TabIndex = 5;
            this.picWElec.TabStop = false;
            // 
            // picWCuts
            // 
            this.picWCuts.Location = new System.Drawing.Point(210, 6);
            this.picWCuts.Name = "picWCuts";
            this.picWCuts.Size = new System.Drawing.Size(50, 25);
            this.picWCuts.TabIndex = 4;
            this.picWCuts.TabStop = false;
            // 
            // picWGuts
            // 
            this.picWGuts.Location = new System.Drawing.Point(67, 68);
            this.picWGuts.Name = "picWGuts";
            this.picWGuts.Size = new System.Drawing.Size(50, 25);
            this.picWGuts.TabIndex = 3;
            this.picWGuts.TabStop = false;
            // 
            // picWBomb
            // 
            this.picWBomb.Location = new System.Drawing.Point(67, 37);
            this.picWBomb.Name = "picWBomb";
            this.picWBomb.Size = new System.Drawing.Size(50, 25);
            this.picWBomb.TabIndex = 2;
            this.picWBomb.TabStop = false;
            // 
            // picWIce
            // 
            this.picWIce.Location = new System.Drawing.Point(353, 6);
            this.picWIce.Name = "picWIce";
            this.picWIce.Size = new System.Drawing.Size(50, 25);
            this.picWIce.TabIndex = 1;
            this.picWIce.TabStop = false;
            // 
            // picWStandard
            // 
            this.picWStandard.Location = new System.Drawing.Point(67, 6);
            this.picWStandard.Name = "picWStandard";
            this.picWStandard.Size = new System.Drawing.Size(50, 25);
            this.picWStandard.TabIndex = 0;
            this.picWStandard.TabStop = false;
            // 
            // tabPaletteCycles
            // 
            this.tabPaletteCycles.Controls.Add(this.picPaletteCycling);
            this.tabPaletteCycles.Controls.Add(this.lblCycleDesc);
            this.tabPaletteCycles.Location = new System.Drawing.Point(4, 22);
            this.tabPaletteCycles.Name = "tabPaletteCycles";
            this.tabPaletteCycles.Padding = new System.Windows.Forms.Padding(3);
            this.tabPaletteCycles.Size = new System.Drawing.Size(415, 156);
            this.tabPaletteCycles.TabIndex = 2;
            this.tabPaletteCycles.Text = "Palette Cycling";
            this.tabPaletteCycles.UseVisualStyleBackColor = true;
            // 
            // picPaletteCycling
            // 
            this.picPaletteCycling.Location = new System.Drawing.Point(9, 32);
            this.picPaletteCycling.Name = "picPaletteCycling";
            this.picPaletteCycling.Size = new System.Drawing.Size(75, 25);
            this.picPaletteCycling.TabIndex = 1;
            this.picPaletteCycling.TabStop = false;
            // 
            // lblCycleDesc
            // 
            this.lblCycleDesc.AutoSize = true;
            this.lblCycleDesc.Location = new System.Drawing.Point(6, 3);
            this.lblCycleDesc.Name = "lblCycleDesc";
            this.lblCycleDesc.Size = new System.Drawing.Size(294, 26);
            this.lblCycleDesc.TabIndex = 0;
            this.lblCycleDesc.Text = "These colours are cycled in to the two middle colours of the \r\nlast background pa" +
                "lette. (Left to right order)";
            // 
            // picNESPal
            // 
            this.picNESPal.Location = new System.Drawing.Point(68, 12);
            this.picNESPal.Name = "picNESPal";
            this.picNESPal.Size = new System.Drawing.Size(286, 73);
            this.picNESPal.TabIndex = 1;
            this.picNESPal.TabStop = false;
            this.picNESPal.Paint += new System.Windows.Forms.PaintEventHandler(this.picNESPal_Paint);
            // 
            // lbl000F
            // 
            this.lbl000F.AutoSize = true;
            this.lbl000F.Location = new System.Drawing.Point(360, 12);
            this.lbl000F.Name = "lbl000F";
            this.lbl000F.Size = new System.Drawing.Size(41, 13);
            this.lbl000F.TabIndex = 2;
            this.lbl000F.Text = "00 - 0F";
            // 
            // lbl101F
            // 
            this.lbl101F.AutoSize = true;
            this.lbl101F.Location = new System.Drawing.Point(360, 28);
            this.lbl101F.Name = "lbl101F";
            this.lbl101F.Size = new System.Drawing.Size(41, 13);
            this.lbl101F.TabIndex = 3;
            this.lbl101F.Text = "10 - 1F";
            // 
            // lbl202F
            // 
            this.lbl202F.AutoSize = true;
            this.lbl202F.Location = new System.Drawing.Point(360, 44);
            this.lbl202F.Name = "lbl202F";
            this.lbl202F.Size = new System.Drawing.Size(41, 13);
            this.lbl202F.TabIndex = 4;
            this.lbl202F.Text = "20 - 2F";
            // 
            // lbl303F
            // 
            this.lbl303F.AutoSize = true;
            this.lbl303F.Location = new System.Drawing.Point(360, 60);
            this.lbl303F.Name = "lbl303F";
            this.lbl303F.Size = new System.Drawing.Size(41, 13);
            this.lbl303F.TabIndex = 5;
            this.lbl303F.Text = "30 - 3F";
            // 
            // lblMousePal
            // 
            this.lblMousePal.AutoSize = true;
            this.lblMousePal.Location = new System.Drawing.Point(9, 88);
            this.lblMousePal.Name = "lblMousePal";
            this.lblMousePal.Size = new System.Drawing.Size(132, 13);
            this.lblMousePal.TabIndex = 6;
            this.lblMousePal.Text = "Palette Under Mouse: $00";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(360, 292);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(279, 292);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 8;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // frmPaletteEditor
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(444, 326);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblMousePal);
            this.Controls.Add(this.lbl303F);
            this.Controls.Add(this.lbl202F);
            this.Controls.Add(this.lbl101F);
            this.Controls.Add(this.lbl000F);
            this.Controls.Add(this.picNESPal);
            this.Controls.Add(this.tbcPalettes);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPaletteEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Palette Editor";
            this.Load += new System.EventHandler(this.frmPaletteEditor_Load);
            this.tbcPalettes.ResumeLayout(false);
            this.tabCurrentLevel.ResumeLayout(false);
            this.tabCurrentLevel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAfterDoorsBG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSpr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBG)).EndInit();
            this.tabWeaponPalette.ResumeLayout(false);
            this.tabWeaponPalette.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picWM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWAfterDeath)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWFire)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWElec)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWCuts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWGuts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWBomb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWIce)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWStandard)).EndInit();
            this.tabPaletteCycles.ResumeLayout(false);
            this.tabPaletteCycles.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPaletteCycling)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picNESPal)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tbcPalettes;
        private System.Windows.Forms.TabPage tabCurrentLevel;
        private System.Windows.Forms.TabPage tabWeaponPalette;
        private System.Windows.Forms.TabPage tabPaletteCycles;
        private System.Windows.Forms.Label lblAfterDoors;
        private System.Windows.Forms.Label lblBeforeDoors;
        private System.Windows.Forms.PictureBox picAfterDoorsBG;
        private System.Windows.Forms.PictureBox picSpr;
        private System.Windows.Forms.PictureBox picBG;
        private System.Windows.Forms.Button btnMatchLevelPalettes;
        private System.Windows.Forms.PictureBox picPaletteCycling;
        private System.Windows.Forms.Label lblCycleDesc;
        private System.Windows.Forms.Button btnMatchPalettes;
        private System.Windows.Forms.Label lblCutsman;
        private System.Windows.Forms.Label lblAfterDeath;
        private System.Windows.Forms.Label lblFire;
        private System.Windows.Forms.Label lblM;
        private System.Windows.Forms.Label lblBomb;
        private System.Windows.Forms.Label lblElec;
        private System.Windows.Forms.Label lblGuts;
        private System.Windows.Forms.Label lblIceman;
        private System.Windows.Forms.Label lblNormal;
        private System.Windows.Forms.PictureBox picWM;
        private System.Windows.Forms.PictureBox picWAfterDeath;
        private System.Windows.Forms.PictureBox picWFire;
        private System.Windows.Forms.PictureBox picWElec;
        private System.Windows.Forms.PictureBox picWCuts;
        private System.Windows.Forms.PictureBox picWGuts;
        private System.Windows.Forms.PictureBox picWBomb;
        private System.Windows.Forms.PictureBox picWIce;
        private System.Windows.Forms.PictureBox picWStandard;
        private System.Windows.Forms.PictureBox picNESPal;
        private System.Windows.Forms.Label lbl000F;
        private System.Windows.Forms.Label lbl101F;
        private System.Windows.Forms.Label lbl202F;
        private System.Windows.Forms.Label lbl303F;
        private System.Windows.Forms.Label lblMousePal;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
    }
}
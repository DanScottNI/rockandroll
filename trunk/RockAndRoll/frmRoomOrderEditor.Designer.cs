namespace RockAndRoll
{
    partial class frmRoomOrderEditor
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
            this.lvwRoomOrder = new System.Windows.Forms.ListView();
            this.colIndex = new System.Windows.Forms.ColumnHeader();
            this.colScreenID = new System.Windows.Forms.ColumnHeader();
            this.colIsRespawn1 = new System.Windows.Forms.ColumnHeader();
            this.colIsRespawn2 = new System.Windows.Forms.ColumnHeader();
            this.colIsActivate1 = new System.Windows.Forms.ColumnHeader();
            this.colIsActivate2 = new System.Windows.Forms.ColumnHeader();
            this.picRoom = new System.Windows.Forms.PictureBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picRoom)).BeginInit();
            this.SuspendLayout();
            // 
            // lvwRoomOrder
            // 
            this.lvwRoomOrder.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colIndex,
            this.colScreenID,
            this.colIsRespawn1,
            this.colIsRespawn2,
            this.colIsActivate1,
            this.colIsActivate2});
            this.lvwRoomOrder.FullRowSelect = true;
            this.lvwRoomOrder.GridLines = true;
            this.lvwRoomOrder.HideSelection = false;
            this.lvwRoomOrder.Location = new System.Drawing.Point(12, 12);
            this.lvwRoomOrder.Name = "lvwRoomOrder";
            this.lvwRoomOrder.Size = new System.Drawing.Size(538, 376);
            this.lvwRoomOrder.TabIndex = 0;
            this.lvwRoomOrder.UseCompatibleStateImageBehavior = false;
            this.lvwRoomOrder.View = System.Windows.Forms.View.Details;
            this.lvwRoomOrder.SelectedIndexChanged += new System.EventHandler(this.lvwRoomOrder_SelectedIndexChanged);
            // 
            // colIndex
            // 
            this.colIndex.Text = "Index.";
            this.colIndex.Width = 56;
            // 
            // colScreenID
            // 
            this.colScreenID.Text = "Screen ID.";
            this.colScreenID.Width = 75;
            // 
            // colIsRespawn1
            // 
            this.colIsRespawn1.Text = "Chk 1 Respawn";
            this.colIsRespawn1.Width = 99;
            // 
            // colIsRespawn2
            // 
            this.colIsRespawn2.Text = "Chk 2 Respawn";
            this.colIsRespawn2.Width = 91;
            // 
            // colIsActivate1
            // 
            this.colIsActivate1.Text = "Chk 1 Activate";
            this.colIsActivate1.Width = 91;
            // 
            // colIsActivate2
            // 
            this.colIsActivate2.Text = "Chk 2 Activate";
            this.colIsActivate2.Width = 91;
            // 
            // picRoom
            // 
            this.picRoom.Location = new System.Drawing.Point(556, 12);
            this.picRoom.Name = "picRoom";
            this.picRoom.Size = new System.Drawing.Size(256, 256);
            this.picRoom.TabIndex = 1;
            this.picRoom.TabStop = false;
            this.picRoom.Paint += new System.Windows.Forms.PaintEventHandler(this.picRoom_Paint);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(656, 365);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(737, 365);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // frmRoomOrderEditor
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(824, 400);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.picRoom);
            this.Controls.Add(this.lvwRoomOrder);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRoomOrderEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Room Order Editor";
            this.Load += new System.EventHandler(this.frmRoomOrderEditor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picRoom)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvwRoomOrder;
        private System.Windows.Forms.PictureBox picRoom;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ColumnHeader colIndex;
        private System.Windows.Forms.ColumnHeader colScreenID;
        private System.Windows.Forms.ColumnHeader colIsRespawn1;
        private System.Windows.Forms.ColumnHeader colIsRespawn2;
        private System.Windows.Forms.ColumnHeader colIsActivate1;
        private System.Windows.Forms.ColumnHeader colIsActivate2;
    }
}
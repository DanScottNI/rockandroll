using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MegamanData.Megaman;
using ROMHackLib;
using ROMHackLib.Graphics.NES;

namespace RockAndRoll
{
    public partial class frmRoomOrderEditor : Form
    {
        MegamanROM megamanROM;
        Bitmap screenRender;

        public frmRoomOrderEditor(ref MegamanROM megamanrom)
        {
            InitializeComponent();
            this.megamanROM = megamanrom;
            screenRender = new Bitmap(256, 256, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
        }

        /// <summary>
        /// Populates the listview with the screen index data.
        /// </summary>
        public void LoadScreenIndexData()
        {
            lvwRoomOrder.BeginUpdate();
            // Clear the listview
            lvwRoomOrder.Items.Clear();
            int startScreenIndex = megamanROM.CurrentLevel.ScreenIDLevelStart;
            int endScreenIndex = startScreenIndex + megamanROM.CurrentLevel.LevelLength();


            for (int i = 0; i < megamanROM.CurrentLevel.RoomOrder.Count; i++)
            {

                ListViewItem item = new ListViewItem(i.ToHex());

                item.SubItems.Add(megamanROM.CurrentLevel.RoomOrder[i].ToHex().ToUpper());
                if (i >= startScreenIndex && i <= endScreenIndex)
                {
                    item.BackColor = Color.LightGreen;
                }

                lvwRoomOrder.Items.Add(item);
            }

            lvwRoomOrder.EndUpdate();
        }

        public void SaveScreenIndexData()
        {

        }

        private void frmRoomOrderEditor_Load(object sender, EventArgs e)
        {
            LoadScreenIndexData();
        }

        private void picRoom_Paint(object sender, PaintEventArgs e)
        {
            if (lvwRoomOrder.SelectedItems.Count > 0)
            {
                megamanROM.DrawScreen(ref screenRender, Convert.ToByte("0x" + lvwRoomOrder.SelectedItems[0].SubItems[1].Text, 16), false, Color.Transparent, Color.Transparent, Color.Transparent);
                e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                e.Graphics.DrawImage(screenRender, 0, 0, screenRender.Width, screenRender.Height);
            }
        }

        private void lvwRoomOrder_SelectedIndexChanged(object sender, EventArgs e)
        {
            picRoom.Invalidate();
        }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MegamanData.Megaman;
using ROMHackLib.NES;
using ROMHackLib.Graphics.NES;

namespace RockAndRoll
{
    public partial class frmPaletteEditor : Form
    {
        MegamanROM megamanROM;
        Bitmap PalBitmap = new Bitmap(256, 64);
        NESRender nes = new NESRender(256, 64);
        byte SelectedColour = 0;
        public frmPaletteEditor(MegamanROM rom)
        {
            InitializeComponent();
            megamanROM = rom;
        }

        private void DrawPalette()
        {
            megamanROM.RenderPalette(ref PalBitmap, ref nes);
        }

        private void frmPaletteEditor_Load(object sender, EventArgs e)
        {
            DrawPalette();
        }

        private void picNESPal_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            e.Graphics.DrawImage(PalBitmap, 0, 0, PalBitmap.Width, PalBitmap.Height);
            e.Graphics.DrawRectangle(new Pen(Color.Red), (SelectedColour % 16) * 16, (SelectedColour / 16) * 16, 15, 15);
        }

    }
}

using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using MegamanData.Megaman;
using ROMHackLib;
using ROMHackLib.NES;

namespace RockAndRoll
{
    public partial class frmMain : Form
    {
        /// <summary>
        /// Variable that caches the directory in which the application resides.
        /// </summary>
        string executablePath;
        string resourcePath;

        /// <summary>
        /// Whether we are in solidity editing mode.
        /// </summary>
        bool editSolidity = false;

        EditorEditMode editingMode = EditorEditMode.MapEditingMode;

        /// <summary>
        /// A variable that stores the tile ID currently mapped to the left mouse button.
        /// </summary>
        byte? currentTileLeft = null;

        /// <summary>
        /// A variable that stores the tile ID currently mapped to the middle mouse button.
        /// </summary>
        byte? currentTileMiddle = null;

        /// <summary>
        /// Object used to store what object is currently selected.
        /// </summary>
        ObjectInformation objectInfo = null;

        MegamanROM megamanROM;

        // the bitmap is slightly larger than it needs to be, as objects are rendering off the 
        // edge of it.
        Bitmap levelData = new Bitmap(264, 264, PixelFormat.Format32bppArgb);
        Bitmap TileSelector = new Bitmap(32, 256, PixelFormat.Format32bppArgb);

        ApplicationConfig config;

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            executablePath = Path.GetDirectoryName(Application.ExecutablePath);
            resourcePath = Path.Combine(executablePath, "Resources");
            SetEnabledStatus(false);
            DisplayTitleInfo();
            LoadConfiguration();
        }

        private void LoadROM(string filename)
        {
            megamanROM = new MegamanROM(filename, Path.Combine(resourcePath, "Megaman" + Path.DirectorySeparatorChar +
                "Mega Man (U).ini"), resourcePath);

            SetEnabledStatus(true);
            DisplayTitleInfo();
            SetDataFileIcon();

            // Reset the solidity editing mode to false.
            editSolidity = false;

            // Set the editor into map editing mode.
            SetMapEditingMode();


            config.AddToRecentFiles(filename);
            PopulateRecentMenu();

            SetupLevel();
        }

        private void SetupLevel()
        {
            // Reset the current tile settings.
            currentTileLeft = 0;
            currentTileMiddle = 0;

            DisplayLevelInfo();
            scrLevel.Maximum = (megamanROM.CurrentLevel.RoomOrder.Count - 1) + (scrLevel.LargeChange - 1);
            scrLevel.Value = megamanROM.CurrentRoomIndex;

            picLevel.Invalidate();
            picTiles.Invalidate();
        }

        private void SetEnabledStatus(bool enabled)
        {
            mnuCloseROM.Enabled = enabled;
            picTiles.Visible = enabled;
            picLevel.Visible = enabled;
            scrLevel.Enabled = enabled;
            scrLevel.Visible = enabled;
            scrTiles.Enabled = enabled;
            scrTiles.Visible = enabled;

            // The menu items.
            mnuSaveROM.Enabled = enabled;
            mnuCloseROM.Enabled = enabled;
            mnuAddNewEnemy.Enabled = enabled;
            mnuAddNewSpecialObject.Enabled = enabled;
            mnuDistributeHack.Enabled = enabled;
            mnuEnemyManagement.Enabled = enabled;
            mnuEnemyStatistics.Enabled = enabled;
            mnuFileProperties.Enabled = enabled;
            mnuGoToLevel.Enabled = enabled;
            mnuGoToLevelStart.Enabled = enabled;
            mnuLaunchEmu.Enabled = enabled;
            mnuLevelProperties.Enabled = enabled;
            mnuMapEditingMode.Enabled = enabled;
            mnuObjectEditingMode.Enabled = enabled;
            mnuPaletteEditor.Enabled = enabled;
            mnuPatternTableSettings.Enabled = enabled;
            mnuRoomOrderEditor.Enabled = enabled;
            mnuScrollEditor.Enabled = enabled;
            mnuSoundEffectsMusicTrackEditor.Enabled = enabled;
            mnuStatistics.Enabled = enabled;
            mnuTSAEditor.Enabled = enabled;

            mnuViewBeamdownPoints.Enabled = enabled;
            mnuViewEnemies.Enabled = enabled;
            mnuViewGridlines.Enabled = enabled;
            mnuViewSpecialObjects.Enabled = enabled;

            // The toolbar items.
            tlbSaveROM.Enabled = enabled;
            tlbCloseROM.Enabled = enabled;
            tlbAddEnemy.Enabled = enabled;
            tlbAddSpecialObject.Enabled = enabled;
            tlbEnemyManagement.Enabled = enabled;
            tlbGridlines.Enabled = enabled;
            tlbLevelProperties.Enabled = enabled;
            tlbMapEditingMode.Enabled = enabled;
            tlbObjectEditingMode.Enabled = enabled;
            tlbPaletteEditor.Enabled = enabled;
            tlbRoomOrder.Enabled = enabled;
            tlbScrollEditor.Enabled = enabled;
            tlbSoundEffects.Enabled = enabled;
            tlbStatistics.Enabled = enabled;
            tlbTSA.Enabled = enabled;
        }

        private void DisplayLevelInfo()
        {
            string levelInfo = string.Format("{0} - Screen Index: {1} - Screen ID {2}", megamanROM.CurrentLevel.Name, megamanROM.CurrentRoomIndex.ToHex(), megamanROM.CurrentRoomID.ToHex());
            lblLevelInfo.Text = levelInfo;
        }

        private void DisplayTitleInfo()
        {
            if (megamanROM == null)
            {
                this.Text = Properties.Resources.RockAndRoll;
                lblROMType.Text = string.Empty;
                lblLevelInfo.Text = string.Empty;
                lblLoadedROM.Text = Properties.Resources.ROMNotLoaded;
                lblROMType.Image = null;
            }
            else
            {
                string captionText;

                captionText = string.Format("{1} [{0}]", Path.GetFileName(megamanROM.Filename), Properties.Resources.RockAndRoll);

                lblLoadedROM.Text = Path.GetFileName(megamanROM.Filename);

                if (megamanROM.IsROMChanged == true)
                {
                    captionText += " *";
                }

                if (this.Text != captionText)
                {
                    this.Text = captionText;
                }
            }
        }

        private void SetDataFileIcon()
        {
            if (megamanROM != null)
            {
                if (File.Exists(Path.Combine(resourcePath, megamanROM.Flag)))
                {
                    lblROMType.Image =  new Bitmap(Path.Combine(resourcePath, megamanROM.Flag));
                }
            }
        }

        private void DrawLevel()
        {
            megamanROM.DrawScreen(ref levelData, true, config.EnemyColour, config.SpecialObjectColour, config.BeamDownColour);
        }

        private void DrawTileSelector()
        {
            megamanROM.DrawTileSelector(ref TileSelector, 0, false);
        }

        private void mnuOpenROM_Click(object sender, EventArgs e)
        {
            if (ofdDialog.ShowDialog() == DialogResult.OK)
                LoadROM(ofdDialog.FileName);
        }

        private void picLevel_Paint(object sender, PaintEventArgs e)
        {
            if (megamanROM != null)
            {
                DrawLevel();
                e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                e.Graphics.DrawImage(levelData, 0, 0, levelData.Width * 2, levelData.Height * 2);
            }
        }

        private void scrLevel_ValueChanged(object sender, EventArgs e)
        {
            if (megamanROM != null)
            {
                megamanROM.CurrentRoomIndex = Convert.ToByte(scrLevel.Value);
                picLevel.Invalidate();
                DisplayLevelInfo();
            }
        }

        private void picTiles_Paint(object sender, PaintEventArgs e)
        {
            if (megamanROM != null)
            {
                DrawTileSelector();
                e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                e.Graphics.DrawImage(TileSelector, 0, 0, TileSelector.Width * 2, TileSelector.Height * 2);

                Graphics g = e.Graphics;

                // If the two tiles match, then we should draw instead of a rectangle,
                // a rectangle that has different coloured sides.
                if (currentTileLeft == currentTileMiddle)
                {
                    if ((currentTileLeft >= scrTiles.Value) && (currentTileLeft <= scrTiles.Value + 7))
                    {
                        // Left
                        g.DrawLine(new Pen(new SolidBrush(config.SelectedTileLeftColour), 2.0f), 1, (currentTileLeft.Value - scrTiles.Value) * 64, 1, ((currentTileLeft.Value - scrTiles.Value) * 64) + 64);

                        // Top 
                        g.DrawLine(new Pen(new SolidBrush(config.SelectedTileLeftColour), 2.0f), 0, (currentTileLeft.Value - scrTiles.Value) * 64, 62, (currentTileLeft.Value - scrTiles.Value) * 64);

                        // Right
                        g.DrawLine(new Pen(new SolidBrush(config.SelectedTileMiddleColour), 2.0f), 62, ((currentTileMiddle.Value - scrTiles.Value) * 64), 62, ((currentTileMiddle.Value - scrTiles.Value) * 64) + 64);

                        // Bottom
                        g.DrawLine(new Pen(new SolidBrush(config.SelectedTileMiddleColour), 2.0f), 0, ((currentTileMiddle.Value - scrTiles.Value) * 64) + 63, 62, ((currentTileMiddle.Value - scrTiles.Value) * 64) + 63);
                    }
                }
                else
                {
                    if ((currentTileLeft >= scrTiles.Value) && (currentTileLeft <= scrTiles.Value + 7))
                    {
                        g.DrawRectangle(new Pen(new SolidBrush(config.SelectedTileLeftColour), 2.0f), 1, (currentTileLeft.Value - scrTiles.Value) * 64, 62, 63);
                    }

                    if ((currentTileMiddle >= scrTiles.Value) && (currentTileMiddle <= scrTiles.Value + 7))
                    {
                        g.DrawRectangle(new Pen(new SolidBrush(config.SelectedTileMiddleColour), 2.0f), 1, (currentTileMiddle.Value - scrTiles.Value) * 64, 62, 63);
                    }
                }

            }
        }

        private void mnuPaletteEditor_Click(object sender, EventArgs e)
        {
            // Create the palette editor form
            frmPaletteEditor pal = new frmPaletteEditor(megamanROM);
            // If the user clicks the OK button on the form, refresh all the on-screen tiles,
            // and 
            if (pal.ShowDialog() == DialogResult.OK)
            {
                // Refresh all the on-screen tiles.
                megamanROM.RefreshOnScreenTiles();

                // Now, refresh the two picturebox controls which have the tiles in them
                picLevel.Invalidate();
                picTiles.Invalidate();
            }
        }

        private void mnuRoomOrderEditor_Click(object sender, EventArgs e)
        {
            frmRoomOrderEditor roomed = new frmRoomOrderEditor(ref megamanROM);
            if (roomed.ShowDialog() == DialogResult.OK)
            {
                // Now, refresh the two picturebox controls which have the tiles in them
                picLevel.Invalidate();
            }
        }

        private void PopulateRecentMenu()
        {
            if (config.RecentFiles != null && config.RecentFiles.Count > 0)
            {
                mnuRecent.Visible = true;
                mnuRecent.DropDownItems.Clear();

                foreach (string recentfile in config.RecentFiles)
                {
                    ToolStripMenuItem menu = new ToolStripMenuItem(recentfile.ShortenPathname(75));
                    menu.Tag = recentfile;
                    menu.ToolTipText = recentfile;
                    menu.Click += new EventHandler(mnuRecentItemClick);
                    mnuRecent.DropDownItems.Add(menu);
                }
            }
            else
            {
                mnuRecent.Visible = false;
            }
        }

        private void mnuRecentItemClick(object sender, EventArgs e)
        {
            LoadROM(Convert.ToString((sender as ToolStripMenuItem).Tag));
        }

        private void LoadConfiguration()
        {
            config = new ApplicationConfig(Path.Combine(executablePath, "config1.xml"));
            config.LoadConfiguration();

            PopulateRecentMenu();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            config.SaveConfiguration();
        }

        private void picLevel_MouseDown(object sender, MouseEventArgs e)
        {
            if (editingMode == EditorEditMode.MapEditingMode)
            {
                if (e.Button == MouseButtons.Left)
                {
                    // If the shift key is held down, then whatever tile ID is mapped to the
                    // middle mouse button,
                    if (Control.ModifierKeys == Keys.Shift)
                    {
                        megamanROM.SetLevelData((e.Y / 2) / 32, (e.X / 2) / 32, currentTileMiddle.Value);
                    }
                    else
                    {
                        megamanROM.SetLevelData((e.Y / 2) / 32, (e.X / 2) / 32, currentTileLeft.Value);
                    }

                    // Update the caption bar to reflect that changes have been made to the ROM.
                    DisplayTitleInfo();

                    // Refresh the main level viewer.
                    picLevel.Invalidate();
                }
                else if (e.Button == MouseButtons.Middle)
                {
                    megamanROM.SetLevelData((e.Y / 2) / 32, (e.X / 2) / 32, currentTileMiddle.Value);
                }
                else if (e.Button == MouseButtons.Right)
                {
                    if (Control.ModifierKeys == Keys.Shift)
                    {
                        currentTileMiddle = megamanROM.GetLevelData((e.Y / 2) / 32, (e.X / 2) / 32);
                    }
                    else
                    {
                        currentTileLeft = megamanROM.GetLevelData((e.Y / 2) / 32, (e.X / 2) / 32);
                    }
                    picTiles.Invalidate();
                }

            }
            else if (editingMode == EditorEditMode.ObjectEditingMode)
            {
                objectInfo = megamanROM.DetectObjectUnderMouse(e.X / 2, e.Y / 2);

                if (objectInfo != null)
                {
                    if (objectInfo.Type == ObjectType.Enemy)
                    {
                    }
                    else if (objectInfo.Type == ObjectType.BeamDown)
                    {
                    }
                    else if (objectInfo.Type == ObjectType.SpecialObject)
                    {
                    }
                }
            }
        }

        private void picLevel_MouseUp(object sender, MouseEventArgs e)
        {
        }

        private void picLevel_MouseMove(object sender, MouseEventArgs e)
        {
            if (editingMode == EditorEditMode.MapEditingMode)
            {
                if (e.Button == MouseButtons.Left)
                {
                    // If the shift key is held down, then whatever tile ID is mapped to the
                    // middle mouse button,
                    if (Control.ModifierKeys == Keys.Shift)
                    {
                        megamanROM.SetLevelData((e.Y / 2) / 32, (e.X / 2) / 32, currentTileMiddle.Value);
                    }
                    else
                    {
                        megamanROM.SetLevelData((e.Y / 2) / 32, (e.X / 2) / 32, currentTileLeft.Value);
                    }

                    // Update the caption bar to reflect that changes have been made to the ROM.
                    DisplayTitleInfo();

                    // Refresh the main level viewer.
                    picLevel.Invalidate();
                }
                else if (e.Button == MouseButtons.Middle)
                {
                    megamanROM.SetLevelData((e.Y / 2) / 32, (e.X / 2) / 32, currentTileMiddle.Value);
                }
                else if (e.Button == MouseButtons.Right)
                {
                    if (Control.ModifierKeys == Keys.Shift)
                    {
                        currentTileMiddle = megamanROM.GetLevelData((e.Y / 2) / 32, (e.X / 2) / 32);
                    }
                    else
                    {
                        currentTileLeft = megamanROM.GetLevelData((e.Y / 2) / 32, (e.X / 2) / 32);
                    }
                    picTiles.Invalidate();
                }
            }
            else if (editingMode == EditorEditMode.ObjectEditingMode)
            {
            }
        }

        private void mnuMapEditingMode_Click(object sender, EventArgs e)
        {
            SetMapEditingMode();
        }

        private void mnuObjectEditingMode_Click(object sender, EventArgs e)
        {
            SetObjectEditingMode();
        }

        private void SetMapEditingMode()
        {
            editingMode = EditorEditMode.MapEditingMode;
            mnuObjectEditingMode.Checked = false;
            mnuMapEditingMode.Checked = true;
            tlbObjectEditingMode.Checked = false;
            tlbMapEditingMode.Checked = true;
            lblROMType.Text = Properties.Resources.MapEditingMode;
        }

        private void SetObjectEditingMode()
        {
            editingMode = EditorEditMode.ObjectEditingMode;
            mnuObjectEditingMode.Checked = true;
            mnuMapEditingMode.Checked = false;
            tlbObjectEditingMode.Checked = true;
            tlbMapEditingMode.Checked = false;
            lblROMType.Text = Properties.Resources.ObjectEditingMode;
        }

        private void mnuSolidityMode_Click(object sender, EventArgs e)
        {
            SetSolidityMode(!editSolidity);
        }

        private void SetSolidityMode(bool solidityMode)
        {
            editSolidity = solidityMode;
            mnuSolidityMode.Checked = editSolidity;
        }

        private void mnuPreferences_Click(object sender, EventArgs e)
        {
            using (frmPreferences frmPref = new frmPreferences(ref config))
            {
                if (frmPref.ShowDialog() == DialogResult.OK && megamanROM != null)
                {
                    megamanROM.RefreshOnScreenTiles();
                    picLevel.Invalidate();
                    picTiles.Invalidate();
                }

            }
        }

        private void frmMain_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void frmMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (megamanROM != null)
            {
                if (e.KeyCode == Keys.PageUp)
                {
                    megamanROM.CurrentLevelIndex++;
                    SetupLevel();
                }
                else if (e.KeyCode == Keys.PageDown)
                {
                    megamanROM.CurrentLevelIndex--;
                    SetupLevel();
                }
            }
        }
    }
}

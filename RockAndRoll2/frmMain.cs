using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using System.IO;
using System.Windows.Forms;
using MegamanData.Megaman2;
using ROMHackLib;

namespace RockAndRoll2
{
    public partial class frmMain : Form
    {
        /// <summary>
        /// Variable that caches the directory in which the application resides.
        /// </summary>
        string executablePath;
        string resourcePath;
        Megaman2ROM megaman2ROM;
        Bitmap levelData = new Bitmap(256, 256, PixelFormat.Format32bppArgb);
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

        private void DisplayTitleInfo()
        {
            Version version =
            System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            DateTime dt = new DateTime(2000, 1, 1);
            string buildTime = dt.AddDays(version.Build).ToShortDateString();

            if (megaman2ROM == null)
            {

                this.Text = "Rock and Roll 2 - Mega Man Editor (" + buildTime + ")";
                StatusBar1.Panels[2].Text = "";
                StatusBar1.Panels[1].Text = "";
                StatusBar1.Panels[0].Text = "ROM Not Loaded";
                StatusBar1.Panels[2].Icon = null;
            }
            else
            {
                string captionText;

                captionText = "Rock and Roll 2 - Mega Man Editor (" + buildTime + ") [" + Path.GetFileName(megaman2ROM.ROMFilename) + "]";

                StatusBar1.Panels[0].Text = Path.GetFileName(megaman2ROM.ROMFilename);

                if (megaman2ROM.IsROMChanged == true)
                {
                    captionText += " *";
                }

                if (this.Text != captionText)
                {
                    this.Text = captionText;
                }
            }
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
            mnuScrollEditor.Enabled = enabled;
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
            tlbGridlines.Enabled = enabled;
            tlbLevelProperties.Enabled = enabled;
            tlbMapEditingMode.Enabled = enabled;
            tlbObjectEditingMode.Enabled = enabled;
            tlbPaletteEditor.Enabled = enabled;
            tlbScrollEditor.Enabled = enabled;
            tlbStatistics.Enabled = enabled;
            tlbTSA.Enabled = enabled;
        }

        private void DrawLevel()
        {
            megaman2ROM.DrawScreen(ref levelData);
        }

        private void DrawTileSelector()
        {
            megaman2ROM.DrawTileSelector(ref TileSelector, 0, true);
        }

        private void LoadROM(string filename)
        {
            megaman2ROM = new Megaman2ROM(filename, Path.Combine(resourcePath, "Megaman2" + Path.DirectorySeparatorChar + "Mega Man 2 (U).ini"),
                resourcePath);

            SetEnabledStatus(true);
            DisplayTitleInfo();
            DisplayLevelInfo();

            SetDataFileIcon();

            config.AddToRecentFiles(filename);
            PopulateRecentMenu();
        }

        private void SetDataFileIcon()
        {
            if (megaman2ROM != null)
            {
                if (File.Exists(Path.Combine(resourcePath, megaman2ROM.Flag)))
                {
                    StatusBar1.Panels[2].Icon = new Icon(Path.Combine(resourcePath, megaman2ROM.Flag));
                }
            }

        }

        private void DisplayLevelInfo()
        {
            string levelInfo = string.Format("{0} {1}", megaman2ROM.CurrentLevel.Name, megaman2ROM.CurrentRoomIndex.ToString());
            StatusBar1.Panels[1].Text = levelInfo;
        }

        private void picLevel_Paint(object sender, PaintEventArgs e)
        {
            if (megaman2ROM != null)
            {
                DrawLevel();
                e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                e.Graphics.DrawImage(levelData, 0, 0, levelData.Width * 2, levelData.Height * 2);
            }
        }

        private void mnuOpenROM_Click(object sender, EventArgs e)
        {
            if (ofdDialog.ShowDialog() == DialogResult.OK)
            {
                LoadROM(ofdDialog.FileName);
            }
        }

        private void scrLevel_Scroll(object sender, ScrollEventArgs e)
        {
            if (megaman2ROM != null)
            {
                megaman2ROM.CurrentRoomIndex = Convert.ToByte(scrLevel.Value);
                picLevel.Invalidate();
            }
        }

        private void LoadConfiguration()
        {
            config = new ApplicationConfig(Path.Combine(executablePath, "config2.xml"));
            config.LoadConfiguration();

            PopulateRecentMenu();
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

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            config.SaveConfiguration();
        }

    }
}

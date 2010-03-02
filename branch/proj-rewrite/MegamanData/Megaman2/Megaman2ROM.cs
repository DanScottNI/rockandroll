using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Text;
using Nini.Config;
using ROMHackLib.Graphics.NES;
using ROMHackLib.NES;

namespace MegamanData.Megaman2
{
    /// <summary>
    /// Class that represents a Mega Man 2 ROM.
    /// </summary>
    public unsafe class Megaman2ROM
    {
        /// <summary>
        /// The palette for the current level.
        /// </summary>
        private byte[,] levelPalette = new byte[8, 4];

        /// <summary>
        /// The directory in which the application's resources reside.
        /// </summary>
        private string assetDirectory;

        /// <summary>
        /// The pattern table for the current level.
        /// </summary>
        private byte[] patternTable = new byte[8192];

        /// <summary>
        /// Whether or not the current tile has been drawn.
        /// </summary>
        private bool[] tilesDrawn = new bool[256];

        /// <summary>
        /// A NESRender object consisting of the level's tiles.
        /// </summary>
        private NESRender levelTiles;

        /// <summary>
        /// The current level index.
        /// </summary>
        private int currentLevelIndex = -1;

        /// <summary>
        /// The current room index.
        /// </summary>
        private byte currentRoomIndex;

        /// <summary>
        /// Gets or sets the current level.
        /// </summary>
        public Level CurrentLevel { get; set; }

        /// <summary>
        /// Gets or sets a list of Mega Man 2 levels.
        /// </summary>
        public Collection<Level> Levels { get; set; }

        /// <summary>
        /// Gets or sets the palette for the current level.
        /// </summary>
        public byte[,] LevelPalette
        {
            get
            {
                return this.levelPalette;
            }

            set
            {
                this.levelPalette = value;
            }
        }

        /// <summary>
        /// Gets or sets the index of the current level.
        /// </summary>
        public int CurrentLevelIndex
        {
            get
            {
                return this.currentLevelIndex;
            }

            set
            {
                if (this.currentLevelIndex > -1)
                {
                    //// SaveRoomData();
                    this.CurrentLevel.SaveScrollData();
                }

                this.currentLevelIndex = value;

                this.CurrentLevel = this.Levels[value];

                //// this.CurrentLevel.LoadScrollData();

                // Reinitialise DrawTiles
                for (int i = 0; i < 256; i++)
                {
                    this.tilesDrawn[i] = false;
                }

                this.LoadPatternTable();
                this.LoadBGPalette(0);
                //// LoadEnemyData();
                //// this.CurrentLevel.LoadSpecialObjectData();
                this.LoadRoomTiles(0);
                this.currentRoomIndex = 0;
            }
        }

        /// <summary>
        /// Gets or sets the icon which represents the currently loaded level.
        /// </summary>
        public string Flag { get; set; }

        /// <summary>
        /// Gets or sets the room that is currently displayed in the editor.
        /// </summary>
        public byte CurrentRoomIndex
        {
            get
            {
                return this.currentRoomIndex;
            }

            set
            {
                this.currentRoomIndex = value;
            }
        }

        /// <summary>
        /// The ROM that is currently loaded.
        /// </summary>
        private INESROMImage rom;

        /// <summary>
        /// Initializes a new instance of the Megaman2ROM class.
        /// </summary>
        /// <param name="fileName">The filename of the Megaman ROM.</param>
        /// <param name="dataFile">The datafile to use when parsing the ROM.</param>
        /// <param name="assetDirectory">The directory in which the resources used by the library are contained.</param>
        public Megaman2ROM(string fileName, string dataFile, string assetDirectory)
        {
            // Create a new ROM to load data from
            this.rom = new INESROMImage(fileName);

            this.assetDirectory = assetDirectory;

            // Load in the external data
            this.LoadDataFile(dataFile);

            // Load in the pattern table settings.
            this.LoadPatternTableSettings();

            /*this.LoadEnemyDescriptions();
            this.LoadTSASettingsList();
            this.LoadSoundEffectList();
            this.LoadEnemyData();
            this.LoadEnemyStatistics();*/

            // Draw the tiles
            this.levelTiles = new NESRender(32 * 256, 32);

            this.CurrentLevelIndex = 0;
        }

        /// <summary>
        /// Loads the TSA settings list.
        /// </summary>
        public void LoadTSASettingsList()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Draws the level tile.
        /// </summary>
        /// <param name="index">The index of the tile to draw.</param>
        public void DrawLevelTile(byte index)
        {
            byte[,] tilePal = new byte[2, 2];

            tilePal[0, 0] = (byte)(this.rom[this.CurrentLevel.AttributeOffset + index] & 3);
            tilePal[0, 1] = (byte)((this.rom[this.CurrentLevel.AttributeOffset + index] >> 2) & 3);
            tilePal[1, 0] = (byte)((this.rom[this.CurrentLevel.AttributeOffset + index] >> 4) & 3);
            tilePal[1, 1] = (byte)((this.rom[this.CurrentLevel.AttributeOffset + index] >> 6) & 3);

            for (int i = 0; i < 2; i++)
            {
                for (int x = 0; x < 2; x++)
                {
                    fixed (byte* palPointer = &this.levelPalette[tilePal[x, i], 0])
                    {
                        fixed (byte* tilePointer = &this.patternTable[((rom[this.CurrentLevel.TSAOffset + (index * 4) + ((i * 2) + x)] & 0x3F) * 0x40) + 0x1000])
                        {
                            this.levelTiles.DrawTile((i * 16) + (index * 32), (x * 16) + 0, tilePointer, palPointer);
                            this.levelTiles.DrawTile((i * 16) + (index * 32), (x * 16) + 8, tilePointer + 0x10, palPointer);
                            this.levelTiles.DrawTile((i * 16) + (index * 32) + 8, (x * 16) + 0, tilePointer + 0x20, palPointer);
                            this.levelTiles.DrawTile((i * 16) + ((index * 32) + 8), (x * 16) + 8, tilePointer + 0x30, palPointer);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Draws the pattern table.
        /// </summary>
        public void DrawPatternTable()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Draws the TSA pattern table.
        /// </summary>
        public void DrawTSAPatternTable()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Loads the background palette, for a specific cycle ID.
        /// </summary>
        /// <param name="cycleID">The cycle ID.</param>
        public void LoadBGPalette(byte cycleID)
        {
            for (int i = 0; i < 4; i++)
            {
                for (int x = 0; x < 4; x++)
                {
                    this.levelPalette[i, x] = rom[this.CurrentLevel.GetPaletteDataOffset(cycleID) + (i * 4) + x];
                }
            }

            for (int i = 0; i < 4; i++)
            {
                for (int x = 0; x < 4; x++)
                {
                    this.levelPalette[i + 4, x] = rom[(this.CurrentLevel.PaletteOffset + 0x12) + (i * 4) + x];
                }
            }
        }

        /// <summary>
        /// Loads the data file.
        /// </summary>
        /// <param name="dataFileName">File name of the data file.</param>
        public void LoadDataFile(string dataFileName)
        {
            IniConfigSource ini = new IniConfigSource(dataFileName);
            ini.CaseSensitive = false;

            int numberLevels;

            numberLevels = ini.Configs["General"].GetInt("NumLevels");
            this.Flag = ini.Configs["General"].GetString("flag");

            if (this.Levels == null)
            {
                this.Levels = new Collection<Level>();
            }

            for (int i = 0; i < numberLevels; i++)
            {
                Level lvl = new Level(ref rom);
                IConfig col = ini.Configs["Level" + i];
                lvl.Name = col.GetString("Name");
                lvl.TSAOffset = col.GetHex("TSA");
                lvl.AttributeOffset = col.GetHex("Attribute");
                lvl.LevelOffset = col.GetHex("LevelData");
                lvl.CHRSettingsOffset = col.GetHex("CHRSettings");
                lvl.PPUSettingsOffset = col.GetHex("PPUSettings");
                lvl.PaletteOffset = col.GetHex("pal");

                // Beam down co-ordinates.
                lvl.BeamDown0 = col.GetHex("BeamDown0");
                lvl.BeamDown1 = col.GetHex("BeamDown1");
                lvl.BeamDown2 = col.GetHex("BeamDown2");

                // Level items.
                lvl.ItemsStart0 = col.GetHex("ItemsStart0");
                lvl.ItemsStart1 = col.GetHex("ItemsStart1");
                lvl.ItemsStart2 = col.GetHex("ItemsStart2");

                // Events.
                lvl.EventStart0 = col.GetHex("EvStart0");
                lvl.EventStart1 = col.GetHex("EvStart1");
                lvl.EventStart2 = col.GetHex("EvStart2");

                // The various scroll settings.
                lvl.ScrollOffset = col.GetHex("ScrData");

                // Screen starting settings.
                lvl.ScreenStart0 = col.GetHex("ScreenStart0");
                lvl.ScreenStart1 = col.GetHex("ScreenStart1");
                lvl.ScreenStart2 = col.GetHex("ScreenStart2");

                this.Levels.Add(lvl);
            }
        }

        /// <summary>
        /// Loads the enemy data.
        /// </summary>
        public void LoadEnemyData()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Loads the enemy descriptions.
        /// </summary>
        public void LoadEnemyDescriptions()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Loads the pattern table.
        /// </summary>
        public void LoadPatternTable()
        {
            int patPos = 0;

            // Empty the pattern table.
            for (int i = 0; i < this.patternTable.Length; i++)
            {
                this.patternTable[i] = 0x00;
            }

            for (int i = 0; i < this.CurrentLevel.PatternTableSettings.Count; i++)
            {
                for (int x = 0; x < this.CurrentLevel.PatternTableSettings[i].NumberOfBytesToLoad; x++)
                {
                    this.patternTable[patPos + x] = rom[this.CurrentLevel.PatternTableSettings[i].DataROMAddress + x];
                }
                patPos = patPos + this.CurrentLevel.PatternTableSettings[i].NumberOfBytesToLoad;
            }
        }

        /// <summary>
        /// Loads all the pattern table settings, for each level.
        /// </summary>
        public void LoadPatternTableSettings()
        {
            /*
  This code loads in the pattern table settings.
  Format is as follows:

  Byte #00 - Number of Entries

  Entries are three bytes in size.

  Entry Byte #00 - Memory Address (Multiply by 1000)
  Entry Byte #01 - Number of PPU Rows
  Entry Byte #02 - Bank ?
  */
            int off = 0, numEntries = 0;

            // These are the number of entries in this PPU settings entry.
            foreach (Level lvl in this.Levels)
            {
                lvl.PatternTableSettings = new Collection<PatternTableSettings>();

                numEntries = rom[lvl.PPUSettingsOffset];

                for (int x = 0; x < numEntries; x++)
                {
                    off = lvl.PPUSettingsOffset;
                    PatternTableSettings pat = new PatternTableSettings();
                    pat.MemoryOffset = rom[off + 1 + (x * 3)];
                    pat.RowsToLoad = rom[off + 1 + (x * 3) + 1];
                    pat.PRGBank = rom[off + 1 + (x * 3) + 2];
                    lvl.PatternTableSettings.Add(pat);
                }
            }
        }

        /// <summary>
        /// Determines whether the ROM is a Mega Man 2 ROM.
        /// </summary>
        public void IsMegaman2ROM()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Gets the ROM filename.
        /// </summary>
        public string ROMFilename
        {
            get
            {
                return rom.Filename;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the ROM has been changed.
        /// </summary>
        public bool IsROMChanged
        {
            get
            {
                return rom.IsChanged;
            }
        }

        /// <summary>
        /// Draws the screen at the particular index.
        /// </summary>
        /// <param name="lvlBitmap">The bitmap on which to draw the screen.</param>
        /// <param name="screenID">The screen ID.</param>
        public void DrawScreen(ref System.Drawing.Bitmap lvlBitmap, byte screenID)
        {
            int roomOffset;
            byte tileID;

            roomOffset = this.CurrentLevel.LevelOffset + (screenID * 64);

            Graphics g = Graphics.FromImage(lvlBitmap);
            g.Clear(Color.Black);

            System.Drawing.Rectangle srcRect = new Rectangle(0, 0, 32, 32);

            for (int i = 0; i < 8; i++)
            {
                for (int x = 0; x < 8; x++)
                {
                    tileID = rom[roomOffset + (i * 8) + x];
                    if (this.tilesDrawn[tileID] == false)
                    {
                        this.DrawLevelTile(tileID);
                        this.tilesDrawn[tileID] = true;
                    }

                    srcRect.X = tileID * 32;
                    this.levelTiles.DrawBitmap(ref lvlBitmap, srcRect, new Rectangle(i * 32, x * 32, 32, 32));
                }
            }
            g.Dispose();
        }

        /// <summary>
        /// Draws the screen, by the index stored in CurrentRoomIndex.
        /// </summary>
        /// <param name="lvlBitmap">The bitmap on which to draw the screen.</param>
        public void DrawScreen(ref Bitmap lvlBitmap)
        {
            this.DrawScreen(ref lvlBitmap, this.currentRoomIndex);
        }

        /// <summary>
        /// Draws the tile selector.
        /// </summary>
        /// <param name="tileBitmap">The tile bitmap.</param>
        /// <param name="tileIndex">Index of the tile to start drawing at.</param>
        /// <param name="drawSettings">Whether to draw the solidity settings over the tile.</param>
        public void DrawTileSelector(ref System.Drawing.Bitmap tileBitmap, int tileIndex, bool drawSettings)
        {
            System.Drawing.Rectangle srcRect = new Rectangle(0, 0, 32, 32);

            // Take the index of the tile selector, and render eight tiles.
            for (int x = tileIndex; x < (tileIndex + 8); x++)
            {
                // If the tile hasn't been drawn, then
                // draw it.
                if (this.tilesDrawn[x] == false)
                {
                    this.DrawLevelTile(Convert.ToByte(x));
                }
                srcRect.X = x * 32;
                this.levelTiles.DrawBitmap(ref tileBitmap, srcRect, new Rectangle(0, x * 32, 32, 32));
            }
        }

        /// <summary>
        /// Loads the enemy statistics.
        /// </summary>
        private void LoadEnemyStatistics()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Loads the sound effect list.
        /// </summary>
        private void LoadSoundEffectList()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Loads the room tiles.
        /// </summary>
        /// <param name="roomID">The ID of the room for which to load the tiles.</param>
        private void LoadRoomTiles(int roomID)
        {
            for (int i = 0; i <= 255; i++)
            {
                this.DrawLevelTile(Convert.ToByte(i));
            }
        }
    }
}
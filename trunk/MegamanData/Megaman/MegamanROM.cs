using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.IO;
using System.Linq;
using Nini.Config;
using ROMHackLib;
using ROMHackLib.Graphics.NES;
using ROMHackLib.NES;

namespace MegamanData.Megaman
{
    /// <summary>
    /// Class that represents a Mega Man ROM.
    /// </summary>
    public unsafe class MegamanROM
    {
        /// <summary>
        /// The palette for the current level.
        /// </summary>
        private byte[,] levelPalette = new byte[8, 4];

        /// <summary>
        /// The palette for the current level, after the doors have been triggered.
        /// </summary>
        private byte[,] levelPaletteAfterDoors = new byte[8, 4];

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
        /// A NESRender object, consisting of a font.
        /// </summary>
        private NESRender fontBitmap;

        /// <summary>
        /// The current level index.
        /// </summary>
        private int? currentLevelIndex = null;

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
        /// Gets or sets the palette for the current level, after the doors have been triggered.
        /// </summary>
        public byte[,] LevelPaletteAfterDoors
        {
            get
            {
                return this.levelPaletteAfterDoors;
            }

            set
            {
                this.levelPaletteAfterDoors = value;
            }
        }

        /// <summary>
        /// Gets or sets a list of Mega Man levels.
        /// </summary>
        public Collection<Level> Levels { get; set; }

        /// <summary>
        /// Gets or sets the current level.
        /// </summary>
        public Level CurrentLevel { get; set; }

        /// <summary>
        /// Gets or sets the  index of the current level.
        /// </summary>
        public int? CurrentLevelIndex
        {
            get
            {
                return this.currentLevelIndex;
            }
            set
            {
                if (this.currentLevelIndex != null)
                {
                    // SaveRoomData();
                    this.CurrentLevel.SaveScrollData();
                    this.CurrentLevel.SaveRoomOrder();
                }

                if (value != null)
                {
                    if (value >= this.Levels.Count)
                    {
                        this.currentLevelIndex = 0;
                    }
                    else if (value < 0)
                    {
                        this.currentLevelIndex = this.Levels.Count - 1;
                    }
                    else
                    {
                        this.currentLevelIndex = value;
                    }

                    this.CurrentLevel = this.Levels[currentLevelIndex.Value];
                    this.CurrentLevel.LoadScrollData();

                    // Reinitialise DrawTiles
                    for (int i = 0; i < 256; i++)
                    {
                        this.tilesDrawn[i] = false;
                    }
                    this.CurrentLevel.LoadRoomOrder();

                    this.LoadPatternTable();
                    this.LoadLevelPalette();
                    //// LoadEnemyData();
                    this.CurrentLevel.LoadSpecialObjectData();
                    this.LoadRoomTiles(rom[CurrentLevel.ScreenStartCheck1Offset]);
                    this.CurrentRoomIndex = rom[CurrentLevel.ScreenStartCheck1Offset];
                }
            }
        }

        /// <summary>
        /// Gets the current room ID.
        /// </summary>
        public byte CurrentRoomID
        {
            get
            {
                return this.CurrentLevel.RoomOrder[this.CurrentRoomIndex];
            }
        }

        /// <summary>
        /// Gets or sets the room that is currently displayed in the editor.
        /// </summary>
        public byte CurrentRoomIndex { get; set; }

        /// <summary>
        /// Gets or sets the icon which represents the currently loaded level.
        /// </summary>
        public string Flag { get; set; }

        /// <summary>
        /// Gets or sets a Dictionary object which contains enemy names, indexed by their ID.
        /// </summary>
        public Dictionary<int, string> EnemyNames { get; set; }

        /// <summary>
        /// Gets or sets a Dictionary object which contains TSA settings, indexed by their ID.
        /// </summary>
        public Dictionary<int, string> TSASettingNames { get; set; }

        /// <summary>
        /// Gets or sets a Dictionary object which contains the track names, indexed by their ID.
        /// </summary>
        public Dictionary<int, string> SoundTrackNames { get; set; }

        /// <summary>
        /// Gets or sets a Dictionary object which contains the track names, indexed by their ID.
        /// </summary>
        public Collection<SoundEffect> SoundEffects { get; set; }

        /// <summary>
        /// Gets or sets the  maximum number of enemies that the ROM can hold.
        /// </summary>
        public int MaximumNumberEnemies { get; set; }

        /// <summary>
        /// Gets or sets the  maximum number of special objects that the ROM can hold.
        /// </summary>
        public int MaximumNumberSpecialObjects { get; set; }

        /// <summary>
        /// Gets or sets the offset to start saving the enemy data to in the ROM.
        /// </summary>
        public int StartEnemyData { get; set; }

        /// <summary>
        /// Gets or sets the offset of the start of the table for damage that enemies do to the player.
        /// </summary>
        public int EnemyDamageStartOffset { get; set; }

        /// <summary>
        /// Gets or sets the offset of the start of the table for damage that enemies take from Megaman's normal weapon.
        /// </summary>
        public int EnemyPDamageStartOffset { get; set; }

        /// <summary>
        /// Gets or sets the offset of the start of the table for damage that enemies take from Cutman's weapon.
        /// </summary>
        public int EnemyCDamageStartOffset { get; set; }

        /// <summary>
        /// Gets or sets the offset of the start of the table for damage that enemies take from Iceman's weapon.
        /// </summary>
        public int EnemyIDamageStartOffset { get; set; }

        /// <summary>
        /// Gets or sets the offset of the start of the table for damage that enemies take from Bombman's weapon.
        /// </summary>
        public int EnemyBDamageStartOffset { get; set; }

        /// <summary>
        /// Gets or sets the offset of the start of the table for damage that enemies take from Fireman's weapon.
        /// </summary>
        public int EnemyFDamageStartOffset { get; set; }

        /// <summary>
        /// Gets or sets the offset of the start of the table for damage that enemies take from Elecman's weapon.
        /// </summary>
        public int EnemyEDamageStartOffset { get; set; }

        /// <summary>
        /// Gets or sets the offset of the start of the table for damage that enemies take from Gutsman's weapon.
        /// </summary>
        public int EnemyGDamageStartOffset { get; set; }

        /// <summary>
        /// Gets or sets the offset of the start of the table for enemies health.
        /// </summary>
        public int GlobalEnemyHealthOffset { get; set; }

        /// <summary>
        /// Gets or sets the offset of the start of the table for score received from killing enemies.
        /// </summary>
        public int EnemyScoreStartOffset { get; set; }

        /// <summary>
        /// Gets or sets the offset of the first palette to use, after the player dies.
        /// </summary>
        public int AfterDeath1Offset { get; set; }

        /// <summary>
        /// Gets or sets the offset of the second palette to use, after the player dies.
        /// </summary>
        public int AfterDeath2Offset { get; set; }

        /// <summary>
        /// Gets or sets the offset for the start of the table for weapon colours.
        /// </summary>
        public int WeaponColoursStartOffset { get; set; }

        /// <summary>
        /// Gets or sets the list of offsets in the ROM which contain random data.
        /// </summary>
        public Collection<Statistic> Statistics { get; set; }

        /// <summary>
        /// Gets or sets a list of statistics for each enemy in the game. Covers damage they can take
        /// from certain weapons, the amount of damage they do to Mega Man, and the score
        /// the player receives from killing them.
        /// </summary>
        public Collection<EnemyStatistics> EnemyStats { get; set; }

        /// <summary>
        /// Gets the filename of the ROM.
        /// </summary>
        public string Filename
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
        /// The ROM that is currently loaded.
        /// </summary>
        private INESROMImage rom;

        /// <summary>
        /// Initializes a new instance of the MegamanROM class.
        /// </summary>
        /// <param name="fileName">The filename of the Megaman ROM.</param>
        /// <param name="dataFile">The datafile to use when parsing the ROM.</param>
        /// <param name="assetDirectory">The directory in which the resources used by the library are contained.</param>
        public MegamanROM(string fileName, string dataFile, string assetDirectory)
        {
            // Create a new ROM to load data from
            rom = new INESROMImage(fileName);

            this.assetDirectory = assetDirectory;

            // Load in the external data
            this.LoadDataFile(dataFile);

            // Load in the pattern table settings.
            this.LoadPatternTableSettings();

            this.LoadEnemyDescriptions();
            this.LoadTSASettingsList();
            this.LoadSoundEffectList();
            this.LoadEnemyData();
            this.LoadEnemyStatistics();

            // Draw the tiles
            this.levelTiles = new NESRender(32 * 256, 32);

            // Draw the font.
            this.fontBitmap = new NESRender(184, 8);

            this.fontBitmap.DrawText(0, 0, "0123456789       ABCDEF");

            this.CurrentLevelIndex = 0;
        }

        /// <summary>
        /// Loads in the pattern table settings for all levels.
        /// </summary>
        public void LoadPatternTableSettings()
        {
            int numentries = 0, res = 0;
            PatternTableSettings pat;

            foreach (Level lvl in this.Levels)
            {
                lvl.PatternTableSetting = new Collection<PatternTableSettings>();
                numentries = rom[lvl.PatternTableDataOffset];
                for (int x = 0; x < numentries; x++)
                {
                    pat = new PatternTableSettings();

                    res = Convert.ToInt32("0x" + Convert.ToString((((rom[lvl.PatternTableDataOffset + 1 + (x * 2)] & 0xFC) >> 2) | 0x80), 16) + "00", 16);
                    res = (res - 0x8000) + ((rom[lvl.PatternTableDataOffset + 1 + (x * 2)] & 0x03) * 0x4000);
                    res = res + 0x10;

                    pat.Offset = res;
                    pat.Size = rom[lvl.PatternTableDataOffset + 1 + (x * 2) + 1] * 0x100;

                    lvl.PatternTableSetting.Add(pat);
                }
            }
        }

        /// <summary>
        /// Draws a specified level tile.
        /// </summary>
        /// <param name="index">The index of the tile to draw</param>
        public void DrawLevelTile(byte index)
        {
            byte[,] tilePal = new byte[2, 2];

            tilePal[0, 0] = (byte)(rom[this.CurrentLevel.AttributeOffset + index] & 3);
            tilePal[0, 1] = (byte)((rom[this.CurrentLevel.AttributeOffset + index] >> 2) & 3);
            tilePal[1, 0] = (byte)((rom[this.CurrentLevel.AttributeOffset + index] >> 4) & 3);
            tilePal[1, 1] = (byte)((rom[this.CurrentLevel.AttributeOffset + index] >> 6) & 3);

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

            tilesDrawn[index] = true;
        }

        /// <summary>
        /// Draws the room tiles needed for the level.
        /// </summary>
        /// <param name="room">The ID of the screen to load the tile for.</param>
        public void LoadRoomTiles(byte room)
        {
            int roomOffset;
            byte roomByte;

            roomOffset = rom.PointerToOffset(this.CurrentLevel.RoomPointersOffset +
                (rom[this.CurrentLevel.RoomOrderOffset + this.CurrentRoomIndex] * 2));

            for (int i = 0; i < 8; i++)
            {
                for (int x = 0; x < 8; x++)
                {
                    roomByte = rom[roomOffset + (i * 8) + x];
                    if (this.tilesDrawn[roomByte] == false)
                    {
                        this.DrawLevelTile(roomByte);
                    }
                }
            }
        }

        /// <summary>
        /// Loads a level palette.
        /// </summary>
        public void LoadLevelPalette()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int x = 0; x < 4; x++)
                {
                    this.levelPalette[i, x] = rom[this.CurrentLevel.PaletteOffset + (i * 4) + x];
                }
            }
        }

        /// <summary>
        /// Draws the tile selector.
        /// </summary>
        /// <param name="tileBitmap">The bitmap to draw the tile selector to.</param>
        /// <param name="tileIndex">The index of the first tile to render to the tile selector.</param>
        /// <param name="drawSettings">Whether or not to draw the tile settings.</param>
        public void DrawTileSelector(ref Bitmap tileBitmap, byte tileIndex, bool drawSettings)
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

            if (drawSettings == true)
            {
                this.DrawTSASettings(ref tileBitmap, tileIndex);
            }
        }

        /// <summary>
        /// Draws the screen with the specified index.
        /// </summary>
        /// <param name="screenBitmap">The screen bitmap.</param>
        /// <param name="screenIndex">The index.</param>
        /// <param name="drawObjects">if set to true, the objects are drawn.</param>
        /// <param name="enemyColour">The enemy colour.</param>
        /// <param name="specialObjColour">The special object colour.</param>
        /// <param name="beamdownColour">The beam down colour.</param>
        public void DrawScreen(ref Bitmap screenBitmap, byte screenIndex, bool drawObjects, Color enemyColour, Color specialObjColour, Color beamdownColour)
        {
            byte tileID;

            using (Graphics g = Graphics.FromImage(screenBitmap))
            {
                g.Clear(Color.Black);

                System.Drawing.Rectangle sourceRectangle = new Rectangle(0, 0, 32, 32);

                for (int i = 0; i < 8; i++)
                {
                    for (int x = 0; x < 8; x++)
                    {
                        tileID = this.CurrentLevel.GetLevelData(screenIndex, x, i);

                        if (this.tilesDrawn[tileID] == false)
                        {
                            this.DrawLevelTile(tileID);
                        }

                        sourceRectangle.X = tileID * 32;
                        this.levelTiles.DrawBitmap(ref screenBitmap, sourceRectangle, new Rectangle(i * 32, x * 32, 32, 32));
                    }
                }

                if (drawObjects)
                {
                    // Now render any enemies that are on this screen.
                    List<Enemy> screenEnemies = this.CurrentLevel.Enemies.Where(e => e.ScreenID == screenIndex).ToList();

                    // Keep a count of the number of enemies rendered.
                    int totalRendered = 0;

                    foreach (Enemy enemy in screenEnemies)
                    {
                        g.FillRectangle(new SolidBrush(enemyColour), new Rectangle(enemy.X, enemy.Y, 16, 16));
                        string enemyHex = enemy.ID.ToHex().ToUpper();
                        byte[] enemyIDArr = enemyHex.ToByteArray();

                        string enemyIndex = totalRendered.ToHex().ToUpper();
                        byte[] enemyIndexArr = enemyIndex.ToByteArray();

                        // Render the ID of the 
                        this.fontBitmap.DrawBitmap(ref screenBitmap, new Rectangle((enemyIDArr[0] - 48) * 8, 0, 8, 8), new Rectangle(enemy.X, enemy.Y, 8, 8));
                        this.fontBitmap.DrawBitmap(ref screenBitmap, new Rectangle((enemyIDArr[1] - 48) * 8, 0, 8, 8), new Rectangle(enemy.X + 8, enemy.Y, 8, 8));
                        this.fontBitmap.DrawBitmap(ref screenBitmap, new Rectangle((enemyIndexArr[1] - 48) * 8, 0, 8, 8), new Rectangle(enemy.X, enemy.Y + 8, 8, 8));

                        totalRendered++;
                    }

                    // Now, render the special objects that are on this screen.
                    List<SpecialObject> screenObjects = this.CurrentLevel.SpecialObjects.Where(s => s.ScreenID == screenIndex).ToList();

                    totalRendered = 0;

                    foreach (SpecialObject obj in screenObjects)
                    {
                        g.DrawRectangle(new Pen(specialObjColour), new Rectangle(obj.X1, obj.Y1, obj.Width, obj.Height));

                        // Create the ID.
                        string objHex = ((int)obj.ID).ToHex().ToUpper();
                        byte[] objIDArray = objHex.ToByteArray();
                        this.fontBitmap.DrawBitmap(ref screenBitmap, new Rectangle((objIDArray[0] - 48) * 8, 0, 8, 8), new Rectangle(obj.X1, obj.Y1, 8, 8));
                        this.fontBitmap.DrawBitmap(ref screenBitmap, new Rectangle((objIDArray[1] - 48) * 8, 0, 8, 8), new Rectangle(obj.X1 + 8, obj.Y1, 8, 8));
                    }

                    if (rom[CurrentLevel.ScreenStartCheck1Offset] == screenIndex)
                    {
                        byte[] idarray = "B1".ToByteArray();
                        g.FillRectangle(new SolidBrush(beamdownColour), new Rectangle(128, CurrentLevel.BeamDown1Coord, 16, 16));

                        this.fontBitmap.DrawBitmap(ref screenBitmap, new Rectangle((idarray[0] - 48) * 8, 0, 8, 8), new Rectangle(128, CurrentLevel.BeamDown1Coord, 8, 8));
                        this.fontBitmap.DrawBitmap(ref screenBitmap, new Rectangle((idarray[1] - 48) * 8, 0, 8, 8), new Rectangle(128 + 8, CurrentLevel.BeamDown1Coord, 8, 8));
                    }

                    if (rom[CurrentLevel.ScreenStartCheck2Offset] == screenIndex)
                    {
                        byte[] idarray = "B2".ToByteArray();
                        g.FillRectangle(new SolidBrush(beamdownColour), new Rectangle(128, CurrentLevel.BeamDown2Coord, 16, 16));

                        this.fontBitmap.DrawBitmap(ref screenBitmap, new Rectangle((idarray[0] - 48) * 8, 0, 8, 8), new Rectangle(128, CurrentLevel.BeamDown2Coord, 8, 8));
                        this.fontBitmap.DrawBitmap(ref screenBitmap, new Rectangle((idarray[1] - 48) * 8, 0, 8, 8), new Rectangle(128 + 8, CurrentLevel.BeamDown2Coord, 8, 8));
                    }

                    if (rom[CurrentLevel.ScreenStartCheck3Offset] == screenIndex)
                    {
                        byte[] idarray = "B3".ToByteArray();

                        g.FillRectangle(new SolidBrush(beamdownColour), new Rectangle(128, CurrentLevel.BeamDown3Coord, 16, 16));

                        this.fontBitmap.DrawBitmap(ref screenBitmap, new Rectangle((idarray[0] - 48) * 8, 0, 8, 8), new Rectangle(128, CurrentLevel.BeamDown3Coord, 8, 8));
                        this.fontBitmap.DrawBitmap(ref screenBitmap, new Rectangle((idarray[1] - 48) * 8, 0, 8, 8), new Rectangle(128 + 8, CurrentLevel.BeamDown3Coord, 8, 8));
                    }
                }
            }
        }

        /// <summary>
        /// Draws the current screen.
        /// </summary>
        /// <param name="lvlBitmap">The bitmap to draw the screen onto.</param>
        /// <param name="drawObjects">if set to true, the objects are drawn.</param>
        /// <param name="enemyColour">The enemy colour.</param>
        /// <param name="specialObjColour">The special object colour.</param>
        /// <param name="beamdownColour">The beam down colour.</param>
        public void DrawScreen(ref Bitmap lvlBitmap, bool drawObjects, Color enemyColour, Color specialObjColour, Color beamdownColour)
        {
            this.DrawScreen(ref lvlBitmap, this.CurrentLevel.RoomOrder[CurrentRoomIndex], true, enemyColour, specialObjColour, beamdownColour);
        }

        /// <summary>
        /// Detects the object under the mouse.
        /// </summary>
        /// <param name="x">The x coordinate of the mouse pointer.</param>
        /// <param name="y">The y coordinate of the mouse pointer.</param>
        /// <returns>An ObjectInformation structure, containing information about the object under the mouse. If any.</returns>
        public ObjectInformation DetectObjectUnderMouse(int x, int y)
        {
            ObjectInformation objInfo = new ObjectInformation();

            objInfo.Type = ObjectType.None;
            objInfo.ID = this.GetEnemyUnderMouse(x, y);
            if (objInfo.ID != null)
            {
                objInfo.Type = ObjectType.Enemy;
            }

            if (objInfo.ID != null)
            {
                objInfo.ID = this.GetSpecialObjectUnderMouse(x, y);
                if (objInfo.ID != null)
                {
                    objInfo.Type = ObjectType.SpecialObject;
                }
                if (objInfo.ID != null)
                {
                    objInfo.ID = this.GetBeamdownUnderMouse(x, y);
                    if (objInfo.ID != null)
                    {
                        objInfo.Type = ObjectType.BeamDown;
                    }
                }
            }

            return objInfo;
        }

        /// <summary>
        /// Draws the NES palette colours.
        /// </summary>
        /// <param name="bitmap">The bitmap to draw the colours to.</param>
        public void DrawNESColours(ref Bitmap bitmap)
        {
            /*  ROM.DrawNESColours(pBitmap);*/
        }

        /// <summary>
        /// Draws the palette data to a specified bitmap.
        /// </summary>
        /// <param name="bitmap">The bitmap.</param>
        /// <param name="paletteData">The palette data.</param>
        /// <param name="paletteSize">Size of the palette.</param>
        public void DrawPaletteData(ref Bitmap bitmap, byte* paletteData, int paletteSize)
        {
            /*var
  temp : ^byte;
  i : Integer;
begin
  if pBitmap.Width < pPalSize * 25 then exit;

  temp := pPalData;

  for i := 0 to pPalSize - 1 do
  begin
    pBitmap.FillRect(i*25,0,(i * 25)+25,25, ROM.NESPal[temp^]);
    inc(temp);
  end;
*/
        }

        /// <summary>
        /// Draws the pattern table.
        /// </summary>
        /// <param name="bitmap">The bitmap.</param>
        /// <param name="offset">The offset.</param>
        /// <param name="paletteIndex">Index of the palette.</param>
        public void DrawPatternTable(ref Bitmap bitmap, int offset, int paletteIndex)
        {
            /*var
  i,x : Integer;
begin
  for i := 0 to 15 do
    for x := 0 to 15 do
      ROM.DrawNESTile(@_PatternTable[pTable + (i*16 + x) * 16],pBitmap,x*8,i*8,@Palette[pPal,0]);*/
        }

        /// <summary>
        /// Draws the sprite change data.
        /// </summary>
        /// <param name="bitmap">The bitmap.</param>
        /// <param name="offset">The offset from where to get the data.</param>
        public void DrawSpriteChangeData(ref Bitmap bitmap, int offset)
        {
            NESRender render = new NESRender(bitmap.Width, bitmap.Height);

            for (int i = 0; i < 16; i++)
            {
                fixed (byte* palpointer = &this.levelPalette[4, 0])
                {
                    fixed (byte* tiledata = &rom.RawROM[offset + (i * 0x10)])
                    {
                        render.DrawTile(i * 8, 0, tiledata, palpointer);
                    }
                }
            }

            render.DrawBitmap(ref bitmap);
        }

        /// <summary>
        /// Draws the TSA pattern table.
        /// </summary>
        /// <param name="bitmap">The bitmap.</param>
        /// <param name="paletteIndex">Index of the palette.</param>
        public void DrawTSAPatternTable(ref Bitmap bitmap, int paletteIndex)
        {
            /*var
  i,x : Integer;
  pal : Pointer;
begin

{  if (Room > CurrLevel.Properties['DoorsWorkFrom'].Value) and (CurrLevel.Properties.ValueExists('AfterDoorsPalette') = true) then
    pal := @AfterDoorsPalette[pPal,0]
  else}
    pal := @Palette[pPal,0];

  for x := 0 to 7 do
    for i := 0 to 31 do
      ROM.DrawNESTile(@_PatternTable[$1000 + (x*32 + i) * 16],pBitmap,(i div 2) *8,(x*16)+(i mod 2) *8,Pal);*/
        }

        /// <summary>
        /// Edits the TSA data for a block.
        /// </summary>
        /// <param name="blockID">The block ID.</param>
        /// <param name="x">The x coordinate of the block quadrant.</param>
        /// <param name="y">The y coordinate of the block quadrant.</param>
        /// <param name="newTileID">The new tile ID.</param>
        public void EditTSA(byte blockID, byte x, byte y, byte newTileID)
        {
            int tileOffset = this.CurrentLevel.TSAOffset + (blockID * 4) + (x * 2) + y;
            byte tempSolidity = Convert.ToByte(rom[tileOffset] & 0xC0);
            rom[tileOffset] = Convert.ToByte(newTileID + tempSolidity);
            this.DrawLevelTile(blockID);
        }

        /// <summary>
        /// Gets the beamdown under mouse.
        /// </summary>
        /// <param name="x">The X coordinate of the mouse pointer.</param>
        /// <param name="y">The Y coordinate of the mouse pointer.</param>
        /// <returns>The ID of the beamdown point, if there is one under the mouse. If not, -1 is returned.</returns>
        public int? GetBeamdownUnderMouse(int x, int y)
        {
            if ((this.CurrentRoomIndex != rom[this.CurrentLevel.ScreenStartCheck1Offset]) &&
                (this.CurrentRoomIndex != rom[this.CurrentLevel.ScreenStartCheck2Offset]) &&
                (this.CurrentRoomIndex != rom[this.CurrentLevel.ScreenStartCheck3Offset]))
            {
                return null;
            }

            if ((x >= 128) && (x <= 144))
            {
                if (this.CurrentRoomIndex == rom[this.CurrentLevel.ScreenStartCheck1Offset])
                {
                    if ((y >= this.CurrentLevel.BeamDown1Coord) && (y <= this.CurrentLevel.BeamDown1Coord + 16))
                    {
                        return 0;
                    }
                }

                if (this.CurrentRoomIndex == rom[this.CurrentLevel.ScreenStartCheck2Offset])
                {
                    if ((y >= this.CurrentLevel.BeamDown2Coord) && (y <= this.CurrentLevel.BeamDown2Coord + 16))
                    {
                        return 1;
                    }
                }

                if (this.CurrentRoomIndex == rom[this.CurrentLevel.ScreenStartCheck3Offset])
                {
                    if ((y >= this.CurrentLevel.BeamDown3Coord) && (y <= this.CurrentLevel.BeamDown3Coord + 16))
                    {
                        return 2;
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Retrieves the ID of the special object, under the mouse.
        /// </summary>
        /// <param name="x">The X coordinate of the mouse.</param>
        /// <param name="y">The Y coordinate of the mouse.</param>
        /// <returns>If a special object is under the mouse, the ID of the special object. Otherwise null.</returns>
        public int? GetSpecialObjectUnderMouse(int x, int y)
        {
            if (this.CurrentLevel.SpecialObjects == null)
            {
                return null;
            }

            if (this.CurrentLevel.SpecialObjects.Count == 0)
            {
                return null;
            }

            for (int i = 0; i < this.CurrentLevel.SpecialObjects.Count; i++)
            {
                if (this.CurrentLevel.SpecialObjects[i].ScreenID == this.CurrentRoomIndex)
                {
                    if ((x >= this.CurrentLevel.SpecialObjects[i].X1) && (x <= this.CurrentLevel.SpecialObjects[i].X2))
                    {
                        if ((y >= this.CurrentLevel.SpecialObjects[i].Y1) && (y <= this.CurrentLevel.SpecialObjects[i].Y2))
                        {
                            return i;
                        }
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Retrieves the ID of the enemy under mouse. (If any)
        /// </summary>
        /// <param name="x">The X coordinate of the mouse.</param>
        /// <param name="y">The Y coordinate of the mouse.</param>
        /// <returns>The ID of the enemy under the mouse. -1 if there isn't any.</returns>
        public int? GetEnemyUnderMouse(int x, int y)
        {
            if (this.CurrentLevel.Enemies == null)
            {
                return null;
            }

            for (int i = 0; i < this.CurrentLevel.Enemies.Count; i++)
            {
                if (this.CurrentLevel.Enemies[i].ScreenID == this.CurrentRoomIndex)
                {
                    if ((x >= this.CurrentLevel.Enemies[i].X) && (x <= this.CurrentLevel.Enemies[i].X + 16))
                    {
                        if ((y >= this.CurrentLevel.Enemies[i].Y) && (y <= this.CurrentLevel.Enemies[i].Y + 16))
                        {
                            return i;
                        }
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Increments a quadrant of a tile's attributes.
        /// </summary>
        /// <param name="tileID">The ID of the tile for which to increment.</param>
        /// <param name="x">The X coordinate of the quadrant of the tile to increment.</param>
        /// <param name="y">The Y coordinate of the quadrant of the tile to increment.</param>
        public void IncrementTileAttributes(byte tileID, byte x, byte y)
        {
            byte[,] tilePal = new byte[1, 1];

            tilePal[0, 0] = Convert.ToByte(rom[this.CurrentLevel.AttributeOffset + tileID] & 0x3);
            tilePal[1, 0] = Convert.ToByte((rom[this.CurrentLevel.AttributeOffset + tileID] >> 2) & 0x3);
            tilePal[0, 1] = Convert.ToByte((rom[this.CurrentLevel.AttributeOffset + tileID] >> 4) & 0x3);
            tilePal[1, 1] = Convert.ToByte((rom[this.CurrentLevel.AttributeOffset + tileID] >> 6) & 0x3);

            if (tilePal[x, y] == 3)
            {
                tilePal[x, y] = 0;
            }
            else
            {
                tilePal[x, y]++;
            }

            rom[this.CurrentLevel.AttributeOffset + tileID] = Convert.ToByte((tilePal[0, 0] & 3) + ((tilePal[1, 0] & 3) << 2) + ((tilePal[0, 1] & 3) << 4) + ((tilePal[1, 1] & 3) << 6));
            this.DrawLevelTile(tileID);
        }

        /// <summary>
        /// Increments the selected tile's solidity attribute. If the attribute is set to 3, it resets to zero.
        /// </summary>
        /// <param name="tileID">The ID of the tile.</param>
        /// <param name="x">The X co-ordinate of the tile.</param>
        /// <param name="y">The Y co-ordinate of the tile.</param>
        public void IncrementTileSolidityAttributes(byte tileID, byte x, byte y)
        {
            byte tempSolidity;
            byte tempTile;
            int tileOffset;

            tileOffset = this.CurrentLevel.TSAOffset + (tileID * 4) + (x * 2) + x;
            tempSolidity = Convert.ToByte((rom[tileOffset] & 0xC0) >> 6);
            tempTile = Convert.ToByte(rom[tileOffset] & 0x3f);
            if (tempSolidity == 3)
            {
                tempSolidity = 0;
            }
            else
            {
                tempSolidity++;
            }
            rom[tileOffset] = Convert.ToByte(tempTile + (tempSolidity << 6));
        }

        /// <summary>
        /// Gets the total number of enemies in the ROM.
        /// </summary>
        /// <returns>An integer with the number of enemies in the ROM.</returns>
        public int RetrieveTotalNumberEnemies()
        {
            int enemyamount = 0;
            foreach (Level lvl in this.Levels)
            {
                enemyamount += lvl.Enemies.Count;
            }

            return enemyamount;
        }

        /// <summary>
        /// Refreshes the on screen tiles.
        /// </summary>
        public void RefreshOnScreenTiles()
        {
            // Loop through the tilesDrawn array, and reset all elements to
            // not drawn. This means that when the user flicks to other screens,
            // they won't get tiles with totally different palettes.
            for (int i = 0; i < this.tilesDrawn.Length; i++)
            {
                this.tilesDrawn[i] = false;
            }

            // Draw all the tiles on the current screen.
            this.LoadRoomTiles(this.CurrentRoomIndex);
        }

        /// <summary>
        /// Adds the scroll data to the current level.
        /// </summary>
        /// <param name="index">The index where to insert the data..</param>
        /// <returns>A Boolean value as to whether the addition was successful.</returns>
        public bool AddScrollData(int index)
        {
            int pos;
            int othersize;
            bool result = false;

            for (int i = 0; i < this.Levels.Count; i++)
            {
                if (i != this.CurrentLevelIndex)
                {
                    // 0x2F
                    pos = this.Levels[i].ScrollOffset + rom[this.Levels[i].ScrollStartOffset];
                    othersize = 0;
                    while (rom[pos] != 0x00)
                    {
                        othersize++;
                        pos++;
                    }
                    othersize++;

                    // TODO: check this works!
                    if ((this.CurrentLevel.ScrollData.Count + othersize) < 0x2F)
                    {
                        if (index > -1)
                        {
                            this.CurrentLevel.ScrollData.Insert(index, 0);
                        }
                        result = true;
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Adds a special object to the current level.
        /// </summary>
        /// <param name="screenID">The screen ID in which to add the special object.</param>
        /// <returns>A Boolean value as to whether the addition was successful.</returns>
        public bool AddSpecialObject(byte screenID)
        {
            SpecialObject specobj;

            if (this.CurrentLevel.SpecialObjects.Count == this.MaximumNumberSpecialObjects)
            {
                return false;
            }

            specobj = new SpecialObject();
            specobj.X1 = screenID;

            // Make the default a G-Block.
            specobj.ID = SpecialObjectTypes.GBlock;

            // Set the width and the height.
            specobj.Width = 0x20;
            specobj.Height = 0x20;
            specobj.X2 = specobj.X1 + specobj.Width;
            specobj.Y2 = specobj.Y1 + specobj.Height;
            specobj.ScreenID = screenID;
            this.CurrentLevel.SpecialObjects.Add(specobj);
            rom.IsChanged = true;
            return true;
        }

        /// <summary>
        /// Adds an enemy to the current level.
        /// </summary>
        /// <param name="screenID">The screen ID.</param>
        /// <returns>A Boolean value as to whether the addition was successful.</returns>
        public bool AddEnemy(byte screenID)
        {
            if (this.RetrieveTotalNumberEnemies() >= this.MaximumNumberEnemies)
            {
                return false;
            }

            Enemy enemy = new Enemy();
            enemy.ScreenID = screenID;
            this.CurrentLevel.Enemies.Add(enemy);
            rom.IsChanged = true;
            return true;
        }

        /// <summary>
        /// Renders the palette.
        /// </summary>
        /// <param name="bitmap">The bitmap.</param>
        /// <param name="pal">The palette to render.</param>
        public void RenderPalette(ref Bitmap bitmap, ref ROMHackLib.Graphics.NES.NESRender pal)
        {
            rom.RenderPalette(ref bitmap, ref pal);
        }

        /// <summary>
        /// Gets the current level's current selected room's level data, at specified co-ordinates.
        /// </summary>
        /// <param name="row">The row number.</param>
        /// <param name="column">The column number.</param>
        /// <returns>The level data at the specified co-ordinate.</returns>
        public byte GetLevelData(int row, int column)
        {
            return this.CurrentLevel.GetLevelData(CurrentLevel.RoomOrder[CurrentRoomIndex], row, column);
        }

        /// <summary>
        /// Sets the current level's current selected room's level data, at specified co-ordinates.
        /// </summary>
        /// <param name="row">The row number.</param>
        /// <param name="column">The column number.</param>
        /// <param name="tileID">The tile ID.</param>
        public void SetLevelData(int row, int column, byte tileID)
        {
            this.CurrentLevel.SetLevelData(this.CurrentRoomIndex, row, column, tileID);
        }

        /// <summary>
        /// Loads the TSA settings list.
        /// </summary>
        private void LoadTSASettingsList()
        {
            this.TSASettingNames = rom.ReadColonSeparatedFile(Path.Combine(this.assetDirectory, "Megaman" + Path.DirectorySeparatorChar + "tsaset.dat"));
        }

        /// <summary>
        /// Loads in the pattern table for the current level.
        /// </summary>
        private void LoadPatternTable()
        {
            int patpos = 0;

            for (int i = 0; i < this.patternTable.Length; i++)
            {
                this.patternTable[i] = 0;
            }

            foreach (PatternTableSettings pat in this.CurrentLevel.PatternTableSetting)
            {
                for (int x = 0; x < pat.Size; x++)
                {
                    this.patternTable[patpos + x] = rom[pat.Offset + x];
                }
                patpos += pat.Size;
            }
        }

        /// <summary>
        /// Draws the TSA settings to a bitmap.
        /// </summary>
        /// <param name="bit">The bitmap to draw the TSA settings to.</param>
        /// <param name="blockID">The ID of the block at which to load, and render the settings for.</param>
        private void DrawTSASettings(ref Bitmap bit, byte blockID)
        {
            byte solidity;
            Bitmap tempNumbers = new Bitmap(Path.Combine(this.assetDirectory, "numbers.bmp"));
            Graphics g = Graphics.FromImage(bit);
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            for (int i = 0; i < 8; i++)
            {
                solidity = Convert.ToByte((rom[this.CurrentLevel.TSAOffset + ((blockID + i) * 4)] & 0xC0) >> 6);
                g.DrawImage(tempNumbers, 0, i * 32, new Rectangle(solidity * 8, 0, 8, 8), GraphicsUnit.Pixel);
                solidity = Convert.ToByte((rom[this.CurrentLevel.TSAOffset + ((blockID + i) * 4) + 1] & 0xC0) >> 6);
                g.DrawImage(tempNumbers, 0, (i * 32) + 16, new Rectangle(solidity * 8, 0, 8, 8), GraphicsUnit.Pixel);
                solidity = Convert.ToByte((rom[this.CurrentLevel.TSAOffset + ((blockID + i) * 4) + 2] & 0xC0) >> 6);
                g.DrawImage(tempNumbers, 16, (i * 32), new Rectangle(solidity * 8, 0, 8, 8), GraphicsUnit.Pixel);
                solidity = Convert.ToByte((rom[this.CurrentLevel.TSAOffset + ((blockID + i) * 4) + 3] & 0xC0) >> 6);
                g.DrawImage(tempNumbers, 16, (i * 32) + 16, new Rectangle(solidity * 8, 0, 8, 8), GraphicsUnit.Pixel);
            }
            g.Dispose();
        }

        /// <summary>
        /// Loads the enemy descriptions.
        /// </summary>
        private void LoadEnemyDescriptions()
        {
            this.EnemyNames = rom.ReadColonSeparatedFile(Path.Combine(this.assetDirectory, "Megaman" + Path.DirectorySeparatorChar + "enemy.dat"));
        }

        /// <summary>
        /// Loads the data file.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        private void LoadDataFile(string fileName)
        {
            IniConfigSource ini = new IniConfigSource(@fileName);
            ini.CaseSensitive = false;

            int numberLevels;

            numberLevels = ini.Configs["General"].GetInt("NumberOfLevels");
            this.MaximumNumberEnemies = ini.Configs["General"].GetHex("MaxEnemies");
            this.MaximumNumberSpecialObjects = ini.Configs["General"].GetHex("MaxSpecObj");
            this.StartEnemyData = ini.Configs["General"].GetHex("StartEnemyData");
            this.Flag = ini.Configs["General"].GetString("flag");

            this.WeaponColoursStartOffset = ini.Configs["General"].GetHex("WeaponColours");
            this.AfterDeath1Offset = ini.Configs["General"].GetHex("AfterDeath1");
            this.AfterDeath2Offset = ini.Configs["General"].GetHex("AfterDeath2");

            // Enemy Information
            this.EnemyDamageStartOffset = ini.Configs["Enemy"].GetHex("EnemyDamage");
            this.EnemyPDamageStartOffset = ini.Configs["Enemy"].GetHex("EnemyPDamage");
            this.EnemyCDamageStartOffset = ini.Configs["Enemy"].GetHex("EnemyCDamage");
            this.EnemyIDamageStartOffset = ini.Configs["Enemy"].GetHex("EnemyIDamage");
            this.EnemyBDamageStartOffset = ini.Configs["Enemy"].GetHex("EnemyBDamage");
            this.EnemyFDamageStartOffset = ini.Configs["Enemy"].GetHex("EnemyFDamage");
            this.EnemyEDamageStartOffset = ini.Configs["Enemy"].GetHex("EnemyEDamage");
            this.EnemyGDamageStartOffset = ini.Configs["Enemy"].GetHex("EnemyGDamage");
            this.EnemyScoreStartOffset = ini.Configs["Enemy"].GetHex("EnemyScore");
            this.GlobalEnemyHealthOffset = ini.Configs["Enemy"].GetHex("GlobalEnemyHealth");

            // Load in the statistics.
            this.Statistics = new Collection<Statistic>();
            int statisticsAmount = ini.Configs["Statistics"].GetInt("Amount");

            for (int i = 0; i < statisticsAmount; i++)
            {
                Statistic stat = new Statistic();
                stat.Name = ini.Configs["Statistics"].GetString("Stat" + i.ToString() + "Name");
                stat.Offset = ini.Configs["Statistics"].GetHex("Stat" + i.ToString() + "Offset");
                if (ini.Configs["Statistics"].Contains("Stat" + i.ToString() + "Max"))
                {
                    stat.MaximumValue = ini.Configs["Statistics"].GetHex("Stat" + i.ToString() + "Max");
                }
                if (ini.Configs["Statistics"].Contains("Stat" + i.ToString() + "List"))
                {
                    stat.List = ini.Configs["Statistics"].GetString("Stat" + i.ToString() + "List");
                }
                this.Statistics.Add(stat);
            }

            if (this.Levels == null)
            {
                this.Levels = new Collection<Level>();
            }

            for (int i = 0; i < numberLevels; i++)
            {
                Level lvl = new Level(ref rom);
                IConfig col = ini.Configs["Level" + i];
                lvl.TSAOffset = col.GetHex("TSA");
                lvl.AttributeOffset = col.GetHex("Attribute");
                lvl.RoomOrderOffset = col.GetHex("RoomOrder");
                lvl.RoomPointersOffset = col.GetHex("RoomPointers");
                lvl.PaletteOffset = col.GetHex("Palette");
                lvl.NumberOfTiles = col.GetHex("NumberOfTiles");
                lvl.Name = col.GetString("Name");
                lvl.EnemyPointerOffset = col.GetHex("EnemyDataPo");
                lvl.ScrollOffset = col.GetHex("Scroll");
                lvl.ScrollStartOffset = col.GetHex("ScrollPos");
                lvl.EnemyCheckPoint1Offset = col.GetHex("CheckPo1");
                lvl.EnemyCheckPoint2Offset = col.GetHex("CheckPo2");
                lvl.PatternTableDataOffset = col.GetHex("PatternTableData");
                lvl.MusicIndexOffset = col.GetHex("Music");
                lvl.TSASetting0Offset = col.GetHex("TSASetting0Offset");
                lvl.TSASetting1Offset = col.GetHex("TSASetting1Offset");
                lvl.TSASetting2Offset = col.GetHex("TSASetting2Offset");
                lvl.TSASetting3Offset = col.GetHex("TSASetting3Offset");
                lvl.BeamDown1Offset = col.GetHex("BeamDown1Offset");
                lvl.BeamDown2Offset = col.GetHex("BeamDown2Offset");
                lvl.BeamDown3Offset = col.GetHex("BeamDown3Offset");
                lvl.ScreenStartCheck1Offset = col.GetHex("RoomOrderPos");
                lvl.ScreenStartCheck2Offset = col.GetHex("ScreenStartCheck2");
                lvl.ScreenStartCheck3Offset = col.GetHex("ScreenStartCheck3");
                lvl.ScrollPosChk1Offset = col.GetHex("ScrollPosChk1");
                lvl.ScrollPosChk2Offset = col.GetHex("ScrollPosChk2");
                lvl.DoorsFromOffset = col.GetHex("DoorsFromOffset");
                lvl.RoomOrderFix1CheckOffset = col.GetHex("RoomOrderFix1Check");
                lvl.RoomOrderFix2CheckOffset = col.GetHex("RoomOrderFix2Check");
                lvl.ScreenStartChk2TrigOffset = col.GetHex("ScreenStartChk2Trig");
                lvl.ScreenStartChk3TrigOffset = col.GetHex("ScreenStartChk3Trig");
                lvl.RoomOrderFix1Check2Offset = col.GetHex("RoomOrderFix1Check2");
                lvl.RoomOrderFix2Check2Offset = col.GetHex("RoomOrderFix2Check2");
                lvl.SpriteChangePointersOffset = col.GetHex("SpriteChangePointers");
                lvl.SpriteChangeDataOffset = col.GetHex("SpriteChangeData");
                if (col.Contains("AfterDoorsPalette"))
                {
                    lvl.AfterDoorsPaletteOffset = col.GetHex("AfterDoorsPalette");
                }
                if (col.Contains("ColourCycles"))
                {
                    lvl.ColourCyclesOffset = col.GetHex("ColourCycles");
                }
                lvl.BossPBlaster = col.GetHex("BossDamageOffset");
                lvl.BossCut = col.GetHex("BossDamageOffset") + 1;
                lvl.BossIce = col.GetHex("BossDamageOffset") + 2;
                lvl.BossBomb = col.GetHex("BossDamageOffset") + 3;
                lvl.BossFire = col.GetHex("BossDamageOffset") + 4;
                lvl.BossElec = col.GetHex("BossDamageOffset") + 5;
                lvl.BossGuts = col.GetHex("BossDamageOffset") + 6;
                lvl.ProjectileDamage = col.GetHex("ProjectileDamage");
                lvl.SpecObjOffset = col.GetHex("SpecObjOffset");
                lvl.LevelLength();

                this.Levels.Add(lvl);
            }

            // Create a new instance of the sound effects dictionary.
            this.SoundEffects = new Collection<SoundEffect>();

            IConfig colsound = ini.Configs["SoundEffects"];

            // Load in the amount of sound effects.
            int secount = colsound.GetInt("Amount");
            for (int i = 0; i < secount; i++)
            {
                string _sename = colsound.GetString("SE" + i.ToString() + "Name");
                int _seoffset = colsound.GetHex("SE" + i.ToString() + "Offset");
                this.SoundEffects.Add(new SoundEffect(ref rom, _sename, _seoffset));
            }
        }

        /// <summary>
        /// Loads the sound effect list.
        /// </summary>
        private void LoadSoundEffectList()
        {
            this.SoundTrackNames = rom.ReadColonSeparatedFile(Path.Combine(this.assetDirectory, "Megaman" + Path.DirectorySeparatorChar + "se.dat"));
        }

        /// <summary>
        /// Loads the enemy data.
        /// </summary>
        private void LoadEnemyData()
        {
            int pos = 0;
            Enemy enemy;

            foreach (Level lvl in this.Levels)
            {
                pos = rom.PointerToOffset(lvl.EnemyPointerOffset, 0x18010);
                lvl.Enemies = new Collection<Enemy>();
                while (rom[pos] < 0xFF)
                {
                    enemy = new Enemy();
                    enemy.ScreenID = rom[pos];
                    enemy.X = rom[pos + 1];
                    enemy.Y = rom[pos + 2];
                    enemy.ID = rom[pos + 2];
                    enemy.CheckPointStatus = 0;
                    lvl.Enemies.Add(enemy);
                    pos = pos + 4;
                }

                if (lvl.EnemyCheckPoint1Offset < lvl.Enemies.Count)
                {
                    lvl.Enemies[lvl.EnemyCheckPoint1Offset].CheckPointStatus = 1;
                }
                if (lvl.EnemyCheckPoint2Offset < lvl.Enemies.Count)
                {
                    lvl.Enemies[lvl.EnemyCheckPoint2Offset].CheckPointStatus = 2;
                }
            }
        }

        /// <summary>
        /// Loads the enemy statistics.
        /// </summary>
        private void LoadEnemyStatistics()
        {
            this.EnemyStats = new Collection<EnemyStatistics>();
            EnemyStatistics enemystat = null;
            for (int i = 0; i < 0x3b; i++)
            {
                enemystat = new EnemyStatistics();
                enemystat.PWeaponDamage = this.rom[this.EnemyPDamageStartOffset + i];
                enemystat.CWeaponDamage = this.rom[this.EnemyCDamageStartOffset + i];
                enemystat.IWeaponDamage = this.rom[this.EnemyIDamageStartOffset + i];
                enemystat.BWeaponDamage = this.rom[this.EnemyBDamageStartOffset + i];
                enemystat.FWeaponDamage = this.rom[this.EnemyFDamageStartOffset + i];
                enemystat.EWeaponDamage = this.rom[this.EnemyEDamageStartOffset + i];
                enemystat.GWeaponDamage = this.rom[this.EnemyGDamageStartOffset + i];
                enemystat.PlayerDamage = this.rom[this.EnemyDamageStartOffset + i];
                enemystat.Score = this.rom[this.EnemyScoreStartOffset + i];

                this.EnemyStats.Add(enemystat);
            }
        }
    }
}
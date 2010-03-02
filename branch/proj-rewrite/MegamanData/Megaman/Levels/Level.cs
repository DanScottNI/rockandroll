using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Text;
using MegamanData.Megaman.Graphics;
using MegamanData.Megaman.Levels;
using ROMHackLib.NES;

namespace MegamanData.Megaman.Levels
{
    /// <summary>
    /// Represents a level in Mega Man.
    /// </summary>
    public unsafe class Level
    {
        /// <summary>
        /// Gets or sets the name of the level.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the offset of the TSA data.
        /// </summary>
        public int TSAOffset { get; set; }

        /// <summary>
        /// Gets or sets the offset of the attribute data.
        /// </summary>
        public int AttributeOffset { get; set; }

        /// <summary>
        /// Gets or sets the offset of the pattern table data.
        /// </summary>
        public int PatternTableDataOffset { get; set; }

        /// <summary>
        /// Gets or sets the offset of the first TSA setting.
        /// </summary>
        public int TSASetting0Offset { get; set; }

        /// <summary>
        /// Gets or sets the offset of the second TSA setting.
        /// </summary>
        public int TSASetting1Offset { get; set; }

        /// <summary>
        /// Gets or sets the offset of the third TSA setting.
        /// </summary>
        public int TSASetting2Offset { get; set; }

        /// <summary>
        /// Gets or sets the offset of the fourth TSA setting.
        /// </summary>
        public int TSASetting3Offset { get; set; }

        /// <summary>
        /// Gets or sets the offset of the palette.
        /// </summary>
        public int PaletteOffset { get; set; }

        /// <summary>
        /// Gets or sets the offset of the after doors palette. (The palette changes when the screen counter
        /// hits the screen defined at the DoorsFrom offset)
        /// </summary>
        public int AfterDoorsPaletteOffset { get; set; }

        /// <summary>
        /// Gets or sets the number of level tiles that this level uses.
        /// </summary>
        public int NumberOfTiles { get; set; }

        /// <summary>
        /// Gets or sets a List of bytes representing the scroll data for this level.
        /// </summary>
        public Collection<byte> ScrollData { get; set; }

        /// <summary>
        /// Gets or sets the offset to the scroll data table.
        /// </summary>
        public int ScrollOffset { get; set; }

        /// <summary>
        /// Gets or sets the scroll start offset.
        /// </summary>
        public int ScrollStartOffset { get; set; }

        /// <summary>
        /// Gets or sets the scroll position for checkpoint 1.
        /// </summary>
        public int ScrollPosChk1Offset { get; set; }

        /// <summary>
        /// Gets or sets the scroll position for checkpoint 2.
        /// </summary>
        public int ScrollPosChk2Offset { get; set; }

        /// <summary>
        /// Gets or sets the room order fix1 for checkpoint 1.
        /// </summary>
        public int RoomOrderFix1CheckOffset { get; set; }

        /// <summary>
        /// Gets or sets the room order fix1 for checkpoint 2.
        /// </summary>
        public int RoomOrderFix1Check2Offset { get; set; }

        /// <summary>
        /// Gets or sets the room order fix2 for checkpoint 1.
        /// </summary>
        public int RoomOrderFix2CheckOffset { get; set; }

        /// <summary>
        /// Gets or sets the room order fix2 for checkpoint 2.
        /// </summary>
        public int RoomOrderFix2Check2Offset { get; set; }

        /// <summary>
        /// Gets or sets the list of Bytes representing the room order.
        /// </summary>
        public Collection<byte> RoomOrder { get; set; }

        /// <summary>
        /// Gets or sets the screen start offset for checkpoint 1.
        /// </summary>
        public int ScreenStartCheck1Offset { get; set; }

        /// <summary>
        /// Gets or sets offset to the room order data table.
        /// </summary>
        public int RoomOrderOffset { get; set; }

        /// <summary>
        /// Gets or sets pointers to the room data.
        /// </summary>
        public int RoomPointersOffset { get; set; }

        /// <summary>
        /// Gets or sets the screen start check2.
        /// </summary>
        public int ScreenStartCheck2Offset { get; set; }

        /// <summary>
        /// Gets or sets the screen start check3.
        /// </summary>
        public int ScreenStartCheck3Offset { get; set; }

        /// <summary>
        /// Gets or sets the screen start checkpoint 2 trigger.
        /// </summary>
        public int ScreenStartChk2TrigOffset { get; set; }

        /// <summary>
        /// Gets or sets the screen start checkpoint 3 trigger.
        /// </summary>
        public int ScreenStartChk3TrigOffset { get; set; }

        /// <summary>
        /// Gets or sets the pointer to the enemy data.
        /// </summary>
        public int EnemyPointerOffset { get; set; }

        /// <summary>
        /// Gets or sets the index of the enemy which is the last enemy before checkpoint 1.
        /// </summary>
        public int EnemyCheckPoint1Offset { get; set; }

        /// <summary>
        /// Gets or sets the index of the enemy which is the last enemy before checkpoint 2.
        /// </summary>
        public int EnemyCheckPoint2Offset { get; set; }

        /// <summary>
        /// Gets or sets the track index that is used in this level.
        /// </summary>
        public int MusicIndexOffset { get; set; }

        /// <summary>
        /// Gets or sets the offset for the special objects.
        /// </summary>
        public int SpecObjOffset { get; set; }

        /// <summary>
        /// Gets or sets the Y co-ordinate that Mega Man beams down to at the start of the level.
        /// </summary>
        public int BeamDown1Offset { get; set; }

        /// <summary>
        /// Gets or sets the Y co-ordinate that Mega Man beams down to for the first checkpoint.
        /// </summary>
        public int BeamDown2Offset { get; set; }

        /// <summary>
        /// Gets or sets the Y co-ordinate that Mega Man beams down to for the second checkpoint.
        /// </summary>
        public int BeamDown3Offset { get; set; }

        /// <summary>
        /// Gets or sets the boss damage offset.
        /// </summary>
        public int BossDamageOffset { get; set; }

        /// <summary>
        /// Gets or sets the projectile damage.
        /// </summary>
        public int ProjectileDamage { get; set; }

        /// <summary>
        /// Gets or sets the doors from offset.
        /// </summary>
        public int DoorsFromOffset { get; set; }

        /// <summary>
        /// Gets or sets the sprite change pointers.
        /// </summary>
        public int SpriteChangePointersOffset { get; set; }

        /// <summary>
        /// Gets or sets the sprite change data.
        /// </summary>
        public int SpriteChangeDataOffset { get; set; }

        /// <summary>
        /// Gets or sets the tile to start the TSA data at.
        /// </summary>
        public int StartTSAAt { get; set; }

        /// <summary>
        /// Gets or sets the damage that Bombman's weapon does against this level's boss.
        /// </summary>
        public int BossPBlaster { get; set; }

        /// <summary>
        /// Gets or sets the damage that Cutman's weapon does against this level's boss.
        /// </summary>
        public int BossCut { get; set; }

        /// <summary>
        /// Gets or sets the damage that Iceman's weapon does against this level's boss.
        /// </summary>
        public int BossIce { get; set; }

        /// <summary>
        /// Gets or sets the damage that Gutsman's weapon does against this level's boss.
        /// </summary>
        public int BossGuts { get; set; }

        /// <summary>
        /// Gets or sets the damage that Elecman's weapon does against this level's boss.
        /// </summary>
        public int BossElec { get; set; }

        /// <summary>
        /// Gets or sets the damage that Fireman's weapon does against this level's boss.
        /// </summary>
        public int BossFire { get; set; }

        /// <summary>
        /// Gets or sets the damage that Bombman's weapon does against this level's boss.
        /// </summary>
        public int BossBomb { get; set; }

        /// <summary>
        /// Gets or sets the colour cycles for levels.
        /// </summary>
        public int ColourCyclesOffset { get; set; }

        /// <summary>
        /// Gets or sets the enemies that this level uses.
        /// </summary>
        public Collection<MegamanData.Megaman.Enemies.Enemy> Enemies { get; set; }

        /// <summary>
        /// Gets or sets the special objects that are contained within this level.
        /// </summary>
        public Collection<SpecialObject> SpecialObjects { get; set; }

        /// <summary>
        /// Gets or sets the pattern table settings for this level.
        /// </summary>
        public Collection<PatternTableSettings> PatternTableSetting { get; set; }

        /// <summary>
        /// Gets or sets the beam down #1 co-ordinate.
        /// </summary>
        public byte BeamDown1Coord
        {
            get
            {
                return this.rom[BeamDown1Offset];
            }

            set
            {
                this.rom[BeamDown1Offset] = value;
            }
        }

        /// <summary>
        /// Gets or sets the beam down #2 co-ordinate.
        /// </summary>
        public byte BeamDown2Coord
        {
            get
            {
                return this.rom[BeamDown2Offset];
            }

            set
            {
                this.rom[BeamDown2Offset] = value;
            }
        }

        /// <summary>
        /// Gets or sets the beam down #3 co-ordinate.
        /// </summary>
        public byte BeamDown3Coord
        {
            get
            {
                return this.rom[BeamDown3Offset];
            }

            set
            {
                this.rom[BeamDown3Offset] = value;
            }
        }

        /// <summary>
        /// Gets or sets the screen ID of the level start.
        /// </summary>
        public byte ScreenIDLevelStart
        {
            get
            {
                return rom[this.ScreenStartCheck1Offset];
            }

            set
            {
                rom[this.ScreenStartCheck1Offset] = value;
            }
        }

        /// <summary>
        /// The ROM that is currently loaded.
        /// </summary>
        private INESROMImage rom;

        /// <summary>
        /// Initializes a new instance of the <see cref="Level"/> class.
        /// </summary>
        /// <param name="romImage">The rom image.</param>
        public Level(ref INESROMImage romImage)
        {
            this.rom = romImage;
        }

        /// <summary>
        /// Calculates the length of a level, against the scroll data for the level.
        /// </summary>
        /// <returns>A value containing the length in rooms, of the level.</returns>
        public byte LevelLength()
        {
            int roomAmount = 0;
            int pos = ScrollOffset + rom[ScrollStartOffset];

            while (rom[pos] != 0x00)
            {
                roomAmount = roomAmount + ((rom[pos] & 0x1f) + 1);
                pos++;
            }

            return Convert.ToByte(roomAmount);
        }

        /// <summary>
        /// Determines whether the ID specified for an enemy is valid.
        /// </summary>
        /// <param name="id">The ID of the enemy to check for validity.</param>
        /// <returns>A Boolean depending on whether the ID is valid.</returns>
        public bool ValidateEnemy(int id)
        {
            if (this.Enemies == null)
            {
                return false;
            }

            if (this.Enemies.Count == 0)
            {
                return false;
            }

            if (id == -1)
            {
                return false;
            }

            if (id > this.Enemies.Count - 1)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Determines whether the ID specified for a special object is valid.
        /// </summary>
        /// <param name="id">The ID of the special object to check for validity.</param>
        /// <returns>A Boolean depending on whether the ID is valid.</returns>
        public bool ValidateSpecialObject(int id)
        {
            if (this.SpecialObjects == null)
            {
                return false;
            }

            if (this.SpecialObjects.Count == 0)
            {
                return false;
            }

            if (id == -1)
            {
                return false;
            }

            if (id > this.SpecialObjects.Count - 1)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Increments an enemy's ID.
        /// </summary>
        /// <param name="id">The ID of the enemy in the current level to increment.</param>
        /// <param name="incrementNumber">The number of IDs to increment the current ID by.</param>
        public void IncrementEnemyID(int id, byte incrementNumber)
        {
            if (this.ValidateEnemy(id) == true)
            {
                this.Enemies[id].ID = Convert.ToByte(this.Enemies[id].ID + incrementNumber);
                rom.IsChanged = true;
            }
        }

        /// <summary>
        /// Increments a special object's ID. If the object is a left-hand side of a door,
        /// it gets reset to a pop block.
        /// </summary>
        /// <param name="id">The ID of the special object in the current level, to increment.</param>
        public void IncrementSpecialObjectID(int id)
        {
            if (this.ValidateSpecialObject(id) == true)
            {
                if (this.SpecialObjects[id].ID == SpecialObjectTypes.DoorLeftSide)
                {
                    this.SpecialObjects[id].ID = SpecialObjectTypes.PopBlock;
                }
                else
                {
                    this.SpecialObjects[id].ID += 1;
                }
                rom.IsChanged = true;
            }
        }

        /// <summary>
        /// Adds a pattern table setting.
        /// </summary>
        /// <param name="offset">The offset.</param>
        /// <param name="size">The size of the data.</param>
        public void AddPatternTableSettings(int offset, int size)
        {
            PatternTableSettings pat = new PatternTableSettings();
            pat.Offset = offset;
            pat.Size = size;
            this.PatternTableSetting.Add(pat);
        }

        /// <summary>
        /// Deletes an enemy from the current level.
        /// </summary>
        /// <param name="id">The id of the enemy.</param>
        public void DeleteEnemy(int id)
        {
            this.Enemies.RemoveAt(id);
            rom.IsChanged = true;
        }

        /// <summary>
        /// Deletes scroll data from the current level.
        /// </summary>
        /// <param name="scrollDataIndex">The index of the scroll data.</param>
        public void DeleteScrollData(int scrollDataIndex)
        {
            this.ScrollData.RemoveAt(scrollDataIndex);
            ScrollData.Add(0xFF);
        }

        /// <summary>
        /// Deletes a special object from the current level.
        /// </summary>
        /// <param name="id">The id of the enemy.</param>
        public void DeleteSpecialObject(int id)
        {
            this.SpecialObjects.RemoveAt(id);
        }

        /// <summary>
        /// Draws the scroll data.
        /// </summary>
        /// <param name="bitmap">The bitmap.</param>
        /// <param name="scrollStart">The scroll start.</param>
        /// <param name="scrollCheckPoint1">The scroll check point1.</param>
        /// <param name="scrollCheckPoint2">The scroll check point2.</param>
        public void DrawScrollData(ref Bitmap bitmap, byte scrollStart, byte scrollCheckPoint1, byte scrollCheckPoint2)
        {
            /*var
  pos, roomamount, direction,x,y,i, size : Integer;
  Scr1Drew, Scr2Drew : Boolean;
//  WidthHeight : TWidthHeight;
begin
  pos := pScrollStart;
  x := 100;
  y := 210;
  size := 10;
  Scr1Drew := False;
  Scr2Drew := False;
//  WidthHeight := WorkOutSizeOfScrollGraphic(pos);


  while (CurrLevel.ScrollData[pos] <> $00) and (pos < CurrLevel.ScrollData.Count) do
  begin
    if CurrLevel.ScrollData[pos] = $FF then break;
    RoomAmount := (CurrLevel.ScrollData[pos] and $1F) + 1;
    direction := (CurrLevel.ScrollData[pos] and $E0);

    for i := 0 to RoomAmount -1 do
    begin

      pBitmap.FillRect(x,y,x+size,y+size,clFuchsia32);
      pBitmap.FrameRectS(x,y,x+size,y+size,clWhite32);

      if (direction and $20 = $20) and (i = RoomAmount -1) then
      begin
        pBitmap.FillRect(x,y,x+size,y+size,clBlue32);
        pBitmap.FrameRectS(x,y,x+size,y+size,clWhite32);
      end;
      if (pos = pScrollChk1) and (Scr1Drew = false) then
      begin
        pBitmap.FillRect(x,y,x+size,y+size,clGreen32);
        pBitmap.FrameRectS(x,y,x+size,y+size,clWhite32);
        Scr1Drew := True;
      end;
      if (pos = pScrollChk2) and (Scr2Drew = false) then
      begin
        pBitmap.FillRect(x,y,x+size,y+size,clYellow32);
        pBitmap.FrameRectS(x,y,x+size,y+size,clWhite32);
        Scr2Drew := True;
      end;

      inc(x,size);

    end;

    if (direction and $80 = $80) then
    begin

      dec(y,size);
      dec(x,size);
    end
    else if (direction and $40 = $40) then
    begin
      inc(y,size);
      dec(x,size);
    end;
    inc(pos);

  end;
  pBitmap.FillRect(x,y,x+size,y+size,clRed32);
  pBitmap.FrameRectS(x,y,x+size,y+size,clWhite32);
*/
        }

        /// <summary>
        /// Gets the level data.
        /// </summary>
        /// <param name="roomIndex">Index of the room.</param>
        /// <param name="row">The row number.</param>
        /// <param name="column">The column number.</param>
        /// <returns>The byte of level data, for the specified room, at the x/y co-ordinates.</returns>
        public byte GetLevelData(byte roomIndex, int row, int column)
        {
            int roomOffset;
            byte tileID;

            roomOffset = rom.PointerToOffset(this.RoomPointersOffset + (roomIndex * 2));

            tileID = rom[roomOffset + (column * 8) + row];

            return tileID;
        }

        /// <summary>
        /// Sets the level data for a specified room, at the specified X/Y co-ordinates.
        /// </summary>
        /// <param name="roomIndex">Index of the room.</param>
        /// <param name="row">The row number.</param>
        /// <param name="column">The column number.</param>
        /// <param name="tileID">The tile ID.</param>
        public void SetLevelData(byte roomIndex, int row, int column, byte tileID)
        {
            // We don't allow rows or columns outside the correct range to be set.
            if (row > 7 || column > 7 || row < 0 || column < 0)
            {
                return;
            }

            int roomOffset;

            roomOffset = rom.PointerToOffset(this.RoomPointersOffset + (rom[this.RoomOrderOffset + roomIndex] * 2));

            rom[roomOffset + (column * 8) + row] = tileID;
        }

        /// <summary>
        /// Saves the room order.
        /// </summary>
        internal void SaveRoomOrder()
        {
            // TODO check this is needed.
            for (int i = 0; i < this.RoomOrder.Count; i++)
            {
                rom[i + this.RoomOrderOffset] = this.RoomOrder[i];
            }
        }

        /// <summary>
        /// Loads the special object data.
        /// </summary>
        internal void LoadSpecialObjectData()
        {
            SpecialObject specobj;

            this.SpecialObjects = new Collection<SpecialObject>();
            for (int i = 0; i < rom[this.SpecObjOffset]; i++)
            {
                specobj = new SpecialObject();
                specobj.ID = (SpecialObjectTypes)rom[this.SpecObjOffset + 1 + (i * 6)];
                specobj.ScreenID = rom[this.SpecObjOffset + 1 + (i * 6) + 1];

                specobj.X1 = rom[this.SpecObjOffset + 1 + (i * 6) + 2];
                specobj.Y1 = rom[this.SpecObjOffset + 1 + (i * 6) + 3];
                specobj.X2 = rom[this.SpecObjOffset + 1 + (i * 6) + 4];
                specobj.Y2 = rom[this.SpecObjOffset + 1 + (i * 6) + 5];

                if (specobj.X2 < specobj.X1)
                {
                    specobj.X2 = specobj.X2 + 0x100;
                }
                if (specobj.Y2 < specobj.Y1)
                {
                    specobj.Y2 = specobj.Y2 + 0x100;
                }

                specobj.Width = specobj.X2 - specobj.X1;
                specobj.Height = specobj.Y2 - specobj.Y1;

                this.SpecialObjects.Add(specobj);
            }
        }

        /// <summary>
        /// Loads the scroll data.
        /// </summary>
        internal void LoadScrollData()
        {
            this.ScrollData = new Collection<byte>();
            for (int i = 0; i < 0x2f; i++)
            {
                this.ScrollData.Add(rom[this.ScrollOffset + i]);
            }
            this.LevelLength();
        }

        /// <summary>
        /// Loads the room order.
        /// </summary>
        internal void LoadRoomOrder()
        {
            this.RoomOrder = new Collection<byte>();
            for (int i = 0; i < 0x30; i++)
            {
                this.RoomOrder.Add(rom[this.RoomOrderOffset + i]);
            }
        }

        /// <summary>
        /// Saves the scroll data.
        /// </summary>
        internal void SaveScrollData()
        {
            int bytesToSave = 0;

            // Calculate how many bytes we actually want to save to the ROM.
            if (this.ScrollData.Count < 0x30)
            {
                bytesToSave = this.ScrollData.Count;
            }
            else
            {
                bytesToSave = 0x2F;
            }

            for (int i = 0; i < bytesToSave; i++)
            {
                rom[this.ScrollOffset + i] = this.ScrollData[i];
            }
        }
    }
}
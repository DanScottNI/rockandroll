using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using ROMHackLib.NES;

namespace MegamanData.Megaman2
{
    /// <summary>
    /// Class that represents a level in Megaman 2.
    /// </summary>
    public class Level
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the TSA offset.
        /// </summary>
        public int TSAOffset { get; set; }

        /// <summary>
        /// Gets or sets the attribute offset.
        /// </summary>
        public int AttributeOffset { get; set; }

        /// <summary>
        /// Gets or sets the palette offset.
        /// </summary>
        public int PaletteOffset { get; set; }

        /// <summary>
        /// Gets or sets the level offset.
        /// </summary>
        public int LevelOffset { get; set; }

        /// <summary>
        /// Gets or sets the scroll offset.
        /// </summary>
        public int ScrollOffset { get; set; }

        /// <summary>
        /// Gets or sets the PPU settings offset.
        /// </summary>
        public int PPUSettingsOffset { get; set; }

        /// <summary>
        /// Gets or sets the CHR settings offset.
        /// </summary>
        public int CHRSettingsOffset { get; set; }

        /// <summary>
        /// Gets or sets the first beam down point.
        /// </summary>
        public int BeamDown0 { get; set; }

        /// <summary>
        /// Gets or sets the second beam down point.
        /// </summary>
        public int BeamDown1 { get; set; }

        /// <summary>
        /// Gets or sets the third beam down point.
        /// </summary>
        public int BeamDown2 { get; set; }

        /// <summary>
        /// Gets or sets the first event start. 
        /// </summary>
        public int EventStart0 { get; set; }

        /// <summary>
        /// Gets or sets the second event start.
        /// </summary>
        public int EventStart1 { get; set; }

        /// <summary>
        /// Gets or sets the third event start.
        /// </summary>
        public int EventStart2 { get; set; }

        /// <summary>
        /// Gets or sets the first items start.
        /// </summary>
        public int ItemsStart0 { get; set; }

        /// <summary>
        /// Gets or sets the second items start.
        /// </summary>
        public int ItemsStart1 { get; set; }

        /// <summary>
        /// Gets or sets the third items start.
        /// </summary>
        public int ItemsStart2 { get; set; }

        /// <summary>
        /// Gets or sets the first screen start.
        /// </summary>
        public int ScreenStart0 { get; set; }

        /// <summary>
        /// Gets or sets the second screen start.
        /// </summary>
        public int ScreenStart1 { get; set; }

        /// <summary>
        /// Gets or sets the third screen start.
        /// </summary>
        public int ScreenStart2 { get; set; }

        /// <summary>
        /// Gets or sets the pattern table settings.
        /// </summary>
        public Collection<PatternTableSettings> PatternTableSettings { get; set; }

        /// <summary>
        /// Gets or sets the number of palette cycles.
        /// </summary>
        public byte PaletteCyclesNumber
        {
            get
            {
                return this.rom[this.PaletteOffset];
            }

            set
            {
                this.rom[this.PaletteOffset] = value;
            }
        }

        /// <summary>
        /// Gets or sets the palette cycles speed.
        /// </summary>
        public byte PaletteCyclesSpeed
        {
            get
            {
                return this.rom[this.PaletteOffset + 1];
            }

            set
            {
                this.rom[this.PaletteOffset + 1] = value;
            }
        }

        /// <summary>
        /// The ROM that is currently loaded.
        /// </summary>
        private INESROMImage rom;

        /// <summary>
        /// Initializes a new instance of the <see cref="Level"/> class.
        /// </summary>
        /// <param name="romImage">The ROM image.</param>
        public Level(ref INESROMImage romImage)
        {
            this.rom = romImage;
        }

        /// <summary>
        /// Gets the location of the palette data, for a specific palette cycle.
        /// </summary>
        /// <param name="cycleID">The cycle ID.</param>
        /// <returns>The location of the palette data.</returns>
        public int GetPaletteDataOffset(byte cycleID)
        {
            int bgpalOffset;

            if (cycleID == 0)
            {
                bgpalOffset = this.PaletteOffset + 2;
            }
            else
            {
                bgpalOffset = (this.PaletteOffset + 2 + 0x10) + ((cycleID - 1) * 0x10);
            }

            return bgpalOffset;
        }

        /// <summary>
        /// Loads the scroll data.
        /// </summary>
        internal void LoadScrollData()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Saves the scroll data.
        /// </summary>
        internal void SaveScrollData()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Loads the special object data.
        /// </summary>
        internal void LoadSpecialObjectData()
        {
            throw new NotImplementedException();
        }
    }
}

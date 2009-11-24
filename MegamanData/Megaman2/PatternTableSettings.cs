using System;
using System.Collections.Generic;
using System.Text;
using ROMHackLib;

namespace MegamanData.Megaman2
{
    /// <summary>
    /// Class that represents the settings for a level's pattern table.
    /// </summary>
    public class PatternTableSettings
    {
        /// <summary>
        /// Gets or sets the memory offset.
        /// </summary>
        public byte MemoryOffset { get; set; }

        /// <summary>
        /// Gets or sets the number of PPU rows to load.
        /// </summary>
        public byte RowsToLoad { get; set; }

        /// <summary>
        /// Gets or sets the PRG bank in which the graphics data is located.
        /// </summary>
        public byte PRGBank { get; set; }

        /// <summary>
        /// Gets the ROM address for the pattern table data.
        /// </summary>
        public int DataROMAddress
        {
            get
            {
                int memOffset, bankOffset = 0;
                memOffset = Convert.ToInt32("0x" + this.MemoryOffset.ToHex() + "10", 16);

                if (memOffset > 0xC000)
                {
                    memOffset = memOffset - 0xC000;
                }
                else if (memOffset > 0x8000)
                {
                    memOffset = memOffset - 0x8000;
                }

                bankOffset = this.PRGBank * 0x4000;
                
                return bankOffset + memOffset;
            }
        }

        /// <summary>
        /// Gets the number of bytes to load from the data.
        /// </summary>
        public int NumberOfBytesToLoad
        {
            get
            {
                return this.RowsToLoad * 0x100;
            }
        }
    }
}

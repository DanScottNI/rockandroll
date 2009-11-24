using System;
using System.Collections.Generic;
using System.Text;

namespace MegamanData.Megaman
{
    /// <summary>
    /// Class that represents the data that decides what to load into the pattern table.
    /// </summary>
    public class PatternTableSettings
    {
        /// <summary>
        /// Gets or sets the offset from which to load tiles.
        /// </summary>
        public int Offset { get; set; }
        
        /// <summary>
        /// Gets or sets the number of tiles to load from the offset
        /// </summary>
        public int Size { get; set; }
    }
}

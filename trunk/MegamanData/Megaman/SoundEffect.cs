using System;
using System.Collections.Generic;
using System.Text;
using ROMHackLib.NES;

namespace MegamanData.Megaman
{
    /// <summary>
    /// Class that represents a sound effect in Mega Man.
    /// </summary>
    public class SoundEffect
    {
        /// <summary>
        /// The ROM image that is currently loaded.
        /// </summary>
        private INESROMImage rom;

        /// <summary>
        /// Initializes a new instance of the SoundEffect class.
        /// </summary>
        /// <param name="romImage">The ROM image to load the sound effect from.</param>
        /// <param name="name">The name of the sound effect trigger.</param>
        /// <param name="offset">The offset of the sound effect trigger.</param>
        public SoundEffect(ref INESROMImage romImage, string name, int offset)
        {
            rom = romImage;
            this.Name = name;
            this.Offset = offset;
        }

        /// <summary>
        /// Gets or sets the track index of the sound effect.
        /// </summary>
        public byte TrackIndex
        {
            get
            {
                return rom[this.Offset];
            }

            set
            {
                rom[this.Offset] = value;
            }
        }

        /// <summary>
        /// Gets or sets the description of when the sound effect is triggered.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the offset of the sound effect.
        /// </summary>
        public int Offset { get; set; }
    }
}

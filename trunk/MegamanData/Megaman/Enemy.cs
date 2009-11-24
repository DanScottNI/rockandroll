using System;
using System.Collections.Generic;
using System.Text;

namespace MegamanData.Megaman
{
    /// <summary>
    /// Class that represents an enemy in Mega Man.
    /// </summary>
    public class Enemy
    {
        /// <summary>
        /// The X coordinate.
        /// </summary>
        private short xcoord;

        /// <summary>
        /// The Y coordinate.
        /// </summary>
        private short ycoord;

        /// <summary>
        /// Gets or sets the X co-ordinate of the enemy, on the screen.
        /// </summary>
        public short X
        {
            get
            {
                return this.xcoord;
            }
            set
            {
                if (value > 247)
                {
                    this.xcoord = 247;
                }
                else
                {
                    this.xcoord = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the identifier for the screen.
        /// </summary>
        public byte ScreenID { get; set; }

        /// <summary>
        /// Gets or sets whether this enemy is the last enemy before a checkpoint.
        /// </summary>
        public byte CheckPointStatus { get; set; }

        /// <summary>
        /// Gets or sets the ID of the enemy.
        /// </summary>
        public byte ID { get; set; }

        /// <summary>
        /// Gets or sets the Y co-ordinate of the enemy on the screen.
        /// </summary>
        public short Y
        {
            get
            {
                return this.ycoord;
            }
            set
            {
                if (value > 247)
                {
                    this.ycoord = 247;
                }
                else
                {
                    this.ycoord = value;
                }
            }
        }
    }
}

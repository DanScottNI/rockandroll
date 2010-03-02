using System;
using System.Collections.Generic;
using System.Text;

namespace MegamanData.Megaman
{
    /// <summary>
    /// An enumerated type representing the four types of special objects.
    /// </summary>
    public enum SpecialObjectTypes : byte
    {
        /// <summary>
        /// An object representing a pop block.
        /// </summary>
        PopBlock = 0,
        
        /// <summary>
        /// An object representing the right-hand side of a door.
        /// </summary>
        DoorRightSide = 1,
        
        /// <summary>
        /// An object representing a block that can be thrown using the Gutsman weapon.
        /// </summary>
        GBlock = 2,
        
        /// <summary>
        /// An object representing the left-hand side of a door.
        /// </summary>
        DoorLeftSide = 3
    }

    /// <summary>
    /// Class that represents a special object in Mega Man.
    /// </summary>
    public class SpecialObject
    {
        /// <summary>
        /// Gets or sets the type of special object.
        /// </summary>
        public SpecialObjectTypes ID { get; set; }
        
        /// <summary>
        /// Gets or sets the left X co-ordinate.
        /// </summary>
        public int X1 { get; set; }
        
        /// <summary>
        /// Gets or sets the top y co-ordinate.
        /// </summary>
        public int Y1 { get; set; }
        
        /// <summary>
        /// Gets or sets the right X co-ordinate.
        /// </summary>
        public int X2 { get; set; }
        
        /// <summary>
        /// Gets or sets the bottom Y coordinate.
        /// </summary>
        public int Y2 { get; set; }
        
        /// <summary>
        /// Gets or sets the screen ID on which the special object is located.
        /// </summary>
        public byte ScreenID { get; set; }
        
        /// <summary>
        /// Gets or sets the width on-screen of the special object.
        /// </summary>
        public int Width
        {
            get
            {
                return this.X2 - this.X1;
            }
            set
            {
                this.X2 = this.X1 + value;
            }
        }

        /// <summary>
        /// Gets or sets the height on-screen of the special object.
        /// </summary>
        public int Height
        {
            get
            {
                return this.Y2 - this.Y1;
            }
            set
            {
                this.Y2 = this.Y1 + value;
            }
        }
    }
}

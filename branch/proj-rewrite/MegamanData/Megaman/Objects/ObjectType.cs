using System;
using System.Collections.Generic;
using System.Text;

namespace MegamanData.Megaman
{
    /// <summary>
    /// The type of object returned.
    /// </summary>
    public enum ObjectType
    {
        /// <summary>
        /// No object returned.
        /// </summary>
        None = 0,

        /// <summary>
        /// The object is an enemy.
        /// </summary>
        Enemy = 1,

        /// <summary>
        /// The object is a special object.
        /// </summary>
        SpecialObject = 2,

        /// <summary>
        /// The object is a beamdown point.
        /// </summary>
        BeamDown = 3
    }

    /// <summary>
    /// A class that contains information about an object.
    /// </summary>
    public class ObjectInformation
    {
        /// <summary>
        /// Gets or sets the type of object.
        /// </summary>
        public ObjectType Type { get; set; }

        /// <summary>
        /// Gets or sets the ID for the object.
        /// </summary>
        public int? ID { get; set; }
    }
}

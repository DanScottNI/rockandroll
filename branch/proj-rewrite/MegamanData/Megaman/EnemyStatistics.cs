using System;
using System.Collections.Generic;
using System.Text;

namespace MegamanData.Megaman
{
    /// <summary>
    /// A class that represents statistics related to enemies.
    /// </summary>
    public class EnemyStatistics
    {
        /// <summary>
        /// Gets or sets the amount of damage that an enemy can take from Megaman's normal weapon.
        /// </summary>
        public byte PWeaponDamage { get; set; }

        /// <summary>
        /// Gets or sets the amount of damage that an enemy can take from Cutman's weapon.
        /// </summary>
        public byte CWeaponDamage { get; set; }

        /// <summary>
        /// Gets or sets the amount of damage that an enemy can take from Iceman's weapon.
        /// </summary>
        public byte IWeaponDamage { get; set; }

        /// <summary>
        /// Gets or sets the amount of damage that an enemy can take from Bombman's weapon.
        /// </summary>
        public byte BWeaponDamage { get; set; }

        /// <summary>
        /// Gets or sets the amount of damage that an enemy can take from Fireman's weapon.
        /// </summary>
        public byte FWeaponDamage { get; set; }

        /// <summary>
        /// Gets or sets the amount of damage that an enemy can take from Elecman's weapon.
        /// </summary>
        public byte EWeaponDamage { get; set; }

        /// <summary>
        /// Gets or sets the amount of damage that an enemy can take from Gutsman's weapon..
        /// </summary>
        public byte GWeaponDamage { get; set; }

        /// <summary>
        /// Gets or sets the amount of damage that the player takes when the enemy hits them.
        /// </summary>
        public byte PlayerDamage { get; set; }

        /// <summary>
        /// Gets or sets the amount of score received when the enemy is destroyed.
        /// </summary>
        public byte Score { get; set; }
    }
}

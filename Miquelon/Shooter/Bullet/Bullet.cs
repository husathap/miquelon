using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miquelon.Shooter.Bullet
{
    /// <summary>
    /// A class represent a bullet in the game.
    /// </summary>
    public abstract class Bullet : Sprite
    {
        /// <summary>
        /// The power of the bullet.
        /// </summary>
        public float Power { get; set; }

        /// <summary>
        /// The trajectory of the bullet.
        /// </summary>
        public Vector2 Trajectory { get; set; }
    }
}

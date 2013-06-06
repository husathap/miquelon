using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miquelon.Shooter.Bullet
{
    /// <summary>
    /// A class that represents a healing bullet.
    /// </summary>
    public class HPP : Bullet
    {

        public static Texture2D HPPTexture;

        /// <summary>
        /// Create a new healing bullet.
        /// </summary>
        /// <param name="Position">The position of the bullet.</param>
        /// <param name="Trajectory">The trajectory of the bullet.</param>
        public HPP(Vector2 Position, Vector2 Trajectory)
        {
            this.Texture = HPPTexture;
            this.Trajectory = Trajectory;
            this.Position = Position;
            this.Scale = 1f;
            this.Power = -1;
            this.Color = Color.White;
        }
    }
}

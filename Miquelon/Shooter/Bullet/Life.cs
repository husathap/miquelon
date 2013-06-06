using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miquelon.Shooter.Bullet
{
    /// <summary>
    /// A class represents a Life bullet.
    /// </summary>
    public class Life : Bullet
    {

        public static Texture2D LifeTexture;

        /// <summary>
        /// Create a new instance of Life bullet.
        /// </summary>
        /// <param name="Position">The initial position of the bullet.</param>
        /// <param name="Trajectory">The trajectory of the bullet.</param>
        public Life(Vector2 Position, Vector2 Trajectory)
        {
            this.Texture = LifeTexture;
            this.Trajectory = Trajectory;
            this.Position = Position;
            this.Scale = 1f;
            this.Power = 0;
            this.Color = Color.White;
        }
    }
}

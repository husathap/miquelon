using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miquelon.Shooter.Bullet
{
    /// <summary>
    /// A class that represents a Cross bullet.
    /// </summary>
    public class Cross : Bullet
    {

        /// <summary>
        /// The texture of Cross bullet.
        /// </summary>
        public static Texture2D CrossTexture;

        /// <summary>
        /// Create a new Cross bullet.
        /// </summary>
        /// <param name="Position">The position of the Cross bullet.</param>
        /// <param name="Trajectory">The trajectory of the Cross bullet.</param>
        public Cross(Vector2 Position, Vector2 Trajectory)
        {
            this.Texture = CrossTexture;
            this.Trajectory = Trajectory;
            this.Position = Position;
            this.Scale = 1f;
            this.Power = 1.2f;
            this.Color = Color.White;
        }
    }
}

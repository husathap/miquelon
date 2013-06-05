using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miquelon.Shooter.Bullet
{

    /// <summary>
    /// A class that represent a Clear bullet.
    /// </summary>
    public class Clear : Bullet
    {

        /// <summary>
        /// The texture of Clear bullet.
        /// </summary>
        public static Texture2D ClearTexture;

        /// <summary>
        /// Create a new instance of Clear bullet.
        /// </summary>
        /// <param name="Position">The initial position of the bullet.</param>
        /// <param name="Trajectory">The trajectory of the bullet.</param>
        public Clear(Vector2 Position, Vector2 Trajectory)
        {
            this.Texture = ClearTexture;
            this.Trajectory = Trajectory;
            this.Position = Position;
            this.Scale = 1f;
            this.Color = Color.White;
        }
    }
}

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miquelon.Shooter.Bullet
{

    /// <summary>
    /// A class represent Add type bullet.
    /// </summary>
    public class Add : Bullet
    {

        public static Texture2D AddTexture;

        /// <summary>
        /// Indicate whether the bullet will be inverted or not.
        /// </summary>
        public bool Inverted;

        /// <summary>
        /// Create a new instance of Add bullet.
        /// </summary>
        /// <param name="Position">The position of the bullet.</param>
        /// <param name="Trajectory">The trajectory of the bullet.</param>
        /// <param name="Inverted">Indicate whether the bullet is "inverted" or not.</param>
        public Add(Vector2 Position, Vector2 Trajectory, bool Inverted = false)
        {
            this.Texture = AddTexture;
            this.Trajectory = Trajectory;
            this.Position = Position;
            this.Scale = 1f;
            this.Power = 0;
            this.Color = Color.White;
            this.Inverted = Inverted;

            if (Inverted)
            {
                this.Rotation = (float)Math.PI;
            }
        }
    }
}

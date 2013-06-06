using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miquelon.Shooter.Bullet
{

    /// <summary>
    /// A class represents a Blocky type bullet.
    /// </summary>
    public class Blocky : Bullet
    {

        public static Texture2D BlockyTexture;

        /// <summary>
        /// Create a new instance of Blocky.
        /// </summary>
        /// <param name="Position">The initial position of Blocky.</param>
        /// <param name="Trajectory">The trajectory of Blocky.</param>
        public Blocky(Vector2 Position, Vector2 Trajectory)
        {
            this.Texture = BlockyTexture;
            this.Trajectory = Trajectory;
            this.Position = Position;
            this.Scale = 1f;
            this.Power = 1;
            this.Color = Color.White;
        }
    }
}

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miquelon.Shooter.Bullet
{
    /// <summary>
    /// A class that represents the laser in the game.
    /// </summary>
    public class TinyLaser : Bullet
    {

        /// <summary>
        /// The texture of Tiny Laser. 
        /// </summary>
        public static Texture2D TinyLaserTexture;

        /// <summary>
        /// Create a small point in the laser stream.
        /// </summary>
        /// <param name="Position">The position the laser.</param>
        /// <param name="Trajectory">The trajectory of the laser.</param>
        /// <param name="Color">The colour of the laser.</param>
        public TinyLaser(Vector2 Position, Vector2 Trajectory, Color Color)
        {
            this.Texture = TinyLaserTexture;
            this.Trajectory = Trajectory;
            this.Position = Position;
            this.Scale = 0.3f;
            this.Power = 0.1f;
            this.CollisionBoxRadius = 0.2f;
            this.Color = Color;
        }
    }
}

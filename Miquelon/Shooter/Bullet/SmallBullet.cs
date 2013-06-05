using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miquelon.Shooter.Bullet
{

    /// <summary>
    /// A class represent a normal enemy bullet.
    /// </summary>
    public class SmallBullet : Bullet
    {

        /// <summary>
        /// The texture of the bullet.
        /// </summary>
        public static Texture2D SmallBulletTexture;

        /// <summary>
        /// Create a new instance of the bullet.
        /// </summary>
        /// <param name="Position">The initial position of the bullet.</param>
        /// <param name="Trajectory">The trajectory of the bullet.</param>
        /// <param name="Color">The color of the bullet.</param>
        public SmallBullet(Vector2 Position, Vector2 Trajectory, Color Color)
        {
            this.Texture = SmallBulletTexture;
            this.Trajectory = Trajectory;
            this.Position = Position;
            this.Scale = 0.4f;
            this.Power = 1;
            this.CollisionBoxRadius = 0.3f;
            this.Color = Color;
        }
    }
}

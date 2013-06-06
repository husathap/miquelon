using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miquelon.Shooter.Bullet
{

    /// <summary>
    /// A class represent Big Bullet.
    /// </summary>
    public class BigBullet : Bullet
    {

        public static Texture2D BigBulletTexture;

        /// <summary>
        /// Create a new Big Bullet.
        /// </summary>
        /// <param name="Position">The initial position of the bullet.</param>
        /// <param name="Trajectory">The trajectory of the bullet.</param>
        /// <param name="Color">The colour of the bullet.</param>
        public BigBullet(Vector2 Position, Vector2 Trajectory, Color Color)
        {
            this.Texture = BigBulletTexture;
            this.Trajectory = Trajectory;
            this.Position = Position;
            this.Scale = 0.5f;
            this.Power = 10;
            this.CollisionBoxRadius = 80;
            this.Color = Color;
        }
    }
}

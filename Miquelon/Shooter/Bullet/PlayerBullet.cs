using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miquelon.Shooter.Bullet
{
    /// <summary>
    /// A class that represent the player's bullet. This is the only good bullet in the whole bunch.
    /// </summary>
    public class PlayerBullet : Bullet
    {
        /// <summary>
        /// The player's bullet texture.
        /// </summary>
        public static Texture2D PlayerBulletTexture;

        /// <summary>
        /// The bullet's random number generator.
        /// </summary>
        static Random rand = new Random();

        /// <summary>
        /// Create a new player's bullet.
        /// </summary>
        /// <param name="Position">The position of the player's bullet.</param>
        public PlayerBullet(Vector2 Position)
        {
            this.Texture = PlayerBulletTexture;
            this.Trajectory = new Vector2(10, 0);
            this.Position = Position;
            this.Scale = 1f;
            this.Power = 1;
            this.Color = new Color(rand.Next(0, 255), rand.Next(0, 255), rand.Next(0, 255));
        }
    }
}

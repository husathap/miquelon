using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miquelon.Shooter.Enemy
{

    /// <summary>
    /// A class represents Horizontal Saucer.
    /// </summary>
    public class HorizontalSaucer : Enemy
    {
        /// <summary>
        /// Indicate whether the sucer will fire in both way or not.
        /// </summary>
        public bool TwoWay;

        /// <summary>
        /// The temporary variable for the saucer.
        /// </summary>
        float IntendedX;

        /// <summary>
        /// The counter of the enemy.
        /// </summary>
        float counter = 0;

        /// <summary>
        /// The texture of Saucer.
        /// </summary>
        public static Texture2D SaucerTexture;

        /// <summary>
        /// Update the enemy.
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            if (this.Position.X < IntendedX)
            {
                this.Position += new Vector2(1, 0);
            }

            if (this.Position.X > IntendedX)
            {
                this.Position -= new Vector2(1, 0);
            }

            if (Math.Sin(counter) > 0)
            {
                //Shoot!
                Fire(new Bullet.TinyLaser(this.Position, new Vector2(4, 0), Color.Lime));

                if (TwoWay)
                {
                    Fire(new Bullet.TinyLaser(this.Position, new Vector2(-4, 0), Color.Lime));
                }
            }

            if (counter >= MathHelper.TwoPi)
            {
                counter = 0;
            }

            counter += 0.05f;
        }

        /// <summary>
        /// Create a new Horizontal Saucer.
        /// </summary>
        /// <param name="AssociatedLevel">The level that the enemy appears in.</param>
        /// <param name="Position">The position of the enemy.</param>
        /// <param name="StartingX">The intial X-position.</param>
        /// <param name="TwoWay">Indicate whether the saucer shoots both ways or not.</param>
        public HorizontalSaucer(Level.Level AssociatedLevel, Vector2 Position, int StartingX, bool TwoWay)
        {
            this.AssociatedLevel = AssociatedLevel;
            this.Position = new Vector2(StartingX, Position.Y);
            this.IntendedX = Position.X;
            this.HP = 8;
            this.MaxHP = 8;
            this.Scale = 1f;
            this.Texture = SaucerTexture;
            this.CollisionBoxRadius = 20f;
            this.TwoWay = TwoWay;
        }
    }
}

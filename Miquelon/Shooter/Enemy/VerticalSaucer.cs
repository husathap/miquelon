using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miquelon.Shooter.Enemy
{

    /// <summary>
    /// A class represents Vertical Saucer.
    /// </summary>
    public class VerticalSaucer : Enemy
    {

        /// <summary>
        /// Indicate whether the sucer will fire in both way or not.
        /// </summary>
        public bool TwoWay;

        /// <summary>
        /// The temporary variable for the saucer.
        /// </summary>
        float IntendedY;

        float counter = 0;

        public static Texture2D SaucerTexture;

        /// <summary>
        /// Update the enemy.
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            if (this.Position.Y < IntendedY)
            {
                this.Position += new Vector2(0, 1);
            }

            if (this.Position.Y > IntendedY)
            {
                this.Position -= new Vector2(0, 1);
            }

            if (Math.Sin(counter) > 0)
            {
                //Shoot!
                Fire(new Bullet.TinyLaser(this.Position, new Vector2(0, 4), Color.Lime));

                if (TwoWay)
                {
                    Fire(new Bullet.TinyLaser(this.Position, new Vector2(0, -4), Color.Lime));
                }
            }

            if (counter >= MathHelper.TwoPi)
            {
                counter = 0;
            }

            counter += 0.05f;
        }

        /// <summary>
        /// Create a new Verticle Saucer.
        /// </summary>
        /// <param name="AssociatedLevel">The level in which the enemy appears.</param>
        /// <param name="Position">The position of the enemy.</param>
        /// <param name="StartingY">The initial Y-position.</param>
        /// <param name="TwoWay">Indicate whether the enemy will fire both ways or not.</param>
        public VerticalSaucer(Level.Level AssociatedLevel, Vector2 Position, int StartingY, bool TwoWay)
        {
            this.AssociatedLevel = AssociatedLevel;
            this.Position = new Vector2(Position.X, StartingY);
            this.IntendedY = Position.Y;
            this.HP = 8;
            this.MaxHP = 8;
            this.Scale = 1f;
            this.Texture = SaucerTexture;
            this.CollisionBoxRadius = 20f;
            this.TwoWay = TwoWay;
        }
    }
}

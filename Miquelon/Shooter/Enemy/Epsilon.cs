using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miquelon.Shooter.Enemy
{

    /// <summary>
    /// A class representing Epsilon.
    /// </summary>
    public class Epsilon : Enemy
    {
        /// <summary>
        /// The movement of the enemy.
        /// </summary>
        Vector2 Movement;

        // The counters for the enemy.
        float counter = 0;
        int counter2 = 0;

        /// <summary>
        /// The texture of Saucer.
        /// </summary>
        public static Texture2D EpsilonTexture;

        /// <summary>
        /// Update the enemy.
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            this.Position += this.Movement;

            if (this.Position.X <= 0 || this.Position.X >= 1024)
            {
                this.Movement *= -1;
            }

            if (this.Position.Y > 550)
            {
                this.Position -= new Vector2(0, 5);
            }

            if (Math.Sin(counter) > 0)
            {
                //Shoot!
                Fire(new Bullet.TinyLaser(this.Position, new Vector2(0, 4), Color.Red));
                Fire(new Bullet.TinyLaser(this.Position, new Vector2(0, -4), Color.Red));
            }

            if (counter >= MathHelper.TwoPi)
            {
                counter = 0;
            }

            counter += 0.05f;

            if (counter2 >= 40)
            {
                Vector2 Traj = Player.Sprite.Position - this.Position;

                this.Fire(new Bullet.SmallBullet(new Vector2(this.X, this.Y), Traj / Traj.Length() * 2,
                    Color.Gray));

                counter2 = 0;
            }
            counter2++;
        }

        /// <summary>
        /// Create a new instance of Epsilon.
        /// </summary>
        /// <param name="AssociatedLevel">The pointer to the level in which the enemy belongs.</param>
        /// <param name="x">The initial X-position.</param>
        /// <param name="LeftFirst">Indicate whether the enemy goes left or right first.</param>
        public Epsilon(Level.Level AssociatedLevel, int x, bool LeftFirst)
        {
            this.AssociatedLevel = AssociatedLevel;
            this.Position = new Vector2(x, 625);
            this.HP = 20;
            this.MaxHP = 20;
            this.Scale = 1f;
            this.Texture = EpsilonTexture;
            this.CollisionBoxRadius = 25f;

            if (LeftFirst)
            {
                this.Movement = new Vector2(-1, 0);
            }
            else
            {
                this.Movement = new Vector2(1, 0);
            }
        }
    }
}

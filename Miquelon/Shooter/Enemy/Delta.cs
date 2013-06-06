using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miquelon.Shooter.Enemy
{

    /// <summary>
    /// A class represents Delta.
    /// </summary>
    public class Delta : Enemy
    {
        /// <summary>
        /// The movement vector of the enemy.
        /// </summary>
        Vector2 Movement;

        float counter = 0;
        int counter2 = 0;

        public static Texture2D DeltaTexture;

        /// <summary>
        /// Update the enemy.
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            this.Position += this.Movement;

            if (this.Position.Y <= 50 || this.Position.Y >= 600)
            {
                this.Movement *= -1;
            }

            if (this.Position.X > 974)
            {
                this.Position -= new Vector2(5, 0);
            }

            if (Math.Sin(counter) > 0)
            {
                //Shoot!
                Fire(new Bullet.TinyLaser(this.Position, new Vector2(4, 0), Color.Blue));
                Fire(new Bullet.TinyLaser(this.Position, new Vector2(-4, 0), Color.Blue));
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
        /// Create a new instance of the enemy.
        /// </summary>
        /// <param name="AssociatedLevel">The pointer to the level in which the enemy belongs.</param>
        /// <param name="y">The initial Y-position of the enemy.</param>
        /// <param name="UpFirst">Indicate whether the enemy goes up first or down first.</param>
        public Delta(Level.Level AssociatedLevel, int y, bool UpFirst)
        {
            this.AssociatedLevel = AssociatedLevel;
            this.Position = new Vector2(1050, y);
            this.HP = 20;
            this.MaxHP = 20;
            this.Scale = 1f;
            this.Texture = DeltaTexture;
            this.CollisionBoxRadius = 25f;

            if (UpFirst)
            {
                this.Movement = new Vector2(0, 1);
            }
            else
            {
                this.Movement = new Vector2(0, -1);
            }
        }
    }
}

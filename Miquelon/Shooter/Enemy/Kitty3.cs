using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miquelon.Shooter.Enemy
{
    /// <summary>
    /// A class represents Kitty III.
    /// </summary>
    public class Kitty3 : Enemy
    {

        public static Texture2D KittyTexture;

        /// <summary>
        /// Indicate whether in the preparation stage or not.
        /// </summary>
        bool PrepStage = true;

        /// <summary>
        /// The movement vector of Kitty.
        /// </summary>
        Vector2 Movement = new Vector2(-4, 0);

        int counter = 0;

        /// <summary>
        /// Update the enemy.
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            if (PrepStage)
            {
                this.X -= 5;

                if (this.X <= 1024)
                {
                    PrepStage = false;
                }
            }
            else
            {
                this.Position += Movement;

                if (this.X <= 0 || this.X >= 1024)
                {
                    Movement *= -1;
                }

                Vector2 Traj = Player.Sprite.Position - this.Position;

                Fire(new Bullet.TinyLaser(this.Position, Traj / Traj.Length() * 3, Color.Yellow));

                if (counter >= 100)
                {
                    for (float i = 0; i <= MathHelper.TwoPi; i += MathHelper.TwoPi / 30)
                    {
                        Fire(new Bullet.Cross(this.Position, new Vector2((float)Math.Cos(Traj.Y + i), (float)Math.Sin(Traj.X - i))));
                    }

                    counter = 0;
                }
                counter++;
            }
        }


        /// <summary>
        /// Create a new Kitty III.
        /// </summary>
        /// <param name="AssociatedLevel">The level in which this enemy exists.</param>
        public Kitty3(Level.Level AssociatedLevel)
        {
            this.AssociatedLevel = AssociatedLevel;
            this.Position = new Vector2(1100, 300);
            this.HP = 25;
            this.MaxHP = 25;
            this.Scale = 1f;
            this.Texture = KittyTexture;
            this.CollisionBoxRadius = 30;
        }
    }
}

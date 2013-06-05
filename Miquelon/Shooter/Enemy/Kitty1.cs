using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miquelon.Shooter.Enemy
{
    /// <summary>
    /// A class represents Kitty I.
    /// </summary>
    public class Kitty1 : Enemy
    {
        /// <summary>
        /// Represent the counter of the enemy.
        /// </summary>
        int counter = 0;

        /// <summary>
        /// The texture of the enemy.
        /// </summary>
        public static Texture2D KittyTexture;

        /// <summary>
        /// Update the enemy.
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {

            if (this.Y < 325)
            {
                this.Y += 5;
            }
            else
            {

                counter++;

                if (counter > 120)
                {

                    // Filling
                    for (float i = 0.01f; i < 2 * Math.PI; i += 0.1f)
                    {
                        float x = (float)(Math.Cosh(i));
                        float y = (float)(Math.Sinh(i));
                        this.Fire(new Bullet.Cross(new Vector2(this.X, this.Y), new Vector2(-x * 2, -y * 5f)));
                        this.Fire(new Bullet.Cross(new Vector2(this.X, this.Y), new Vector2(-x * 2, y * 5f)));
                        this.Fire(new Bullet.Cross(new Vector2(this.X, this.Y), new Vector2(x * 2, -y * 5f)));
                        this.Fire(new Bullet.Cross(new Vector2(this.X, this.Y), new Vector2(x * 2, y * 5f)));
                    }

                    Fire(new Bullet.Add(new Vector2(Player.Sprite.X, 0), new Vector2(0, 4), true));
                    AssociatedLevel.EnemyList.Add(new TrackingShooterFish3(AssociatedLevel, (int)Player.Sprite.Y));

                    counter = 0;
                }
            }
        }


        /// <summary>
        /// Create a new Kitty I.
        /// </summary>
        /// <param name="AssociatedLevel">The level in which this enemy exists.</param>
        public Kitty1(Level.Level AssociatedLevel)
        {
            this.AssociatedLevel = AssociatedLevel;
            this.Position = new Vector2(512, 0);
            this.HP = 35;
            this.MaxHP = 35;
            this.Scale = 1f;
            this.Texture = KittyTexture;
            this.CollisionBoxRadius = 30f;
        }
    }
}

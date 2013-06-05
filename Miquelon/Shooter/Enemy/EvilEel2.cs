using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miquelon.Shooter.Enemy
{
    /// <summary>
    /// A class representing Evil Eel II.
    /// </summary>
    public class EvilEel2 : Enemy
    {
        /// <summary>
        /// Represent the counter of the enemy.
        /// </summary>
        int counter = 0;

        /// <summary>
        /// The texture of Evil Eel II.
        /// </summary>
        public static Texture2D EvilEel2Texture;

        /// <summary>
        /// Update the enemy.
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            this.X -= 2;

            if (this.X < -200)
            {
                this.DeadFlag = true;
            }

            counter++;

            if (counter > 200)
            {
                // Filling
                this.Fire(new Bullet.BigBullet(new Vector2(this.X, this.Y), new Vector2(-7, 0), 
                    Color.Red));
                
                counter = 0;
            }

        }

        /// <summary>
        /// Create a new Evil Eel II.
        /// </summary>
        /// <param name="AssociatedLevel">The level in which this enemy exists.</param>
        /// <param name="y">The Y position of the enemy.</param>
        public EvilEel2(Level.Level AssociatedLevel, int y)
        {
            this.AssociatedLevel = AssociatedLevel;
            this.Position = new Vector2(1124, y);
            this.HP = 5;
            this.MaxHP = 5;
            this.Scale = 1f;
            this.Texture = EvilEel2Texture;
            this.CollisionBoxRadius = 10f;
        }

        /// <summary>
        /// Create a new Evil Eel II.
        /// </summary>
        /// <param name="AssociatedLevel">The level in which this enemy exists.</param>
        /// <param name="x">The X position of the enemy.</param>
        /// <param name="y">The Y position of the enemy.</param>
        public EvilEel2(Level.Level AssociatedLevel, int x, int y)
        {
            this.AssociatedLevel = AssociatedLevel;
            this.Position = new Vector2(x, y);
            this.HP = 6;
            this.MaxHP = 6;
            this.Scale = 1f;
            this.Texture = EvilEel2Texture;
            this.CollisionBoxRadius = 10f;
        }
    }
}


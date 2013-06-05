using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miquelon.Shooter.Enemy
{
    /// <summary>
    /// A class representing Evil Eel.
    /// </summary>
    public class EvilEel : Enemy
    {
        /// <summary>
        /// Represent the counter of the enemy.
        /// </summary>
        int counter = 0;

        /// <summary>
        /// The texture of Ultimate Cytopod.
        /// </summary>
        public static Texture2D EvilEelTexture;

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
        /// Create a new Evil Eel.
        /// </summary>
        /// <param name="AssociatedLevel">The level in which this enemy exists.</param>
        /// <param name="y">The initial Y-position of the enemy.</param>
        public EvilEel(Level.Level AssociatedLevel, int y)
        {
            this.AssociatedLevel = AssociatedLevel;
            this.Position = new Vector2(1124, y);
            this.HP = 5;
            this.MaxHP = 5;
            this.Scale = 1f;
            this.Texture = EvilEelTexture;
            this.CollisionBoxRadius = 10f;
        }

        /// <summary>
        /// Create a new Ultimate Blocky.
        /// </summary>
        /// <param name="AssociatedLevel">The level in which this enemy exists.</param>
        /// <param name="x">The X position of the enemy.</param>
        /// <param name="y">The Y position of the enemy.</param>
        public EvilEel(Level.Level AssociatedLevel, int x, int y)
        {
            this.AssociatedLevel = AssociatedLevel;
            this.Position = new Vector2(x, y);
            this.HP = 5;
            this.MaxHP = 5;
            this.Scale = 1f;
            this.Texture = EvilEelTexture;
            this.CollisionBoxRadius = 10f;
        }
    }
}


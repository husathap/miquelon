using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miquelon.Shooter.Enemy
{
    /// <summary>
    /// A class represents Shooter Fish.
    /// </summary>
    public class ShooterFish : Enemy
    {

        int counter = 0;

        public static Texture2D ShooterFishTexture;

        /// <summary>
        /// Update the enemy.
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            this.X -= 2;

            if (this.X < -40)
            {
                this.DeadFlag = true;
            }

            counter++;

            if (counter > 40)
            {
                // Filling
                this.Fire(new Bullet.SmallBullet(new Vector2(this.X, this.Y), new Vector2(-4, 0), 
                    Color.Red));
                
                counter = 0;
            }

        }

        /// <summary>
        /// Create a new Shooter Fish.
        /// </summary>
        /// <param name="AssociatedLevel">The level in which this enemy exists.</param>
        /// <param name="y">The Y position of the enemy.</param>
        public ShooterFish(Level.Level AssociatedLevel, int y)
        {
            this.AssociatedLevel = AssociatedLevel;
            this.Position = new Vector2(1124, y);
            this.HP = 2;
            this.MaxHP = 2;
            this.Scale = 1f;
            this.Texture = ShooterFishTexture;
            this.CollisionBoxRadius = 25f;
        }

        /// <summary>
        /// Create a new Shooter Fish.
        /// </summary>
        /// <param name="AssociatedLevel">The level in which this enemy exists.</param>
        /// <param name="x">The X position of the enemy.</param>
        /// <param name="y">The Y position of the enemy.</param>
        public ShooterFish(Level.Level AssociatedLevel, int x, int y)
        {
            this.AssociatedLevel = AssociatedLevel;
            this.Position = new Vector2(x, y);
            this.HP = 2;
            this.MaxHP = 2;
            this.Scale = 1f;
            this.Texture = ShooterFishTexture;
            this.CollisionBoxRadius = 25f;
        }
    }
}


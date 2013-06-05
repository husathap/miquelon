using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miquelon.Shooter.Enemy
{
    /// <summary>
    /// A class represents Shooter Fish II.
    /// </summary>
    public class ShooterFish2 : Enemy
    {
        /// <summary>
        /// Represent the counter of the enemy.
        /// </summary>
        int counter = 0;

        /// <summary>
        /// The texture of Ultimate Cytopod.
        /// </summary>
        public static Texture2D ShooterFish2Texture;

        Random rand = new Random();

        public override void Update(GameTime gameTime)
        {
            this.X -= 2;

            if (this.X < -40)
            {
                this.DeadFlag = true;
            }

            rand.NextDouble();

            counter++;

            if (counter > 35)
            {
                // Filling
                this.Fire(new Bullet.SmallBullet(new Vector2(this.X, this.Y), new Vector2(-4, 0),
                    Color.Red));
                
                counter = 0;
            }

        }

        /// <summary>
        /// Create a new Shooter Fish II.
        /// </summary>
        /// <param name="AssociatedLevel">The level in which this enemy exists.</param>
        /// <param name="y">The Y position of the enemy.</param>
        public ShooterFish2(Level.Level AssociatedLevel, int y)
        {
            this.AssociatedLevel = AssociatedLevel;
            this.Position = new Vector2(1124, y);
            this.HP = 2;
            this.MaxHP = 2;
            this.Scale = 1f;
            this.Texture = ShooterFish2Texture;
            this.CollisionBoxRadius = 25f;
        }

        /// <summary>
        /// Create a new Shooter Fish II.
        /// </summary>
        /// <param name="AssociatedLevel">The level in which this enemy exists.</param>
        /// <param name="y">The Y position of the enemy.</param>
        /// <param name="y">The Y position of the enemy.</param>
        public ShooterFish2(Level.Level AssociatedLevel, int x, int y)
        {
            this.AssociatedLevel = AssociatedLevel;
            this.Position = new Vector2(x, y);
            this.HP = 2;
            this.MaxHP = 2;
            this.Scale = 1f;
            this.Texture = ShooterFish2Texture;
            this.CollisionBoxRadius = 25f;
        }
    }
}


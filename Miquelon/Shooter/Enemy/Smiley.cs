using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miquelon.Shooter.Enemy
{
    /// <summary>
    /// A class represents Smiley.
    /// </summary>
    public class Smiley : Enemy
    {
        /// <summary>
        /// Represent the counter of the enemy.
        /// </summary>
        int counter = 0;

        /// <summary>
        /// Represent the second counter of the enemy.
        /// </summary>
        float counter2 = 0;

        /// <summary>
        /// The texture of Ultimate Cytopod.
        /// </summary>
        public static Texture2D SmileyTexture;

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
                Vector2 Traj = Player.Sprite.Position - this.Position;
                this.Fire(new Bullet.BigBullet(new Vector2(this.X, this.Y), Traj / Traj.Length() * 5, 
                    Color.Yellow));
                
                counter = 0;
            }

            if (Math.Sin(counter2) > 0)
            {
                //Shoot!
                Vector2 Traj = Player.Sprite.Position - this.Position;
                Fire(new Bullet.TinyLaser(this.Position, Traj / Traj.Length() * 3, Color.Cyan));
            }

            counter2 += 0.04f;

            if (counter2 >= MathHelper.TwoPi)
            {
                counter2 = 0;
            }
        }

        /// <summary>
        /// Create a new Smiley.
        /// </summary>
        /// <param name="AssociatedLevel">The level in which this enemy exists.</param>
        /// <param name="y">The Y position of the enemy.</param>
        public Smiley(Level.Level AssociatedLevel, int y)
        {
            this.AssociatedLevel = AssociatedLevel;
            this.Position = new Vector2(1124, y);
            this.HP = 5;
            this.MaxHP = 5;
            this.Scale = 1f;
            this.Texture = SmileyTexture;
            this.CollisionBoxRadius = 30f;
        }

        /// <summary>
        /// Create a new Smiley.
        /// </summary>
        /// <param name="AssociatedLevel">The level in which this enemy exists.</param>
        /// <param name="x">The X position of the enemy.</param>
        /// <param name="y">The Y position of the enemy.</param>
        public Smiley(Level.Level AssociatedLevel, int x, int y)
        {
            this.AssociatedLevel = AssociatedLevel;
            this.Position = new Vector2(x, y);
            this.HP = 5;
            this.MaxHP = 5;
            this.Scale = 1f;
            this.Texture = SmileyTexture;
            this.CollisionBoxRadius = 20f;
        }
    }
}


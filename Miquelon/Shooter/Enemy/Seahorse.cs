using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miquelon.Shooter.Enemy
{
    /// <summary>
    /// A class represents Seahorse.
    /// </summary>
    public class Seahorse : Enemy
    {
        /// <summary>
        /// Represent the counter of the enemy.
        /// </summary>
        int counter = 0;

        /// <summary>
        /// The texture of Ultimate Cytopod.
        /// </summary>
        public static Texture2D SeahorseTexture;

        /// <summary>
        /// Update the enemy.
        /// </summary>
        /// <param name="gameTime">gameTime</param>
        public override void Update(GameTime gameTime)
        {

            this.Y -= 2;

            if (this.Y <= 0)
            {
                this.DeadFlag = true;
            }

            counter++;

            if (counter > 35)
            {
                // Filling
                Vector2 Traj = Player.Sprite.Position - this.Position;

                this.Fire(new Bullet.SmallBullet(new Vector2(this.X, this.Y), Traj / Traj.Length() * 5,
                    Color.Yellow));
                
                counter = 0;
            }

        }

        /// <summary>
        /// Create a new Seahorse.
        /// </summary>
        /// <param name="AssociatedLevel">The level in which this enemy exists.</param>
        /// <param name="x">The X position of the enemy.</param>
        public Seahorse(Level.Level AssociatedLevel, int x)
        {
            this.AssociatedLevel = AssociatedLevel;
            this.Position = new Vector2(x, 630);
            this.HP = 3;
            this.MaxHP = 3;
            this.Scale = 1f;
            this.Texture = SeahorseTexture;
            this.CollisionBoxRadius = 25f;
        }

        /// <summary>
        /// Create a new Seahorse.
        /// </summary>
        /// <param name="AssociatedLevel">The level in which this enemy exists.</param>
        /// <param name="x">The X position of the enemy.</param>
        /// <param name="y">The Y position of the enemy.</param>
        public Seahorse(Level.Level AssociatedLevel, int x, int y)
        {
            this.AssociatedLevel = AssociatedLevel;
            this.Position = new Vector2(x, y);
            this.HP = 3;
            this.MaxHP = 3;
            this.Scale = 1f;
            this.Texture = SeahorseTexture;
            this.CollisionBoxRadius = 25f;
        }
    }
}


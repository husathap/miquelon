using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miquelon.Shooter.Enemy
{
    /// <summary>
    /// A class that represents a Tracking Shooter Fish III.
    /// </summary>
    public class TrackingShooterFish3 : Enemy
    {

        int counter = 0;

        public static Texture2D TrackingShooterFish3Texture;

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
        /// Create a new Tracking Shooter Fish III.
        /// </summary>
        /// <param name="AssociatedLevel">The level in which this enemy exists.</param>
        /// <param name="y">The Y position of the enemy.</param>
        public TrackingShooterFish3(Level.Level AssociatedLevel, int y)
        {
            this.AssociatedLevel = AssociatedLevel;
            this.Position = new Vector2(1124, y);
            this.HP = 3;
            this.MaxHP = 3;
            this.Scale = 1f;
            this.Texture = TrackingShooterFish3Texture;
            this.CollisionBoxRadius = 25f;
        }

        /// <summary>
        /// Create a new Tracking Shooter Fish III.
        /// </summary>
        /// <param name="AssociatedLevel">The level in which this enemy exists.</param>
        /// <param name="x">The X position of the enemy.</param>
        /// <param name="y">The Y position of the enemy.</param>
        public TrackingShooterFish3(Level.Level AssociatedLevel, int x, int y)
        {
            this.AssociatedLevel = AssociatedLevel;
            this.Position = new Vector2(x, y);
            this.HP = 3;
            this.MaxHP = 3;
            this.Scale = 1f;
            this.Texture = TrackingShooterFish3Texture;
            this.CollisionBoxRadius = 25f;
        }
    }
}


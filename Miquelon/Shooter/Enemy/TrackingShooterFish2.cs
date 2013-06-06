using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miquelon.Shooter.Enemy
{
    /// <summary>
    /// A class that represents a Tracking Shooter Fish II.
    /// </summary>
    public class TrackingShooterFish2 : Enemy
    {

        int counter = 0;

        public static Texture2D TrackingShooterFishTexture;

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

                this.Fire(new Bullet.SmallBullet(new Vector2(this.X, this.Y), Traj / Traj.Length() * 4,
                    Color.Red));
                
                counter = 0;
            }

        }

        /// <summary>
        /// Create a new Tracking Shooter Fish II.
        /// </summary>
        /// <param name="AssociatedLevel">The level in which this enemy exists.</param>
        /// <param name="y">The Y position of the enemy.</param>
        public TrackingShooterFish2(Level.Level AssociatedLevel, int y)
        {
            this.AssociatedLevel = AssociatedLevel;
            this.Position = new Vector2(1124, y);
            this.HP = 2;
            this.MaxHP = 2;
            this.Scale = 1f;
            this.Texture = TrackingShooterFishTexture;
            this.CollisionBoxRadius = 25f;
        }

        /// <summary>
        /// Create a new Tracking Shooter Fish II.
        /// </summary>
        /// <param name="AssociatedLevel">The level in which this enemy exists.</param>
        /// <param name="x">The X position of the enemy.</param>
        /// <param name="y">The Y position of the enemy.</param>
        public TrackingShooterFish2(Level.Level AssociatedLevel, int x, int y)
        {
            this.AssociatedLevel = AssociatedLevel;
            this.Position = new Vector2(x, y);
            this.HP = 2;
            this.MaxHP = 2;
            this.Scale = 1f;
            this.Texture = TrackingShooterFishTexture;
            this.CollisionBoxRadius = 25f;
        }
    }
}


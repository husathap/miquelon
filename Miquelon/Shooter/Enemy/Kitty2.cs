using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miquelon.Shooter.Enemy
{
    /// <summary>
    /// A class represents Kitty II.
    /// </summary>
    public class Kitty2 : Enemy
    {

        /// <summary>
        /// The texture of Kitty.
        /// </summary>
        public static Texture2D KittyTexture;

        /// <summary>
        /// Preparing for an attack.
        /// </summary>
        bool PrepStage = true;

        /// <summary>
        /// The movement information in the X-axis.
        /// </summary>
        Vector2 XMovement = new Vector2(-4, 0);

        /// <summary>
        /// The movement information in the Y-axis.
        /// </summary>
        Vector2 YMovement = new Vector2(0, -4);

        /// <summary>
        /// Update the enemy.
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            if (PrepStage)
            {
                this.Y -= 5;

                if (this.Y <= 325)
                {
                    PrepStage = false;
                }
            }
            else
            {
                this.Position += XMovement + YMovement;

                if (this.X <= 0 || this.X >= 1024)
                {
                    XMovement *= -1;
                }

                if (this.Y <= 25 || this.Y >= 600)
                {
                    YMovement *= -1;
                }

                Vector2 Traj = Player.Sprite.Position - this.Position;

                Fire(new Bullet.TinyLaser(this.Position, Traj / Traj.Length() * 3, Color.Yellow));
            }
        }


        /// <summary>
        /// Create a new Kitty II.
        /// </summary>
        /// <param name="AssociatedLevel">The level in which this enemy exists.</param>
        public Kitty2(Level.Level AssociatedLevel)
        {
            this.AssociatedLevel = AssociatedLevel;
            this.Position = new Vector2(512, 700);
            this.HP = 10;
            this.MaxHP = 10;
            this.Scale = 1f;
            this.Texture = KittyTexture;
            this.CollisionBoxRadius = 30;
        }
    }
}

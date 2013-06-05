using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miquelon.Shooter.Enemy
{
    /// <summary>
    /// A class that represents Ultimate Blocky.
    /// </summary>
    public class UltimateBlocky : Enemy
    {
        /// <summary>
        /// Represent the counter of the enemy.
        /// </summary>
        int counter = 0;

        /// <summary>
        /// The texture of Ultimate Cytopod.
        /// </summary>
        public static Texture2D UltimateCytopodTexture;

        /// <summary>
        /// Update the enemy.
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            this.Y = Player.Sprite.Y;

            if (this.X > 900)
            {
                this.X -= 4;
            }

            counter++;

            if (counter > 10)
            {

                // Filling
                for (float i = 0.01f; i < 2 * Math.PI; i += 0.1f)
                {
                    float x = (float)(Math.Sin(i));
                    float y = (float)(Math.Cos(i + Math.PI));
                    this.Fire(new Bullet.Blocky(new Vector2(this.X, Player.Sprite.Y), new Vector2(x * 3, y * 3)));
                }
                counter = 0;
            }
        }


        /// <summary>
        /// Create a new Ultimate Blocky.
        /// </summary>
        /// <param name="AssociatedLevel">The level in which this enemy exists.</param>
        public UltimateBlocky(Level.Level AssociatedLevel)
        {
            this.AssociatedLevel = AssociatedLevel;
            this.Position = new Vector2(1124, Player.Sprite.Y);
            this.HP = 100;
            this.MaxHP = 100;
            this.Scale = 1f;
            this.Texture = UltimateCytopodTexture;
            this.CollisionBoxRadius = 50f;
        }
    }
}

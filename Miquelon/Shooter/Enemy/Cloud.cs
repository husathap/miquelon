using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miquelon.Shooter.Enemy
{

    /// <summary>
    /// A class represents Cloud enemy.
    /// </summary>
    public class Cloud : Enemy
    {

        /// <summary>
        /// The counter of the enemy.
        /// </summary>
        float counter = 0;

        /// <summary>
        /// The texture of Cloud.
        /// </summary>
        public static Texture2D CloudTexture;

        /// <summary>
        /// Update the enemy.
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            this.Position += new Vector2(-2, 0);

            if (this.Position.X <= -20)
            {
                DeadFlag = true;
            }

            if (Math.Sin(counter) > 0)
            {
                //Shoot!
                Fire(new Bullet.TinyLaser(this.Position, new Vector2(0, 3), Color.AliceBlue));
                counter += 0.5f;
            }
            else
            {
                counter += 0.1f;
            }

            if (counter >= MathHelper.TwoPi)
            {
                counter = 0;
            }

            
        }

        /// <summary>
        /// Create a new Cloud enemy.
        /// </summary>
        /// <param name="AssociatedLevel">The pointer to the level that this enemy belongs to.</param>
        /// <param name="Position">The starting position of the cloud enemy.</param>
        public Cloud(Level.Level AssociatedLevel, Vector2 Position)
        {
            this.AssociatedLevel = AssociatedLevel;
            this.Position = Position;
            this.HP = 2;
            this.MaxHP = 2;
            this.Scale = 1f;
            this.Texture = CloudTexture;
            this.CollisionBoxRadius = 20f;
        }
    }
}

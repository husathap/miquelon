using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Miquelon.Shooter.Bullet;
using Miquelon.Shooter.Level;

namespace Miquelon.Shooter.Enemy
{

    /// <summary>
    /// An abstract class representing all enemies in the game.
    /// </summary>
    public abstract class Enemy : Sprite
    {
        /// <summary>
        /// The HP of the enemy.
        /// </summary>
        public float HP;

        /// <summary>
        /// The maximum HP of an enemy.
        /// </summary>
        public float MaxHP;

        /// <summary>
        /// The pointer to the current level that the enemy is in.
        /// </summary>
        public Level.Level AssociatedLevel;

        /// <summary>
        /// A flag that indicates whether the enemy is already dead or not.
        /// This flag is to be used for death other than Death by 0 HP.
        /// </summary>
        public bool DeadFlag;

        /// <summary>
        /// Update the enemy in the game.
        /// </summary>
        /// <param name="gameTime"></param>
        public abstract void Update(GameTime gameTime);

        /// <summary>
        /// Fire a bullet in the associated level.
        /// </summary>
        /// <param name="b"></param>
        public void Fire(Bullet.Bullet b)
        {
            AssociatedLevel.EnemyBulletList.Add(b);
        }
    }
}

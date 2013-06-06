using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miquelon.Shooter.Bullet
{

    /// <summary>
    /// A class that represents Garble bullet.
    /// </summary>
    public class Garble : Bullet
    {

        public static Texture2D GarbleTexture;

        /// <summary>
        /// Create a new instance of Garble.
        /// </summary>
        /// <param name="Position">The inisitial position of Garble.</param>
        /// <param name="Trajectory">The trajectory of the bullet.</param>
        public Garble(Vector2 Position, Vector2 Trajectory)
        {
            this.Texture = GarbleTexture;
            this.Trajectory = Trajectory;
            this.Position = Position;
            this.Scale = 1f;
            this.Power = 1;
            this.Color = Color.White;
        }
    }
}

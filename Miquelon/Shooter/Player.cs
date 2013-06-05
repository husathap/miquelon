using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miquelon.Shooter
{
    /// <summary>
    /// A class representation of the player. This stores HP, Lives and Score. It also is responsible for
    /// update the player as well.
    /// </summary>
    public static class Player
    {

        /// <summary>
        /// The Sprite representation of the player.
        /// </summary>
        public static Sprite Sprite;

        /// <summary>
        /// The health of the player.
        /// </summary>
        public static float HP = 50;

        /// <summary>
        /// The maximum health that the player can have.
        /// </summary>
        public static float MaxHP = 100;

        /// <summary>
        /// The number of life that the player have.
        /// </summary>
        public static int Life = 3;

        /// <summary>
        /// The maximum number of life that the player can have.
        /// </summary>
        public static int MaxLife = 10;
    }
}

#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
using Miquelon.Shooter.Level;
#endregion

namespace Miquelon
{
    public partial class Main
    {
        /// <summary>
        /// An object that is returned by the current game state.
        /// </summary>
        public static Object Return;

        /// <summary>
        /// The current state of the game.
        /// </summary>
        public static State CurrentState = new Title();

        /// <summary>
        /// Exit the game.
        /// </summary>
        public static void Quit()
        {
            CurrentState = null;
        }
    }
}

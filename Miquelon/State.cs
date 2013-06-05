#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
#endregion
namespace Miquelon
{
    /// <summary>
    /// An interface represent a game state.
    /// </summary>
    public interface State
    {
        void Update(GameTime gt);
        void Draw(SpriteBatch sb);
    }
}

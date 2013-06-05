using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miquelon.Shooter
{
    /// <summary>
    /// A class that contains extensions for various API classes.
    /// </summary>
    public static class Extension
    {
        /// <summary>
        /// Draw a sprite.
        /// </summary>
        /// <param name="sb">The sprite batch.</param>
        /// <param name="s">The sprite to be drawn.</param>
        public static void Draw(this SpriteBatch sb, Sprite s)
        {
            sb.Draw(s.Texture, s.Position, null, s.Color, s.Rotation, s.Origin, s.Scale, s.SpriteEffects, 0);
        }
    }
}

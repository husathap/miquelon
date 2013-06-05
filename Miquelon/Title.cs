using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Miquelon.Shooter.Level;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miquelon
{
    /// <summary>
    /// A class that represent the first stage of the game.
    /// </summary>
    public class Title : State
    {

        /// <summary>
        /// The texture of the main screen.
        /// </summary>
        public static Texture2D TitleScreenTexture;

        /// <summary>
        /// The background music for the title screen.
        /// </summary>
        public static SoundEffect TitleBackgroundMusic;

        /// <summary>
        /// Indicate whether the input is pressed for the first time or not.
        /// </summary>
        bool FirstTimeInput = true;

        /// <summary>
        /// Indicate whether the title screen is just freshly initialized or not.
        /// </summary>
        bool FirstInitialized = true;

        /// <summary>
        /// The old keyboard status. Used for input updating.
        /// </summary>
        KeyboardState oldks;

        /// <summary>
        /// The background music player for the title screen.
        /// </summary>
        SoundEffectInstance BGMPlayer;

        /// <summary>
        /// Update the title screen.
        /// </summary>
        /// <param name="gt"></param>
        public void Update(GameTime gt)
        {
            KeyboardState ks = Keyboard.GetState();

            if (FirstInitialized)
            {
                BGMPlayer = new SoundEffectInstance(TitleBackgroundMusic);
                BGMPlayer.IsLooped = true;
                BGMPlayer.Play();
                FirstInitialized = false;
            }

            if (FirstTimeInput)
            {
                if (ks.IsKeyUp(Keys.Enter) && ks.IsKeyUp(Keys.Space))
                {
                    FirstTimeInput = false;
                }
            }
            else
            {

                if ((ks.IsKeyUp(Keys.Enter) && (oldks.IsKeyDown(Keys.Enter))) ||
                    (ks.IsKeyUp(Keys.Space) && (oldks.IsKeyDown(Keys.Space))))
                {
                    BGMPlayer.Stop();
                    BGMPlayer = null;
                    Main.CurrentState = Slides.Intro.Create();
                }

                if (ks.IsKeyUp(Keys.Escape) && (oldks.IsKeyDown(Keys.Escape)))
                {
                    Main.Quit();
                }
            }

            oldks = ks;
        }

        /// <summary>
        /// Drawing the title screen.
        /// </summary>
        /// <param name="sb"></param>
        public void Draw(SpriteBatch sb)
        {
            sb.Draw(TitleScreenTexture, new Rectangle(0, 0, 1024, 600), Color.White);
        }
    }
}

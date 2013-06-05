using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Miquelon.Shooter;
using Miquelon.Shooter.Level;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miquelon.Slides
{
    /// <summary>
    /// Manage the slides in the game.
    /// </summary>
    public class Slide : State
    {

        /// <summary>
        /// The queue that holds all of the instruction.
        /// </summary>
        public Queue<Object> Instructions = new Queue<Object>();

        public static Texture2D IntertileTexture;
        public static Texture2D TransitionTexture;
        public static SpriteFont SlideFont;

        float AlphaCounter = 1f;

        KeyboardState oldks;

        bool FirstTime = true;

        SoundEffectInstance SoundManager;

        /// <summary>
        /// Update the current slide.
        /// </summary>
        /// <param name="gt">The gametime.</param>
        public void Update(GameTime gt)
        {
            if (Instructions.Count == 0)
            {
                Main.Quit();
            }
            else
            {
                if (Instructions.Peek() is String)
                {
                    UpdateWithAcceptKey();
                }
                else if (Instructions.Peek() is SoundEffect)
                {
                    SoundManager = new SoundEffectInstance((SoundEffect)Instructions.Dequeue());
                    SoundManager.IsLooped = true;
                    SoundManager.Play();
                }
                else if (Instructions.Peek() is Texture2D)
                {
                    UpdateWithAcceptKey();
                }
                else if (Instructions.Peek() is State)
                {
                    if (SoundManager != null)
                    {
                        SoundManager.Stop();
                        SoundManager = null;
                    }
                    Main.CurrentState = (State)Instructions.Dequeue();
                }
                else
                {
                    SoundManager.Stop();
                }
            }
        }

        /// <summary>
        /// Update while the slide is awaiting space or enter input;
        /// </summary>
        public void UpdateWithAcceptKey()
        {
            if (AlphaCounter > 0)
            {
                AlphaCounter -= 0.05f;
            }
            else
            {
                KeyboardState ks = Keyboard.GetState();

                if (FirstTime)
                {
                    if (ks.IsKeyUp(Keys.Enter) && ks.IsKeyUp(Keys.Space))
                    {
                        FirstTime = false;
                    }
                }
                else
                {
                    if ((ks.IsKeyUp(Keys.Enter) && oldks.IsKeyDown(Keys.Enter)) ||
                        (ks.IsKeyUp(Keys.Space) && oldks.IsKeyDown(Keys.Space)))
                    {
                        Instructions.Dequeue();
                        FirstTime = true;
                        AlphaCounter = 1f;
                    }
                }

                oldks = ks;
            }
        }

        /// <summary>
        /// The current slide onto the screen.
        /// </summary>
        /// <param name="sb"></param>
        public void Draw(SpriteBatch sb)
        {
            if (Instructions.Count > 0)
            {
                if (Instructions.Peek() is Texture2D)
                {
                    sb.Draw((Texture2D)Instructions.Peek(), new Rectangle(0, 0, 1024, 600), Color.White);
                    sb.Draw(Slide.TransitionTexture, new Rectangle(0, 0, 1024, 600), new Color(Color.White, AlphaCounter));
                }
                else
                {
                    String CurrentString = Instructions.Peek().ToString();

                    sb.Draw(Slide.IntertileTexture, new Rectangle(0, 0, 1024, 600), Color.White);
                    sb.DrawString(SlideFont, CurrentString, new Vector2(512 - SlideFont.MeasureString(CurrentString).X / 2, 
                        300 - SlideFont.MeasureString(CurrentString).Y / 2), Color.White);
                    sb.Draw(Slide.TransitionTexture, new Rectangle(0, 0, 1024, 600), new Color(Color.White, AlphaCounter));
                }
            }
        }

        /// <summary>
        /// Quickly add a new instruction into the Instruction queue.
        /// </summary>
        /// <param name="Instruction">The instruction to be added.</param>
        public void AddInstr(Object Instruction)
        {
            Instructions.Enqueue(Instruction);
        }
    }
}

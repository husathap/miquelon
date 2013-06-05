using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miquelon.Shooter.Level
{
    /// <summary>
    /// A class that represents the first boss's level. 
    /// </summary>
    public class Boss1 : Level
    {
        /// <summary>
        /// The first background piece in level 1.
        /// </summary>
        public static Texture2D Boss1BG1Texture;

        /// <summary>
        /// The second background piece in level 1.
        /// </summary>
        public static Texture2D Boss1BG2Texture;

        /// <summary>
        /// The music for the level.
        /// </summary>
        public static SoundEffect LevelMusic;

        // Variables for managing the background.
        float Rotation = 0;

        /// <summary>
        /// Helps to restart the level.
        /// </summary>
        protected override void PrepareLevel()
        {
            EnemyList.Add(new Enemy.Spike(this));
            WaveList.Enqueue(Wave1);
        }

        /// <summary>
        /// Update the level.
        /// </summary>
        /// <param name="gt">The gametime used for updating.</param>
        protected override void UpdateBackground(GameTime gt)
        {
            Rotation += 0.001f;
            if (Rotation > MathHelper.TwoPi)
                Rotation = 0;
        }

        /// <summary>
        /// Draw the background of the first level.
        /// </summary>
        /// <param name="sb"></param>
        protected override void DrawBackground(SpriteBatch sb)
        {
            sb.Draw(Boss1BG1Texture, new Rectangle(0, 0, 1024, 600), Color.White);
            sb.Draw(Boss1BG2Texture, new Vector2(512, 300), null, Color.White, Rotation, new Vector2(Boss1BG2Texture.Width / 2,
                Boss1BG2Texture.Height / 2), 1, SpriteEffects.None, 0);
        }

        /// <summary>
        /// Representating the first wave.
        /// </summary>
        /// <returns></returns>
        bool Wave1()
        {
            return EnemyList.Count == 0;
        }

        /// <summary>
        /// Create a new instance of Level1.
        /// </summary>
        public Boss1() : base(LevelMusic)
        {
            PrepareLevel();
        }

        /// <summary>
        /// Transition to the next level.
        /// </summary>
        protected override void EndLevel()
        {
            Main.CurrentState = Slides.TransitionToLevel2.Create();
        }
    }
}

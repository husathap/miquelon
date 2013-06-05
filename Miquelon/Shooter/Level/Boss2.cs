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
    /// A class that represents the second boss's level.
    /// </summary>
    public class Boss2 : Level
    {
        /// <summary>
        /// The first background piece in level 2.
        /// </summary>
        public static Texture2D Boss2BGTexture;


        /// <summary>
        /// The music for the level.
        /// </summary>
        public static SoundEffect LevelMusic;

        /// <summary>
        /// A variable keeping track of rotation.
        /// </summary>
        float Rotation = 0;

        /// <summary>
        /// Helps to restart the level.
        /// </summary>
        protected override void PrepareLevel()
        {
            EnemyList.Add(new Enemy.MikePeterson(this));
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
            sb.Draw(Boss2BGTexture, new Rectangle(0, 50, 1024, 600), Color.White);
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
        public Boss2() : base(LevelMusic)
        {
            PrepareLevel();
        }

        /// <summary>
        /// Transition to the next state.
        /// </summary>
        protected override void EndLevel()
        {
            Main.CurrentState = Slides.Kitty.Create();
        }
    }
}

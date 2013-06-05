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
    /// A class that represents the final boss's level. 
    /// </summary>
    public class Boss3 : Level
    {
        /// <summary>
        /// The first background piece in level 1.
        /// </summary>
        public static Texture2D Boss3BG1Texture;

        /// <summary>
        /// The second background piece in level 1.
        /// </summary>
        public static Texture2D Boss3BG2Texture;

        /// <summary>
        /// The music for the level.
        /// </summary>
        public static SoundEffect LevelMusic;

        /// <summary>
        /// The variable keeping track of rotation.
        /// </summary>
        float Rotation = 0;

        /// <summary>
        /// Helps to restart the level.
        /// </summary>
        protected override void PrepareLevel()
        {
            EnemyList.Add(new Enemy.Bella(this));
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
            sb.Draw(Boss3BG1Texture, new Rectangle(0, 0, 1024, 600), Color.White);
            sb.Draw(Boss3BG2Texture, new Vector2(512, 300), null, new Color(Color.DarkBlue, 0.6f), Rotation, new Vector2(Boss3BG2Texture.Width / 2,
                Boss3BG2Texture.Height / 2), 1, SpriteEffects.None, 0);
            sb.Draw(Boss3BG2Texture, new Vector2(600, 200), null, new Color(Color.Brown, 0.2f), Rotation, new Vector2(Boss3BG2Texture.Width / 2,
                Boss3BG2Texture.Height / 2), 1, SpriteEffects.None, 0);
            sb.Draw(Boss3BG2Texture, new Vector2(200, 400), null, new Color(Color.Teal, 0.3f), Rotation, new Vector2(Boss3BG2Texture.Width / 2,
                Boss3BG2Texture.Height / 2), 1, SpriteEffects.None, 0);
            sb.Draw(Boss3BG2Texture, new Vector2(1000, 400), null, new Color(Color.SteelBlue, 0.7f), Rotation, new Vector2(Boss3BG2Texture.Width / 2,
                Boss3BG2Texture.Height / 2), 1, SpriteEffects.None, 0);
            sb.Draw(Boss3BG2Texture, new Vector2(100, 100), null, new Color(Color.Tomato, 0.43f), Rotation, new Vector2(Boss3BG2Texture.Width / 2,
               Boss3BG2Texture.Height / 2), 1, SpriteEffects.None, 0);
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
        public Boss3() : base(LevelMusic)
        {
            PrepareLevel();
        }

        /// <summary>
        /// Transition to the next state.
        /// </summary>
        protected override void EndLevel()
        {
            Player.Life = 3;
            Player.HP = Player.MaxHP * .5f;
            Main.CurrentState = Slides.Ending.Create();
        }
    }
}

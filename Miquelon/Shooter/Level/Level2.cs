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
    /// A class that represents the second level 
    /// </summary>
    public class Level2 : Level
    {
        /// <summary>
        /// The first background piece.
        /// </summary>
        public static Texture2D Level2BG1Texture;

        /// <summary>
        /// The music for the level.
        /// </summary>
        public static SoundEffect LevelMusic;

        /// <summary>
        /// The random number generator.
        /// </summary>
        Random rand = new Random();

        /// <summary>
        /// The first piece of the background rectangle.
        /// </summary>
        Rectangle Piece1 = new Rectangle(0, 0, 1024, 600);

        /// <summary>
        /// The second piece of the background rectangle.
        /// </summary>
        Rectangle Piece2 = new Rectangle(1024, 0, 1024, 600);

        int counter = 0;

        /// <summary>
        /// Helps to prepare the level.
        /// </summary>
        protected override void PrepareLevel()
        {

            EnemyList.Add(new Enemy.EvilEel2(this, 200));
            EnemyList.Add(new Enemy.EvilEel2(this, 500));

            WaveList.Enqueue(Wave1);
            WaveList.Enqueue(Wave2);
            WaveList.Enqueue(Wave3);
            WaveList.Enqueue(Wave4);
            WaveList.Enqueue(Wave5);
            WaveList.Enqueue(Wave6);
            WaveList.Enqueue(Wave7);
        }

        bool Wave1()
        {
            if (EnemyList.Count == 0)
            {
                EnemyList.Add(new Enemy.VerticalSaucer(this, new Vector2(256, 200), 0, false));
                EnemyList.Add(new Enemy.VerticalSaucer(this, new Vector2(512, 200), 0, false));
                EnemyList.Add(new Enemy.VerticalSaucer(this, new Vector2(768, 200), 0, false));
                counter = 0;
                return true;
            }

            if (counter >= 40)
            {
                for (int i = 0; i <= 10; i++)
                {
                    EnemyBulletList.Add(new Bullet.HPP(new Vector2(rand.Next(1024), 10), new Vector2(0, rand.Next(3, 6))));
                }

                EnemyBulletList.Add(new Bullet.Add(new Vector2(rand.Next(1024), 10), new Vector2(0, rand.Next(3, 6))));
                EnemyBulletList.Add(new Bullet.Add(new Vector2(rand.Next(1024), 10), new Vector2(0, rand.Next(3, 6)), true));
                counter = 0;
            }

            counter++;

            return false;
        }

        bool Wave2()
        {
            if (counter >= 10)
            {
                EnemyBulletList.Add(new Bullet.Add(new Vector2(rand.Next(1024), 10), new Vector2(0, rand.Next(3, 6)), true));
                counter = 0;
            }

            counter++;

            if (EnemyList.Count == 0)
            {
                EnemyList.Add(new Enemy.VerticalSaucer(this, new Vector2(612, 300), 1074, true));
                EnemyList.Add(new Enemy.VerticalSaucer(this, new Vector2(412, 300), 1074, true));
                EnemyList.Add(new Enemy.HorizontalSaucer(this, new Vector2(300, 400), -25, true));
                EnemyList.Add(new Enemy.HorizontalSaucer(this, new Vector2(512, 200), -25, true));
                EnemyList.Add(new Enemy.HorizontalSaucer(this, new Vector2(624, 100), -25, true));

                EnemyList.Add(new Enemy.EvilEel2(this, 100));
                EnemyList.Add(new Enemy.EvilEel2(this, 1124, 200));
                EnemyList.Add(new Enemy.EvilEel2(this, 1224, 300));
                EnemyList.Add(new Enemy.EvilEel2(this, 1324, 400));
                EnemyList.Add(new Enemy.EvilEel2(this, 1424, 500));

                return true;
            }
            else
            {
                return false;
            }
        }

        bool Wave3()
        {
            if (EnemyList.Count == 0)
            {
                EnemyList.Add(new Enemy.VerticalSaucer(this, new Vector2(256, 300), 1074, true));
                EnemyList.Add(new Enemy.VerticalSaucer(this, new Vector2(512, 300), 1074, true));
                EnemyList.Add(new Enemy.VerticalSaucer(this, new Vector2(768, 300), 1074, true));
                EnemyList.Add(new Enemy.HorizontalSaucer(this, new Vector2(300, 400), -25, true));
                EnemyList.Add(new Enemy.HorizontalSaucer(this, new Vector2(512, 200), -25, true));
                EnemyList.Add(new Enemy.HorizontalSaucer(this, new Vector2(624, 100), -25, true));
                return true;
            }
            else
            {
                return false;
            }
        }

        bool Wave4()
        {
            if (EnemyList.Count == 0)
            {
                EnemyList.Add(new Enemy.VerticalSaucer(this, new Vector2(612, 300), 1074, true));
                EnemyList.Add(new Enemy.VerticalSaucer(this, new Vector2(412, 300), 1074, true));
                EnemyList.Add(new Enemy.VerticalSaucer(this, new Vector2(852, 300), 1074, true));

                EnemyList.Add(new Enemy.VerticalSaucer(this, new Vector2(612, 200), 1374, true));
                EnemyList.Add(new Enemy.VerticalSaucer(this, new Vector2(412, 300), 1374, true));
                EnemyList.Add(new Enemy.VerticalSaucer(this, new Vector2(852, 400), 1374, true));
                EnemyList.Add(new Enemy.VerticalSaucer(this, new Vector2(512, 250), 1374, true));

                EnemyList.Add(new Enemy.HorizontalSaucer(this, new Vector2(512, 250), -25, true));
                EnemyList.Add(new Enemy.HorizontalSaucer(this, new Vector2(350, 450), 1100, true));
                EnemyList.Add(new Enemy.HorizontalSaucer(this, new Vector2(924, 150), 1100, true));
                EnemyList.Add(new Enemy.HorizontalSaucer(this, new Vector2(600, 550), -1100, true));

                counter = 0;

                return true;
            }
            else
            {

                if (counter >= 60)
                {
                    EnemyBulletList.Add(new Bullet.Add(new Vector2(rand.Next(1024), 620), new Vector2(0, -3), true));
                    EnemyBulletList.Add(new Bullet.Add(new Vector2(rand.Next(1024), 30), new Vector2(0, 3)));
                    EnemyBulletList.Add(new Bullet.HPP(new Vector2(rand.Next(1024), 620), new Vector2(0, -3)));
                    EnemyBulletList.Add(new Bullet.Garble(new Vector2(rand.Next(1024), 30), new Vector2(0, 3)));

                    counter = 0;
                }
                counter++;

                return false;
            }
        }

        bool Wave5()
        {
            if (EnemyList.Count == 0)
            {
                EnemyList.Add(new Enemy.Epsilon(this, 50, true));
                EnemyList.Add(new Enemy.Epsilon(this, 974, false));
                EnemyList.Add(new Enemy.Delta(this, 100, true));
                EnemyList.Add(new Enemy.Delta(this, 550, false));
                return true;
            }
            else
            {
                if (counter >= 55)
                {
                    EnemyBulletList.Add(new Bullet.Add(new Vector2(rand.Next(1024), 620), new Vector2(1, -2)));
                    EnemyBulletList.Add(new Bullet.Add(new Vector2(rand.Next(1024), 30), new Vector2(1, 1), true));
                    EnemyBulletList.Add(new Bullet.HPP(new Vector2(rand.Next(1024), 30), new Vector2(1, 3)));

                    EnemyBulletList.Add(new Bullet.Garble(new Vector2(rand.Next(1024), 620), new Vector2(-1.5f, -3)));

                    counter = 0;
                }
                counter++;

                return false;
            }
        }

        bool Wave6()
        {
            if (EnemyList.Count == 0)
            {
                EnemyList.Add(new Enemy.EvilEel2(this, 400));
                EnemyList.Add(new Enemy.ShooterFish2(this, 100));
                EnemyList.Add(new Enemy.TrackingShooterFish2(this, 500));

                EnemyList.Add(new Enemy.EvilEel2(this, 1350, 300));
                EnemyList.Add(new Enemy.ShooterFish2(this, 1200, 200));
                EnemyList.Add(new Enemy.TrackingShooterFish2(this, 1200, 400));

                EnemyList.Add(new Enemy.EvilEel2(this, 1400, 100));
                EnemyList.Add(new Enemy.ShooterFish2(this, 1400, 170));
                EnemyList.Add(new Enemy.TrackingShooterFish2(this, 1400, 550));

                EnemyList.Add(new Enemy.EvilEel2(this, 1600, 100));
                EnemyList.Add(new Enemy.ShooterFish2(this, 1600, 170));
                EnemyList.Add(new Enemy.ShooterFish2(this, 1600, 300));
                EnemyList.Add(new Enemy.TrackingShooterFish2(this, 1600, 550));
                EnemyList.Add(new Enemy.TrackingShooterFish2(this, 1600, 550));
                EnemyList.Add(new Enemy.TrackingShooterFish2(this, 1600, 550));

                EnemyList.Add(new Enemy.EvilEel2(this, 1800, 300));
                EnemyList.Add(new Enemy.ShooterFish2(this, 1800, 340));
                EnemyList.Add(new Enemy.ShooterFish2(this, 1800, 400));
                EnemyList.Add(new Enemy.ShooterFish2(this, 1800, 450));
                EnemyList.Add(new Enemy.TrackingShooterFish2(this, 1600, 550));

                EnemyList.Add(new Enemy.EvilEel2(this, 2000, 500));
                EnemyList.Add(new Enemy.ShooterFish2(this, 2000, 100));
                EnemyList.Add(new Enemy.ShooterFish2(this, 2000, 300));
                EnemyList.Add(new Enemy.ShooterFish2(this, 2000, 500));
                EnemyList.Add(new Enemy.TrackingShooterFish2(this, 1600, 200));

                EnemyList.Add(new Enemy.EvilEel2(this, 2100, 450));
                EnemyList.Add(new Enemy.ShooterFish2(this, 2150, 555));
                EnemyList.Add(new Enemy.ShooterFish2(this, 2300, 333));
                EnemyList.Add(new Enemy.ShooterFish2(this, 2100, 200));
                EnemyList.Add(new Enemy.TrackingShooterFish2(this, 2100, 450));

                EnemyList.Add(new Enemy.EvilEel2(this, 2500, 100));
                EnemyList.Add(new Enemy.EvilEel2(this, 2500, 550));
                EnemyList.Add(new Enemy.ShooterFish2(this, 2550, 222));
                EnemyList.Add(new Enemy.TrackingShooterFish2(this, 2500, 333));
                EnemyList.Add(new Enemy.ShooterFish2(this, 2560, 444));
                EnemyList.Add(new Enemy.TrackingShooterFish2(this, 2500, 450));

                EnemyList.Add(new Enemy.EvilEel2(this, 2700, 100));
                EnemyList.Add(new Enemy.EvilEel2(this, 2700, 550));
                EnemyList.Add(new Enemy.TrackingShooterFish2(this, 2750, 50));
                EnemyList.Add(new Enemy.TrackingShooterFish2(this, 2700, 333));
                EnemyList.Add(new Enemy.ShooterFish2(this, 2700, 512));
                EnemyList.Add(new Enemy.TrackingShooterFish2(this, 2700, 450));
                return true;
            }
            else
            {
                return false;
            }
        }

        bool Wave7()
        {
            if (EnemyList.Count == 0)
            {
                counter = 0;
                return true;
            }
            else
            {
                if (counter >= 10)
                {
                    EnemyBulletList.Add(new Bullet.HPP(new Vector2(rand.Next(1024), 620), new Vector2(-2, -2)));
                    EnemyBulletList.Add(new Bullet.Clear(new Vector2(rand.Next(1024), 620), new Vector2(-2, -2)));

                    if (rand.NextDouble() <= 0.05)
                    {
                        EnemyBulletList.Add(new Bullet.Life(new Vector2(rand.Next(1024), 620), new Vector2(-2, -2)));
                    }

                    counter = 0;
                }
                counter++;
                return false;
            }
        }

        /// <summary>
        /// Update the level.
        /// </summary>
        /// <param name="gt">The gametime used for updating.</param>
        protected override void UpdateBackground(GameTime gt)
        {
            Piece1.X -= 1;
            Piece2.X -= 1;

            if (Piece1.X <= -1024)
            {
                Piece1.X = 1024;
            }

            if (Piece2.X <= -1024)
            {
                Piece2.X = 1024;
            }
        }

        /// <summary>
        /// Draw the background of the first level.
        /// </summary>
        /// <param name="sb"></param>
        protected override void DrawBackground(SpriteBatch sb)
        {
            sb.Draw(Level2BG1Texture, Piece1, Color.White);
            sb.Draw(Level2BG1Texture, Piece2, Color.White);
        }

        /// <summary>
        /// Create a new instance of Level1.
        /// </summary>
        public Level2() : base(LevelMusic)
        {
            PrepareLevel();
        }

        /// <summary>
        /// Transition to then next state.
        /// </summary>
        protected override void EndLevel()
        {
            Main.CurrentState = Slides.SecondBoss.Create();
        }
    }
}

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
    /// A class that represents the third level. 
    /// </summary>
    public class Level3 : Level
    {
        /// <summary>
        /// The first background piece in level 3.
        /// </summary>
        public static Texture2D Level3BG1Texture;

        /// <summary>
        /// The second background piece in level 3.
        /// </summary>
        public static Texture2D Level3BG2Texture;

        /// <summary>
        /// The music for the level.
        /// </summary>
        public static SoundEffect LevelMusic;

        /// <summary>
        /// The first piece of the background rectangle.
        /// </summary>
        Rectangle Piece1 = new Rectangle(0, 0, 1024, 600);

        /// <summary>
        /// The second piece of the background rectangle.
        /// </summary>
        Rectangle Piece2 = new Rectangle(1024, 0, 1024, 600);

        /// <summary>
        /// The random number generator.
        /// </summary>
        Random rand = new Random();

        /// <summary>
        /// A counter of the level.
        /// </summary>
        int counter = 0;

        /// <summary>
        /// A counter of the level.
        /// </summary>
        int counter2 = 0;

        /// <summary>
        /// Helps to restart the level.
        /// </summary>
        protected override void PrepareLevel()
        {

            EnemyList.Add(new Enemy.Seahorse(this, 100, 700));
            EnemyList.Add(new Enemy.Seahorse(this, 400, 600));
            EnemyList.Add(new Enemy.Seahorse(this, 300, 800));
            EnemyList.Add(new Enemy.Seahorse(this, 1000, 850));

            EnemyList.Add(new Enemy.TrackingShooterFish3(this, 1200, 100));
            EnemyList.Add(new Enemy.TrackingShooterFish3(this, 1200, 200));
            EnemyList.Add(new Enemy.TrackingShooterFish3(this, 1200, 500));

            EnemyList.Add(new Enemy.Cloud(this, new Vector2(1100, 200)));
            EnemyList.Add(new Enemy.Cloud(this, new Vector2(1100, 210)));
            EnemyList.Add(new Enemy.Cloud(this, new Vector2(1140, 190)));

            EnemyList.Add(new Enemy.Cloud(this, new Vector2(1400, 250)));
            EnemyList.Add(new Enemy.Cloud(this, new Vector2(1350, 200)));
            EnemyList.Add(new Enemy.Cloud(this, new Vector2(1200, 190)));

            EnemyList.Add(new Enemy.Smiley(this, 1300, 325));
            EnemyList.Add(new Enemy.Smiley(this, 1650, 325));

            EnemyList.Add(new Enemy.Cloud(this, new Vector2(2000, 250)));
            EnemyList.Add(new Enemy.Cloud(this, new Vector2(2150, 200)));
            EnemyList.Add(new Enemy.Cloud(this, new Vector2(2250, 230)));

            EnemyList.Add(new Enemy.Seahorse(this, 100, 2000));
            EnemyList.Add(new Enemy.Seahorse(this, 400, 2100));
            EnemyList.Add(new Enemy.Seahorse(this, 300, 2200));
            EnemyList.Add(new Enemy.Seahorse(this, 1000, 2150));

            WaveList.Enqueue(Wave1);
            WaveList.Enqueue(Wave2);
            WaveList.Enqueue(Wave3);
            WaveList.Enqueue(Wave4);
            WaveList.Enqueue(Wave5);
            WaveList.Enqueue(Wave6);
            WaveList.Enqueue(Wave7);
            WaveList.Enqueue(Wave8);
            WaveList.Enqueue(Wave9);
            WaveList.Enqueue(Wave10);
            WaveList.Enqueue(Wave11);
        }

        /// <summary>
        /// Representing the first wave.
        /// </summary>
        /// <returns></returns>
        bool Wave1()
        {
            if (EnemyList.Count != 0)
            {
                if (counter >= 15)
                {
                    EnemyBulletList.Add(new Bullet.HPP(new Vector2(rand.Next(1024), 0), new Vector2(0, 2)));
                    EnemyBulletList.Add(new Bullet.Clear(new Vector2(rand.Next(1024), 0), new Vector2(0, 4)));
                    EnemyBulletList.Add(new Bullet.Cross(new Vector2(rand.Next(1024), 0), new Vector2(0, 3)));

                    if (rand.NextDouble() <= 0.05)
                    {
                        EnemyBulletList.Add(new Bullet.Life(new Vector2(rand.Next(1024), 0), new Vector2(0, 5)));
                    }

                    counter = 0;
                }

                counter++;
                return false;
            }
            else
            {
                counter = 0;

                for (int i = 630; i <= 1200; i += 100)
                {
                    EnemyList.Add(new Enemy.Seahorse(this, 300, i));
                    EnemyList.Add(new Enemy.Seahorse(this, 824, i));
                }

                return true;
            }
        }

        /// <summary>
        /// Represent the second wave of the enemy.
        /// </summary>
        /// <returns></returns>
        bool Wave2()
        {
            if (EnemyList.Count != 0)
            {
                
                return false;
            }
            else
            {
                EnemyList.Add(new Enemy.Smiley(this, 1300, 225));
                EnemyList.Add(new Enemy.Smiley(this, 1300, 325));
                EnemyList.Add(new Enemy.Smiley(this, 1300, 425));
                EnemyList.Add(new Enemy.Smiley(this, 1200, 325));
                EnemyList.Add(new Enemy.Smiley(this, 1400, 325));

                return true;
            }
        }

        bool Wave3()
        {
            if (EnemyList.Count != 0)
            {
                if (counter >= 15)
                {
                    EnemyBulletList.Add(new Bullet.HPP(new Vector2(rand.Next(1024), 630), new Vector2(0, -2)));
                    EnemyBulletList.Add(new Bullet.Clear(new Vector2(rand.Next(1024), 630), new Vector2(0, -2)));

                    if (rand.NextDouble() <= 0.01)
                    {
                        EnemyBulletList.Add(new Bullet.Life(new Vector2(rand.Next(1024), 0), new Vector2(0, 5)));
                    }

                    counter = 0;
                }

                counter++;
                return false;
            }
            else
            {
                EnemyList.Add(new Enemy.Kitty1(this));
                return true;
            }
        }

        bool Wave4()
        {
            if (EnemyList.Count != 0)
            {

                return false;
            }
            else
            {
                for (int i = 1200; i <= 3000; i += 150)
                {
                    EnemyList.Add(new Enemy.Cloud(this, new Vector2(i, 100)));
                }

                for (int i = 1400; i <= 3000; i += 600)
                {
                    EnemyList.Add(new Enemy.Smiley(this, i, 300));
                }

                return true;
            }
        }

        bool Wave5()
        {
            if (EnemyList.Count != 0)
            {
                if (counter >= 30)
                {
                    for (int i = 0; i <= 5; i++)
                    {
                        EnemyBulletList.Add(new Bullet.HPP(new Vector2(rand.Next(1024), 0), new Vector2(0, rand.Next(5))));
                        EnemyBulletList.Add(new Bullet.HPP(new Vector2(rand.Next(1024), 0), new Vector2(0, rand.Next(5))));
                        EnemyBulletList.Add(new Bullet.HPP(new Vector2(rand.Next(1024), 0), new Vector2(0, rand.Next(5))));
                        EnemyBulletList.Add(new Bullet.Clear(new Vector2(rand.Next(1024), 0), new Vector2(0, rand.Next(5))));
                    }
                    counter = 0;
                }

                counter++; 
                return false;
            }
            else
            {
                for (int i = 100; i <= 550; i += 80)
                {
                    EnemyList.Add(new Enemy.Smiley(this, 1300, i));
                }
                counter = 0;
                return true;
            }
        }

        bool Wave6()
        {
            if (EnemyList.Count == 0)
            {
                EnemyList.Add(new Enemy.Kitty2(this));
                return true;
            }
            return false;
        }

        bool Wave7()
        {
            if (EnemyList.Count != 0)
            {
                return false;
            }
            else
            {
                for (int y = 0; y <= 2; y++)
                {
                    for (int x = 50; x <= 1024; x += 100)
                    {
                        EnemyList.Add(new Enemy.Seahorse(this, x, (int)(0.5 * (float)x + 800 + 700 * y)));
                    }
                }
                return true;
            }
        }

        bool Wave8()
        {
            if (EnemyList.Count != 0)
            {
                if (counter >= 30)
                {
                    EnemyBulletList.Add(new Bullet.HPP(new Vector2(rand.Next(1024), 0), new Vector2(1, rand.Next(4))));
                    EnemyBulletList.Add(new Bullet.Cross(new Vector2(rand.Next(1024), 0), new Vector2(-1, rand.Next(4))));
                    EnemyBulletList.Add(new Bullet.Clear(new Vector2(rand.Next(1024), 0), new Vector2(0, rand.Next(4))));
                    counter = 0;
                }

                counter++;

                if (counter2 >= 200)
                {
                    EnemyBulletList.Add(new Bullet.Life(new Vector2(1054, rand.Next(50, 600)), new Vector2(-3, 0.01f)));
                    counter2 = 0;
                }

                counter2++;

                return false;
            }
            else
            {
                EnemyList.Add(new Enemy.Smiley(this, 1300, 325));
                EnemyList.Add(new Enemy.Smiley(this, 1300, 425));
                EnemyList.Add(new Enemy.Smiley(this, 1200, 325));

                for (int i = 200; i <= 600; i += 200)
                {
                    EnemyList.Add(new Enemy.Smiley(this, 2600, i));
                }

                return true;
            }
        }

        bool Wave9()
        {
            if (EnemyList.Count != 0)
            {
                if (counter >= 50)
                {
                    EnemyBulletList.Add(new Bullet.HPP(new Vector2(rand.Next(1024), 0), new Vector2(0, rand.Next(4))));
                    EnemyBulletList.Add(new Bullet.Clear(new Vector2(rand.Next(1024), 0), new Vector2(0, rand.Next(4))));
                    counter = 0;
                }

                counter++;

                if (counter2 >= 200)
                {
                    EnemyBulletList.Add(new Bullet.Life(new Vector2(1054, rand.Next(50, 600)), new Vector2(-3, 0)));
                    counter2 = 0;
                }

                counter2++;

                return false;
            }
            else
            {
                EnemyList.Add(new Enemy.TrackingShooterFish3(this, 325));
                return true;
            }
        }

        bool Wave10()
        {
            if (EnemyList.Count == 0)
            {
                EnemyList.Add(new Enemy.Kitty3(this));
                return true;
            }
            return false;
        }

        bool Wave11()
        {
            return EnemyList.Count == 0;
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
            sb.Draw(Level3BG1Texture, Piece1, Color.White);
            sb.Draw(Level3BG1Texture, Piece2, Color.White);
        }

        /// <summary>
        /// Create a new instance of Level1.
        /// </summary>
        public Level3() : base(LevelMusic)
        {
            PrepareLevel();
        }

        /// <summary>
        /// Transition to then next state.
        /// </summary>
        protected override void EndLevel()
        {
            Main.CurrentState = Slides.FinalBoss.Create();
        }
    }
}

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
    /// A class that represents the first level 
    /// </summary>
    public class Level1 : Level
    {
        /// <summary>
        /// The first background piece in level 1.
        /// </summary>
        public static Texture2D Lvl1BG1Texture;

        /// <summary>
        /// The second background piece in level 1.
        /// </summary>
        public static Texture2D Lvl1BG2Texture;

        /// <summary>
        /// The third background piece in level 1.
        /// </summary>
        public static Texture2D Lvl1BG3Texture;

        /// <summary>
        /// The music for the level.
        /// </summary>
        public static SoundEffect LevelMusic;

        /// <summary>
        /// The counter for the level.
        /// </summary>
        int counter = 0;

        /// <summary>
        /// The second counter for the level.
        /// </summary>
        int counter2 = 0;

        /// <summary>
        /// The third counter for the level.
        /// </summary>
        int counter3 = 0;

        /// <summary>
        /// The random number generator.
        /// </summary>
        Random rand = new Random();

        // Variables for managing the background.
        Rectangle BGPiece1 = new Rectangle(0, 0, 1024, 600);
        Rectangle BGPiece2 = new Rectangle(1024, 0, 1024, 600);
        float Rotation = 0;

        /// <summary>
        /// Helps to restart the level.
        /// </summary>
        protected override void PrepareLevel()
        {
            EnemyList.Add(new Enemy.ShooterFish(this, 100));
            EnemyList.Add(new Enemy.ShooterFish(this, 300));
            EnemyList.Add(new Enemy.ShooterFish(this, 400));

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
            WaveList.Enqueue(Wave12);
            WaveList.Enqueue(Wave13);
            WaveList.Enqueue(Wave14);
            WaveList.Enqueue(Wave15);
        }

        /// <summary>
        /// Update the level.
        /// </summary>
        /// <param name="gt">The gametime used for updating.</param>
        protected override void UpdateBackground(GameTime gt)
        {
            BGPiece1.X -= 2;
            BGPiece2.X -= 2;

            if (BGPiece1.Right <= 0)
            {
                BGPiece1.X = 1024;
            }

            if (BGPiece2.Right <= 0)
            {
                BGPiece2.X = 1024;
            }

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
            sb.Draw(Lvl1BG1Texture, new Rectangle(0, 0, 1024, 600), Color.White);
            sb.Draw(Lvl1BG2Texture, new Vector2(512, 300), null, Color.White, Rotation, new Vector2(Lvl1BG2Texture.Width / 2,
                Lvl1BG2Texture.Height / 2), 1, SpriteEffects.None, 0);
            sb.Draw(Lvl1BG3Texture, BGPiece1, Color.White);
            sb.Draw(Lvl1BG3Texture, BGPiece2, Color.White);
        }

        bool Wave1()
        {
            if (counter >= 40)
            {
                EnemyBulletList.Add(new Bullet.Blocky(new Vector2(rand.Next(1024), -20), new Vector2(-1, 3)));
                counter = 0;
            }

            counter++;

            if (this.EnemyList.Count == 0)
            {
                EnemyList.Add(new Enemy.ShooterFish(this, 200));
                EnemyList.Add(new Enemy.ShooterFish(this, 400));
                EnemyList.Add(new Enemy.ShooterFish(this, 500));
                counter = 0;
                return true;
            }
            return false;
        }

        bool Wave2()
        {
            if (counter >= 40)
            {
                EnemyBulletList.Add(new Bullet.Blocky(new Vector2(rand.Next(1024), -20), new Vector2(-1, 3)));
                EnemyBulletList.Add(new Bullet.HPP(new Vector2(rand.Next(1024), -20), new Vector2(-1, 3)));
                counter = 0;
            }

            counter++;

            if (this.EnemyList.Count == 0)
            {
                EnemyList.Add(new Enemy.TrackingShooterFish(this, 200));
                EnemyList.Add(new Enemy.ShooterFish(this, 400));
                EnemyList.Add(new Enemy.TrackingShooterFish(this, 500));
                EnemyList.Add(new Enemy.TrackingShooterFish(this, 600));
                counter = 0;
                return true;
            }
            return false;
        }

        bool Wave3()
        {
            if (counter >= 20)
            {
                counter = 0;
                EnemyBulletList.Add(new Bullet.Blocky(new Vector2(rand.Next(1024), -20), new Vector2(-1, 3)));
            }

            counter++;

            if (counter2 >= 40)
            {
                counter2 = 0;
                EnemyBulletList.Add(new Bullet.Add(new Vector2(rand.Next(1024), -20), new Vector2(-1, 3)));
            }

            counter2++;

            if (counter3 >= 50)
            {
                if (rand.NextDouble() < 0.3)
                {
                    EnemyBulletList.Add(new Bullet.Life(new Vector2(rand.Next(1024), -20), new Vector2(-1, 3)));
                }
                else
                {
                    EnemyBulletList.Add(new Bullet.HPP(new Vector2(rand.Next(1024), -20), new Vector2(-1, 3)));
                }

                counter3 = 0;
            }

            counter3++;

            if (this.EnemyList.Count == 0)
            {
                EnemyList.Add(new Enemy.TrackingShooterFish(this, 200));
                EnemyList.Add(new Enemy.TrackingShooterFish(this, 300));
                EnemyList.Add(new Enemy.TrackingShooterFish(this, 500));
                EnemyList.Add(new Enemy.TrackingShooterFish(this, 600));
                EnemyList.Add(new Enemy.TrackingShooterFish(this, 100));
                counter = 0;
                counter2 = 0;
                return true;
            }
            return false;
        }

        bool Wave4()
        {
            if (counter >= 10)
            {
                counter = 0;
                EnemyBulletList.Add(new Bullet.Blocky(new Vector2(rand.Next(1024), -20), new Vector2(-1, 3)));
            }

            counter++;

            if (counter2 >= 40)
            {
                counter2 = 0;
                EnemyBulletList.Add(new Bullet.Add(new Vector2(rand.Next(1024), -20), new Vector2(-1, 3)));
            }

            counter2++;

            if (counter3 >= 50)
            {
                double num = rand.NextDouble();
                if (num < 0.1)
                {
                    EnemyBulletList.Add(new Bullet.Life(new Vector2(rand.Next(1024), -20), new Vector2(-1, 3)));
                }
                else if (num >= 0.1 && num <= 0.5)
                {
                    EnemyBulletList.Add(new Bullet.HPP(new Vector2(rand.Next(1024), -20), new Vector2(-1, 3)));
                }
                else
                {
                    EnemyBulletList.Add(new Bullet.Clear(new Vector2(rand.Next(1024), -20), new Vector2(-1, 3)));
                }

                counter3 = 0;
            }

            counter3++;

            if (this.EnemyList.Count == 0)
            {
                EnemyList.Add(new Enemy.TrackingShooterFish(this, 200));
                EnemyList.Add(new Enemy.TrackingShooterFish(this, 300));
                EnemyList.Add(new Enemy.TrackingShooterFish(this, 500));
                EnemyList.Add(new Enemy.TrackingShooterFish(this, 600));
                EnemyList.Add(new Enemy.EvilEel(this, 350));
                counter = 0;
                counter2 = 0;
                counter3 = 0;
                return true;
            }
            return false;
        }


        bool Wave5()
        {
            if (counter >= 10)
            {
                counter = 0;
                EnemyBulletList.Add(new Bullet.Blocky(new Vector2(rand.Next(1024), 620), new Vector2(1, -3)));
            }

            counter++;

            if (counter2 >= 40)
            {
                counter2 = 0;
                EnemyBulletList.Add(new Bullet.Add(new Vector2(rand.Next(1024), 620), new Vector2(1, -3)));
            }

            counter2++;

            if (counter3 >= 50)
            {
                double num = rand.NextDouble();
                if (num < 0.1)
                {
                    EnemyBulletList.Add(new Bullet.Life(new Vector2(rand.Next(1024), 620), new Vector2(1, -3)));
                }
                else if (num >= 0.1 || num <= 0.5)
                {
                    EnemyBulletList.Add(new Bullet.HPP(new Vector2(rand.Next(1024), 620), new Vector2(1, -3)));
                }
                else
                {
                    EnemyBulletList.Add(new Bullet.Clear(new Vector2(rand.Next(1024), 620), new Vector2(1, -3)));
                }

                counter3 = 0;
            }

            counter3++;

            if (this.EnemyList.Count == 0)
            {
                EnemyList.Add(new Enemy.TrackingShooterFish(this, 200));
                EnemyList.Add(new Enemy.TrackingShooterFish(this, 300));
                EnemyList.Add(new Enemy.TrackingShooterFish(this, 500));
                EnemyList.Add(new Enemy.TrackingShooterFish(this, 600));
                counter = 0;
                counter2 = 0;
                counter3 = 0;
                return true;
            }
            return false;
        }


        bool Wave6()
        {
            return EnemyBulletList.Count == 0 && EnemyList.Count == 0;
        }


        bool Wave7()
        {
            EnemyList.Add(new Enemy.UltimateBlocky(this));
            return true;
        }


        bool Wave8()
        {
            return EnemyBulletList.Count == 0 && EnemyList.Count == 0;
        }


        bool Wave9()
        {
            for (int i = 1044; i <= 3000; i += 200)
            {
                EnemyList.Add(new Enemy.TrackingShooterFish(this, i, 80));
                EnemyList.Add(new Enemy.TrackingShooterFish(this, i, 520));
            }

            return true;
        }


        bool Wave10()
        {
            if (counter >= 50)
            {
                counter = 0;
                EnemyBulletList.Add(new Bullet.Blocky(new Vector2(-20, rand.Next(600)), new Vector2(4f, 0.002f)));
            }

            counter++;

            if (counter2 >= 100)
            {
                counter2 = 0;
                EnemyBulletList.Add(new Bullet.Add(new Vector2(-20, rand.Next(600)), new Vector2(4f, 0.002f)));
            }

            counter2++;

            if (counter3 >= 10)
            {
                double num = rand.NextDouble();
                if (num < 0.05)
                {
                    EnemyBulletList.Add(new Bullet.Life(new Vector2(-20, rand.Next(600)), new Vector2(4f, 0.002f)));
                }
                else if (num >= 0.05 || num <= 0.8)
                {
                    EnemyBulletList.Add(new Bullet.HPP(new Vector2(-20, rand.Next(600)), new Vector2(4f, 0.002f)));
                }
                else
                {
                    EnemyBulletList.Add(new Bullet.Clear(new Vector2(-20, rand.Next(600)), new Vector2(4f, 0.002f)));
                }

                counter3 = 0;
            }

            counter3++;

            return EnemyList.Count == 0;
        }

        bool Wave11()
        {
            EnemyList.Add(new Enemy.EvilEel(this, 1324, 350));
            EnemyList.Add(new Enemy.EvilEel(this, 250));
            return true;
        }


        bool Wave12()
        {
            if (EnemyList.Count > 0)
            {
                if (counter >= 5)
                {
                    EnemyBulletList.Add(new Bullet.HPP(new Vector2(1044, rand.Next(600)), new Vector2(-3.5f, -0.2f)));
                    counter = 0;
                }
                counter++;
                return false;
            }

            return true;
        }

        bool Wave13()
        {
            for (int i = 1044; i <= 2500; i += 100)
            {
                EnemyList.Add(new Enemy.TrackingShooterFish(this, i, 250));
                EnemyList.Add(new Enemy.TrackingShooterFish(this, i, 450));
            }
            return true;
        }

        bool Wave14()
        {
            if (counter >= 50)
            {
                counter = 0;
                EnemyBulletList.Add(new Bullet.Blocky(new Vector2(rand.Next(1024), 620), new Vector2(0, -5)));
            }

            counter++;

            if (counter2 >= 100)
            {
                counter2 = 0;
                EnemyBulletList.Add(new Bullet.Add(new Vector2(rand.Next(1024), 620), new Vector2(0, -5)));
            }

            counter2++;

            if (counter3 >= 10)
            {
                double num = rand.NextDouble();
                if (num < 0.05)
                {
                    EnemyBulletList.Add(new Bullet.Life(new Vector2(rand.Next(1024), 620), new Vector2(0, -5)));
                }
                else if (num >= 0.05 || num <= 0.8)
                {
                    EnemyBulletList.Add(new Bullet.HPP(new Vector2(rand.Next(1024), 620), new Vector2(0, -5)));
                }
                else
                {
                    EnemyBulletList.Add(new Bullet.Clear(new Vector2(rand.Next(1024), 620), new Vector2(0, -5)));
                }

                counter3 = 0;
            }

            counter3++;

            return EnemyList.Count == 0;
        }

        bool Wave15()
        {
            return EnemyList.Count == 0 && EnemyBulletList.Count == 0;
        }

        /// <summary>
        /// Create a new instance of Level1.
        /// </summary>
        public Level1() : base(LevelMusic)
        {
            PrepareLevel();
        }

        /// <summary>
        /// Transition to the next state.
        /// </summary>
        protected override void EndLevel()
        {
            Main.CurrentState = Slides.FirstBoss.Create();
        }
    }
}

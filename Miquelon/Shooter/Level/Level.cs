using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Miquelon.Shooter.Bullet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miquelon.Shooter.Level
{
    /// <summary>
    /// A delegate representing a wave of enemy. The function return trues when the wave is done.
    /// </summary>
    /// <returns></returns>
    public delegate bool Wave();

    /// <summary>
    /// A base class of all shooter levels in the game.
    /// </summary>
    public abstract class Level : State
    {

        /// <summary>
        /// Tell whether the level is fully initialized or not.
        /// </summary>
        bool FullyInitialized = false;

        /// <summary>
        /// The font of MainBar.
        /// </summary>
        public static SpriteFont MainBarFont;

        /// <summary>
        /// The texture for MainBar.
        /// </summary>
        public static Texture2D MainBarTexture;

        /// <summary>
        /// The texture for HPBar.
        /// </summary>
        public static Texture2D HPBarTexture;

        /// <summary>
        /// The texture for Pause Screen.
        /// </summary>
        public static Texture2D PauseScreenTexture;

        /// <summary>
        /// The texture for game over.
        /// </summary>
        public static Texture2D GameOverTexture;

        /// <summary>
        /// The texture for the back of the HP Bar.
        /// </summary>
        public static Texture2D HPBarBackTexture;

        /// <summary>
        /// The texture used for transitioning.
        /// </summary>
        public static Texture2D TransitionTexture;

        /// <summary>
        /// The sound effect when the screen is cleared.
        /// </summary>
        public static SoundEffect ClearSFX;

        /// <summary>
        /// The sound effect when the enemy is hit.
        /// </summary>
        public static SoundEffect EnemyHitSFX;

        /// <summary>
        /// The sound effect when the player gets a good stuff.
        /// </summary>
        public static SoundEffect GoodStuffSFX;

        /// <summary>
        /// The sound effect when the player is hit.
        /// </summary>
        public static SoundEffect PlayerHitSFX;

        /// <summary>
        /// The sound effect when the player gets a life.
        /// </summary>
        public static SoundEffect LifeSFX;

        /// <summary>
        /// The sound effect when the enemy is hit.
        /// </summary>
        public static SoundEffect EnemyHit;

        /// <summary>
        /// The sound effect when the enemy is killed.
        /// </summary>
        public static SoundEffect EnemyDead;

        /// <summary>
        /// The sound effect when the player gets an Add.
        /// </summary>
        public static SoundEffect AddSFX;

        /// <summary>
        /// The background music for the level.
        /// </summary>
        public SoundEffect BackgroundMusic;

        /// <summary>
        /// The controller for the background music.
        /// </summary>
        SoundEffectInstance BGInstance = new SoundEffectInstance();

        /// <summary>
        /// Indicate whether the game is paused or not.
        /// </summary>
        bool PauseMode;

        /// <summary>
        /// Indicate whether the game is over or not.
        /// </summary>
        bool GameOverMode;

        /// <summary>
        /// The old keyboard state.
        /// </summary>
        KeyboardState oldks;

        /// <summary>
        /// The counter for when a new player bullet can be released.
        /// </summary>
        int PlayerBulletWait;

        /// <summary>
        /// The list of all player's bullet. It is declared as public so that programmers can do some trick with the bullets.
        /// </summary>
        public List<PlayerBullet> PlayerBulletList = new List<PlayerBullet>();

        /// <summary>
        /// The list of all enemies' bullet. It is declared as public so that programmers can do some trick with the bullets.
        /// </summary>
        public List<Bullet.Bullet> EnemyBulletList = new List<Bullet.Bullet>();

        /// <summary>
        /// Contains the list of all enemies on the screen.
        /// </summary>
        public List<Enemy.Enemy> EnemyList = new List<Enemy.Enemy>();

        /// <summary>
        /// The list of all of the wave in the level. If the list is null,
        /// then the level is in "Test Mode" which means the level will never
        /// quit.
        /// </summary>
        public Queue<Wave> WaveList = new Queue<Wave>();

        /// <summary>
        /// The opacity of the transition screen.
        /// </summary>
        float TransitionOpacity = 1f;

        /// <summary>
        /// Update the background of the game. Use this to also update the other environment factor as well.
        /// </summary>
        /// <param name="gt"></param>
        protected virtual void UpdateBackground(GameTime gt) { }

        /// <summary>
        /// A variable indicate whether the space/enter key is pressed for the first time or not.
        /// </summary>
        bool FirstTimeInput = true;

        /// <summary>
        /// Update the level.
        /// </summary>
        /// <param name="gt"></param>
        public void Update(GameTime gt)
        {

            if (!FullyInitialized)
            {
                BGInstance.Play();
                FullyInitialized = true;
            }

            KeyboardState ks = Keyboard.GetState();

#if DEBUG
            // Allows the developer to skip the level during debugging.
            if (ks.IsKeyUp(Keys.F1) && oldks.IsKeyDown(Keys.F1))
            {
                if (WaveList != null)
                {
                    WaveList.Clear();
                }
            }
#endif

            if (GameOverMode)
            {
                if (FirstTimeInput)
                {
                    if (oldks.IsKeyUp(Keys.Enter) && oldks.IsKeyUp(Keys.Space))
                    {
                        FirstTimeInput = false;
                    }
                }
                else
                {
                    GameOverUpdate(ks);
                }
            }
            else
            {

                if (!PauseMode)
                {
                    // Check whether the game should be paused or not.
                    if (ks.IsKeyUp(Keys.Escape) && oldks.IsKeyDown(Keys.Escape))
                    {
                        PauseMode = true;
                        if (BackgroundMusic != null)
                            BGInstance.Pause();
                    }

                    // Update the wave.
                    if (WaveList != null)
                    {
                        if (WaveList.Count > 0)
                        {
                            if (WaveList.Peek().Invoke())
                            {
                                WaveList.Dequeue();
                            }
                        }
                        else
                        {
                            // No more waves. So moving on to the next state.
                            Player.Sprite.Position = new Vector2(100, 350);

                            if (BackgroundMusic != null)
                            {
                                BGInstance.Stop();
                            }

                            // Transition to the next state.
                            EndLevel();
                        }
                    }

                    // Update the components.
                    UpdatePlayer(ks);
                    UpdateBullet();
                    UpdateEnemy(gt);
                    UpdateBackground(gt);
                }
                else
                {
                    PauseUpdate(ks);
                }
            }

            oldks = ks;
        }

        /// <summary>
        /// Update the enemies in the game.
        /// </summary>
        private void UpdateEnemy(GameTime gt)
        {
            int i = 0;

            while (i < EnemyList.Count)
            {
                int j = 0;

                while (j < PlayerBulletList.Count)
                {
                    if (PlayerBulletList[j].IsColliding(EnemyList[i]) && EnemyList[i].HP > 0)
                    {
                        EnemyList[i].HP -= 1;
                        PlayerBulletList.RemoveAt(j);
                        EnemyHitSFX.Play();

                        if (EnemyList[i].HP <= 0)
                        {
                            EnemyDead.Play();
                        }

                        j--;
                    }
                    j++;
                }

                if (EnemyList[i].DeadFlag || EnemyList[i].HP <= 0)
                {
                    EnemyList.RemoveAt(i);
                    i--;
                }
                else
                {
                    EnemyList[i].Update(gt);
                }

                i++;
            }
        }

        /// <summary>
        /// Update the game after the game is over. Wait for input to back to the main screen.
        /// </summary>
        /// <param name="ks"></param>
        private void GameOverUpdate(KeyboardState ks)
        {
            if (!FirstTimeInput)
            {
                if ((ks.IsKeyUp(Keys.Enter) && oldks.IsKeyDown(Keys.Enter)) ||
                        (ks.IsKeyUp(Keys.Space) && oldks.IsKeyDown(Keys.Space)))
                {
                    Player.Life = 3;
                    Player.HP = Player.MaxHP * .5f;
                    Player.Sprite.Position = new Vector2(100, 350);
                    Main.CurrentState = new Title();
                }
            }
        }

        /// <summary>
        /// Update the bullets.
        /// </summary>
        private void UpdateBullet()
        {
            int i = 0;

            // Update the player's bullet.
            while (i < PlayerBulletList.Count)
            {
                if (PlayerBulletList[i].X > 1044)
                {
                    PlayerBulletList.RemoveAt(i);
                    i--;
                }
                else
                {
                    PlayerBulletList[i].Position += PlayerBulletList[i].Trajectory;
                }
                i++;
            }

            i = 0;

            // Update the enemy's bullet.
            while (i < EnemyBulletList.Count)
            {
                if (EnemyBulletList[i].X > 1024 + (float)EnemyBulletList[i].Texture.Width * EnemyBulletList[i].Scale ||
                    EnemyBulletList[i].X < 0 - (float)EnemyBulletList[i].Texture.Width * EnemyBulletList[i].Scale ||
                    EnemyBulletList[i].Y > 600 + (float)EnemyBulletList[i].Texture.Height * EnemyBulletList[i].Scale ||
                    EnemyBulletList[i].Y < 0 - (float)EnemyBulletList[i].Texture.Height * EnemyBulletList[i].Scale)
                {
                    // If out of bound:
                    EnemyBulletList.RemoveAt(i);
                    i--;
                }
                else
                {
                    EnemyBulletList[i].Position += EnemyBulletList[i].Trajectory;

                    // If has collided with the player.
                    if (EnemyBulletList[i].IsColliding(Player.Sprite))
                    {
                        // If the bullet's type is Clear.
                        if (EnemyBulletList[i] is Clear)
                        {
                            ClearSFX.Play();
                            EnemyBulletList.Clear();
                            
                        }
                        // If the bullet's type is Life.
                        else if (EnemyBulletList[i] is Life)
                        {
                            LifeSFX.Play();

                            Player.Life++;

                            if (Player.Life > Player.MaxLife)
                                Player.Life = Player.MaxLife;

                            EnemyBulletList.RemoveAt(i);
                            i--;
                        }
                        // If the bullet's type is Add.
                        else if (EnemyBulletList[i] is Add)
                        {

                            if (!((Add)EnemyBulletList[i]).Inverted)
                            {
                                // Add another bullet to the player's head.
                                EnemyBulletList.Add(new BigBullet(new Vector2(Player.Sprite.X, -100),
                                    new Vector2(0, 6), Color.Red));
                            }
                            else
                            {
                                EnemyBulletList.Add(new BigBullet(new Vector2(Player.Sprite.X, 700),
                                    new Vector2(0, -6), Color.Red));
                            }

                            EnemyBulletList.RemoveAt(i);

                            AddSFX.Play();
                        }
                        // If the bullet's type is anything else.
                        else
                        {
                            // If the bullet's HPP.
                            if (EnemyBulletList[i] is HPP)
                            {
                                GoodStuffSFX.Play();
                            }
                            // If the bullet is truly malicious.
                            else
                            {
                                PlayerHitSFX.Play();
                            }

                            Player.HP -= EnemyBulletList[i].Power;

                            if (Player.HP <= 0)
                            {
                                Player.Life--;
                                if (Player.Life <= 0)
                                {
                                    // If the game is over.

                                    // Restart the level.
                                    if (BackgroundMusic != null)
                                    {
                                        BGInstance.Stop();
                                    }

                                    Player.HP = 0.5f * Player.MaxHP;
                                    EnemyBulletList.Clear();
                                    PlayerBulletList.Clear();
                                    Player.Sprite.Position = new Vector2(100, 350);
                                    if (WaveList != null)
                                        WaveList.Clear();
                                    EnemyList.Clear();
                                    TransitionOpacity = 1f;

                                    GameOverMode = true;
                                    break;
                                }
                                else
                                {
                                    // If the game is not over, but merely lost a life.
                                    if (BackgroundMusic != null)
                                    {
                                        BGInstance.Stop();
                                        BGInstance.Play();
                                    }

                                    Player.HP = 0.5f * Player.MaxHP;
                                    EnemyBulletList.Clear();
                                    PlayerBulletList.Clear();
                                    if (WaveList != null)
                                        WaveList.Clear();
                                    EnemyList.Clear();
                                    Player.Sprite.Position = new Vector2(100, 350);
                                    TransitionOpacity = 1f;

                                    // Restart the level.
                                    PrepareLevel();
                                    break;
                                }
                            }
                            if (Player.HP > Player.MaxHP)
                                Player.HP = Player.MaxHP;

                            EnemyBulletList.RemoveAt(i);
                            i--;
                        }
                    }
                    else
                    {
                        // If the bullet has not hit the player, check if it is out of bound.
                        if (EnemyBulletList[i].X < -600 ||
                            EnemyBulletList[i].X > 1624 ||
                            EnemyBulletList[i].Y < -600 ||
                            EnemyBulletList[i].Y > 1200)
                        {
                            EnemyBulletList.RemoveAt(i);
                            i--;
                        }
                    }
                }

                i++;
            }
        }

        /// <summary>
        /// Update the level when it is paused.
        /// </summary>
        /// <param name="ks">The keybard state to be used.</param>
        void PauseUpdate(KeyboardState ks)
        {
            if ((ks.IsKeyUp(Keys.Enter) && oldks.IsKeyDown(Keys.Enter)) ||
                    (ks.IsKeyUp(Keys.Space) && oldks.IsKeyDown(Keys.Space)))
            {
                PauseMode = false;
                if (BackgroundMusic != null)
                {
                    BGInstance = new SoundEffectInstance(BackgroundMusic);
                    BGInstance.IsLooped = true;
                    BGInstance.Play();
                }
            }

            if (ks.IsKeyUp(Keys.R) && oldks.IsKeyDown(Keys.R))
            {
                Player.Life = 3;
                Player.HP = Player.MaxHP * .5f;
                Player.Sprite.Position = new Vector2(100, 350);
                if (BackgroundMusic != null)
                {
                    BGInstance.Stop();
                }
                Main.CurrentState = new Title();
            }
        }

        /// <summary>
        /// Update the player.
        /// </summary>
        /// <param name="gt">The game time.</param>
        /// <param name="ks">The keyboard state.</param>
        void UpdatePlayer(KeyboardState ks)
        {
            // Rightie Scheme

            if (ks.IsKeyDown(Keys.Up))
            {
                Player.Sprite.Y = Math.Max(50, Player.Sprite.Y - 3);
            }

            if (ks.IsKeyDown(Keys.Down))
            {
                Player.Sprite.Y = Math.Min(600, Player.Sprite.Y + 3);
            }

            if (ks.IsKeyDown(Keys.Left))
            {
                Player.Sprite.X = Math.Max(0, Player.Sprite.X - 3);
            }

            if (ks.IsKeyDown(Keys.Right))
            {
                Player.Sprite.X = Math.Min(1024, Player.Sprite.X + 3);
            }

            // Letfie Scheme

            if (ks.IsKeyDown(Keys.W))
            {
                Player.Sprite.Y = Math.Max(50, Player.Sprite.Y - 3);
            }

            if (ks.IsKeyDown(Keys.S))
            {
                Player.Sprite.Y = Math.Min(600, Player.Sprite.Y + 3);
            }

            if (ks.IsKeyDown(Keys.A))
            {
                Player.Sprite.X = Math.Max(0, Player.Sprite.X - 3);
            }

            if (ks.IsKeyDown(Keys.D))
            {
                Player.Sprite.X = Math.Min(1024, Player.Sprite.X + 3);
            }

            // Shooting
            if (ks.IsKeyDown(Keys.Enter) || ks.IsKeyDown(Keys.Space))
            {
                PlayerBulletWait++;
            }

            if (PlayerBulletWait >= 10)
            {
                PlayerBulletList.Add(new PlayerBullet(Player.Sprite.Position));
                //Player.HP -= 0.1f;
                PlayerBulletWait = 0;
            }
        }

        /// <summary>
        /// Draw the level onto screen.
        /// </summary>
        /// <param name="sb">The spritebatch that used for drawing.</param>
        public void Draw(SpriteBatch sb)
        {
            if (!GameOverMode)
            {
                // Draw the background
                DrawBackground(sb);

                // Draw the bullets.

                foreach (Sprite eb in EnemyBulletList)
                {
                    sb.Draw(eb);
                }

                foreach (Sprite pb in PlayerBulletList)
                {
                    sb.Draw(pb);
                }

                // Draw the enemies.
                foreach (Enemy.Enemy e in EnemyList)
                {
                    Color TempColor = new Color(1f, e.HP / e.MaxHP, e.HP / e.MaxHP, e.Color.A);
                    sb.Draw(e.Texture, e.Position, null, TempColor, e.Rotation, e.Origin, e.Scale, SpriteEffects.None, 1);
                }

                // Draw the player.
                sb.Draw(Player.Sprite);

                // Draw the interface.
                sb.Draw(MainBarTexture, new Rectangle(0, 0, 1024, 50), Color.White);
                sb.DrawString(MainBarFont, "HP:", new Vector2(10, 4), Color.White);
                sb.DrawString(MainBarFont, "Life: " + Player.Life, new Vector2(10, 25), Color.White);

                sb.Draw(HPBarBackTexture, new Rectangle(45, 6, 500, 16), Color.White);
                sb.Draw(HPBarTexture, new Rectangle(45, 6, (int)(Player.HP / Player.MaxHP * 500), 16), new Rectangle(45, 6, (int)(Player.HP / Player.MaxHP * 500), 16), Color.White);

                // Draw the transition screen over it.
                if (TransitionOpacity > 0)
                {
                    sb.Draw(TransitionTexture, new Rectangle(0, 0, 1024, 600), new Color(Color.White, TransitionOpacity));
                    TransitionOpacity -= 0.01f;
                }

                // If the game is paused, draw the pause screen over it.
                if (PauseMode)
                {
                    sb.Draw(PauseScreenTexture, new Rectangle(0, 0, 1024, 600), Color.White);
                }
            }
            else
            {
                sb.Draw(GameOverTexture, new Rectangle(0, 0, 1024, 600), Color.White);
            }
        }

        /// <summary>
        /// Draw the background. Override to use.
        /// </summary>
        /// <param name="sb"></param>
        protected virtual void DrawBackground(SpriteBatch sb) { }

        /// <summary>
        /// Help the game to prepare a level during restarting and during the actual gameplay.
        /// </summary>
        protected abstract void PrepareLevel();

        /// <summary>
        /// The method will be called when the level is finished. Use this to transition to the next screen.
        /// </summary>
        protected abstract void EndLevel();

        /// <summary>
        /// Initialize a new level.
        /// </summary>
        /// <param name="BackgroundMusic">The background music for the level.</param>
        public Level(SoundEffect backgroundMusic)
        {
            BackgroundMusic = backgroundMusic;
            if (BackgroundMusic != null)
            {
                BGInstance = new SoundEffectInstance(BackgroundMusic);
                
                BGInstance.IsLooped = true;
            }
        }


    }
}

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Miquelon.Shooter.Bullet;
using Miquelon.Shooter.Level;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;

namespace Miquelon.Shooter
{
    /// <summary>
    /// Load content and resources for Shooter part of Miquelon.
    /// </summary>
    public static class ShooterContentLoader
    {
        /// <summary>
        /// Load the content.
        /// </summary>
        /// <param name="?"></param>
        public static void LoadContent(ContentManager Content)
        {
            // Initialize the player.
            Player.Sprite = new Sprite();
            Player.Sprite.Texture = Content.Load<Texture2D>("Art/Shooter/Player");
            Player.Sprite.Position = new Vector2(100, 350);
            Player.Sprite.CollisionBoxRadius = 30;

            // Initialize the level.
            Level.Level.MainBarFont = Content.Load<SpriteFont>("Fonts/MainBarFont");
            Level.Level.HPBarTexture = Content.Load<Texture2D>("Art/Shooter/HPBar");
            Level.Level.MainBarTexture = Content.Load<Texture2D>("Art/Shooter/MainBar");
            Level.Level.PauseScreenTexture = Content.Load<Texture2D>("Art/Shooter/PauseScreen");
            Level.Level.HPBarBackTexture = Content.Load<Texture2D>("Art/Shooter/HPBarBack");
            Level.Level.TransitionTexture = Content.Load<Texture2D>("Art/Screen");
            Level.Level.GameOverTexture = Content.Load<Texture2D>("Art/Shooter/GameOver");
            Level.Level.ClearSFX = Content.Load<SoundEffect>("SFX/Clear");
            Level.Level.EnemyHitSFX = Content.Load<SoundEffect>("SFX/EnemyHit");
            Level.Level.GoodStuffSFX = Content.Load<SoundEffect>("SFX/GoodStuff");
            Level.Level.PlayerHitSFX = Content.Load<SoundEffect>("SFX/PlayerHit");
            Level.Level.LifeSFX = Content.Load<SoundEffect>("SFX/Life");
            Level.Level.EnemyHitSFX = Content.Load<SoundEffect>("SFX/EnemyHit");
            Level.Level.EnemyDead = Content.Load<SoundEffect>("SFX/EnemyDead");
            Level.Level.AddSFX = Content.Load<SoundEffect>("SFX/Add");

            // Initialize specific levels.
            Level.Level1.Lvl1BG1Texture = Content.Load<Texture2D>("Art/Shooter/Lvl1Bg1");
            Level.Level1.Lvl1BG2Texture = Content.Load<Texture2D>("Art/Shooter/Lvl1Bg2");
            Level.Level1.Lvl1BG3Texture = Content.Load<Texture2D>("Art/Shooter/Lvl1Bg3");
            Level.Level1.LevelMusic = Content.Load<SoundEffect>("Music/Traversal");

            Level.Boss1.Boss1BG1Texture = Content.Load<Texture2D>("Art/Shooter/Boss1Bg1");
            Level.Boss1.Boss1BG2Texture = Content.Load<Texture2D>("Art/Shooter/Boss1Bg2");
            Level.Boss1.LevelMusic = Content.Load<SoundEffect>("Music/ImAMeme");

            Level.Level2.LevelMusic = Content.Load<SoundEffect>("Music/Traversal");
            Level.Level2.Level2BG1Texture = Content.Load<Texture2D>("Art/Shooter/Lvl2Bg1");

            Level.Boss2.Boss2BGTexture = Content.Load<Texture2D>("Art/Shooter/Boss2Bg");
            Level.Boss2.LevelMusic = Content.Load<SoundEffect>("Music/IAmARandomBoss");

            Level.Level3.Level3BG1Texture = Content.Load<Texture2D>("Art/Shooter/Lvl3Bg1");
            Level.Level3.Level3BG2Texture = Content.Load<Texture2D>("Art/Shooter/Lvl3Bg2");
            Level.Level3.LevelMusic = Content.Load<SoundEffect>("Music/Traversal");

            Level.Boss3.Boss3BG1Texture = Content.Load<Texture2D>("Art/Shooter/Boss3Bg1");
            Level.Boss3.Boss3BG2Texture = Content.Load<Texture2D>("Art/Shooter/Boss3Bg2");
            Level.Boss3.LevelMusic = Content.Load<SoundEffect>("Music/IAmAFinalBoss");
            
            // Initialize the bullets.
            PlayerBullet.PlayerBulletTexture = Content.Load<Texture2D>("Art/Shooter/PlayerBullet");
            HPP.HPPTexture = Content.Load<Texture2D>("Art/Shooter/HPP");
            Blocky.BlockyTexture = Content.Load<Texture2D>("Art/Shooter/Blocky");
            Clear.ClearTexture = Content.Load<Texture2D>("Art/Shooter/Clear");
            Life.LifeTexture = Content.Load<Texture2D>("Art/Shooter/Life");
            SmallBullet.SmallBulletTexture = Content.Load<Texture2D>("Art/Shooter/SmallBullet");
            BigBullet.BigBulletTexture = Content.Load<Texture2D>("Art/Shooter/BigBullet");
            Add.AddTexture = Content.Load<Texture2D>("Art/Shooter/Add");
            Garble.GarbleTexture = Content.Load<Texture2D>("Art/Shooter/Garble");
            TinyLaser.TinyLaserTexture = SmallBullet.SmallBulletTexture;
            Cross.CrossTexture = Content.Load<Texture2D>("Art/Shooter/Cross");

            // Initialize the enemies.
            Enemy.UltimateBlocky.UltimateCytopodTexture = Content.Load<Texture2D>("Art/Shooter/UltimateCytopod");
            Enemy.ShooterFish.ShooterFishTexture = Content.Load<Texture2D>("Art/Shooter/Enemy1");
            Enemy.TrackingShooterFish.TrackingShooterFish2Texture = Enemy.ShooterFish.ShooterFishTexture;
            Enemy.EvilEel.EvilEelTexture = Content.Load<Texture2D>("Art/Shooter/EvilEel");
            Enemy.Spike.SpikeTexture = Content.Load<Texture2D>("Art/Shooter/Spike");
            Enemy.ShooterFish2.ShooterFish2Texture = Content.Load<Texture2D>("Art/Shooter/Enemy2");
            Enemy.TrackingShooterFish2.TrackingShooterFishTexture = Enemy.ShooterFish2.ShooterFish2Texture;
            Enemy.EvilEel2.EvilEel2Texture = Content.Load<Texture2D>("Art/Shooter/EvilEel2");
            Enemy.VerticalSaucer.SaucerTexture = Content.Load<Texture2D>("Art/Shooter/Saucer");
            Enemy.HorizontalSaucer.SaucerTexture = Enemy.VerticalSaucer.SaucerTexture;
            Enemy.Epsilon.EpsilonTexture = Content.Load<Texture2D>("Art/Shooter/Epsilon");
            Enemy.Delta.DeltaTexture = Content.Load<Texture2D>("Art/Shooter/Delta");
            Enemy.MikePeterson.MikePetersonTexture = Content.Load<Texture2D>("Art/Shooter/MikePeterson");
            Enemy.Cloud.CloudTexture = Content.Load<Texture2D>("Art/Shooter/Cloud");
            Enemy.TrackingShooterFish3.TrackingShooterFish3Texture = Content.Load<Texture2D>("Art/Shooter/Enemy3");
            Enemy.Smiley.SmileyTexture = Content.Load<Texture2D>("Art/Shooter/Smiley");
            Enemy.Seahorse.SeahorseTexture = Content.Load<Texture2D>("Art/Shooter/Seahorse");
            Enemy.Kitty1.KittyTexture = Content.Load<Texture2D>("Art/Shooter/Kitty");
            Enemy.Kitty2.KittyTexture = Content.Load<Texture2D>("Art/Shooter/Kitty");
            Enemy.Kitty3.KittyTexture = Content.Load<Texture2D>("Art/Shooter/Kitty");
            Enemy.Bella.BellaTexture = Content.Load<Texture2D>("Art/Shooter/Bella");
        }
    }
}

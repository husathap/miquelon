using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miquelon.Shooter.Enemy
{
    /// <summary>
    /// A class represents the final boss.
    /// </summary>
    public class Bella : Enemy
    {

        double counter = 0;
        float counter2 = 0;
        int counter3 = 0;


        Random rand = new Random();

        public static Texture2D BellaTexture;

        /// <summary>
        /// Update the enemy.
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            if (HP >= 150 && HP <= 200)
            {

                this.Y = Player.Sprite.Y;
                this.X = 1024 - Player.Sprite.X;

                if (Keyboard.GetState().IsKeyDown(Keys.Enter) || Keyboard.GetState().IsKeyDown(Keys.Space))
                {
                    Vector2 Traj = Player.Sprite.Position - this.Position;
                    //Fire(new Bullet.TinyLaser(this.Position, Traj / Traj.Length() * 5, Color.Yellow));

                    if (counter >= 40)
                    {
                        // Filling
                        for (float i = 0.01f; i < 2 * Math.PI; i += 0.1f)
                        {
                            float x = (float)(Math.Cosh(i));
                            float y = (float)(Math.Sinh(i));
                            this.Fire(new Bullet.Cross(new Vector2(this.X, this.Y), new Vector2(-x * 3, -y * 6f)));
                            this.Fire(new Bullet.Cross(new Vector2(this.X, this.Y), new Vector2(-x * 3, y * 6f)));
                            this.Fire(new Bullet.Cross(new Vector2(this.X, this.Y), new Vector2(x * 3, -y * 6f)));
                            this.Fire(new Bullet.Cross(new Vector2(this.X, this.Y), new Vector2(x * 3, y * 6f)));
                        }

                        counter = 0;
                    }
                    counter++;

                }

                counter2 += 0.1f;

                
                if (Math.Sin(counter2) > 0)
                {
                    Vector2 Traj = Player.Sprite.Position - this.Position;
                    Fire(new Bullet.TinyLaser(this.Position, Traj / Traj.Length() * 4 + new Vector2(-1, 1) / (float)Math.Sqrt(2), Color.Red));
                    Fire(new Bullet.TinyLaser(this.Position, Traj / Traj.Length() * 4, Color.Blue));
                    Fire(new Bullet.TinyLaser(this.Position, Traj / Traj.Length() * 4 + new Vector2(-1, -1) / (float)Math.Sqrt(2), Color.Green));
                }

                if (counter2 > MathHelper.TwoPi)
                {
                    counter2 = 0;
                }

                counter3++;

                if (counter3 >= 200)
                {
                    Vector2 Traj = Player.Sprite.Position - this.Position;
                    Fire(new Bullet.BigBullet(this.Position, Traj / Traj.Length() * 3 + new Vector2(-1, -2), Color.Yellow));
                    Fire(new Bullet.BigBullet(this.Position, Traj / Traj.Length() * 3, Color.Yellow));
                    Fire(new Bullet.BigBullet(this.Position, Traj / Traj.Length() * 3 + new Vector2(-1, 2), Color.Yellow));
                    counter3 = 0;
                }
                
            }
            else if (HP >= 100 && HP < 150)
            {

                this.Y = Player.Sprite.Y;
                this.X = 1024 - Player.Sprite.X;

                if (Keyboard.GetState().IsKeyDown(Keys.Enter) || Keyboard.GetState().IsKeyDown(Keys.Space))
                {
                    Vector2 Traj = Player.Sprite.Position - this.Position;
                    //Fire(new Bullet.TinyLaser(this.Position, Traj / Traj.Length() * 5, Color.Yellow));

                     if (counter >= 150)
                     {
                        for (float i = 0; i <= MathHelper.TwoPi; i += MathHelper.TwoPi / 30)
                        {
                            Fire(new Bullet.Cross(this.Position, new Vector2((float)Math.Cos(Traj.Y + i), (float)Math.Sin(Traj.X - i)) * 3));
                        }

                        for (float i = 0; i <= MathHelper.TwoPi; i += MathHelper.TwoPi / 30)
                        {
                            Fire(new Bullet.Cross(this.Position, new Vector2((float)Math.Cos(Traj.Y - i), (float)Math.Sin(Traj.X + i)) * 2));
                        }

                        for (float i = 0; i <= MathHelper.TwoPi; i += MathHelper.TwoPi / 30)
                        {
                            Fire(new Bullet.Cross(this.Position, new Vector2((float)Math.Cos(Traj.Y - i), (float)Math.Sin(Traj.X + i)) * 1));
                        }

                        counter = 0;
                    }
                    counter++;

                    Vector2[] Trajs = new Vector2[3];

                    Trajs[0] = Player.Sprite.Position - new Vector2(1024, 325);
                    Trajs[1] = Player.Sprite.Position - new Vector2(512, 50);
                    Trajs[2] = Player.Sprite.Position - new Vector2(512, 600);

                    for (int i = 0; i <= 2; i++)
                    {
                        Trajs[i] /= Trajs[i].Length();
                        Trajs[i] *= 3;
                    }

                    Fire(new Bullet.TinyLaser(new Vector2(1024, 325), Trajs[0], Color.Cyan));
                    Fire(new Bullet.TinyLaser(new Vector2(512, 50), Trajs[1], Color.Cyan));
                    Fire(new Bullet.TinyLaser(new Vector2(512, 600), Trajs[2], Color.Cyan));
                }
            }
            else if (HP >= 50 && HP < 100)
            {
                if (this.Y < 500 - Player.Sprite.Y)
                {
                    this.Y++;
                }
                else if (this.Y > 500 - Player.Sprite.Y)
                {
                    this.Y--;
                }

                if (Keyboard.GetState().IsKeyDown(Keys.Enter) || Keyboard.GetState().IsKeyDown(Keys.Space))
                {
                    if (counter >= 100)
                    {
                        AssociatedLevel.EnemyList.Add(new Cloud(AssociatedLevel, new Vector2(1100, 100)));
                        AssociatedLevel.EnemyList.Add(new TrackingShooterFish3(AssociatedLevel, 250));
                        counter = 0;
                    }
                    counter++;

                    if (counter2 >= 500)
                    {
                        AssociatedLevel.EnemyList.Add(new Smiley(AssociatedLevel, 450));
                        counter2 = 0;
                    }
                    counter2++;
                }
            }
            else
            {
                if (this.Y < 600 - Player.Sprite.Y)
                {
                    this.Y++;
                }
                else if (this.Y > 600 - Player.Sprite.Y)
                {
                    this.Y--;
                }

                if (Keyboard.GetState().IsKeyDown(Keys.Enter) || Keyboard.GetState().IsKeyDown(Keys.Space))
                {
                    Fire(new Bullet.TinyLaser(this.Position, new Vector2(-3, 0), Color.Yellow));
                }
            }
        }

        /// <summary>
        /// Create a new instance of the final boss..
        /// </summary>
        /// <param name="AssociatedLevel">The level in which this enemy exists.</param>
        public Bella(Level.Level AssociatedLevel)
        {
            this.AssociatedLevel = AssociatedLevel;
            this.Position = new Vector2(-200, 350);
            this.HP = 200;
            this.MaxHP = 200;
            this.Scale = 1f;
            this.Texture = BellaTexture;
            this.CollisionBoxRadius = 40;
        }

    }
}


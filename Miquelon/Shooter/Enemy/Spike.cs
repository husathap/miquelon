using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miquelon.Shooter.Enemy
{
    /// <summary>
    /// A class represents Spike.
    /// </summary>
    public class Spike : Enemy
    {

        int counter = 0;
        int counter2 = 0;

        Random rand = new Random();

        /// <summary>
        /// The texture of Spike.
        /// </summary>
        public static Texture2D SpikeTexture;

        /// <summary>
        /// Update the enemy.
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            if (HP >= 200 && HP <= 300)
            {
                this.Y = Player.Sprite.Y;

                if (this.X > 700)
                {
                    this.X -= 1;
                }

                if (counter >= 65)
                {
                    Fire(new Bullet.BigBullet(this.Position, new Vector2(-2, 2), Color.Red));
                    Fire(new Bullet.BigBullet(this.Position, new Vector2(-4, 0), Color.Blue));
                    Fire(new Bullet.BigBullet(this.Position, new Vector2(-2, -2), Color.Green));
                    Fire(new Bullet.HPP(new Vector2(rand.Next(1024), -20), new Vector2(0, rand.Next(5))));
                    counter = 0;
                }
                counter++;
            }
            else if (HP >= 100 && HP < 200)
            {
                if (this.Y > Player.Sprite.Y)
                {
                    this.Y--;
                }
                else if (this.Y < Player.Sprite.Y)
                {
                    this.Y++;
                }
                

                if (counter >= 40)
                {
                    Vector2 Traj = Player.Sprite.Position - this.Position;
                    Fire(new Bullet.Add(this.Position, Traj / Traj.Length() * 2));
                    Fire(new Bullet.SmallBullet(this.Position, Traj / Traj.Length() * 1, Color.Blue));
                    Fire(new Bullet.SmallBullet(this.Position, Traj / Traj.Length() * 3, Color.Green));
                    Fire(new Bullet.SmallBullet(this.Position, Traj / Traj.Length() * 6, Color.Red));
                    counter = 0;
                }
                counter++;

                if (counter2 >= 50)
                {
                    Fire(new Bullet.HPP(new Vector2(rand.Next(1024), -20), new Vector2(0, rand.Next(5))));
                    counter2 = 0;
                }
                counter2++;
                
            }
            else
            {
                if (this.X < 1000)
                {
                    this.X += 5;
                }

                if (counter >= 8)
                {
                    this.Y = rand.Next(10, 120) * 5;

                    int cat = rand.Next(13);

                    if (cat == 0 || cat == 1)
                    {
                        Fire(new Bullet.Add(this.Position, new Vector2(-4, 0)));
                    }
                    else if (cat == 2)
                    {
                        Fire(new Bullet.HPP(this.Position, new Vector2(-4, 0)));
                    }
                    else if (cat == 3 || cat == 4 || cat == 5)
                    {
                        Fire(new Bullet.SmallBullet(this.Position, new Vector2(-4, 0), Color.Red));
                    }
                    else if (cat == 6 || cat == 7 || cat == 8)
                    {
                        Fire(new Bullet.SmallBullet(this.Position, new Vector2(-4, 0), Color.Blue));
                    }
                    else if (cat == 9 || cat == 10 || cat == 11)
                    {
                        Fire(new Bullet.SmallBullet(this.Position, new Vector2(-4, 0), Color.Green));
                    }
                    else
                    {
                        int c = rand.Next(3);

                        switch (c)
                        {
                            case 0:
                                Fire(new Bullet.BigBullet(this.Position, new Vector2(-4, 0), Color.Red));
                                break;
                            case 1:
                                Fire(new Bullet.BigBullet(this.Position, new Vector2(-4, 0), Color.Blue));
                                break;
                            case 2:
                                Fire(new Bullet.BigBullet(this.Position, new Vector2(-4, 0), Color.Green));
                                break;
                        }
                    }

                    counter = 0;
                }
                counter++;
            }
        }

        /// <summary>
        /// Create a new Spike.
        /// </summary>
        /// <param name="AssociatedLevel">The level in which this enemy exists.</param>
        public Spike(Level.Level AssociatedLevel)
        {
            this.AssociatedLevel = AssociatedLevel;
            this.Position = new Vector2(1300, 350);
            this.HP = 300;
            this.MaxHP = 300;
            this.Scale = 1f;
            this.Texture = SpikeTexture;
            this.CollisionBoxRadius = 40;
        }

    }
}


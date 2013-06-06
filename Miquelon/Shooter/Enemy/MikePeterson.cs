using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miquelon.Shooter.Enemy
{
    /// <summary>
    /// A class represents Mike Peterson.
    /// </summary>
    public class MikePeterson : Enemy
    {

        double counter = 0;
        double counter2 = 0;
        double counter3 = 0;
        int counter4 = 0;

        Vector2 Movement = new Vector2(0, -4);

        /// <summary>
        /// The random number generator.
        /// </summary>
        Random rand = new Random();

        /// <summary>
        /// The texture of Mike Peterson.
        /// </summary>
        public static Texture2D MikePetersonTexture;

        /// <summary>
        /// Update the enemy.
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            if (HP >= 200 && HP <= 300)
            {
                this.Y = Player.Sprite.Y;

                if (this.X > 900)
                {
                    this.X -= 5;
                }

                if (Math.Sin(counter) >= 0)
                {
                    Vector2 Traj = Player.Sprite.Position - this.Position;

                    Fire(new Bullet.TinyLaser(this.Position, Traj / Traj.Length() * 5, Color.Black));
                    Fire(new Bullet.TinyLaser(new Vector2(Player.Sprite.X, 40), new Vector2(0, 5), Color.Red));
                    Fire(new Bullet.TinyLaser(new Vector2(Player.Sprite.X - 300, 40), new Vector2(0, 5), Color.Lime));
                    Fire(new Bullet.TinyLaser(new Vector2(Player.Sprite.X + 300, 40), new Vector2(0, 5), Color.Lime));
                }

                counter += 0.09;

                if (counter >= MathHelper.TwoPi)
                    counter = 0;
            }
            else if (HP >= 100 && HP < 200)
            {
                this.Y = Player.Sprite.Y;

                Vector2 Traj = Player.Sprite.Position - this.Position;

                counter += 0.05;
                counter2 += 0.2;
                counter3 += 0.06;

                if (Math.Sin(counter) >= 0)
                {
                    Fire(new Bullet.TinyLaser(this.Position, Traj / Traj.Length() * 4 + new Vector2
                        ((float)Math.Cosh(counter2) * -1, (float)Math.Sin(counter3)) / 70,
                        Color.Black));
                    Fire(new Bullet.TinyLaser(this.Position, Traj / Traj.Length() * 4 + new Vector2
                        ((float)Math.Cosh(counter2) * -1, (float)Math.Sin(counter3)) / 70 + new Vector2(-2, -2),
                        Color.Black));
                    Fire(new Bullet.TinyLaser(this.Position, Traj / Traj.Length() * 4 + new Vector2
                        ((float)Math.Cosh(counter2) * -1, (float)Math.Sin(counter3)) / 70 + new Vector2(-2, 2),
                        Color.Black));
                }

                if (counter >= MathHelper.TwoPi)
                    counter = 0;
                if (counter2 >= MathHelper.TwoPi)
                    counter2 = 0;
                if (counter3 >= Math.PI / 4)
                    counter3 = 0;

                if (counter4 >= 200)
                {
                    Fire(new Bullet.Add(new Vector2(Player.Sprite.X, 20), new Vector2(0, 4)));
                    Fire(new Bullet.HPP(new Vector2(Player.Sprite.X - 50, 10), new Vector2(0, 4)));
                    Fire(new Bullet.HPP(new Vector2(Player.Sprite.X + 50, 10), new Vector2(0, 4)));
                    Fire(new Bullet.HPP(new Vector2(Player.Sprite.X, -30), new Vector2(0, 4)));
                    Fire(new Bullet.HPP(new Vector2(Player.Sprite.X, 70), new Vector2(0, 4)));
                    counter4 = 0;
                }
                counter4++;
            }
            else
            {
                this.Position += Movement;

                if (this.Y <= 50 || this.Y >= 600)
                {
                    Movement *= -1;
                }

                if (counter >= 4)
                {
                    Vector2 Traj = new Vector2((float)Math.Sin(this.X), (float)Math.Tan(this.Y));
                    Vector2 Traj2 = new Vector2((float)Math.Tan(this.Y), (float)Math.Sin(this.X));
                    Fire(new Bullet.Garble(this.Position, Traj / Traj.Length() * -3));
                    Fire(new Bullet.Garble(this.Position, Traj2 / Traj2.Length() * -3));
                    counter = 0;
                }
                counter++;

                if (counter2 >= MathHelper.TwoPi)
                {
                    counter2 = 0;
                }

                if (Math.Sin(counter2) >= 0)
                {
                    Vector2 Traj = Player.Sprite.Position - this.Position;
                    Fire(new Bullet.TinyLaser(this.Position, Traj / Traj.Length() * 2 + new Vector2(-1, 1) / (float)Math.Sqrt(2), Color.Cyan));
                    Fire(new Bullet.TinyLaser(this.Position, Traj / Traj.Length() * 2, Color.Yellow));
                    Fire(new Bullet.TinyLaser(this.Position, Traj / Traj.Length() * 2 + new Vector2(-1, -1) / (float)Math.Sqrt(2), Color.Magenta));
                }

                counter2 += 0.04;
            }
        }

        /// <summary>
        /// Create a new Mike Peterson.
        /// </summary>
        /// <param name="AssociatedLevel">The level in which this enemy exists.</param>
        public MikePeterson(Level.Level AssociatedLevel)
        {
            this.AssociatedLevel = AssociatedLevel;
            this.Position = new Vector2(1300, 350);
            this.HP = 300;
            this.MaxHP = 300;
            this.Scale = 1f;
            this.Texture = MikePetersonTexture;
            this.CollisionBoxRadius = 50;
        }

    }
}


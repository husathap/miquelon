using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Miquelon.Shooter
{

    /// <summary>
    /// A class thate represents all sprite in the game.
    /// </summary>
    public class Sprite
    {

        /// <summary>
        /// The position of the sprite.
        /// </summary>
        Vector2 position;

        /// <summary>
        /// The bounding circle for the sprite.
        /// </summary>
        BoundingSphere collisionBox;

        /// <summary>
        /// The origin of the sprite.
        /// </summary>
        Vector2 origin;

        /// <summary>
        /// The color of the sprite.
        /// </summary>
        Color color = Color.White;

        /// <summary>
        /// The scale of the sprite.
        /// </summary>
        float scale = 1;

        /// <summary>
        /// The texture of the sprite.
        /// </summary>
        Texture2D texture;

        /// <summary>
        /// The sprite effect of the sprite;
        /// </summary>
        SpriteEffects spriteEffects = SpriteEffects.None;

        /// <summary>
        /// Get or set the scale of the sprite.
        /// </summary>
        [DefaultValue(1)]
        public float Scale
        {
            get
            {
                return scale;
            }
            set
            {
                scale = value;
            }
        }

        /// <summary>
        /// Get or set the roation of the sprite.
        /// </summary>
        [DefaultValue(0)]
        public float Rotation { get; set; }

        /// <summary>
        /// Get or set the color of the sprite.
        /// </summary>
        public Color Color { 
            get 
            { 
                return color; 
            } 
            set 
            { 
                color = value; 
            } 
        }

        /// <summary>
        /// Get or set the collision box of the sprite.
        /// </summary>
        BoundingSphere CollisionBox {
            get
            {
                return collisionBox;
            }
            set
            {
                collisionBox = value;
            }
        }

        /// <summary>
        /// The texture of the sprite.
        /// </summary>
        public Texture2D Texture
        {
            get
            {
                return texture;
            }
            set
            {
                texture = value;
            }
        }

        /// <summary>
        /// Get or set the position of the sprite.
        /// </summary>
        public Vector2 Position
        {
            get
            {
                return position;
            }

            set
            {
                position = value;
                collisionBox.Center = new Vector3(value.X, value.Y, 0);
            }
        }

        /// <summary>
        /// Get or set the X position of the sprite.
        /// </summary>
        public float X
        {
            get
            {
                return position.X; 
            }

            set
            {
                position.X = value;
                collisionBox.Center.X = X;
            }
        }

        /// <summary>
        /// Get or set the Y position of the sprite.
        /// </summary>
        public float Y
        {
            get
            {
                return position.Y;
            }

            set
            {
                position.Y = value;
                collisionBox.Center.Y = Y;
            }
        }

        /// <summary>
        /// Get the origin of the sprite.
        /// </summary>
        public Vector2 Origin { 
            get 
            {
                if (origin == Vector2.Zero)
                {
                    origin = new Vector2(texture.Width / 2, texture.Height / 2);
                }
                return origin;
            } 
        }

        /// <summary>
        /// Get or set the collision box radius.
        /// </summary>
        public float CollisionBoxRadius
        {
            get
            {
                return collisionBox.Radius;
            }

            set
            {
                collisionBox.Radius = value;
            }
        }

        /// <summary>
        /// Get or set the setting of the sprite. Use this to know or change the sprite's flipping rotation.
        /// </summary>
        public SpriteEffects SpriteEffects
        {
            get
            {
                return spriteEffects;
            }
            set
            {
                spriteEffects = value;
            }
        }


        /// <summary>
        /// Check whether the target is colliding with the sprite or not.
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public bool IsColliding(Sprite target)
        {
            return this.CollisionBox.Intersects(target.CollisionBox);
        }
    }
}

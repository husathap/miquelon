#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
#endregion
using Miquelon.Shooter;
using Miquelon.Shooter.Bullet;
using Miquelon.Slides;
using Microsoft.Xna.Framework.Audio;

namespace Miquelon
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public partial class Main : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public Main()
            : base()
        {
            Content.RootDirectory = "Content";
            this.Window.Title = "Of Fish & Chips";
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 1024;
            graphics.PreferredBackBufferHeight = 600;
            SetPosition(this.Window, new Point(
                GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width / 2 - 512,
                GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height / 2 - 300));   
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            Title.TitleScreenTexture = Content.Load<Texture2D>("Art/TitleScreen");
            Title.TitleBackgroundMusic = Content.Load<SoundEffect>("Music/GoFishing");

            // Load contents for Shooter component of Miquelon.
            ShooterContentLoader.LoadContent(Content);

            // Load contents for Slide component of Miquelon.
            Slides.SlideContentLoader.LoadContent(Content);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }


        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (CurrentState == null)
                Exit();
            else
            {
                if (this.IsActive)
                    CurrentState.Update(gameTime);
            }

            base.Update(gameTime);
        }

        
        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            if (CurrentState != null) {
                spriteBatch.Begin();
                CurrentState.Draw(spriteBatch);
                spriteBatch.End();
            }

            base.Draw(gameTime);
        }

        // Containing code modified from: http://projectdrake.net/blog/?p=176.
        public static void SetPosition(GameWindow gameWindow, Point position)
        {
            OpenTK.GameWindow OTKWindow = GetForm(gameWindow);
            if (OTKWindow != null)
            {
                OTKWindow.X = position.X;
                OTKWindow.Y = position.Y;
            }
        }

        // Containing code modified from: http://projectdrake.net/blog/?p=176.
        public static OpenTK.GameWindow GetForm(GameWindow gameWindow)
        {
            Type type = typeof(OpenTKGameWindow);
            System.Reflection.FieldInfo field = type.GetField("window", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            if (field != null)
                return field.GetValue(gameWindow) as OpenTK.GameWindow;
            return null;
        }
    }
}

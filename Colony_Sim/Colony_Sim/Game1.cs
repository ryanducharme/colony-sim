using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Colony_Sim
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _gameWorldSpriteBatch;
        
        Scenes.SceneManager sceneManager;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            _graphics.PreferredBackBufferWidth = 1280;  // set this value to the desired width of your window
            _graphics.PreferredBackBufferHeight = 720;   // set this value to the desired height of your window
            _graphics.ApplyChanges();
            
            Camera2d.GraphicsDeviceManager = _graphics;
            TextureUtil.graphicsDevice = _graphics.GraphicsDevice;
            TextureUtil.DefaultGreen = Content.Load<Texture2D>("Textures\\Grass");
            TextureUtil.DefaultDarkGreen = Content.Load<Texture2D>("Textures\\DarkGrass");

            sceneManager = new Scenes.SceneManager(_graphics.GraphicsDevice, this);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _gameWorldSpriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void Update(GameTime gameTime)
        {
            Input.Update();
            Camera2d.Update();
            sceneManager.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {            
            GraphicsDevice.Clear(Color.CornflowerBlue);
            sceneManager.Draw(gameTime, _gameWorldSpriteBatch);
            base.Draw(gameTime);
        }
    }
}
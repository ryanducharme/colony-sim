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
        private SpriteBatch _UISpriteBatch;

        Level level;
        SpriteFont font;
        Texture2D man;
        InputManager inputManager;
        Label label;
        Container container;

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
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _gameWorldSpriteBatch = new SpriteBatch(GraphicsDevice);
            _UISpriteBatch = new SpriteBatch(GraphicsDevice);
            Texture2D buttonTexture = Content.Load<Texture2D>("Textures\\pink_brick");
            man = Content.Load<Texture2D>("Textures\\Man");
            font = Content.Load<SpriteFont>("Fonts\\DefaultFont");
            level = new Level(GraphicsDevice);
            label = new Label(font, new Vector2(100, 100), "Hello world!", Color.White);
            container = new Container(new Vector2(20, 20), buttonTexture);
            container.AddContent(label);

            //fix this to not need to add in level and container
            inputManager = new InputManager(level, container);
            
            //container.AddContent(button);
            level.GenerateLevel();
            //camera = new Camera2d(_graphics);
        }

        protected override void Update(GameTime gameTime)
        {

            MouseInputManager.Update();
            inputManager.Update(_gameWorldSpriteBatch);
            Camera2d.Update();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {            
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _gameWorldSpriteBatch.Begin(SpriteSortMode.BackToFront, null, null, null, null, null, Camera2d.Transform);
            level.Draw(_gameWorldSpriteBatch);
            _gameWorldSpriteBatch.Draw(man, new Vector2(15,15), Color.White);
            _gameWorldSpriteBatch.End();


            _UISpriteBatch.Begin();
            var framerate = (1 / gameTime.ElapsedGameTime.TotalSeconds);
            _UISpriteBatch.DrawString(font, "FPS: " + framerate, new Vector2(0, 0), Color.Black);
            label.Text = "Tile Data:\n" + inputManager.GetTileData() + "\n" + inputManager.ScreenToWorldLevelIndex.ToString();
            label.Position = new Vector2(0,20);
            _UISpriteBatch.End();

            container.Draw(_gameWorldSpriteBatch);

            base.Draw(gameTime);
            
            
        }
    }
}
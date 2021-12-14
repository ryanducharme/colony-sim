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
        private SpriteBatch _spriteBatch;
        
        Level level;
        Button button;
        SpriteFont font;
        bool mouseOverButton;
        string debugMsg = "";
        Camera2d camera;
        InputManager inputManager;
        MouseInputManager mgr;
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
            _graphics.PreferredBackBufferWidth = 1920;  // set this value to the desired width of your window
            _graphics.PreferredBackBufferHeight = 1080;   // set this value to the desired height of your window
            _graphics.ApplyChanges();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            
            Texture2D buttonTexture = Content.Load<Texture2D>("Textures\\pink_brick");
            font = Content.Load<SpriteFont>("Fonts\\DefaultFont");
            button = new Button(buttonTexture, new Vector2(20, 20));
            level = new Level(GraphicsDevice);
            
            label = new Label(font, new Vector2(100, 100), "Hello world!", Color.White);
            container = new Container(new Vector2(20, 20), buttonTexture);
            container.AddContent(label);

            //fix this to not need to add in level and container
            inputManager = new InputManager(level, container);
            mgr = new MouseInputManager();
            //container.AddContent(button);
            level.GenerateLevel();
        }

        protected override void Update(GameTime gameTime)
        {
            mgr.Update();
            inputManager.Update(_spriteBatch);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            level.Draw(_spriteBatch);
            //button.Draw(_spriteBatch);
            _spriteBatch.Begin();

            _spriteBatch.DrawString(font, mgr.GetMousePosition().ToString(),
                new Vector2(_graphics.PreferredBackBufferWidth - 150, 10), Color.Black);

            if (mouseOverButton)
            {
                _spriteBatch.DrawString(font, "Over button", new Vector2(_graphics.PreferredBackBufferWidth - 150, 30), Color.Black);
                if (mgr.GetCurrentMouseState().LeftButton == ButtonState.Pressed)
                {
                    _spriteBatch.DrawString(font, debugMsg, new Vector2(_graphics.PreferredBackBufferWidth - 150, 70), Color.Black);
                }
            }
            _spriteBatch.DrawString(font, debugMsg, new Vector2(_graphics.PreferredBackBufferWidth - 150, 70), Color.Black);
            _spriteBatch.End();
            label.Position = new Vector2(mgr.GetMousePosition().X + 15, mgr.GetMousePosition().Y + 15);
            label.Text = "Tile Data:\n" + inputManager.GetTileData() + "\n" + inputManager.levelScreenToWorldPosition.ToString();
            //Debug.WriteLine(inputManager.levelScreenToWorldPosition.ToString());
            button.Position = new Vector2(mgr.GetMousePosition().X + 15, mgr.GetMousePosition().Y + 90);
            //label.Draw(_spriteBatch);
            container.Draw(_spriteBatch);   
            base.Draw(gameTime);
        }
    }
}
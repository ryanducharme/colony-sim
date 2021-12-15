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
        //Camera2d camera;
        
        InputManager inputManager;
        Label label;
        Container container;

        //Vector3 left = new Vector3(-1, 0, 0);
        //Vector3 mapPosition = new Vector3(0, 0, 0);
        //int cameraSpeed = 5;
        //Matrix testMatrix;
       // Matrix result = Matrix.CreateRotationX(MathHelper.ToRadians(45)) *
                                 //Matrix.CreateTranslation(new Vector3(1, 0, 0));
        //Matrix currentTranslationMatrix;
        //Matrix previousTranslationMatrix;

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
            
            //container.AddContent(button);
            level.GenerateLevel();
            //camera = new Camera2d(_graphics);
        }

        protected override void Update(GameTime gameTime)
        {

            MouseInputManager.Update();
            inputManager.Update(_spriteBatch);
            //cameraSpeed = 1;
            Camera2d.Update();
            //camera.Update();
            //Debug.Write(Camera2d.ScreenToWorldSpace(MouseInputManager.GetMousePosition()));
            //Debug.WriteLine(MouseInputManager.GetMousePosition());
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin(SpriteSortMode.BackToFront, null, null, null, null, null, Camera2d.Transform);
            level.Draw(_spriteBatch);
            //button.Draw(_spriteBatch);
            //_spriteBatch.Begin();

            //_spriteBatch.DrawString(font, MouseInputManager.GetMousePosition().ToString(),
            //    new Vector2(_graphics.PreferredBackBufferWidth - 150, 10), Color.Black);


            //_spriteBatch.DrawString(font, debugMsg, new Vector2(_graphics.PreferredBackBufferWidth - 150, 70), Color.Black);
            //_spriteBatch.End();
            
            label.Position = new Vector2(MouseInputManager.GetMousePosition().X + 15, MouseInputManager.GetMousePosition().Y + 15);
            label.Text = "Tile Data:\n" + inputManager.GetTileData() + "\n" + inputManager.ScreenToWorldLevelIndex.ToString();
            //Debug.WriteLine(inputManager.levelScreenToWorldPosition.ToString());
            button.Position = new Vector2(MouseInputManager.GetMousePosition().X + 15, MouseInputManager.GetMousePosition().Y + 90);
            _spriteBatch.End();
            //label.Draw(_spriteBatch);
            container.Draw(_spriteBatch);   

            base.Draw(gameTime);
            //var framerate = (1 / gameTime.ElapsedGameTime.TotalSeconds);
            //Debug.WriteLine(framerate);
        }
    }
}
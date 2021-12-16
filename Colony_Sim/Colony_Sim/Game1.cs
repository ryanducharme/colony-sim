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

        Character character;

        Map map;
        SpriteFont font;
        Texture2D man;
        InputManager inputManager;
        Label label;
        Container container;


        List<IUpdateable> updateables;
        List<IDrawable> drawables;

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



            base.Initialize();
        }

        protected override void LoadContent()
        {
            _gameWorldSpriteBatch = new SpriteBatch(GraphicsDevice);
            _UISpriteBatch = new SpriteBatch(GraphicsDevice);
            Texture2D buttonTexture = Content.Load<Texture2D>("Textures\\pink_brick");
            man = Content.Load<Texture2D>("Textures\\Man");
            character = new Character(man);
            character.Texture = man;

            font = Content.Load<SpriteFont>("Fonts\\DefaultFont");
            map = new Map();
            label = new Label(font, new Vector2(100, 100), "Hello world!", Color.White);
            container = new Container(new Vector2(20, 20), buttonTexture);
            container.AddContent(label);



            updateables = new List<IUpdateable>();
            updateables.Add(map);
            updateables.Add(character);


            drawables = new List<IDrawable>();
            drawables.Add(map);
            drawables.Add(character);


            //fix this to not need to add in level and container
            inputManager = new InputManager(map, container, character);
            
            //container.AddContent(button);
            map.GenerateMap();
            
        }

        protected override void Update(GameTime gameTime)
        {



            Input.Update();
            Camera2d.Update();
            //inputManager.Update(_gameWorldSpriteBatch);
            //Debug.WriteLine(character.Bounds);

            foreach(IUpdateable updateable in updateables)
            {
                updateable.Update(gameTime);
            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {            
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _gameWorldSpriteBatch.Begin(SpriteSortMode.BackToFront, null, null, null, null, null, Camera2d.Transform);

            foreach (IDrawable drawable in drawables)
            {
                drawable.Draw(_gameWorldSpriteBatch);
            }




            //map.Draw(_gameWorldSpriteBatch);
            //_gameWorldSpriteBatch.Draw(character.Texture, character.Position, Color.White);
            _gameWorldSpriteBatch.End();


            _UISpriteBatch.Begin();
            var framerate = (1 / gameTime.ElapsedGameTime.TotalSeconds);
            _UISpriteBatch.DrawString(font, "FPS: " + framerate, new Vector2(0, 0), Color.Black);
            label.Text = "Tile Data: " + MapUtil.GetTileData(map, Camera2d.ScreenToWorldSpace(Input.GetMousePosition()))
                + "\n" + inputManager.ScreenToWorldMapIndex.ToString();
            label.Position = new Vector2(0,20);
            _UISpriteBatch.End();

            container.Draw(_gameWorldSpriteBatch);

            base.Draw(gameTime);
            
            
        }
    }
}
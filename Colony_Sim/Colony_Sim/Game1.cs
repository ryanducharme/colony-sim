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
        Container inventoryUI;
        Label characterName;


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
            TextureUtil.DefaultGreen = TextureUtil.GenerateTexture(Color.Green, 64,64);
            TextureUtil.DefaultDarkGreen = TextureUtil.GenerateTexture(Color.DarkGreen, 64, 64);


            base.Initialize();
        }

        protected override void LoadContent()
        {
            _gameWorldSpriteBatch = new SpriteBatch(GraphicsDevice);
            
            //Texture2D buttonTexture = Content.Load<Texture2D>("Textures\\pink_brick");
            man = Content.Load<Texture2D>("Textures\\Man");
            character = new Character(man);
            character.Texture = man;

            font = Content.Load<SpriteFont>("Fonts\\DefaultFont");
            map = new Map();

            _UISpriteBatch = new SpriteBatch(GraphicsDevice);
            label = new Label(font, new Vector2(0, 0), "", Color.White);
            container = new Container(new Vector2(_graphics.PreferredBackBufferWidth - 200, 0), TextureUtil.GenerateTexture(Color.Transparent, 10,10));
            container.AddContent(label);


            inventoryUI = new Container(new Vector2(_graphics.PreferredBackBufferWidth - 200, 0), TextureUtil.GenerateTexture(Color.Black * 0.5f, 200, 500));
            characterName = new Label(font, inventoryUI.Position, 
                $"Name: {character.Name}\n-------Stats-------\nHealth: {character.Health}" +
                $"\nStrength: {character.Strength}\nAttack: {character.Attack}\nDefence: {character.Defence}", Color.White);
            inventoryUI.AddContent(characterName);

            updateables = new List<IUpdateable>();
            updateables.Add(map);
            updateables.Add(character);
            


            drawables = new List<IDrawable>();
            drawables.Add(map);
            drawables.Add(character);


            //fix this to not need to add in level and container
            //inputManager = new InputManager(map, container, character);
            
            
            map.GenerateMap();
            
        }

        protected override void Update(GameTime gameTime)
        {

            //characterName.Text = character.Name;

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
            //Vector2 screenToWorldMapIndex = Camera2d.ScreenToWorldSpace(Input.GetMousePosition());
            //string tileData = MapUtil.GetTileData(map, screenToWorldMapIndex).Type.ToString();
            //label.Text = $"Tile Data: {tileData}\n{screenToWorldMapIndex}";
            //label.Position = new Vector2(0,20);

            if (character.Selected)
            {
                _UISpriteBatch.Draw(inventoryUI.Texture, inventoryUI.Position, Color.Black);
                _UISpriteBatch.DrawString(font, characterName.Text, inventoryUI.Position, Color.White);
            }
            
            
            _UISpriteBatch.End();


            //debug menu sort of
            container.Draw(_gameWorldSpriteBatch);

            base.Draw(gameTime);
            
            
        }
    }
}
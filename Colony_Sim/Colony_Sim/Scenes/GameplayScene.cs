using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Colony_Sim.Scenes
{
    class GameplayScene : Scene, IUpdateable, IDrawable
    {
        public override bool Active { get; set; } = true;
        public GraphicsDevice graphicsDevice { get; set; }
        private SpriteBatch _UISpriteBatch;
        string tileData = "";
        Map map = new Map();
        
        SpriteFont font;
        Label label;
        
        Container container;
        

        List<IDrawable> drawables;
        List<IUpdateable> updateables;


        
        Container inventoryUI;
        


        public GameplayScene(GraphicsDevice g, Game game)
        {
            graphicsDevice = g;
            Initialize();
            LoadContent(game);
        }

        public void Initialize()
        {
            _UISpriteBatch = new SpriteBatch(graphicsDevice);
            updateables = new List<IUpdateable>();
            drawables = new List<IDrawable>();

            map.GenerateMap();
        }

        public void LoadContent(Game game)
        {
            
            font = game.Content.Load<SpriteFont>("Fonts\\DefaultFont");
            label = new Label(font, new Vector2(0, 0), "", Color.White);
            container = new Container(new Vector2(graphicsDevice.Viewport.Width - 200, 0), TextureUtil.GenerateTexture(Color.Transparent, 10, 10));
            container.AddContent(label);

            //inventoryUI = new Container(new Vector2(graphicsDevice.Viewport.Width - 300, 0), TextureUtil.GenerateTexture(Color.Black, 300, 500));
            //inventoryUI.AddContent(new Label(font, inventoryUI.Position, $"{character1.Name}", Color.White));
            //inventoryUI.AddContent(
            //    new Label(font, new Vector2(inventoryUI.Position.X, inventoryUI.Position.Y + 30),
            //    $"---Stats---\n{character1.Health}\n{character1.Strength}\n{character1.Attack}\n{character1.Defence}", Color.White));

            


            updateables.Add(map);
           // updateables.Add(character1);
            
            drawables.Add(map);
            //drawables.Add(character1);
            
        }

        public override void Update(GameTime gameTime)
        {
            Vector2 screenToWorldSpace = Camera2d.ScreenToWorldSpace(Input.GetMousePosition());
            tileData = MapUtil.GetTileData(map, screenToWorldSpace).Type.ToString();

            foreach (IUpdateable updateable in updateables)
            {
                updateable.Update(gameTime);
            }

        }

        
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(SpriteSortMode.BackToFront, null, null, null, null, null, Camera2d.Transform);
            foreach (IDrawable sprite in drawables)
            {
                sprite.Draw(gameTime, spriteBatch);
            }
            spriteBatch.End();


            _UISpriteBatch.Begin();
            //if(character1.Selected)
            //{
            //    inventoryUI.Draw(gameTime, _UISpriteBatch);
            //}
            
            var framerate = (1 / gameTime.ElapsedGameTime.TotalSeconds);
            _UISpriteBatch.DrawString(font, "FPS: " + framerate + $"\nTile Data: {tileData}", new Vector2(0,0), Color.White);
            //_UISpriteBatch.DrawString(font, , new Vector2(0, 0), Color.White);
            _UISpriteBatch.End();
        }
    }
}

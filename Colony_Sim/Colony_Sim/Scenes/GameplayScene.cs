using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Colony_Sim.Scenes
{
    class GameplayScene : Scene, IUpdateable, IDrawable
    {
        public override bool Active { get; set; } = false;
        public GraphicsDevice graphicsDevice { get; set; }
        private SpriteBatch _UISpriteBatch;
        string tileData = "";
        Map map = new Map();
        Character character1;
        SpriteFont font;
        Label label;
        Label characterName;
        Container container;
        Container inventoryUI;

        List<IDrawable> drawables;
        List<IUpdateable> updateables;
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
            character1 = new Character(game.Content.Load<Texture2D>("Textures\\Man"));
            font = game.Content.Load<SpriteFont>("Fonts\\DefaultFont");
            label = new Label(font, new Vector2(0, 0), "", Color.White);
            container = new Container(new Vector2(graphicsDevice.Viewport.Width - 200, 0), TextureUtil.GenerateTexture(Color.Transparent, 10, 10));
            container.AddContent(label);

            updateables.Add(map);
            updateables.Add(character1);

            drawables.Add(map);
            drawables.Add(character1);
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

            //var framerate = (1 / gameTime.ElapsedGameTime.TotalSeconds);
            //_UISpriteBatch.DrawString(font, "\nFPS: " + framerate, new Vector2(0,0), Color.White);
            _UISpriteBatch.DrawString(font, $"Tile Data: {tileData}", new Vector2(0, 0), Color.White);
            _UISpriteBatch.End();
        }
    }
}

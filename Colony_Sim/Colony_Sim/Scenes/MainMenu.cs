using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colony_Sim.Scenes
{
    class MainMenu : Scene, IUpdateable, IDrawable
    {
        SpriteFont font;
        GraphicsDevice graphicsDevice;
        private SpriteBatch _UISpriteBatch;
        public override bool Active { get; set; } = false;
        Button PlayButton;
        List<IDrawable> drawables;
        List<IUpdateable> updateables;
        public MainMenu(GraphicsDevice g, Game game)
        {
            graphicsDevice = g;
            //Initialize();
            LoadContent(game);
            _UISpriteBatch = new SpriteBatch(g);
        }

        public void LoadContent(Game game)
        {
            drawables = new List<IDrawable>();
            updateables = new List<IUpdateable>();
            font = game.Content.Load<SpriteFont>("Fonts\\DefaultFont");
            PlayButton = new Button(TextureUtil.GenerateTexture(Color.Black,200,50), new Vector2(graphicsDevice.Viewport.Width / 2, graphicsDevice.Viewport.Height / 2));
            drawables.Add(PlayButton);
            updateables.Add(PlayButton);
        }

        public override void Update(GameTime gameTime)
        {
            foreach (IUpdateable updateable in updateables)
            {
                updateable.Update(gameTime);
            }
        }
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            foreach (IDrawable sprite in drawables)
            {
                sprite.Draw(gameTime, spriteBatch);
            }
            spriteBatch.End();

            //PlayButton.Draw(gameTime, spriteBatch);
            //spriteBatch.DrawString(font, "Click to play", new Vector2(graphicsDevice.Viewport.Width / 2, graphicsDevice.Viewport.Height / 2), Color.White);


        }
    }
}

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
        public override bool Active { get; set; } = true;
        List<IDrawable> drawables;
        List<IUpdateable> updateables;
        public MainMenu(GraphicsDevice g, Game game)
        {
            graphicsDevice = g;
            //Initialize();
            LoadContent(game);
        }

        public void LoadContent(Game game)
        {
            font = game.Content.Load<SpriteFont>("Fonts\\DefaultFont");
        }

        public override void Update(GameTime time)
        {

        }
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.DrawString(font, "Click to play", new Vector2(graphicsDevice.Viewport.Width / 2, graphicsDevice.Viewport.Height / 2), Color.White);
            spriteBatch.End();
        }
    }
}

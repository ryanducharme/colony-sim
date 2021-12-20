using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Colony_Sim.Scenes
{
    class SceneManager : IDrawable, IUpdateable
    {
        GraphicsDevice graphics;
        List<Scene> Scenes = new List<Scene>();
        MainMenu mainMenu;
        GameplayScene gameScene;

        
        public SceneManager(GraphicsDevice g, Game game)
        {
            graphics = g;
            mainMenu = new MainMenu(graphics, game);
            gameScene = new GameplayScene(graphics, game);
            Scenes.Add(mainMenu);
            Scenes.Add(gameScene);
        }
        public void Update(GameTime gameTime)
        {
            foreach (Scene scene in Scenes)
            {
                //if (Input.MouseLeftPressed())
                //{
                //    mainMenu.Active = false;
                //    gameScene.Active = true;
                //}
                if (scene.Active)
                {
                    scene.Update(gameTime);
                }
            }
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            foreach (Scene scene in Scenes)
            {
                //scene.Active = true;
                if (scene.Active)
                {
                    scene.Draw(gameTime, spriteBatch);
                }
            }
        }
    }
}

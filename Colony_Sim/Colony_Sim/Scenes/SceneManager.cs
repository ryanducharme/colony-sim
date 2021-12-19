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
        GameplayScene gameScene;

        
        public SceneManager(GraphicsDevice g, Game game)
        {
            graphics = g;
            gameScene = new GameplayScene(graphics, game);
            Scenes.Add(gameScene);
        }
        public void Update(GameTime gameTime)
        {
            gameScene.Update(gameTime);
            //if (Input.MouseLeftPressed())
            //{
            //    gameScene.Active = false;
            //}
            //else
            //{
            //    gameScene.Active = true;
            //}
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

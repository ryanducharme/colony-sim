using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Colony_Sim.Scenes
{
    abstract class Scene : IUpdateable, IDrawable
    {
        abstract public bool Active { get; set; }
        public virtual void Update(GameTime gameTime) { }
        public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch) { }

        //public void Draw(SpriteBatch spriteBatch) { }
    }
}

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colony_Sim
{
    class Button : UserInterfaceElement
    {
        //public Vector2 Position { get; set; }
        public Texture2D Texture { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public Vector2 Position { get; set; }
        public Rectangle Bounds { get; set; }
        public bool Visible { get; set; } = true;
        public Button(Texture2D texture, Vector2 position)
        {
            Texture = texture;
            Width = Texture.Width;
            Height = Texture.Height;
            Position = position;
            Bounds = new Rectangle((int)Position.X, (int)Position.Y, Width, Height);
            
        }

        public void OnClick()
        {

        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            if (Visible)
            {
                spriteBatch.Draw(Texture, Position, Color.Red);
            }
            
        }
    }
}

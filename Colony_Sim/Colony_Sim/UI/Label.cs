using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colony_Sim
{
    class Label : UserInterfaceElement, IDrawable
    {
        public Vector2 Position { get; set; } = new Vector2(0, 0);
        public string Text { get; set; }
        SpriteFont Font { get; set; }
        Color FontColor { get; set; } = Color.Red;
        public Rectangle Bounds { get; set; }
        public bool Visible { get; set; } = true;

        public Label(SpriteFont font, Vector2 position, string text, Color fontColor)
        {
            Font = font;
            Position = position;
            Text = text;
            FontColor = fontColor;
        }
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if(Visible)
            {
                spriteBatch.DrawString(Font, Text, Position, FontColor);
            }
            else
            {
                FontColor = Color.Transparent;
            }
            
        }
    }
}

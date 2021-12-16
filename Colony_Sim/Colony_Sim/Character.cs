using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colony_Sim
{
    class Character
    {
        public int Health { get; set; }
        public int Strength { get; set; }
        public int Attack { get; set; }
        public int Defence { get; set; }
        public float Experience { get; set; }
        public float MoveSpeed { get; set; }
        public Vector2 Position { get; set; } = new Vector2(0, 0);
        public Texture2D Texture { get; set; }
        public Rectangle Bounds;

        public Character(Texture2D texture)
        {
            Texture = texture;
            
            Bounds = new Rectangle((int)Position.X, (int)Position.Y, Texture.Width, Texture.Height);
        }

        public void Move(Vector2 targetPosition)
        {
            Position = targetPosition;
        }

        public void Update()
        {

            int x = (int)Position.X;
            int y = (int)Position.Y;
            Position = new Vector2(x, y);
            Bounds.Location = new Vector2(x, y).ToPoint();
            //Bounds.Location = Camera2d.ScreenToWorldSpace(Bounds.Location.ToVector2());
        }
    }
}

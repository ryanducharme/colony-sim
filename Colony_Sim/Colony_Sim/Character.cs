using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colony_Sim
{
    class Character : IUpdateable, IDrawable
    {
        public int Health { get; set; }
        public int Strength { get; set; }
        public int Attack { get; set; }
        public int Defence { get; set; }
        public float Experience { get; set; }
        public int MoveSpeed { get; set; } = 2;
        public Vector2 Position { get; set; } = new Vector2(0, 0);
        public Vector2 Direction { get; set; }
        public Texture2D Texture { get; set; }
        public Rectangle Bounds;


        public Character(Texture2D texture)
        {
            Texture = texture;
            
            Bounds = new Rectangle((int)Position.X, (int)Position.Y, Texture.Width, Texture.Height);
        }

     

        public void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(Texture, Position, Color.White);
        }






        //public void Move(Vector2 targetPosition)
        //{
        //    //Position = targetPosition;
        //    if (targetPosition.X < Position.X)
        //        x += MoveSpeed;
            
        //}

        Vector2 targetPosition;
        float x;
        float y;
        float posX;
        float posY;
        public void Update(GameTime time)
        {


            if (targetPosition.X > Position.X)
            {
                posX += MoveSpeed;
                Debug.WriteLine(x);
            }
            else if( targetPosition.X < Position.X)
            {
                posX -= MoveSpeed;
                Debug.WriteLine(x);
            }
            if (targetPosition.Y > Position.Y)
            {
                posY += MoveSpeed;
                Debug.WriteLine(x);
            }
            else if (targetPosition.Y < Position.Y)
            {
                posY -= MoveSpeed;
                Debug.WriteLine(x);
            }


            if (Input.MousePressed())
            {
                x = Camera2d.ScreenToWorldSpace(Input.GetMousePosition()).X;
                y = Camera2d.ScreenToWorldSpace(Input.GetMousePosition()).Y;
                targetPosition = new Vector2(x,y);
            }
            
            //int x = (int)Position.X;
            //int y = (int)Position.Y;
            
            Position = new Vector2(posX, posY);
            Bounds.Location = new Vector2(x, y).ToPoint();
            //Bounds.Location = Camera2d.ScreenToWorldSpace(Bounds.Location.ToVector2());
        }
    }
}

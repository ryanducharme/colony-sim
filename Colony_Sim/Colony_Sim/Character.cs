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
        public string Name { get; set; } = "Fred";
        public int Health { get; set; } = 100;
        public int Strength { get; set; } = 1;
        public int Attack { get; set; } = 1;
        public int Defence { get; set; } = 1;
        public float Experience { get; set; }
        public int MoveSpeed { get; set; } = 2;
        public Vector2 Position { get; set; } = new Vector2(0, 0);
        public Vector2 Direction { get; set; }
        public Texture2D Texture { get; set; }
        public Rectangle Bounds;
        public bool Selected { get; set; }


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
                
            }
            else if( targetPosition.X < Position.X)
            {
                posX -= MoveSpeed;
                
            }
            if (targetPosition.Y > Position.Y)
            {
                posY += MoveSpeed;
                
            }
            else if (targetPosition.Y < Position.Y)
            {
                posY -= MoveSpeed;
                
            }

            if(Input.MouseBounds.Intersects(Bounds) && Input.MouseLeftPressed())
            {
                Selected = true;
                //Debug.WriteLine(Selected);
            }

            if (!Input.MouseBounds.Intersects(Bounds) && Input.MouseLeftPressed())
            {
                Selected = false;
                //Debug.WriteLine(Selected);
            }

            if (Input.MouseRightPressed() && Selected == true)
            {
                x = Camera2d.ScreenToWorldSpace(Input.GetMousePosition()).X;
                y = Camera2d.ScreenToWorldSpace(Input.GetMousePosition()).Y;
                targetPosition = new Vector2(x - (Texture.Width / 2), y - (Texture.Height / 2));
            }
            
            //int x = (int)Position.X;
            //int y = (int)Position.Y;
            
            Position = new Vector2(posX, posY);
            Bounds.Location = new Vector2(posX, posY).ToPoint();
            //Bounds.Location = Camera2d.ScreenToWorldSpace(Bounds.Location.ToVector2());
        }
    }
}

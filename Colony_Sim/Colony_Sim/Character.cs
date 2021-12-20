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
        public Vector2 Position { get; set; }
        public Vector2 Direction { get; set; }
        public Texture2D Texture { get; set; }
        public bool Selected { get; set; }
        public Rectangle Bounds;
        public bool isMoving;
        Vector2 targetPosition;
        float velocity = 0f;
        float x;
        float y;
        float posX;
        float posY;

        public Character(Texture2D texture, Vector2 position)
        {
            Texture = texture;
            Position = position;
            Bounds = new Rectangle((int)Position.X, (int)Position.Y, Texture.Width, Texture.Height);
            posX = Position.X;
            posY = Position.Y;
        }

        public void Draw(GameTime gameTime, SpriteBatch spritebatch)
        {
            spritebatch.Draw(Texture, Position, Color.White);
        }


        public void Move(Vector2 currentPosition, Vector2 destination)
        {


            if (Vector2.Distance(currentPosition, destination) < 0.3f)
            {
                isMoving = false;
                currentPosition = destination;
            }
            if (currentPosition != destination)
            {
                
                if (destination.X >= currentPosition.X)
                {
                    posX += MoveSpeed;
                }
                if (destination.X <= currentPosition.X)
                {
                    posX -= MoveSpeed;
                }
                if (destination.Y > currentPosition.Y)
                {
                    posY += MoveSpeed;
                }
                if (destination.Y < currentPosition.Y)
                {
                    posY -= MoveSpeed;
                }
                Bounds.Location = new Vector2(posX, posY).ToPoint();
                Position = new Vector2(posX, posY);
            }
            

        }
        Vector2 target;

        public void Update(GameTime time)
        {
            

            if (Input.MouseBounds.Intersects(Bounds) && Input.MouseLeftPressed())
            {
                Selected = true;
                Debug.WriteLine(this.Name);
            }

            if (!Input.MouseBounds.Intersects(Bounds) && Input.MouseLeftPressed())
            {
                Selected = false;
            }

            if (Input.MouseRightPressed() && Selected == true)
            {
                isMoving = true;
                target = new Vector2(
                            Camera2d.ScreenToWorldSpace(Input.GetMousePosition()).X,
                            Camera2d.ScreenToWorldSpace(Input.GetMousePosition()).Y);
            }

            if(isMoving == true)
            {
                Move(Position, target);
            }
            

        }
    }
}

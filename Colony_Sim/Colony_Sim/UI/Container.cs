using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colony_Sim
{
    class Container : UserInterfaceElement
    {
        //Container to hold 1 or more ui elements
        public Vector2 Position { get; set; }
        public bool Visible { get; set; } = true;
        public Texture2D Texture { get; set; }
        public List<UserInterfaceElement> ContainerContents { get; set; }
        

        public Container(Vector2 position, Texture2D texture)
        {
            Position = position;
            ContainerContents = new List<UserInterfaceElement>();
            Texture = texture; 
        }

        public void AddContent(UserInterfaceElement uiElement)
        {
            ContainerContents.Add(uiElement);
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            
            if (Visible)
            {
                spriteBatch.Draw(Texture, Position, Color.White);
                foreach (UserInterfaceElement uiElement in ContainerContents)
                {
                    
                    uiElement.Draw(spriteBatch);
                    spriteBatch.End();
                }
            }
            
            
        }
    }
}

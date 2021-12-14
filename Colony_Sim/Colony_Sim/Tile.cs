using System;
using System.Diagnostics;
using System.Drawing;
using Microsoft.Xna.Framework.Graphics;

namespace Colony_Sim
{
    public class Tile
    {
        public Texture2D Texture { get; set; }
        public bool Selected { get; set; }
        public string Description { get; set; }
        public int Size { get; set; } = 24;
        public TileType Type { get; set; }
        public Microsoft.Xna.Framework.Color Color { get; set; }
        //Rectangle Bounds { get; set; }
        public Tile(GraphicsDevice g, TileType type)
        {
            if(type == TileType.Grass)
            {
                Texture = GenerateTexture(g, Microsoft.Xna.Framework.Color.Green);
                Color = Microsoft.Xna.Framework.Color.Green;
            }
            if (type == TileType.Water)
            {
                Texture = GenerateTexture(g, Microsoft.Xna.Framework.Color.DeepSkyBlue);
            }
            if (type == TileType.Soil)
            {
                Texture = GenerateTexture(g, Microsoft.Xna.Framework.Color.DarkGreen);
                Color = Microsoft.Xna.Framework.Color.DarkGreen;
            }
            if (type == TileType.Empty)
            {
                Texture = GenerateTexture(g, Microsoft.Xna.Framework.Color.CornflowerBlue);
            }
            Type = type;
        }

        private Texture2D GenerateTexture(GraphicsDevice g, Microsoft.Xna.Framework.Color color)
        {    
            Microsoft.Xna.Framework.Color[] data = new Microsoft.Xna.Framework.Color[Size * Size];
            Texture2D texture = new Texture2D(g, Size, Size);
            //Debug.WriteLine(texture.Format.ToString());
            for (int i = 0; i < data.Length; ++i) data[i] = color;
            
            if (Selected)
            {
                for (int i = 0; i < data.Length; ++i) data[i] = Microsoft.Xna.Framework.Color.White;
                texture.SetData(data);
                return texture;
            }
            else
            {
                
            }
            texture.SetData(data);
            return texture;
            //Texture.SetData(data);
        }
    }
}

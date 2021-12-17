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
        public int Size { get; set; } = 64;
        public TileType Type { get; set; }
        public Microsoft.Xna.Framework.Color Color { get; set; }
        //Rectangle Bounds { get; set; }
        public Tile(TileType type)
        {
            if(type == TileType.Grass)
            {
                Texture = TextureUtil.DefaultGreen;
                Color = Microsoft.Xna.Framework.Color.Green;
            }
            if (type == TileType.Water)
            {
                Texture = TextureUtil.GenerateTexture(Microsoft.Xna.Framework.Color.DeepSkyBlue, Size, Size);
            }
            if (type == TileType.Soil)
            {
                Texture = TextureUtil.DefaultDarkGreen;
                Color = Microsoft.Xna.Framework.Color.DarkGreen;
            }
            if (type == TileType.Empty)
            {
                Texture = TextureUtil.GenerateTexture(Microsoft.Xna.Framework.Color.CornflowerBlue, Size, Size);
            }
            Type = type;
        }

        
    }
}

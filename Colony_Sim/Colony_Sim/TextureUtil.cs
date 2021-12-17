using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colony_Sim
{
    static class TextureUtil
    {
        public static GraphicsDevice graphicsDevice { get; set; }
        public static Texture2D DefaultGreen { get; set; }
        public static Texture2D DefaultDarkGreen { get; set; }
        public static Texture2D GenerateTexture(Microsoft.Xna.Framework.Color color, int width, int height)
        {
            Microsoft.Xna.Framework.Color[] data = new Microsoft.Xna.Framework.Color[width * height];
            Texture2D texture = new Texture2D(graphicsDevice, width, height);
            //Debug.WriteLine(texture.Format.ToString());
            for (int i = 0; i < data.Length; ++i) data[i] = color;

            //var textureData = Enumerable.Range(0, width * height)
            //    .Select(i => color)
            //    .ToArray();

            texture.SetData(data);
            return texture;
            //Texture.SetData(data);
        }
    }
}

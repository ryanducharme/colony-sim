using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Colony_Sim
{
    public class Level
    {
        GraphicsDevice graphics;
        public Tile[,] LevelData { get; }
        public int LevelSize { get; set; } = 64;
        public Level(GraphicsDevice g)
        {
            graphics = g;
            LevelData = new Tile[LevelSize, LevelSize];
        }

        public Vector2 GetLevelIndex(int screenX, int screenY)
        {
            int xIndex = screenX / 32;
            int yIndex = screenY / 32;
            return new Vector2(xIndex, yIndex);
        }

        public bool IsWithinLevelBounds(Vector2 testPosition)
        {
            if (testPosition.X >= 0 && testPosition.X < LevelData.GetLength(0) && testPosition.Y >= 0 && testPosition.Y < LevelData.GetLength(1))
            {   
                return true;
            }
            else
            {
                return false;
            }
        }

        public void GenerateLevel()
        {
            Random random = new Random();

            int maxWater = 10;
            int maxRocks = 5;
            int currentWaterTileCount = 0;
            
            
            for (int row = 0; row < LevelSize; row++)
            {
                for (int col = 0; col < LevelSize; col++)
                {
                    int randomNumber = random.Next(0, 3);
                    
                    TileType tileType = (TileType)Enum.ToObject(typeof(TileType), randomNumber);

                    //Check if the tile is a water tile. If it is, make sure we are not passed the max
                    //amount of water tiles.. then save it to memory. If we hit the max amount of water tiles
                    //generate a new random number until it is not a water tile then save that to memory
                    if (tileType == TileType.Water && currentWaterTileCount < maxWater)
                    {
                        currentWaterTileCount++;
                        LevelData[row, col] = new Tile(graphics, tileType);
                    }
                    else
                    {
                        while(randomNumber == (int)TileType.Water)
                        {
                            randomNumber = random.Next(0, 3);
                        }
                        tileType = (TileType)Enum.ToObject(typeof(TileType), randomNumber);
                        LevelData[row, col] = new Tile(graphics, tileType);
                    }
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //Vector position
            int x = 0;
            int y = 0;
            int row = 0;
            int col = 0;

            //spriteBatch.Begin();
            for (row = 0; row < LevelSize; row++)
            {
                for (col = 0; col < LevelSize; col++)
                {
                    
                    spriteBatch.Draw(LevelData[row, col].Texture, new Vector2(y,x), Color.White);
                    x += LevelData[row, col].Size;
                }
                col = 0;
                x = 0;
                y += LevelData[row, col].Size;
            }
            //spriteBatch.End();
        }
    }
}

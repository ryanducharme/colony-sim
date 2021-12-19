using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Colony_Sim
{
    public class Map : IDrawable, IUpdateable
    {
        public Tile[,] MapData { get; }
        public int MapSize { get; set; } = 100;
        public Map()
        {
            MapData = new Tile[MapSize, MapSize];
        }

        public Vector2 GetMapIndex(Vector2 Point)
        {
            float xIndex = Point.X / 64;
            float yIndex = Point.Y / 64;
            return new Vector2(xIndex, yIndex);
        }

        public bool IsWithinMapBounds(Vector2 testPosition)
        {
            if (testPosition.X >= 0 && testPosition.X < MapData.GetLength(0) && testPosition.Y >= 0 && testPosition.Y < MapData.GetLength(1))
                return true;
            else
                return false;
        }

        public void GenerateMap()
        {
            Random random = new Random();

            int maxWater = 0;
            int maxRocks = 5;
            int currentWaterTileCount = 0;
            
            
            for (int row = 0; row < MapSize; row++)
            {
                for (int col = 0; col < MapSize; col++)
                {
                    int randomNumber = random.Next(0, 3);
                    
                    TileType tileType = (TileType)Enum.ToObject(typeof(TileType), randomNumber);

                    //Check if the tile is a water tile. If it is, make sure we are not passed the max
                    //amount of water tiles.. then save it to memory. If we hit the max amount of water tiles
                    //generate a new random number until it is not a water tile then save that to memory
                    if (tileType == TileType.Water && currentWaterTileCount < maxWater)
                    {
                        currentWaterTileCount++;
                        MapData[row, col] = new Tile(tileType);
                    }
                    else
                    {
                        while(randomNumber == (int)TileType.Water)
                        {
                            randomNumber = random.Next(0, 3);
                        }
                        tileType = (TileType)Enum.ToObject(typeof(TileType), randomNumber);
                        MapData[row, col] = new Tile(tileType);
                    }
                }
            }
        }

        public void Update(GameTime gameTime)
        {
            Vector2 mousePos = Camera2d.ScreenToWorldSpace(Input.GetMousePosition());
            if (Input.MouseLeftPressed() && IsWithinMapBounds(GetMapIndex(mousePos)))
            {
                Tile tempTile = MapUtil.GetTileData(this, mousePos);
                tempTile.Selected = true;
                Debug.WriteLine(tempTile.Type.ToString());


            }
        }
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            //Vector position
            int x = 0;
            int y = 0;
            int row = 0;
            int col = 0;

            //spriteBatch.Begin();
            for (row = 0; row < MapSize; row++)
            {
                for (col = 0; col < MapSize; col++)
                {

                    spriteBatch.Draw(MapData[row, col].Texture, new Vector2(y, x), Color.White);
                    
                    x += MapData[row, col].Size;
                }
                col = 0;
                x = 0;
                y += MapData[row, col].Size;
            }

            //var selectedTiles = Tiles.Where(tile => tile.Selected).ToArray();

            //spriteBatch.End();
        }

        // see Gramps for implementation
        public IEnumerable<Tile> Tiles { get => null; }
    }
}

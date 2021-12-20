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
        public Tile[,] TerrainLayer { get; }
        //Character[,] CharacterLayer { get; }
        
        public int MapSize { get; set; } = 100;

        List<Character> CharacterLayer;
        Character MainCharacter;
        Character SecondCharacter;



        public Map()
        {
            TerrainLayer = new Tile[MapSize, MapSize];
            CharacterLayer = new List<Character>();
            MainCharacter = new Character(TextureUtil.GenerateTexture(Color.Red, 32, 32), new Vector2(0,0));
            CharacterLayer.Add(MainCharacter);
            SecondCharacter = new Character(TextureUtil.GenerateTexture(Color.Blue, 32, 32), new Vector2(300, 300));
            SecondCharacter.Name = "Albert";
            CharacterLayer.Add(SecondCharacter);
        }


        

        public Vector2 GetMapIndex(Vector2 Point)
        {
            float xIndex = Point.X / 64;
            float yIndex = Point.Y / 64;
            return new Vector2(xIndex, yIndex);
        }
        public bool IsWithinMapBounds(Vector2 testPosition)
        {
            if (testPosition.X >= 0 && testPosition.X < TerrainLayer.GetLength(0) && testPosition.Y >= 0 && testPosition.Y < TerrainLayer.GetLength(1))
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
                        TerrainLayer[row, col] = new Tile(tileType);
                    }
                    else
                    {
                        while(randomNumber == (int)TileType.Water)
                        {
                            randomNumber = random.Next(0, 3);
                        }
                        tileType = (TileType)Enum.ToObject(typeof(TileType), randomNumber);
                        TerrainLayer[row, col] = new Tile(tileType);
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

            foreach (Character character in CharacterLayer)
            {
                character.Update(gameTime);
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

                    spriteBatch.Draw(TerrainLayer[row, col].Texture, new Vector2(y, x), Color.White);
                    
                    x += TerrainLayer[row, col].Size;
                }
                col = 0;
                x = 0;
                y += TerrainLayer[row, col].Size;
            }


            foreach(Character character in CharacterLayer)
            {
                character.Draw(gameTime, spriteBatch);
            }
        }


        // see Gramps for implementation
        public IEnumerable<Tile> Tiles { get => null; }
    }
}

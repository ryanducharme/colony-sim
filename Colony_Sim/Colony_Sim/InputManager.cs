using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colony_Sim
{
    class InputManager
    {
        public MouseState mouseState { get; set; }
        KeyboardState keyboardState { get; set; }
        MouseState lastMouseState;
        KeyboardState lastKeyboardState;
        Vector2 mousePosition;
        bool mouseOverButton;        
        private Level _level;
        private Container uiContainer;
        Vector2 lastTileClicked;
        int xIndex;
        int yIndex;


        public Vector2 GetLevelPosition()
        {
            return new Vector2(xIndex, yIndex);   
        }
        public InputManager(Level level, Container container)
        {
            _level = level;
            uiContainer = container;
            Debug.WriteLine("InputeManager created");
        }
        public string GetTileData()
        {
            string tileData;
            if (xIndex >= 0 && xIndex < _level.LevelData.GetLength(0) && yIndex >= 0 && yIndex < _level.LevelData.GetLength(1))
            {
                tileData = _level.LevelData[xIndex, yIndex].Type.ToString();
                return tileData;
            }
            else
                return "";


        }
        public Vector2 GetMousePosition()
        {
            mousePosition = new Vector2(mouseState.X, mouseState.Y);
            return mousePosition;
        }

        //public bool MousePressed()
        //{
            
        //    mouseState = Mouse.GetState();
        //    if (mouseState.LeftButton == ButtonState.Pressed)
        //        return true;
        //    else
        //        return false;
        //    Debug.WriteLine(mouseState);
        //}

        //public bool SingleClick(MouseState mouseButton)
        //{
        //    if()
        //}

        public void Update(GameTime time, SpriteBatch spriteBatch)
        {
            lastMouseState = mouseState;
            lastKeyboardState = keyboardState;
            mouseOverButton = false;
            mouseState = Mouse.GetState();
            keyboardState = Keyboard.GetState();

            mousePosition = new Vector2(mouseState.X, mouseState.Y);
            Rectangle mouseBoundingBox = new Rectangle((int)mousePosition.X, (int)mousePosition.Y, 1, 1);

            //Size of each tile
             xIndex = mouseState.X / 24;
             yIndex = mouseState.Y / 24;

            //if (button.Bounds.Intersects(mouseBoundingBox))
            //{
            //    mouseOverButton = true;
            //}
            
            //if (lastKeyboardState.IsKeyDown(Keys.F1) && keyboardState.IsKeyDown(Keys.F1))
            //    uiContainer.Visible = true;
            //else
            //    uiContainer.Visible = false;

            if (xIndex >= 0 && xIndex < _level.LevelData.GetLength(0) && yIndex >= 0 && yIndex < _level.LevelData.GetLength(1))
            {
                
                //detect only one click
                if (lastMouseState.LeftButton == ButtonState.Released && mouseState.LeftButton == ButtonState.Pressed)
                {
                    Debug.WriteLine("left mouse pressed");
                    //Draw water
                    //level.LevelData[xIndex, yIndex] = new Tile(_graphics.GraphicsDevice, TileType.Water);


                    _level.LevelData[xIndex, yIndex].Selected = true;
                    Texture2D tempTexture = new Texture2D(spriteBatch.GraphicsDevice, 24, 24);
                    Microsoft.Xna.Framework.Color[] resetTextureData = new Microsoft.Xna.Framework.Color[24 * 24];
                    Microsoft.Xna.Framework.Color[] data = new Microsoft.Xna.Framework.Color[24 * 24];

                    //set initial initial color
                    for (int i = 0; i < data.Length; ++i) resetTextureData[i] = _level.LevelData[(int)lastTileClicked.X, (int)lastTileClicked.Y].Color;
                    _level.LevelData[(int)lastTileClicked.X, (int)lastTileClicked.Y].Texture.SetData(resetTextureData);
                    for (int i = 0; i < data.Length; ++i) data[i] = _level.LevelData[xIndex, yIndex].Color;

                    //get texture data of current tile then add white borders
                    foreach (int i in Enumerable.Range(0, 24))
                    {
                        // top edge
                        data[i] = Color.LimeGreen;
                        // left edge
                        data[i * 24] = Color.LimeGreen;
                        // right edge
                        data[(i * 24) + 23] = Color.LimeGreen;
                        // bottom edge
                        data[data.Length - 1 - i] = Color.LimeGreen;
                    }
                    //foreach (int edgePixel in Level.EdgePixels)
                    //    data[edgePixel] = Color.LimeGreen;

                    //this works
                    //int end = 23;
                    //for (int i = 0; i < data.Length; ++i)
                    //{
                    //    if (i <= 23)
                    //    {
                    //        data[i] = Color.LimeGreen;
                    //    }
                    //    if (i % 24 == 0)
                    //    {
                    //        data[i] = Color.LimeGreen;
                    //    }
                    //    if (i % 24 == 23)
                    //    {
                    //        data[i] = Color.LimeGreen;
                    //        end *= 2;
                    //    }
                    //    if (i >= data.Length - 24 && i <= data.Length)
                    //    {
                    //        data[i] = Color.LimeGreen;
                    //    }
                    //}

                    tempTexture.SetData(data);
                    _level.LevelData[xIndex, yIndex].Texture = tempTexture;
                    lastTileClicked = new Vector2(xIndex, yIndex);
                }
            }
        }
    }
}

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
        //MouseInputManager mouseInputMgr;
        KeyboardState keyboardState { get; set; }        
        KeyboardState lastKeyboardState;
        //bool mouseOverButton;        
        private Level _level;
        private Container uiContainer;
        Vector2 lastTileClicked;
        public Vector2 ScreenToWorldLevelIndex;

        public InputManager(Level level, Container container)
        {
            _level = level;
            uiContainer = container;
            
            //mouseInputMgr = new MouseInputManager();
        }
        public string GetTileData()
        {
            string tileData;
            if (_level.IsWithinLevelBounds(ScreenToWorldLevelIndex))
            {
                tileData = _level.LevelData[(int)ScreenToWorldLevelIndex.X, (int)ScreenToWorldLevelIndex.Y].Type.ToString();
                return tileData;
            }
            else
                return "not within bounds";
        }
        
        public void Update(SpriteBatch spriteBatch)
        {
            //Rectangle mouseBoundingBox = new Rectangle((int)mousePosition.X, (int)mousePosition.Y, 1, 1);
            //if (button.Bounds.Intersects(mouseBoundingBox))
            //{
            //    mouseOverButton = true;
            //}

            //if (lastKeyboardState.IsKeyDown(Keys.F1) && keyboardState.IsKeyDown(Keys.F1))
            //    uiContainer.Visible = true;
            //else
            //    uiContainer.Visible = false;
            lastKeyboardState = keyboardState;
            keyboardState = Keyboard.GetState();
            
            //Get the mouse coordinates and translate them to the offset of the world. Then see if that vector is within the bounds of the level (chopped up by the tile size)
            ScreenToWorldLevelIndex = _level.GetLevelIndex(Camera2d.ScreenToWorldSpace(MouseInputManager.GetMousePosition()));
            Debug.WriteLine(ScreenToWorldLevelIndex);
            if (_level.IsWithinLevelBounds(ScreenToWorldLevelIndex))
            {
                //Debug.WriteLine("Worked");

                if (MouseInputManager.MousePressed())
                {
                    
                    _level.LevelData[(int)ScreenToWorldLevelIndex.X, (int)ScreenToWorldLevelIndex.Y].Selected = true;
                    Texture2D tempTexture = new Texture2D(spriteBatch.GraphicsDevice, 32, 32);
                    Microsoft.Xna.Framework.Color[] resetTextureData = new Microsoft.Xna.Framework.Color[32 * 32];
                    Microsoft.Xna.Framework.Color[] data = new Microsoft.Xna.Framework.Color[32 * 32];


                    //draw border around tile that is clicked
                    //set initial initial color
                    for (int i = 0; i < data.Length; ++i) resetTextureData[i] = _level.LevelData[(int)lastTileClicked.X, (int)lastTileClicked.Y].Color;
                    _level.LevelData[(int)lastTileClicked.X, (int)lastTileClicked.Y].Texture.SetData(resetTextureData);
                    for (int i = 0; i < data.Length; ++i) data[i] = _level.LevelData[(int)ScreenToWorldLevelIndex.X, (int)ScreenToWorldLevelIndex.Y].Color;

                    //get texture data of current tile then add white borders
                    foreach (int i in Enumerable.Range(0, 32))
                    {
                        // top edge
                        data[i] = Color.LimeGreen;
                        // left edge
                        data[i * 32] = Color.LimeGreen;
                        // right edge
                        data[(i * 32) + 31] = Color.LimeGreen;
                        // bottom edge
                        data[data.Length - 1 - i] = Color.LimeGreen;
                    }
                    tempTexture.SetData(data);
                    _level.LevelData[(int)ScreenToWorldLevelIndex.X, (int)ScreenToWorldLevelIndex.Y].Texture = tempTexture;
                    lastTileClicked = new Vector2((int)ScreenToWorldLevelIndex.X, (int)ScreenToWorldLevelIndex.Y);
                }
            }
        }
    }
}

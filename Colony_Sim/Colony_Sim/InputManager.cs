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
        private Map _Map;
        private Container uiContainer;
        Vector2 lastTileClicked;
        public Vector2 ScreenToWorldMapIndex;
        Character _character;
        Container inventory;
        public InputManager(Map map, Container container, Character character)
        {
            _Map = map;
            uiContainer = container;
            _character = character;
            //mouseInputMgr = new MouseInputManager();
        }
        public string GetTileData()
        {
            string tileData;
            if (_Map.IsWithinMapBounds(ScreenToWorldMapIndex))
            {
                tileData = _Map.MapData[(int)ScreenToWorldMapIndex.X, (int)ScreenToWorldMapIndex.Y].Type.ToString();
                return tileData;
            }
            else
                return "not within bounds";
        }


        

        public void Update(SpriteBatch spriteBatch)
        {
           
            lastKeyboardState = keyboardState;
            keyboardState = Keyboard.GetState();
            
            //Get the mouse coordinates and translate them to the offset of the world. Then see if that vector is within the bounds of the map (chopped up by the tile size)
            ScreenToWorldMapIndex = _Map.GetMapIndex(Camera2d.ScreenToWorldSpace(MouseInputManager.GetMousePosition()));

            //Debug.WriteLine("Mouse: " + MouseInputManager.Bounds);
            if (MouseInputManager.Bounds.Intersects(_character.Bounds) && MouseInputManager.MousePressed())
            {
                //uiContainer.AddContent(new Label())
                Debug.WriteLine("Over Character");
            }



            if (_Map.IsWithinMapBounds(ScreenToWorldMapIndex))
            {
                //Debug.WriteLine("Worked");

                if (MouseInputManager.MousePressed())
                {
                    
                    _Map.MapData[(int)ScreenToWorldMapIndex.X, (int)ScreenToWorldMapIndex.Y].Selected = true;
                    Texture2D tempTexture = new Texture2D(spriteBatch.GraphicsDevice, 32, 32);
                    Microsoft.Xna.Framework.Color[] resetTextureData = new Microsoft.Xna.Framework.Color[32 * 32];
                    Microsoft.Xna.Framework.Color[] data = new Microsoft.Xna.Framework.Color[32 * 32];


                    //draw border around tile that is clicked
                    //set initial initial color
                    for (int i = 0; i < data.Length; ++i) resetTextureData[i] = _Map.MapData[(int)lastTileClicked.X, (int)lastTileClicked.Y].Color;
                    _Map.MapData[(int)lastTileClicked.X, (int)lastTileClicked.Y].Texture.SetData(resetTextureData);
                    for (int i = 0; i < data.Length; ++i) data[i] = _Map.MapData[(int)ScreenToWorldMapIndex.X, (int)ScreenToWorldMapIndex.Y].Color;

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
                    _Map.MapData[(int)ScreenToWorldMapIndex.X, (int)ScreenToWorldMapIndex.Y].Texture = tempTexture;
                    lastTileClicked = new Vector2((int)ScreenToWorldMapIndex.X, (int)ScreenToWorldMapIndex.Y);
                }
            }
        }
    }
}

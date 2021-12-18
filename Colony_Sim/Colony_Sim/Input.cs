using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colony_Sim
{
    static class Input
    {
        private static MouseState CurrentMouseState;
        private static MouseState LastMouseState;
        private static Vector2 MousePosition;
        public static Rectangle MouseBounds;
        public static void Update()
        {
            GetCurrentMouseState();
        }

        //public static MouseInputManager()
        //{
            
        //}
        public static Vector2 GetMousePosition()
        {
            MousePosition.X = CurrentMouseState.X;
            MousePosition.Y = CurrentMouseState.Y;
            MouseBounds = new Rectangle((int)Camera2d.ScreenToWorldSpace(MousePosition).X, (int)Camera2d.ScreenToWorldSpace(MousePosition).Y, 1, 1);
            //Bounds = new Rectangle((int)MousePosition.X, (int)MousePosition.Y, 1, 1);
            return MousePosition;
        }

        public static MouseState GetCurrentMouseState()
        {
            LastMouseState = CurrentMouseState;
            CurrentMouseState = Mouse.GetState();
            return CurrentMouseState;
        }

        public static MouseState GetLastMouseState()
        {
            return LastMouseState;
        }
        public static bool MouseLeftPressed()
        {
            CurrentMouseState = Mouse.GetState();
            if (CurrentMouseState.LeftButton == ButtonState.Pressed)
                return true;
            else
                return false;
            //Debug.WriteLine(mouseState);
        }
        public static bool MouseRightPressed()
        {
            CurrentMouseState = Mouse.GetState();
            if (CurrentMouseState.RightButton == ButtonState.Pressed)
                return true;
            else
                return false;
            //Debug.WriteLine(mouseState);
        }

        //public bool SingleClick(MouseState mouseButton)
        //{
        //    if ()
        //}
    }
}

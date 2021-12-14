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
    static class MouseInputManager
    {
        private static MouseState CurrentMouseState;
        private static MouseState LastMouseState;
        private static Vector2 MousePosition;

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
        public static bool MousePressed()
        {
            CurrentMouseState = Mouse.GetState();
            if (CurrentMouseState.LeftButton == ButtonState.Pressed)
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

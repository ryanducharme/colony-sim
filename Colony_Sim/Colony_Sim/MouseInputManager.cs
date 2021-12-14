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
    class MouseInputManager
    {
        private MouseState CurrentMouseState;
        private MouseState LastMouseState;
        private Vector2 MousePosition;

        public void Update()
        {
            GetCurrentMouseState();
            
        }

        public MouseInputManager()
        {
            
        }
        public Vector2 GetMousePosition()
        {
            MousePosition.X = CurrentMouseState.X;
            MousePosition.Y = CurrentMouseState.Y;
            return MousePosition;
        }

        public MouseState GetCurrentMouseState()
        {
            LastMouseState = CurrentMouseState;
            CurrentMouseState = Mouse.GetState();
            return CurrentMouseState;
        }

        public MouseState GetLastMouseState()
        {
            return LastMouseState;
        }
        public bool MousePressed()
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

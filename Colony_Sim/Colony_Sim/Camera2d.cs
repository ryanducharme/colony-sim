﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;

public static class Camera2d
{
    public static Matrix Transform { get; set; } // Matrix Transform
    public static Vector3 Position { get; set; } // Camera Position
    public static int Speed { get; set; } = 5;
    //protected float _rotation; // Camera Rotation
    public static GraphicsDeviceManager GraphicsDeviceManager { get; set; }
    
    //public static Camera2d(GraphicsDeviceManager g)
    //{
    //    _graphics = g;
    //}
    public static Vector2 ScreenToWorldSpace(in Vector2 point)
    {
        Matrix invertedMatrix = Matrix.Invert(Transform);
        return Vector2.Transform(point, invertedMatrix);
    }
    public static void Update()
    {
        KeyboardState key = Keyboard.GetState();
        //move cam left
        
        if(Colony_Sim.MouseInputManager.GetMousePosition().X <= 0)
        {
            Position -= new Vector3(Speed, 0, 0);
            Transform = Matrix.CreateTranslation(Position);
        }

        if (Colony_Sim.MouseInputManager.GetMousePosition().X >= GraphicsDeviceManager.PreferredBackBufferWidth)
        {
            Position += new Vector3(Speed, 0, 0);
            Transform = Matrix.CreateTranslation(Position);
        }
        if (Colony_Sim.MouseInputManager.GetMousePosition().Y <= 0)
        {
            Position -= new Vector3(0, Speed, 0);
            Transform = Matrix.CreateTranslation(Position);
        }

        if (Colony_Sim.MouseInputManager.GetMousePosition().Y >= GraphicsDeviceManager.PreferredBackBufferHeight)
        {
            Position += new Vector3(0, Speed, 0);
            Transform = Matrix.CreateTranslation(Position);
        }
        //inverse = Transform;
        //inverse = Matrix.Invert(inverse);
        //Debug.WriteLine("Transform: " + Transform);
        //Debug.WriteLine("Inverse: " + inverse);
    }

}
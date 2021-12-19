using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;

public static class Camera2d
{
    public static Matrix Transform { get; set; } = Matrix.Identity; // Matrix Transform
    public static Vector3 Position { get; set; }// Camera Position
    public static Vector3 Scale { get; set; } // Camera zoom
    public static int Speed { get; set; } = 5;
    public static GraphicsDeviceManager GraphicsDeviceManager { get; set; }
    public static float Zoom = 1.0f;
    public static Vector2 ScreenToWorldSpace(Vector2 point)
    {
        Matrix invertedMatrix = Matrix.Invert(Transform);
        return Vector2.Transform(point, invertedMatrix);
    }

    public static void Update()
    {
        KeyboardState key = Keyboard.GetState();
        //move cam left

        if (key.IsKeyDown(Keys.Up))
        {
            Zoom+=0.05f;
            Transform = Matrix.CreateTranslation(Position) * Matrix.CreateScale(new Vector3(Zoom, Zoom, 1));
        }
        if (key.IsKeyDown(Keys.Down))
        {
            Zoom -= 0.05f;
            Transform = Matrix.CreateTranslation(Position) * Matrix.CreateScale(new Vector3(Zoom, Zoom, 1));
        }

        if (Colony_Sim.Input.GetMousePosition().X <= 0)
        {
            Position += new Vector3(Speed, 0, 0);
            Transform = Matrix.CreateTranslation(Position) * Matrix.CreateScale(new Vector3(Zoom, Zoom, 1));
        }

        if (Colony_Sim.Input.GetMousePosition().X >= GraphicsDeviceManager.PreferredBackBufferWidth)
        {
            Position -= new Vector3(Speed, 0, 0);
            Transform = Matrix.CreateTranslation(Position) * Matrix.CreateScale(new Vector3(Zoom, Zoom, 1));
        }
        if (Colony_Sim.Input.GetMousePosition().Y <= 0)
        {
            Position += new Vector3(0, Speed, 0);
            Transform = Matrix.CreateTranslation(Position) * Matrix.CreateScale(new Vector3(Zoom, Zoom, 1));
        }

        if (Colony_Sim.Input.GetMousePosition().Y >= GraphicsDeviceManager.PreferredBackBufferHeight)
        {
            Position -= new Vector3(0, Speed, 0);
            Transform = Matrix.CreateTranslation(Position) * Matrix.CreateScale(new Vector3(Zoom, Zoom, 1));
        }
    }

}
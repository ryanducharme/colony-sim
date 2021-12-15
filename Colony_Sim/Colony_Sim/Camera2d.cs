using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;

public class Camera2d
{
    protected float _zoom; // Camera Zoom
    public Matrix Transform { get; set; } // Matrix Transform
    public Vector3 Position { get; set; } // Camera Position
    public int Speed { get; set; } = 5;
    //protected float _rotation; // Camera Rotation
    private GraphicsDeviceManager _graphics;
    private Matrix inverse;
    public Camera2d(GraphicsDeviceManager g)
    {
        _graphics = g;
    }
    public Vector2 ScreenToWorldSpace(in Vector2 point)
    {
        Matrix invertedMatrix = Matrix.Invert(Transform);
        return Vector2.Transform(point, invertedMatrix);
    }
    public void Update()
    {
        KeyboardState key = Keyboard.GetState();
        //move cam left
        
        if(Colony_Sim.MouseInputManager.GetMousePosition().X <= 0)
        {
            Position -= new Vector3(Speed, 0, 0);
            Transform = Matrix.CreateTranslation(Position);
        }

        if (Colony_Sim.MouseInputManager.GetMousePosition().X >= _graphics.PreferredBackBufferWidth)
        {
            Position += new Vector3(Speed, 0, 0);
            Transform = Matrix.CreateTranslation(Position);
        }
        if (Colony_Sim.MouseInputManager.GetMousePosition().Y <= 0)
        {
            Position -= new Vector3(0, Speed, 0);
            Transform = Matrix.CreateTranslation(Position);
        }

        if (Colony_Sim.MouseInputManager.GetMousePosition().Y >= _graphics.PreferredBackBufferHeight)
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
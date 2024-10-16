using MathLibrary;
using Raylib_cs;

namespace Sandbox
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Raylib.InitWindow(800, 480, "MY COOL MATH :3");
            
            Vector2 screenDimensions = new Vector2(Raylib.GetScreenWidth(), Raylib.GetScreenHeight());
            float groundY = screenDimensions.y * 0.75f;
            float speed = 50;
            float circleRadius = 10;
            Vector2 circlePositon = new Vector2();
            Vector2 circleVelocity = new Vector2(1, 1) * speed;

            while (!Raylib.WindowShouldClose())
            {
                // update variables
                circlePositon += circleVelocity * Raylib.GetFrameTime();

                if (circlePositon.y >= groundY - circleRadius)
                {
                    Vector2 collisionPlane = new Vector2(1, 0);
                    Vector2 collisionNormal = new Vector2(collisionPlane.y, collisionPlane.x);

                    // Velocity . collisionPlane + my swag
                }

                // draw stuff
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.White);

                // ground
                Raylib.DrawLineV(new Vector2(0, groundY), new Vector2(screenDimensions.x, groundY), Color.Black);

                // circle
                Raylib.DrawCircleV(circlePositon, circleRadius, Color.Red);
                Raylib.EndDrawing();
            }

            Raylib.CloseWindow();
        }

        
    }
}

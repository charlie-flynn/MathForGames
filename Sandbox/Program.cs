using MathLibrary;
using Raylib_cs;

namespace Sandbox
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Raylib.InitWindow(800, 800, "MY COOL MATH :3");
            
            Vector2 screenDimensions = new Vector2(Raylib.GetScreenWidth(), Raylib.GetScreenHeight());

            // player
            Vector2 playerPosition = new Vector2(screenDimensions.x * 0.5f, screenDimensions.y * 0.75f);
            Vector2 playerForward = new Vector2(0, 1).Normalized;
            float playerRadius = 20;
            float playerViewAngle = 90;
            float playerViewDistance = 300;
            float playerSpeed = 80;

            // EVIL
            Vector2 enemyPosition = new Vector2(screenDimensions.x * 0.5f, screenDimensions.y * 0.40f);
            float enemyRadius = 30;
            Color enemyColor = Color.Red;

            // buncha test stuff
            Actor testActor = new Actor();
            Actor coolerTestActor = new Actor();
            Transform2D testform = new Transform2D(null);
            Transform2D otherTestform = new Transform2D(testActor);
            Transform2D otherOtherTestform = new Transform2D(coolerTestActor);

            otherTestform.Translate(1, 400);

            testform.AddChild(otherTestform);
            testform.AddChild(otherOtherTestform);

            testform.WriteChildren();
            Console.WriteLine();

            testform.RemoveChild(otherTestform);

            testform.WriteChildren();


            while (!Raylib.WindowShouldClose())
            {
                // UPDATE

                //moved ment
                Vector2 movementInput = new Vector2
                    (Raylib.IsKeyDown(KeyboardKey.D) - Raylib.IsKeyDown(KeyboardKey.A), 
                    Raylib.IsKeyDown(KeyboardKey.S) - Raylib.IsKeyDown(KeyboardKey.W)).Normalized;

                playerPosition += movementInput * playerSpeed * Raylib.GetFrameTime();

                // calculate line of sight
                float distance = enemyPosition.Distance(playerPosition);
                Vector2 playerToEnemyDirection = (playerPosition - enemyPosition).Normalized;
                float angleToEnemy = (float)Math.Abs(playerToEnemyDirection.Angle(playerForward));

                // if enemy is in line of sight
                if (angleToEnemy < (playerViewAngle / 2) * (Math.PI / 180) && distance <= playerViewDistance)
                {
                    enemyColor = Color.Purple;
                }
                else
                {
                    enemyColor = Color.Red;
                }

                // DRAW
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.White);

                // draw enemy
                Raylib.DrawCircleV(enemyPosition, enemyRadius, enemyColor);

                // draw player
                Raylib.DrawCircleV(playerPosition, playerRadius, Color.Green);

                // draw player forward
                Raylib.DrawLineV(playerPosition, playerPosition - (playerForward * 100), Color.Orange);

                Raylib.DrawCircleSectorLines(playerPosition, playerViewDistance, (-90 - (playerViewAngle / 2)), - 90 + (playerViewAngle / 2), 10, Color.Orange);

                Raylib.EndDrawing();
            }

            Raylib.CloseWindow();
        }

        
    }
}

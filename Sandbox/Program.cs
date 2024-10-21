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
            Vector3 testVector = new Vector3(20, 5, 77);
            Vector3 otherTestVector = new Vector3(1, 426, 0);
            Matrix3 testMatrix3 = new Matrix3(
                1, 32, 5,
                20, 0, 7,
                1, 1, 1);

            Matrix3 otherTestMatrix3 = new Matrix3(
                5, 2, 4,
                6, 1, 23,
                2, 7, 2);

            testMatrix3 *= otherTestMatrix3;

            Console.WriteLine();

            Console.WriteLine(testMatrix3.ToString());

            Console.WriteLine();

            Matrix4 testMatrix4 = new Matrix4(
                1, 32, 5, 2,
                20, 0, 7, 4,
                1, 1, 1, 8,
                250, 32, 64, 1);

            Matrix4 otherTestMatrix4 = new Matrix4(
                5, 2, 4, 88,
                6, 1, 23, 2,
                2, 7, 2, 40,
                1, 1, 1, 1);

            testMatrix4 *= otherTestMatrix4;

            Console.WriteLine(testMatrix4.ToString());

            Console.WriteLine();

            Console.WriteLine(testVector.CrossProduct(otherTestVector).ToString());

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

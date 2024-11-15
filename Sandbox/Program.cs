using MathLibrary;
using Raylib_cs;

namespace Sandbox
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Actor a = new Actor();

            Raylib.InitWindow(800, 480, "world");
            Raylib.SetTargetFPS(60);

            Transform2D t1 = new Transform2D(a);
            t1.LocalScale = new Vector2(100, 100);
            t1.LocalPosition = new Vector2
                ((Raylib.GetScreenWidth() / 2) - (t1.LocalScale.x / 2), 
                (Raylib.GetScreenHeight() / 2) - (t1.LocalScale.y / 2));



            float moveSpeed = 200.0f;
            float rotateSpeed = 5.0f;

            Transform2D t2 = new Transform2D(a);
            t2.LocalScale = new Vector2(0.5f, 0.5f);
            t2.LocalPosition = new Vector2(-2, -0.25f);

            t1.AddChild(t2);

            while (!Raylib.WindowShouldClose())
            {

                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.White);

                // movement roating and scale
                if (Raylib.IsKeyDown(KeyboardKey.W) || Raylib.IsKeyDown(KeyboardKey.S))
                {
                t1.Translate(t1.Forward * (Raylib.IsKeyDown(KeyboardKey.W) - Raylib.IsKeyDown(KeyboardKey.S)) * moveSpeed * Raylib.GetFrameTime());
                }
                if (Raylib.IsKeyDown(KeyboardKey.A) || Raylib.IsKeyDown(KeyboardKey.D))
                {
                    t1.Rotate((Raylib.IsKeyDown(KeyboardKey.D) - (Raylib.IsKeyDown(KeyboardKey.A) * 2)) * rotateSpeed * Raylib.GetFrameTime());
                }
                if (Raylib.IsKeyDown(KeyboardKey.Up) || Raylib.IsKeyDown(KeyboardKey.Down))
                {
                    t1.LocalScale += new Vector2(Raylib.IsKeyDown(KeyboardKey.Up) - Raylib.IsKeyDown(KeyboardKey.Down),
                        Raylib.IsKeyDown(KeyboardKey.Up) - Raylib.IsKeyDown(KeyboardKey.Down));
                }

                // draw rectangles
                Vector2 offset = new Vector2(t1.LocalScale.x / 2, t1.LocalScale.y / 2);
                Vector2 offset2 = new Vector2(t2.LocalScale.x / 2, t2.LocalScale.y / 2);
                Rectangle rect = new Rectangle(t1.GlobalPosition + offset, t1.GlobalScale);
                Rectangle rect2 = new Rectangle(t2.GlobalPosition + offset, t2.GlobalScale);

                Raylib.DrawRectanglePro(rect, new Vector2(0, 0) + offset, -t1.GlobalRotationAngle * (180 / (float)Math.PI), Color.Pink);
                Raylib.DrawRectanglePro(rect2, new Vector2(0, 0) + offset2, -t2.GlobalRotationAngle * (180 / (float)Math.PI), Color.SkyBlue);
                Raylib.DrawLineV(t1.GlobalPosition + offset, t1.GlobalPosition + offset + (t1.Forward * t1.GlobalScale.x), Color.SkyBlue);

                // draw the matrices because i must know what's wrong (nothing is wrong :thumbsup:)
                Raylib.DrawText(t1.GlobalMatrixToString(), 10, 20, 22, Color.Blue);
                Raylib.DrawText(t2.GlobalMatrixToString(), 10, 80, 22, Color.Red);
                Raylib.DrawText(t1.LocalMatrixToString(), 10, 160, 22, Color.Blue);
                Raylib.DrawText(t2.LocalMatrixToString(), 10, 240, 22, Color.Red);

                Raylib.EndDrawing();
            }



            #region OLD CODE
            //Raylib.InitWindow(800, 800, "MY COOL MATH :3");
            
            //Vector2 screenDimensions = new Vector2(Raylib.GetScreenWidth(), Raylib.GetScreenHeight());

            //// player
            //Vector2 playerPosition = new Vector2(screenDimensions.x * 0.5f, screenDimensions.y * 0.75f);
            //Vector2 playerForward = new Vector2(0, 1).Normalized;
            //float playerRadius = 20;
            //float playerViewAngle = 90;
            //float playerViewDistance = 300;
            //float playerSpeed = 80;

            //// EVIL
            //Vector2 enemyPosition = new Vector2(screenDimensions.x * 0.5f, screenDimensions.y * 0.40f);
            //float enemyRadius = 30;
            //Color enemyColor = Color.Red;




            //while (!raylib.windowshouldclose())
            //{
            //    // update

            //    //moved ment
            //    vector2 movementinput = new vector2
            //        (raylib.iskeydown(keyboardkey.d) - raylib.iskeydown(keyboardkey.a), 
            //        raylib.iskeydown(keyboardkey.s) - raylib.iskeydown(keyboardkey.w)).normalized;

            //    playerposition += movementinput * playerspeed * raylib.getframetime();

            //    // calculate line of sight
            //    float distance = enemyposition.distance(playerposition);
            //    vector2 playertoenemydirection = (playerposition - enemyposition).normalized;
            //    float angletoenemy = (float)math.abs(playertoenemydirection.angle(playerforward));

            //    // if enemy is in line of sight
            //    if (angletoenemy < (playerviewangle / 2) * (math.pi / 180) && distance <= playerviewdistance)
            //    {
            //        enemycolor = color.purple;
            //    }
            //    else
            //    {
            //        enemycolor = color.red;
            //    }

            //    // draw
            //    raylib.begindrawing();
            //    raylib.clearbackground(color.white);

            //    // draw enemy
            //    raylib.drawcirclev(enemyposition, enemyradius, enemycolor);

            //    // draw player
            //    raylib.drawcirclev(playerposition, playerradius, color.green);

            //    // draw player forward
            //    raylib.drawlinev(playerposition, playerposition - (playerforward * 100), color.orange);

            //    raylib.drawcirclesectorlines(playerposition, playerviewdistance, (-90 - (playerviewangle / 2)), - 90 + (playerviewangle / 2), 10, color.orange);

            //    raylib.enddrawing();
            //}

            //raylib.closewindow();
            #endregion
        }


    }
}

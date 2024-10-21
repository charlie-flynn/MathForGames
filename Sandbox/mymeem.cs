using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathLibrary;

namespace Sandbox
{
    internal class mymeem
    {
        Font comicSans = Raylib.LoadFont("comic.ttf");
        Font brushCursive = Raylib.LoadFont("BRUSHSCI.TTF");
        bool isSansPutDown = false;
        // before the player presses enter, display the first frame. otherwise, display the second frame
                if (!isSansPutDown)
                {
                    // print sans undertale saying the folowin text
                    Raylib.ClearBackground(Color.White);
                    DrawSansUndertale(0, 0);
        Raylib.DrawTextEx(comicSans, "frisk theyre going to put me down. theyre going to put me down like a sick dog. frisk pleas", new Vector2(150, 10), 20, 1, Color.Black);
                }
                else
                {
                    // print sans funeral ):
                    Raylib.SetWindowTitle("Sans got put down");
                    Raylib.ClearBackground(Color.Black);
                    Raylib.DrawRectangle(330, 200, 190, 200, Color.White);
                    Raylib.DrawTextEx(brushCursive, "R.I.P. Sans Undertale", new Vector2(320, 150), 30, 1, Color.White);
                    Raylib.DrawTextEx(brushCursive, "''frisk they put me down''", new Vector2(320, 430), 30, 1, Color.White);
                    DrawSansUndertale(180, 180);


// put down sans when you press the enter key
if (Raylib.IsKeyPressed(KeyboardKey.Enter))
{
    isSansPutDown = true;
        
Raylib.EndDrawing();

            Raylib.CloseWindow();

void DrawSansUndertale(int xOffset, int yOffset)
{
    // positions for most of the pixels
    Vector2[] vectors = new Vector2[]
    {
                    new Vector2(200, 50),
                    new Vector2(210, 50),
                    new Vector2(220, 50),
                    new Vector2(230, 50),
                    new Vector2(240, 50),
                    new Vector2(250, 50),
                    new Vector2(260, 50),
                    new Vector2(270, 50),
                    new Vector2(280, 50),
                    new Vector2(290, 60),
                    new Vector2(300, 60),
                    new Vector2(190, 60),
                    new Vector2(180, 60),
                    new Vector2(170, 70),
                    new Vector2(170, 80),
                    new Vector2(310, 70),
                    new Vector2(310, 80),
                    new Vector2(320, 90),
                    new Vector2(320, 100),
                    new Vector2(320, 110),
                    new Vector2(320, 120),
                    new Vector2(160, 90),
                    new Vector2(160, 100),
                    new Vector2(160, 110),
                    new Vector2(160, 120),
                    new Vector2(170, 130),
                    new Vector2(160, 140),
                    new Vector2(310, 130),
                    new Vector2(310, 140),
                    new Vector2(320, 140),
                    new Vector2(170, 140),
                    new Vector2(160, 150),
                    new Vector2(160, 160),
                    new Vector2(320, 150),
                    new Vector2(320, 160),
                    new Vector2(170, 170),
                    new Vector2(180, 170),
                    new Vector2(310, 170),
                    new Vector2(300, 170),
                    new Vector2(190, 180),
                    new Vector2(200, 180),
                    new Vector2(290, 180),
                    new Vector2(280, 180),
                    new Vector2(210, 190),
                    new Vector2(220, 190),
                    new Vector2(230, 190),
                    new Vector2(240, 190),
                    new Vector2(250, 190),
                    new Vector2(260, 190),
                    new Vector2(270, 190),
    };

    for (int i = 0; i < vectors.Length; i++)
    {
        vectors[i] += new Vector2(xOffset, yOffset);
    }
    // place the pixels where i want them to be
    foreach (Vector2 vector in vectors)
    {
        Raylib.DrawRectangleV(vector, new Vector2(10, 10), Color.Black);
    }
    // draw the eyes
    Raylib.DrawRectangle(190 + xOffset, 90 + yOffset, 30, 30, Color.Black);
    Raylib.DrawRectangle(270 + xOffset, 90 + yOffset, 30, 30, Color.Black);

    // draw the nose
    Raylib.DrawRectangle(230 + xOffset, 130 + yOffset, 30, 10, Color.Black);
    Raylib.DrawRectangle(240 + xOffset, 120 + yOffset, 10, 10, Color.Black);

    // draw the mouth
    Raylib.DrawRectangle(210 + xOffset, 170 + yOffset, 70, 10, Color.Black);
    Raylib.DrawRectangle(190 + xOffset, 150 + yOffset, 110, 10, Color.Black);
    Raylib.DrawRectangle(200 + xOffset, 160 + yOffset, 10, 10, Color.Black);
    Raylib.DrawRectangle(220 + xOffset, 160 + yOffset, 10, 10, Color.Black);
    Raylib.DrawRectangle(240 + xOffset, 160 + yOffset, 10, 10, Color.Black);
    Raylib.DrawRectangle(260 + xOffset, 160 + yOffset, 10, 10, Color.Black);
    Raylib.DrawRectangle(280 + xOffset, 160 + yOffset, 10, 10, Color.Black);
    Raylib.DrawRectangle(190 + xOffset, 140 + yOffset, 10, 10, Color.Black);
    Raylib.DrawRectangle(290 + xOffset, 140 + yOffset, 10, 10, Color.Black);

    return;
}
}
}

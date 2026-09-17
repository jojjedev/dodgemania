using System.Drawing;
using SFML.System;
using SFML.Graphics;
using SFML.Window;
using Color = SFML.Graphics.Color;

namespace smflTest;

public class Player
{
    public Sprite sprite;
    public static Vector2f size;
    public const float Length = 100.0f;
    public static Vector2f Direction = new Vector2f(1, 0);
    public static float Speed = 3.0f;
    public Vector2f Velocity;

    public Player()
    {
        sprite = new Sprite();
        sprite.Texture = new Texture("assets/idledefault.png");
        sprite.Position = new Vector2f(Program.ScreenW / 2, Program.ScreenH / 2);
        Vector2f playerTextureSize = (Vector2f)sprite.Texture.Size;
        sprite.Origin = 0.5f * playerTextureSize;       // Måste flytta origin direkt efter man sätter storleken på original texturen.
        sprite.Scale = new Vector2f(                    // Resizar bilden till önskad storlek.
           Length / playerTextureSize.Y,
           Length / playerTextureSize.Y);
        size = new Vector2f(                            // Gör en vector "size" för den önksade spriten som har dess faktiska x och y längd
            sprite.GetGlobalBounds().Width,
            sprite.GetGlobalBounds().Height);
        
        
        
        

    }

    private void DebugDraw(RenderTarget target)
    {
        Shape rectangle2;
        rectangle2 = new RectangleShape(size);
        rectangle2.Position = sprite.Position;
        rectangle2.Origin = size / 2;
        rectangle2.OutlineColor = Color.Green;
        rectangle2.OutlineThickness = 2;
        rectangle2.FillColor = Color.Transparent;
        target.Draw(rectangle2);
        
    }
    public void Draw(RenderTarget target)
    {
        DebugDraw(target);
        target.Draw(sprite);
    }
}
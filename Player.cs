using System.Drawing;
using SFML.System;
using SFML.Graphics;
using SFML.Window;
using Color = SFML.Graphics.Color;

namespace smflTest;

public class Player
{
    public Sprite sprite;
    public Shape rectangle2;
    public static Vector2f Resized;
    public static Vector2f ResizedOrigin;
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
        Resized = new Vector2f(                            // Gör en vector "size" för den önksade spriten som har dess faktiska x och y längd
            sprite.GetGlobalBounds().Width,
            sprite.GetGlobalBounds().Height);
        ResizedOrigin = 0.5f * Resized;
        
        
        rectangle2 = new RectangleShape(Resized);
        rectangle2.Position = sprite.Position;
        rectangle2.Origin = ResizedOrigin;
        rectangle2.OutlineColor = Color.Green;
        rectangle2.OutlineThickness = 1;
        rectangle2.FillColor = Color.Transparent;
        
    }

    public void Draw(RenderTarget target)
    {
        target.Draw(sprite);
        target.Draw(rectangle2);
    }
}
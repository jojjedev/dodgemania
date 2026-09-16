using System.Drawing;
using SFML.System;
using SFML.Graphics;
using SFML.Window;

namespace smflTest;

public class Player
{
    public Sprite sprite;
    public Vector2f size;
    public const float Length = 16.0f;
    public static Vector2f Direction = new Vector2f(1, 0);
    public static float Speed = 2.5f;
    public Vector2f Velocity = Direction * Speed;
    public Vector2f playerTextureSize;

    public Player()
    {
        sprite = new Sprite();
        sprite.Texture = new Texture("assets/01_Idle/idledefault.png");
        sprite.Position = new Vector2f(Program.ScreenW / 2, Program.ScreenH / 2);
        Vector2f playerTextureSize = (Vector2f)sprite.Texture.Size;
        size = new Vector2f(
            sprite.GetGlobalBounds().Width * 0.35f,
            sprite.GetGlobalBounds().Height * 0.35f);
        sprite.Scale = new Vector2f(
            size.X / playerTextureSize.Y,
            size.X / playerTextureSize.Y);
        sprite.Origin = 0.5f * size;
        
    }

    public void Draw(RenderTarget target)
    {
        target.Draw(sprite);
    }
}
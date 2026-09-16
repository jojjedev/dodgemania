using SFML.System;
using SFML.Graphics;
using SFML.Window;

namespace smflTest;

public class Player
{
    public Sprite sprite;
    public Vector2f size;
    public static Vector2f Direction = new Vector2f(1, 0);
    public static float Speed = 2.5f;
    public Vector2f Velocity = Direction * Speed;
    public Vector2f playerTextureSize;

    public Player()
    {
        sprite = new Sprite();
        sprite.Texture = new Texture("assets/01_Idle/idle0.png");
        sprite.Position = new Vector2f(Program.ScreenW / 2, Program.ScreenH / 2);
        size = new Vector2f(
            sprite.GetGlobalBounds().Width * 0.25f,
            sprite.GetGlobalBounds().Height * 0.25f);
        Vector2f playerTextureSize = (Vector2f)sprite.Texture.Size;
        sprite.Origin = 0.5f * playerTextureSize;
        sprite.Scale = new Vector2f(
            size.X / playerTextureSize.Y,
            size.Y / playerTextureSize.Y);
    }

    public void Draw(RenderTarget target)
    {
        target.Draw(sprite);
    }
}
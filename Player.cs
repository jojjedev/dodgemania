using SFML.System;
using SFML.Graphics;
using SFML.Window;

namespace smflTest;

public class Player
{
    public Sprite sprite;
    public Vector2f size;
    public Vector2f direction = new Vector2f(1, 0);
    public float speed = 3.0f;

    public Player()
    {
        sprite = new Sprite();
        sprite.Texture = new Texture("assets/01_idle/__cat_idle_000.png");
        sprite.Position = new Vector2f(Program.ScreenW / 2, Program.ScreenH / 2);
        size = new Vector2f(
            sprite.GetGlobalBounds().Width,
            sprite.GetGlobalBounds().Height);
        Vector2f playerTextureSize = (Vector2f)sprite.Texture.Size;
        sprite.Origin = 0.5f * playerTextureSize;
        sprite.Scale = new Vector2f(
            size.X / playerTextureSize.Y,
            size.Y / playerTextureSize.Y);
    }

    public void Update(float dt)
    {
        var newPos = sprite.Position;
        newPos += direction * speed * dt * 100.0f;
        sprite.Position = newPos;
    }

    public void Draw(RenderTarget target)
    {
        target.Draw(sprite);
    }
}
using SFML.Graphics;
using SFML.System;

namespace smflTest;

public class Projectile
{
    public Sprite sprite;
    public const float Diameter = 20.0f;
    public const float Radius = Diameter * 0.5f;
    public Vector2f Position;
    public Vector2f direction = new Vector2f(1, 1) / MathF.Sqrt(2.0f);
    public int Score;
    public int Health = 3;
    public Text gui;

    public Projectile()
    {
        sprite = new Sprite();
        sprite.Texture = new Texture("assets/blueBullet.png");
        sprite.Position = new Vector2f()
    }
}
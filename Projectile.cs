using SFML.Graphics;
using SFML.System;

namespace smflTest;

public class Projectile
{
    public Sprite sprite;
    public const float Diameter = 100.0f;
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
        sprite.Position = new Vector2f(Program.ScreenH / 2, Program.ScreenW / 2);
        Vector2f projectileTextureSize = (Vector2f)sprite.Texture.Size;
        sprite.Origin = 0.5f * projectileTextureSize;
        sprite.Scale = new Vector2f(
            Diameter / projectileTextureSize.Y,
            Diameter / projectileTextureSize.Y);
        gui = new Text();
        gui.CharacterSize = 30;
        gui.Font = new Font("assets/vcr.ttf");
        gui.FillColor = new Color(168, 3, 3);

    }

    public void Draw(RenderTarget target)
    {
        // Draws projectile
        target.Draw(sprite);
        
        // Draws "Health" text
        gui.DisplayedString =  $"Health: {Health}";
        gui.Position = new Vector2f(12, 8);
        target.Draw(gui);
        
        // Draws "Score" text
        gui.DisplayedString = $"Score: {Score}";
        gui.Position = new Vector2f(Program.ScreenW - gui.GetGlobalBounds().Width - 12, 8);
        target.Draw(gui);
        
    }

    public void Update(float dt)
    {
        var newPos = sprite.Position;
        newPos = direction * dt * 100.0f;
        sprite.Position = newPos;

    }

    public static Vector2f RandomPosition()
    {
        Random random = new Random();
        int side = random.Next(1, 5);
        int pos;
        Vector2f spawn = new Vector2f();
        switch (side)
        {
            case 1: // Left side
                pos = random.Next(0, Program.ScreenW);
                spawn = new Vector2f(0, pos);
                break;
            case 3: // Right side
                pos = random.Next(0, Program.ScreenW);
                spawn = new Vector2f(Program.ScreenW, pos);
                break;
                
            case 2: // Top side
                pos = random.Next(0, Program.ScreenH);
                spawn = new Vector2f(pos, 0);
                break;
                
            case 4: // Bottom side
                pos = random.Next(0, Program.ScreenH);
                spawn = new Vector2f(pos, Program.ScreenH);
                break;
        }

        return spawn;

    }
}
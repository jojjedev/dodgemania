using SFML.Graphics;
using SFML.System;

namespace smflTest;
//TODO: Just nu spawnar projectilerna på random ställen men riktningen är inte anpassad efter spawnställe.
public class Projectile
{
    public Sprite sprite;
    public const float Diameter = 100.0f;
    public const float Radius = Diameter * 0.5f;
    public Vector2f Position;
    public Vector2f direction = new Vector2f(MathF.Cos(45), MathF.Sin(45)) / MathF.Sqrt(2.0f); 
    public float rotation;
    public int Score;
    public int Health = 3;
    public Text gui;

    public Projectile()
    {
        sprite = new Sprite();
        sprite.Texture = new Texture("assets/blueBullet.png");
        sprite.Position = SpawnPosition();
        Vector2f projectileTextureSize = (Vector2f)sprite.Texture.Size;
        sprite.Origin = 0.5f * projectileTextureSize;
        sprite.Scale = new Vector2f(
            Diameter / projectileTextureSize.Y,
            Diameter / projectileTextureSize.Y);
        sprite.Rotation = 45;
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
        newPos += direction * dt * 100.0f;
        sprite.Position = newPos;
    }

    public static Vector2f SpawnPosition()
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

    public static Vector2f SpawnDirection(Vector2f position)
    {

        switch (position.X)
        {
            case 0:
                switch (position.Y)
                {
                    case <= Program.ScreenH / 2:
                        return RandomDirection(0, 60);
                    case > Program.ScreenH / 2:
                        return RandomDirection(-60, 0);
                }

                break;
            case Program.ScreenW:
                switch (position.Y)
                {
                    case <= Program.ScreenH / 2:
                        return RandomDirection(120, 180);
                        
                    case > Program.ScreenH / 2:
                        return RandomDirection(180, 240);
                }
                break;
        }
        switch (position.Y)
        {
            case 0:
                switch (position.X)
                {
                    case <= Program.ScreenW / 2:
                        return RandomDirection(30, 90);
                    case > Program.ScreenW / 2 :
                        return RandomDirection(90, 150);
                }
                break;
            case Program.ScreenW:
                switch (position.X)
                {
                    case <= Program.ScreenW / 2:
                        return RandomDirection(270, 330);
                    
                    case > Program.ScreenW / 2:
                        return RandomDirection(210, 270);
                }
                break;
        }
        return new Vector2f(0, 0);
    }
    public static Vector2f RandomDirection(int lowerDegree, int higherDegree)
    {
        Random random = new Random();
        int degree = random.Next(lowerDegree, higherDegree);
         return new Vector2f(MathF.Cos(degree), MathF.Sin(degree)) / MathF.Sqrt(2.0f);
    }
}
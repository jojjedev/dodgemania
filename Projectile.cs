using SFML.Graphics;
using SFML.System;

namespace smflTest;
public class Projectile
{
    public Sprite sprite;
    public Vector2f size;
    public Vector2f direction;
    public Vector2f velocity;
    public const float spawnRate = 0.8f;
    public float spawnTimer = 0.0f;

    public Projectile(float speed)
    {
        sprite = new Sprite();
        sprite.Texture = new Texture("assets/blueBullet.png");
        sprite.Position = SpawnPosition();
        sprite.Rotation = SpawnDirection(sprite.Position);
        direction = new Vector2f(MathF.Cos(sprite.Rotation * Single.Pi/180), MathF.Sin(sprite.Rotation * Single.Pi / 180));
        velocity = direction * speed;
        size = new Vector2f(
            sprite.GetGlobalBounds().Width * 0.0625f,
            sprite.GetGlobalBounds().Height * 0.0625f);
        Vector2f projectileTextureSize = (Vector2f)sprite.Texture.Size;
        sprite.Origin = 0.5f * projectileTextureSize;
        sprite.Scale = new Vector2f(
            size.X / projectileTextureSize.Y,
            size.Y / projectileTextureSize.Y);
    }

    public void Update(float dt)
    {
        spawnTimer += dt;
        if (spawnTimer > spawnRate)
        {
            spawnTimer = 0.0f;
        }
        var newPos = sprite.Position;
        newPos += velocity * dt * 100.0f;
        sprite.Position = newPos;
    }
    
    public Vector2f SpawnPosition()
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
                Console.WriteLine("Left side");
                break;
            case 3: // Right side
                pos = random.Next(0, Program.ScreenW);
                spawn = new Vector2f(Program.ScreenW, pos);
                Console.WriteLine("Right side");
                break;
                
            case 2: // Top side
                pos = random.Next(0, Program.ScreenH);
                spawn = new Vector2f(pos, 0);
                Console.WriteLine("Top side");
                break;
                
            case 4: // Bottom side
                pos = random.Next(0, Program.ScreenH);
                spawn = new Vector2f(pos, Program.ScreenH);
                Console.WriteLine("Bottom side");
                break;
        }

        return spawn;

    }
    public static int SpawnDirection(Vector2f position)
    {
        switch (position.X)
        {
            case 0: // Left side
                switch (position.Y)
                {
                    case <= Program.ScreenH / 2: // Lower 
                        return RandomDirection(0, 60);
                    case > Program.ScreenH / 2:  // Upper
                        return RandomDirection(-60, 0);
                }

                break;
            case Program.ScreenW: // Right side
                switch (position.Y)
                {
                    case <= Program.ScreenH / 2: // Lower
                        return RandomDirection(120, 180);
                        
                    case > Program.ScreenH / 2:  // Upper
                        return RandomDirection(180, 240);
                }
                break;
        }
        switch (position.Y)
        {
            case 0: // Upper
                switch (position.X)
                {
                    case <= Program.ScreenW / 2:  // Left
                        return RandomDirection(30, 90);
                        
                    case > Program.ScreenW / 2 :  // Right
                        return RandomDirection(90, 150);
                }
                break;
            case Program.ScreenH:  // Bottom
                switch (position.X)
                {
                    case <= Program.ScreenW / 2:  // Left
                        return RandomDirection(270, 330);
                    
                    case > Program.ScreenW / 2:  // Right
                        return RandomDirection(210, 270);
                        
                }
                break;
        }
        return 0;
    }
    public static int RandomDirection(int lowerDegree, int higherDegree)
    {
        Random random = new Random();
        int degree = random.Next(lowerDegree, higherDegree);
        Console.WriteLine(degree);
        return degree;
    }
}
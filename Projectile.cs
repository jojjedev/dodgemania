using SFML.Graphics;
using SFML.System;
using static smflTest.Constants;

namespace smflTest;
public class Projectile
{
    //private Shape rectangle;
    public Sprite sprite;
    public Vector2f size;
    private const float Length = PROJECTILE_LENGTH;
    private static Vector2f direction;
    private Vector2f velocity;
    public static float spawnRate = SPAWN_RATE_START;
    private float spawnTimer = 0.0f;

    public Projectile(float speed)
    {
        sprite = new Sprite();
        sprite.Texture = new Texture("assets/blueBullet.png");
        sprite.Position = SpawnPosition();
        float rotation = SpawnDirection(sprite.Position);
        direction = new Vector2f(MathF.Cos(rotation * Single.Pi/180), MathF.Sin(rotation * Single.Pi / 180));
        velocity = speed * direction;
        Vector2f projectileTextureSize = (Vector2f)sprite.Texture.Size;         // Projektilens originalstorlek från fil
        sprite.Origin = 0.5f * projectileTextureSize;                           // Sätter referenspunkten i mitten av originalfilen
        sprite.Scale = new Vector2f(                                            // Scalear ner storleken med en faktor. INTE NYA STORLEKEN
            Length / projectileTextureSize.X,
            Length / projectileTextureSize.X);
        size = new Vector2f(                                                 // Nya storleken fås genom GetGlobalBounds.
            sprite.GetGlobalBounds().Width,
            sprite.GetGlobalBounds().Height);
                                                // Sätt nya referenspunkten i mitten av nedscaleade
        sprite.Rotation = rotation;                                             // Rotera spriten utifrån den nya storleken.
                                                                                // Behåller hitboxen.
        
        /*rectangle = new RectangleShape(size);
        rectangle.Position = sprite.Origin;
        rectangle.Rotation = sprite.Rotation;
        rectangle.Origin = sprite.Origin;
        rectangle.OutlineColor = Color.White;
        rectangle.OutlineThickness = 1;
        rectangle.FillColor = Color.Transparent;
        */
    }
    
    private Vector2f SpawnPosition()
    {
        Random random = new Random();
        int side = random.Next(1, 5);
        int pos;
        Vector2f spawn = new Vector2f();
        switch (side)
        {
            case 1: // Left side
                pos = random.Next(0, Program.ScreenW - 50);
                spawn = new Vector2f(0, pos);
                break;
            case 3: // Right side
                pos = random.Next(0, Program.ScreenW - 50);
                spawn = new Vector2f(Program.ScreenW, pos);
                break;
                
            case 2: // Top side
                pos = random.Next(0, Program.ScreenH - 30);
                spawn = new Vector2f(pos, 0);
                break;
                
            case 4: // Bottom side
                pos = random.Next(0, Program.ScreenH - 30);
                spawn = new Vector2f(pos, Program.ScreenH);
                break;
        }

        return spawn;

    }
    private static int SpawnDirection(Vector2f position)
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
    private static int RandomDirection(int lowerDegree, int higherDegree)
    {
        Random random = new Random();
        int degree = random.Next(lowerDegree, higherDegree);
        return degree;
    }
    public void Update(float dt)
    {
        spawnTimer += dt;
        if (spawnTimer > spawnRate) spawnTimer = 0.0f;
        
        var newPos = sprite.Position;
        newPos += velocity * dt * 100.0f;
        sprite.Position = newPos;
        //rectangle.Position = newPos;
    }

    public void Draw(RenderTarget target)
    {
        target.Draw(sprite);
    }
}
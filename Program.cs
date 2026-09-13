using SFML.Graphics;
using SFML.Window;
using SFML.System;

namespace smflTest;

public class Program
{
    public const int ScreenW = 1200;
    public const int ScreenH = 800;
    static void Main(string[] args)
    {
        Projectile projectile = new Projectile();
        
        using (var window = new RenderWindow(
                   new VideoMode(ScreenW, ScreenH), "breakout"))
        {
            window.Closed += (o, e) => window.Close();
            Clock clock = new Clock();
            while (window.IsOpen)
            {
                float dt = clock.Restart().AsSeconds();
                window.DispatchEvents(); // Hanterar alla värdesändringar som har gjorts sedan senaste framen. Ex muspekare flyttats,
                                        // Enemy har dödats eller flyttats på sig etc.
                // TODO: Update screen
                projectile.Update(dt);
                window.Clear(new Color(46, 15, 15));
                // TODO: Draw elements on screen
                projectile.Draw(window);
                window.Display(); // Draw the actual screen with all elements.
            }
        }
    }
}
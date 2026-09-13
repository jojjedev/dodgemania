using SFML.Graphics;
using SFML.Window;
using SFML.System;

namespace smflTest;

public class Program
{
    static void Main(string[] args)
    {
        using (var window = new RenderWindow(
                   new VideoMode(1200, 800), "breakout"))
        {
            window.Closed += (o, e) => window.Close();
            Clock clock = new Clock();
            while (window.IsOpen)
            {
                float dt = clock.Restart().AsSeconds();
                window.DispatchEvents(); // Hanterar alla värdesändringar som har gjorts sedan senaste framen. Ex muspekare flyttats,
                                        // Enemy har dödats eller flyttats på sig etc.
                // TODO: Update screen
                window.Clear(new Color(131, 197, 235));
                // TODO: Draw elements on screen
                window.Display(); // Draw the actual screen with all elements.
            }
        }
    }
}
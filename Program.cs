using SFML.Graphics;
using SFML.Window;
using SFML.System;

namespace smflTest;
//TODO: BLIR NÅGOT KONSTIGT MED HASTIGHETSÖKNINGEN I PROJECTHANDLER
public class Program
{
    public const int ScreenW = 1200;
    public const int ScreenH = 800;
    static void Main(string[] args)
    {
        UI gui = new UI();
        ProjectileHandler projHandler = new ProjectileHandler();
        Player player = new Player();
        PlayerHandler playerHandler = new PlayerHandler();
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
                projHandler.Update(dt, gui);
                playerHandler.Update(player, dt);
                window.Clear(new Color(46, 15, 15));
                gui.Draw(window);
                player.Draw(window);
                projHandler.Draw(window);
                // TODO: Draw elements on screen
                
                window.Display(); // Draw the actual screen with all elements.
            }
        }
    }
}
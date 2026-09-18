using Microsoft.VisualBasic.CompilerServices;
using SFML.Graphics;
using SFML.Window;
using SFML.System;
using static smflTest.Constants;

namespace smflTest;
public class Program
{
    public static bool GameStop;
    public const int ScreenW = SCREEN_WIDTH;
    public const int ScreenH = SCREEN_HEIGHT;
    static void Main(string[] args)
    {
        UI gui = new UI();
        ProjectileHandler projHandler = new ProjectileHandler();
        Player player = new Player();
        PlayerHandler playerHandler = new PlayerHandler();
        
        using (var window = new RenderWindow(
                   new VideoMode(ScreenW, ScreenH), "breakout"))
        {
            window.SetFramerateLimit(144);
            window.Closed += (o, e) => window.Close();
            Clock clock = new Clock();
            while (window.IsOpen)
            {
                float dt = clock.Restart().AsSeconds();
                window.DispatchEvents(); // Hanterar alla värdesändringar som har gjorts sedan senaste framen. Ex muspekare flyttats,
                                        // Enemy har dödats eller flyttats på sig etc.
                if (gui.Health <= 0)
                {
                    GameReset(projHandler, gui);
                }

                if (Keyboard.IsKeyPressed(Keyboard.Key.R))
                {
                    GameEnd(projHandler);
                    Restart(gui);
                }
                projHandler.Update(dt, gui);
                playerHandler.Update(player, dt, gui);
                
                window.Clear(new Color(46, 15, 15));
                
                player.Draw(window);
                projHandler.Draw(window);
                gui.Draw(window);
                window.Display(); // Draw the actual screen with all elements.
            }
        }
    }

    private static void GameReset(ProjectileHandler projectileHandler, UI gui)
    {
        GameEnd(projectileHandler);
        if (Keyboard.IsKeyPressed(Keyboard.Key.Enter)) Restart(gui);
    }

    private static void Restart(UI gui)
    {
        gui.Health = START_HEALTH;
        gui.Score = 0;
        GameStop = false;
        PlayerHandler.Timer = 0;
    }

    private static void GameEnd(ProjectileHandler projectileHandler)
    {
        Projectile.spawnRate = SPAWN_RATE_START;
        ProjectileHandler.ListOfProj.Clear();
        projectileHandler.ProjSpeedModifier = PROJECTILE_SPEED_MODIFIER_START;
        PlayerHandler.SpeedModifier = 0;
        GameStop = true;
    }
    
}
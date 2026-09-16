using System.Net.Security;
using SFML.System;
using SFML.Graphics;
using SFML.Window;


namespace smflTest;

public class PlayerHandler
{
    public float Timer;
    public string[] idleAnimation =
    {
        "assets/01_Idle/idle0.png",
        "assets/01_Idle/idle1.png",
        "assets/01_Idle/idle2.png",
        "assets/01_Idle/idle3.png",
        "assets/01_Idle/idle4.png",
        "assets/01_Idle/idle5.png",
        "assets/01_Idle/idle6.png",
        "assets/01_Idle/idle7.png",
        "assets/01_Idle/idle8.png",
        "assets/01_Idle/idle9.png",
        "assets/01_Idle/idle10.png",
        "assets/01_Idle/idle11.png"
    };
    public string[] runAnimation =
    {
        "assets/02_Run/run0.png",
        "assets/02_Run/run1.png",
        "assets/02_Run/run2.png",
        "assets/02_Run/run3.png",
        "assets/02_Run/run4.png",
        "assets/02_Run/run5.png",
        "assets/02_Run/run6.png",
        "assets/02_Run/run7.png",
        "assets/02_Run/run8.png",
        "assets/02_Run/run9.png",
        "assets/02_Run/run10.png"
    };
    public string[] deadAnimation =
    {
        "assets/05_Dead/dead0.png",
        "assets/05_Dead/dead1.png",
        "assets/05_Dead/dead2.png",
        "assets/05_Dead/dead3.png",
        "assets/05_Dead/dead4.png",
        "assets/05_Dead/dead5.png",
        "assets/05_Dead/dead6.png",
        "assets/05_Dead/dead7.png",
        "assets/05_Dead/dead8.png",
        "assets/05_Dead/dead9.png",
        "assets/05_Dead/dead10.png"
    };

    public void MovePlayer(Player player, float dt)
    {
        if (Keyboard.IsKeyPressed(Keyboard.Key.A))
        {
            ChangeDirection(player,dt, -1, 0);
        }
        else if (Keyboard.IsKeyPressed(Keyboard.Key.D))
        {
            ChangeDirection(player,dt, 1, 0);
        }
        else if (Keyboard.IsKeyPressed(Keyboard.Key.W))
        {
            ChangeDirection(player,dt, 0, -1);
        }
        else if (Keyboard.IsKeyPressed(Keyboard.Key.S))
        {
            ChangeDirection(player,dt, 0, 1);
        }
        else if (Keyboard.IsKeyPressed(Keyboard.Key.A) && Keyboard.IsKeyPressed(Keyboard.Key.W))
        {
            ChangeDirection(player,dt, -1, -1);
        }
        else if (Keyboard.IsKeyPressed(Keyboard.Key.A) && Keyboard.IsKeyPressed(Keyboard.Key.S))
        {
            ChangeDirection(player,dt, -1, 1);
        }
        else if (Keyboard.IsKeyPressed(Keyboard.Key.D) && Keyboard.IsKeyPressed(Keyboard.Key.W))
        {
            ChangeDirection(player, dt, 1,-1);
        }
        else if (Keyboard.IsKeyPressed(Keyboard.Key.D) && Keyboard.IsKeyPressed(Keyboard.Key.S))
        {
            ChangeDirection(player, dt, 1,1);
        }
    }

    public void ChangeDirection(Player player, float dt, float x, float y)
    {
        Player.Direction = new Vector2f(x, y);
        var newPos = player.sprite.Position;
        newPos += player.Velocity * dt * 100.0f;
        player.sprite.Position = newPos;
    }

    public void Update(Player player, float dt)
    {
        MovePlayer(player, dt);
    }
}
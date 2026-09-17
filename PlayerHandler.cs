using System.Net.Security;
using SFML.System;
using SFML.Graphics;
using SFML.Window;


namespace smflTest;

public class PlayerHandler
{
    public float Timer;

    public float SpeedModifier = 0;
    /*public string[] idleAnimation =
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

    public static float[] runTiming = new float[] {
        2 / 11,
        4 / 11,
        6 / 11,
        8 / 11,
        10 / 11,
        12 / 11,
        14 / 11,
        16 / 11,
        18 / 11,
        20 / 11
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
        "assets/05_Dead/dead7.png"
    };
*/
    public void MovePlayer(Player player, float dt)
    {
        Vector2f oldPos = player.sprite.Position;
        if (Keyboard.IsKeyPressed(Keyboard.Key.A) && Keyboard.IsKeyPressed(Keyboard.Key.W))
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
        else if (Keyboard.IsKeyPressed(Keyboard.Key.A))
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

        if (IsPlayerOutofBounds(player, dt))
        {
            player.sprite.Position = oldPos;
        }
        
    }
    public void ChangeDirection(Player player, float dt, float x, float y)
    {
        
        var newPos = player.sprite.Position;
        player.Velocity = new Vector2f(x, y) * (Player.Speed + SpeedModifier);
        switch (x)
        {
            case 1:
                switch (y)
                {
                    case 1:
                        player.Velocity /= MathF.Sqrt(2.0f);
                        break;
                    case -1 :
                        player.Velocity /= MathF.Sqrt(2.0f);
                        break;
                    default:
                        player.Velocity = player.Velocity;
                        break;
                }
                break;
            case -1 :
                switch (y)
                {
                    case 1:
                        player.Velocity /= MathF.Sqrt(2.0f);
                        break;
                    case -1 :
                        player.Velocity /= MathF.Sqrt(2.0f);
                        break;
                    default:
                        player.Velocity = player.Velocity;
                        break;
                }
                break;
        }
        
        newPos += player.Velocity * dt * 100.0f;
        player.sprite.Position = newPos;
        player.rectangle2.Position = newPos;
    }

    public void IncreaseSpeed(UI gui)
    {
        if (gui.InternalScore > 0 && gui.InternalScore % 500 == 0)
        {
            gui.InternalScore = 0;
            if (Player.Speed + SpeedModifier < 6.0f)
            {
                SpeedModifier += 0.5f;
                Console.WriteLine($"{Player.Speed + SpeedModifier}");
            }
        }
    }
    public bool IsPlayerOutofBounds(Player player, float dt) //TODO: Somethings wrong here or in Player.cs with origin
    {
        bool left   = player.sprite.Position.X - Player.Resized.X / 2 < 0 ;
        bool top    = player.sprite.Position.Y - Player.Resized.Y < 0;
        bool right  = player.sprite.Position.X + Player.Resized.X >= Program.ScreenW;
        bool bottom = player.sprite.Position.Y + Player.Resized.Y >= Program.ScreenH;
        return left || right || top || bottom;
    }
    /*public void RunLeftAnimation(Player player, float dt)
    {
        player.sprite.Scale = new Vector2f(
            player.size.X / player.playerTextureSize.Y,
            player.size.Y / player.playerTextureSize.Y);
        if (Timer < 2 / 11)
        {
            player.sprite.Texture = new Texture(runAnimation[0]);
        }

        if (Timer >= 2 / 11 && Timer < 4 / 11)
        {
            player.sprite.Texture = new Texture(runAnimation[1]);
        }

        if (Timer >= 4 / 11 && Timer < 6 / 11)
        {
            player.sprite.Texture = new Texture(runAnimation[2]);
        }

        if (Timer >= 6 / 11 && Timer < 8 / 11)
        {
            player.sprite.Texture = new Texture(runAnimation[3]);
        }

        if (Timer >= 8 / 11 && Timer < 10 / 11)
        {
            player.sprite.Texture = new Texture(runAnimation[4]);
        }

        if (Timer >= 10 / 11 && Timer < 12 / 11)
        {
            player.sprite.Texture = new Texture(runAnimation[5]);
        }

        if (Timer >= 12 / 11 && Timer < 14 / 11)
        {
            player.sprite.Texture = new Texture(runAnimation[6]);
        }

        if (Timer >= 14 / 11 && Timer < 16 / 11)
        {
            player.sprite.Texture = new Texture(runAnimation[7]);
        }

        if (Timer >= 16 / 11 && Timer < 18 / 11)
        {
            player.sprite.Texture = new Texture(runAnimation[8]);
        }

        if (Timer >= 18 / 11 && Timer < 20 / 11)
        {
            player.sprite.Texture = new Texture(runAnimation[9]);
        }

        if (Timer >= 20 / 11)
        {
            player.sprite.Texture = new Texture(runAnimation[10]);
            Timer = 0;
        }
    }*/

    public bool IsPlayerHit(Player player, ProjectileHandler projectileHandler)
    {
        List<Projectile> projList = projectileHandler.ListOfProj;
        
        for (int i = 0; i < projList.Count; i++)
        {
            Vector2f playerPos = player.sprite.Position;
            Vector2f bulletPos = projList[i].sprite.Position;
            bool left   = playerPos.X - Player.Resized.X / 2 < projList[i]..X + projList[i];
            bool top    = playerPos.Y - Player.Resized.Y < 0;
            bool right  = playerPos.X + Player.Resized.X >= projList[i].sprite.Position.X;
            bool bottom = playerPos.Y + Player.Resized.Y >= Program.ScreenH;
            return left || right || top || bottom;
        }

        return false;
    }
    public void Update(Player player, float dt, UI gui)
    {
        Timer += dt;
        IncreaseSpeed(gui);
        MovePlayer(player, dt);
        
    }
}
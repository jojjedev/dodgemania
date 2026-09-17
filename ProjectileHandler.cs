using System.Runtime.InteropServices.Marshalling;
using SFML.System;
using SFML.Graphics;
using SFML.Window;


namespace smflTest;

public class ProjectileHandler
{
    public float Timer;
    public float SpeedModifier = 2;
    
    public static List<Projectile> ListOfProj = new List<Projectile>();
    
    public bool ProjectilePositionCheck(Projectile proj)
    {
        for (int i = 0; i < ListOfProj.Count; i++)
        {
            if (proj.sprite.Position.X > Program.ScreenW + proj.size.X * 1.5f)
            {
                return true;
            }
            if (proj.sprite.Position.X < 0 - proj.size.X * 1.5f)
            {
                return true;
            }   
            if (proj.sprite.Position.Y > Program.ScreenH + proj.size.X * 1.5f)
            {
                return true;
            }   
            if (proj.sprite.Position.Y < 0 - proj.size.X * 1.5f)
            {
                return true;
            }
        }
        return false;
    }

    public void GenerateProjectiles(float dt, UI gui)
    {
        Timer += dt;
        if (ListOfProj.Count > 0)
        {
            return;
        }
        if (Timer > Projectile.spawnRate)
        {
            if (SpeedModifier < 6)
            {
                if (gui.Score > 0 && gui.Score % 500 == 0)
                {
                    SpeedModifier += 0.5f;
                    Projectile.spawnRate *= 0.8f;
                }
            }
            
            Projectile newProj = new Projectile(SpeedModifier);
            ListOfProj.Add(newProj);
            Timer = 0;
        }
    }
    public void Update(float dt, UI gui)
    {
        GenerateProjectiles(dt, gui);
        for (int i = 0; i < ListOfProj.Count; i++)
        {
            ListOfProj[i].Update(dt);
            if (ProjectilePositionCheck(ListOfProj[i]))
            {
                ListOfProj.RemoveAt(i);
                gui.Score += 100;
                gui.InternalScore += 100;
            }
            
        }
        
        
    }
    public void DebugDraw(RenderTarget target, Projectile projectile)
    {
        Shape rectangle2;
        rectangle2 = new RectangleShape(projectile.size);
        rectangle2.Position = projectile.sprite.Position;
        rectangle2.Origin = projectile.size / 2;
        rectangle2.OutlineColor = Color.Green;
        rectangle2.OutlineThickness = 2;
        rectangle2.FillColor = Color.Transparent;
        rectangle2.Rotation = projectile.sprite.Rotation;
        target.Draw(rectangle2);
    }
    public void Draw(RenderTarget target)
    {
        foreach (Projectile projectile in ListOfProj)
        {
            target.Draw(projectile.sprite);
            DebugDraw(target, projectile);
        }
    }
}
using System.Runtime.InteropServices.Marshalling;
using SFML.System;
using SFML.Graphics;
using SFML.Window;


namespace smflTest;

public class ProjectileHandler
{
    public float Timer;
    public float SpeedModifier = 2;
    
    public List<Projectile> ListOfProj = new List<Projectile>();
    
    public bool ProjectilePositionCheck(Projectile proj)
    {
        for (int i = 0; i < ListOfProj.Count; i++)
        {
            if (proj.sprite.Position.X > Program.ScreenW + proj.Resized.X * 1.5f)
            {
                return true;
            }
            if (proj.sprite.Position.X < 0 - proj.Resized.X * 1.5f)
            {
                return true;
            }   
            if (proj.sprite.Position.Y > Program.ScreenH + proj.Resized.X * 1.5f)
            {
                return true;
            }   
            if (proj.sprite.Position.Y < 0 - proj.Resized.X * 1.5f)
            {
                return true;
            }
        }
        return false;
    }

    public void GenerateProjectiles(float dt, UI gui)
    {
        Timer += dt;
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
    public void Draw(RenderTarget target)
    {
        foreach (Projectile projectile in ListOfProj)
        {
            target.Draw(projectile.sprite);
            target.Draw(projectile.rectangle);
        }
    }
}
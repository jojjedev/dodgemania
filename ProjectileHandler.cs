using System.Runtime.InteropServices.Marshalling;
using SFML.System;
using SFML.Graphics;
using SFML.Window;


namespace smflTest;

public class ProjectileHandler
{
    public float Timer;
    public float SpeedModifier = 1;
    public List<Projectile> ListOfProj = new List<Projectile>();
    
    public bool ProjectilePositionCheck(Projectile proj)
    {
        for (int i = 0; i < ListOfProj.Count; i++)
        {
            if (proj.sprite.Position.X > Program.ScreenW + proj.size.X)
            {
                return true;
            }
            if (proj.sprite.Position.X < 0 - proj.size.X)
            {
                return true;
            }   
            if (proj.sprite.Position.Y > Program.ScreenH + proj.size.X)
            {
                return true;
            }   
            if (proj.sprite.Position.Y < 0 - proj.size.X)
            {
                return true;
            }
        }
        return false;
    }

    public void GenerateProjectiles(float dt)
    {
        Timer += dt;
        if (Timer > 1)
        {
            Projectile newProj = new Projectile(SpeedModifier);
            ListOfProj.Add(newProj);
            Console.WriteLine(ListOfProj.Count);
            Timer = 0;
        }
    }
    public void Update(float dt, UI gui)
    {
        if (gui.Score > 0 && gui.Score % 500 == 0)
        {
            SpeedModifier += 0.5f;
        }
        GenerateProjectiles(dt);
        for (int i = 0; i < ListOfProj.Count; i++)
        {
            ListOfProj[i].Update(dt);
            if (ProjectilePositionCheck(ListOfProj[i]))
            {
                ListOfProj.RemoveAt(i);
                gui.Score += 100;
                Console.WriteLine("Projectile should have been removed");
                Console.WriteLine($"{ListOfProj.Count}");
            }
            
        }
        
        
    }
    public void Draw(RenderTarget target)
    {
        foreach (Projectile projectile in ListOfProj)
        {
            target.Draw(projectile.sprite);
        }
    }
}
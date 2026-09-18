using System.Runtime.InteropServices.Marshalling;
using SFML.System;
using SFML.Graphics;
using SFML.Window;
using static smflTest.Constants;


namespace smflTest;

public class ProjectileHandler
{
    public float Timer;
    public float ProjSpeedModifier = PROJECTILE_SPEED_MODIFIER_START;
    public static List<Projectile> ListOfProj = new List<Projectile>();
    
    public bool ProjectilePositionCheck(Projectile proj)
    {
        for (int i = 0; i < ListOfProj.Count; i++)
        {
            return ((proj.sprite.Position.X > Program.ScreenW + proj.size.X * 1.5f) ||
                    (proj.sprite.Position.X < 0 - proj.size.X * 1.5f) ||
                    (proj.sprite.Position.Y > Program.ScreenH + proj.size.X * 1.5f) ||
                    (proj.sprite.Position.Y < 0 - proj.size.X * 1.5f));
        }
        return false;
    }

    public void GenerateProjectiles(float dt, UI gui)
    {
        Timer += dt;
        if (Timer > Projectile.spawnRate)
        {
            if (ProjSpeedModifier < 6)
            {
                if (gui.Score > 0 && gui.Score % 500 == 0)
                {
                    ProjSpeedModifier += 0.5f;
                    Projectile.spawnRate *= 0.8f;
                }
            }
            
            Projectile newProj = new Projectile(ProjSpeedModifier);
            ListOfProj.Add(newProj);
            Timer = 0;
        }
    }
    public void Update(float dt, UI gui)
    {
        if (Program.GameStop) return;
        GenerateProjectiles(dt, gui);
        for (int i = 0; i < ListOfProj.Count; i++)
        {
            ListOfProj[i].Update(dt);
            if (ProjectilePositionCheck(ListOfProj[i]))
            {
                ListOfProj.RemoveAt(i);
                gui.Score += 100;
                if (gui.Score > gui.HighScore) gui.HighScore = gui.Score;
                gui.InternalScore += 100;
            }
            
        }
        
        
    }
    /*public void DebugDraw(RenderTarget target, Projectile projectile)
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
    }*/
    public void Draw(RenderTarget target)
    {
        foreach (Projectile projectile in ListOfProj)
        {
            projectile.Draw(target);
            //DebugDraw(target, projectile);
        }
    }
}
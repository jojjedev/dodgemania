using SFML.Graphics;
using SFML.System;

namespace smflTest;

public class UI
{
    public int Score;
    public int InternalScore;
    public int Health = 3;
    public Text gui;

    public UI()
    {
        gui = new Text();
        gui.CharacterSize = 30;
        gui.Font = new Font("assets/vcr.ttf");
        gui.FillColor = new Color(168, 3, 3);
    }

    public void Draw(RenderTarget target)
    {
        // Draws "Health" text
        gui.DisplayedString =  $"Health: {Health}";
        gui.Position = new Vector2f(12, 8);
        target.Draw(gui);
        
        // Draws "Score" text
        gui.DisplayedString = $"Score: {Score}";
        gui.Position = new Vector2f(Program.ScreenW - gui.GetGlobalBounds().Width - 12, 8);
        target.Draw(gui);
    }
}
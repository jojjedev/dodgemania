using SFML.Graphics;
using SFML.System;
using static smflTest.Constants;

namespace smflTest;

public class UI
{
    public int Score;
    public int HighScore;
    public int InternalScore = 0;
    public int Health = START_HEALTH;
    public Text gui;
    public static bool GameOver;

    public UI()
    {
        gui = new Text();
        gui.CharacterSize = 30;
        gui.Font = new Font("assets/vcr.ttf");
        gui.FillColor = new Color(255, 255, 3);
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
        
        // Draws "High Score" text
        gui.DisplayedString = $"High Score: {HighScore}";
        gui.Position = new Vector2f(Program.ScreenW - gui.GetGlobalBounds().Width - 12, 20 + gui.GetGlobalBounds().Height);
        target.Draw(gui);
        
    }
    // Game Over skärmförsök nedan
   /* public void DrawEndScreen(RenderTarget target)
    {
        if (GameOver)
        {
            Text text = DisplayGameOverText();
            Shape rect = DisplayGameOverRect(text);
            target.Draw(rect);
            target.Draw(text);
            Console.WriteLine("End screen ritad");

        }
    }
    public Text DisplayGameOverText()
    {
        Text gameOverText = new Text();
        gameOverText.DisplayedString = "GAME OVER\nPRESS ENTER TO RESTART";
        gameOverText.CharacterSize = 50;
        gameOverText.Origin = new Vector2f(
            gameOverText.GetGlobalBounds().Width,
            gameOverText.GetGlobalBounds().Height) * 0.5f;
        gameOverText.Position = new Vector2f(Program.ScreenW / 2, Program.ScreenH / 2 - gameOverText.GetGlobalBounds().Height);
        return gameOverText;
    }

    public Shape DisplayGameOverRect(Text gameOverText)
    {
        Shape gameOverRect = new RectangleShape(new Vector2f(gameOverText.GetGlobalBounds().Width * 1.2f,
            gameOverText.GetGlobalBounds().Height * 1.2f));
        gameOverRect.Origin = gameOverText.Origin;
        gameOverRect.Position = gameOverText.Position;
        gameOverRect.FillColor = new Color(65, 65, 65);
        gameOverRect.OutlineColor = Color.Black;
        return gameOverRect;
    }
    */
}
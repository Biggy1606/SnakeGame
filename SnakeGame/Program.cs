internal class Program
{
    private static void Main()
    {
        Console.WindowHeight = 26;
        Console.WindowWidth = 54;
        int screenwidth = Console.WindowWidth - 20;
        int screenheight = Console.WindowHeight - 10;
        Random randomnummer = new();
        //TODO: FIX THIS
        Pixel hoofd = new()
        {
            xPos = screenwidth / 2,
            yPos = screenheight / 2,
            schermKleur = ConsoleColor.Red
        };
        string movement = "RIGHT";
        _ = new List<int>();
        int score = 0;
        _ = new
        List<int>()
        {
            hoofd.xPos,
            hoofd.yPos
        };
        List<int> tailPositions = new();

        _ = DateTime.Now;
        string obstacle = "*";
        int obstacleXpos = randomnummer.Next(1, screenwidth - 1);
        int obstacleYpos = randomnummer.Next(1, screenheight - 1);
        void GameOver()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(screenwidth / 5, screenheight / 2);
            Console.WriteLine("Game Over");
            Console.SetCursorPosition(screenwidth / 5, (screenheight / 2) + 1);
            Console.WriteLine("Dein Score ist: " + score);
            Console.SetCursorPosition(screenwidth / 5, (screenheight / 2) + 2);
            Environment.Exit(0);
        }
        while (true)
        {
            Console.Clear();
            //Draw Obstacle

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition(obstacleXpos, obstacleYpos);
            Console.Write(obstacle);


            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(hoofd.xPos, hoofd.yPos);
            Console.Write("■");


            Console.ForegroundColor = ConsoleColor.White;
            for (int i = 0; i < screenwidth; i++)
            {
                Console.SetCursorPosition(i, 0);
                Console.Write("█");
                Console.SetCursorPosition(i, screenheight - 1);
                Console.Write("█");
            }

            for (int i = 0; i < screenheight; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write("█");
                Console.SetCursorPosition(screenwidth - 1, i);
                Console.Write("█");
            }

            //TODO: FIX THIS
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("\nScore: " + score);
            Console.ForegroundColor = ConsoleColor.White;
            //Console.ForegroundColor = ConsoleColor.Green;
            for (int i = 0; i < tailPositions.Count; i += 2)
            {
                Console.SetCursorPosition(tailPositions[i], tailPositions[i + 1]);
                Console.Write("■");
            }


            //Draw Snake
            Console.SetCursorPosition(hoofd.xPos, hoofd.yPos);
            Console.Write("■");

            //Save head prev position
            int lastX = hoofd.xPos;
            int lastY = hoofd.yPos;

            ConsoleKeyInfo info = Console.ReadKey();
            //Game Logic
            switch (info.Key)
            {
                case ConsoleKey.UpArrow:
                    movement = "UP";
                    break;
                case ConsoleKey.DownArrow:
                    movement = "DOWN";
                    break;
                case ConsoleKey.LeftArrow:
                    movement = "LEFT";
                    break;
                case ConsoleKey.RightArrow:
                    movement = "RIGHT";
                    break;
            }

            if (movement == "UP")
            {
                hoofd.yPos--;
            }

            if (movement == "DOWN")
            {
                hoofd.yPos++;
            }

            if (movement == "LEFT")
            {
                hoofd.xPos--;
            }

            if (movement == "RIGHT")
            {
                hoofd.xPos++;
            }

            for (int i = tailPositions.Count - 2; i > 0; i -= 2)
            {
                tailPositions[i] = tailPositions[i - 2];
                tailPositions[i + 1] = tailPositions[i - 1];
            }
            if (tailPositions.Any())
            {
                tailPositions[0] = hoofd.xPos;
                tailPositions[1] = hoofd.yPos;
            }

            // Collisions
            if (hoofd.xPos == obstacleXpos && hoofd.yPos == obstacleYpos)
            {
                score++;
                obstacleXpos = randomnummer.Next(1, screenwidth - 1);
                obstacleYpos = randomnummer.Next(1, screenheight - 1);
                tailPositions.Add(lastX);
                tailPositions.Add(lastY);

            }
            //Kollision mit Wände oder mit sich selbst
            if (hoofd.xPos == 0 || hoofd.xPos == screenwidth - 1 || hoofd.yPos == 0 || hoofd.yPos == screenheight - 1)
            {
                GameOver();
            }
            for (int i = 0; i < tailPositions.Count; i ++)
            {
                if (hoofd.xPos == tailPositions[i] && hoofd.yPos == tailPositions[i + 1] && i != 0)
                {
                    GameOver();
                }
            }
            //for (int i = 0; i < tailPositions.Count; i += 2)
            //{
            //    if (hoofd.xPos == tailPositions[i] && hoofd.yPos == tailPositions[i + 1] && i != 0)
            //    {
            //        GameOver();
            //    }
            //}



            //Thread.Sleep(1);
        }
    }
}

public class Pixel
{
    public int xPos { get; set; }
    public int yPos { get; set; }
    public ConsoleColor schermKleur { get; set; }
    public string? karacter { get; set; }
}


public class Obstakel
{
    public int Xpos { get; set; }

    public int Ypos { get; set; }
    public ConsoleColor schermKleur { get; set; }
    public string? karacter { get; set; }
}
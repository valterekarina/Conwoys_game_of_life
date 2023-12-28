namespace GameOfLife
{
    public class InputHandler : IInputHandler
    {
        public int GetOption()
        {
            int option = 0;
            bool validInput = false;
            Console.Write("\nPlease select one option: ");
            while (!validInput)
            {
                string optionString = Console.ReadLine();

                if (int.TryParse(optionString, out option) && option >= 1 && option <= 7)
                {
                    validInput = true;
                }
                else
                {
                    Console.Write("\nInvalid option. Please enter a valid number: ");
                }
            }

            return option;
        }

        public int GetHeight()
        {
            bool validInput = false;
            int height = 0;
            while (!validInput)
            {
                Console.Write("\nPlease input height (at least 3): ");
                string heightInput = Console.ReadLine();

                if (int.TryParse(heightInput, out height) && height >= 3)
                {
                    validInput = true;
                }
                else
                {
                    Console.WriteLine("Invalid height. Please enter an integer that's at least 3!");
                }
            }
            return height;
        }

        public int GetWidth()
        {
            bool validInput = false;
            int width = 0;
            while (!validInput)
            {
                Console.Write("\nPlease input width (at least 3): ");
                string widthInput = Console.ReadLine();

                if (int.TryParse(widthInput, out width) && width >= 3)
                {
                    validInput = true;
                }
                else
                {
                    Console.WriteLine("Invalid width. Please enter an integer that's at least 3!");
                }
            }
            return width;
        }

        public string GetFilePath()
        {
            Console.Write("\nInput folder path: ");
            string folderPath = Console.ReadLine();

            Console.Write("\nInput file name: ");
            string filePath = Console.ReadLine();

            string fullFilePath = Path.Combine(folderPath, filePath);

            return fullFilePath;
        }

        public string GetSaveGameAnswer()
        {
            Console.Clear();
            Console.Write("\nDo you wnat to save the game? ('y' - yes/'anything else or nothing' - no) ");
            string answer = Console.ReadLine();
            return answer;
        }

        public bool PauseOrEnd(bool _isPaused, int iteration, int cellsAlive, IGrid grid)
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.Spacebar)
                {
                    _isPaused = !_isPaused;

                }
                else if (key.Key == ConsoleKey.X)
                {
                    string answer = GetSaveGameAnswer();

                    if (answer == "y" || answer == "Y")
                    {
                        string filePath = GetFilePath();
                        Console.Clear();
                        ISaveGame gameSaver = new SaveGame();
                        gameSaver.SaveGameInfo(iteration, cellsAlive, grid, filePath);
                    }
                    else
                    {
                        Console.WriteLine("Game not saved!");
                    }
                    Console.WriteLine("\nGame over!");
                    Environment.Exit(0);
                }
            }
            return _isPaused;
        }
    }
}

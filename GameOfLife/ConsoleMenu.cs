namespace GameOfLife
{
    public class ConsoleMenu : IMenu
    {
        public void CreateMenu()
        {
            Console.WriteLine("Field sizes:\n");
            Console.WriteLine("1) 10x10");
            Console.WriteLine("2) 15x15");
            Console.WriteLine("3) 20x20");
            Console.WriteLine("4) 36x36");
            Console.WriteLine("5) Choose your own grid height and width");
            Console.WriteLine("6) Load previous game");
            Console.WriteLine("7) Stop the application");
        }

        public GameOfLife HandleOption(int option)
        {
            GameOfLife game = null;
            IInputHandler inputHandler = new InputHandler();

            switch (option)
            {
                case 1:
                    game = new GameOfLife(grid: new Grid(10, 10));
                    break;
                case 2:
                    game = new GameOfLife(grid: new Grid(15, 15));
                    break;
                case 3:
                    game = new GameOfLife(grid: new Grid(20, 20));
                    break;
                case 4:
                    game = new GameOfLife(grid: new Grid(36, 36));
                    break;
                case 5:
                    int height = inputHandler.GetHeight();
                    int width = inputHandler.GetWidth();
                    game = new GameOfLife(grid: new Grid(height, width));
                    break;
                case 6:
                    string filePath = inputHandler.GetFilePath();

                    ILoadGame gameLoader = new LoadGame();
                    game = gameLoader.GameLoad(filePath);
                    break;
                case 7:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("There is no option " + option);
                    break;
            }
            return game;
        }
    }
}

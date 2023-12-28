using System.Diagnostics.CodeAnalysis;

namespace GameOfLife
{
    class Program
    {
        [ExcludeFromCodeCoverage]
        static void Main(string[] args)
        {
            IMenu menu = new ConsoleMenu();
            menu.CreateMenu();

            IInputHandler inputHandler = new InputHandler();
            int option = inputHandler.GetOption();

            GameOfLife game = menu.HandleOption(option);

            if (game != null)
            {
                game.Run();
            }
        }
    }
}
namespace GameOfLife
{
    public class GameOfLife
    {
        public IGrid Grid { get; set; }
        public int Iteration { get; set; }
        public int CellsAlive { get; set; }
        public bool ExitLoop { get; set; }
        private bool _isPaused;

        public GameOfLife(IGrid grid)
        {
            Grid = grid;
            Iteration = 0;
            _isPaused = false;
            ExitLoop = false;
        }

        public void Run()
        {

            while (!ExitLoop)
            {
                Console.Clear();
                CellsAlive = Grid.CountAliveCells(Grid);

                Display();

                IInputHandler inputHandler = new InputHandler();
                _isPaused = inputHandler.PauseOrEnd(_isPaused, Iteration, CellsAlive, Grid);

                if (!_isPaused)
                {
                    Grid.UpdateGrid();
                    Iteration++;
                }

                Thread.Sleep(1000);
            }
        }

        public void Display()
        {
            Console.WriteLine("Press 'x' to exit the game!");
            Console.WriteLine("Press 'Spacebar' to pause/unpause the game!");
            Console.WriteLine("Iteration " + Iteration);
            Grid.DisplayGrid(Grid);
            Console.WriteLine("Count of alive cells: " + CellsAlive);
        }
    }
}
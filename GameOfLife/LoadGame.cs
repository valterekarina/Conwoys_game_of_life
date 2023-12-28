using System.Diagnostics.CodeAnalysis;

namespace GameOfLife
{
    public class LoadGame : ILoadGame
    {
        public GameOfLife GameLoad(string filePath)
        {
            try
            {
                GameOfLife loadedGame = new GameOfLife(grid: new Grid(3, 3));
                LoadGameInfo(filePath, loadedGame);
                return loadedGame;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error loading game from a file: " + e.Message);
                return null;
            }
        }
        private void LoadGameInfo(string filePath, GameOfLife loadedGame)
        {

            using (StreamReader reader = new StreamReader(filePath))
            {

                GetIteration(reader, loadedGame);
                GetCellsAlive(reader, loadedGame);
                int gridHeight = GetGridHeight(reader);
                int gridWidth = GetGridWidth(reader);

                loadedGame.Grid = new Grid(gridHeight, gridWidth);

                reader.ReadLine();
                int x = 0;
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    for (int y = 0; y < gridWidth; y++)
                    {
                        char cellChar = line[y];
                        loadedGame.Grid.SetCell(x, y, cellChar == '*');
                    }
                    x++;
                }
            }
        }

        [ExcludeFromCodeCoverage]
        private void GetIteration(StreamReader reader, GameOfLife loadedGame)
        {
            string interationLine = reader.ReadLine();

            if (int.TryParse(interationLine?.Substring(interationLine.IndexOf(':') + 1), out int savedIteration))
            {
                loadedGame.Iteration = savedIteration;
            }
        }

        [ExcludeFromCodeCoverage]
        private void GetCellsAlive(StreamReader reader, GameOfLife loadedGame)
        {
            string cellsAliveLine = reader.ReadLine();

            if (int.TryParse(cellsAliveLine?.Substring(cellsAliveLine.IndexOf(':') + 1), out int savedCellsAlive))
            {
                loadedGame.CellsAlive = savedCellsAlive;
            }
        }

        [ExcludeFromCodeCoverage]
        private int GetGridHeight(StreamReader reader)
        {
            //reader.ReadLine();
            string heightLine = reader.ReadLine();

            if (int.TryParse(heightLine?.Substring(heightLine.IndexOf(':') + 1), out int savedHeight))
            {
                return savedHeight;
            }

            return 0;
        }

        [ExcludeFromCodeCoverage]
        private int GetGridWidth(StreamReader reader)
        {
            string widthLine = reader.ReadLine();

            if (int.TryParse(widthLine?.Substring(widthLine.IndexOf(':') + 1), out int savedWidth))
            {
                return savedWidth;
            }
            return 0;
        }
    }
}

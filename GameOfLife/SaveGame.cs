namespace GameOfLife
{
    public class SaveGame : ISaveGame
    {
        public void SaveGameInfo(int iteration, int cellsAlive, IGrid grid, string filePath)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    writer.WriteLine("Iterations: " + iteration);
                    writer.WriteLine("Alive cells: " + cellsAlive);
                    writer.WriteLine("Grid height: " + grid.Height);
                    writer.WriteLine("Grid width: " + grid.Width);
                    writer.WriteLine("Grid state: ");

                    for (int x = 0; x < grid.Height; x++)
                    {
                        for (int y = 0; y < grid.Width; y++)
                        {
                            ICell cell = grid.GetCell(x, y);
                            char cellChar = cell.IsAlive ? '*' : ' ';
                            writer.Write(cellChar);
                        }
                        writer.WriteLine();
                    }

                    Console.WriteLine("Game information save to file " + filePath);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error saving game to a file: " + e.Message);
                Console.WriteLine("Game not saved!");
                Environment.Exit(0);
            }
        }
    }
}

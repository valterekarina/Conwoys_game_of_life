namespace GameOfLife
{
    public interface ISaveGame
    {
        void SaveGameInfo(int iteration, int cellsAlive, IGrid grid, string filePath);
    }
}

namespace GameOfLife
{
    public interface IGrid
    {
        int Height { get; }
        int Width { get; }
        ICell[,] Cells { get; }
        ICell GetCell(int x, int y);
        void SetCell(int x, int y, bool isAlive);
        void UpdateGrid();
        void DisplayGrid(IGrid grid);
        int CountAliveCells(IGrid grid);
    }
}

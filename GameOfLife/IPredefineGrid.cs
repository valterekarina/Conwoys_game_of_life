namespace GameOfLife
{
    internal interface IPredefineGrid
    {
        void FillSmallestGrid(ICell[,] cells);
        void FillSmallGrid(ICell[,] cells, int height, int width);
        public void FillMediumGrid(ICell[,] cells);
        public void FillLargeGrid(ICell[,] cells);
        public void FillDefaultGrid(ICell[,] cells);
    }
}

using System.Diagnostics.CodeAnalysis;

namespace GameOfLife
{
    public class Grid : IGrid
    {
        private ICell[,] _cells;
        private int _height;
        private int _width;
        public int Height { get { return _height; } }
        public int Width { get { return _width; } }
        public ICell[,] Cells { get { return _cells; } }

        public Grid(int height, int width)
        {
            this._height = height;
            this._width = width;
            this._cells = new ICell[height, width];

            for (int x = 0; x < height; x++)
            {
                for (int y = 0; y < width; y++)
                {
                    _cells[x, y] = new Cell(false);
                }
            }

            IPredefineGrid predefineGrid = new PredefineGrid();

            if (height >= 4 && width == 10 && height <= 10)
            {
                predefineGrid.FillSmallestGrid(_cells);
            }
            else if (height > 10 && width > 10 && height < 20 && width < 20)
            {
                predefineGrid.FillSmallGrid(_cells, height, width);
            }
            else if (height >= 20 && width >= 20 && width < 36)
            {
                predefineGrid.FillMediumGrid(_cells);
            }
            else if (width >= 36 && height >= 11)
            {
                predefineGrid.FillLargeGrid(_cells);
            }
            else
            {
                predefineGrid.FillDefaultGrid(_cells);
            }
        }

        public ICell GetCell(int x, int y)
        {
            if (x >= 0 && x < Height && y >= 0 && y < Width)
            {
                return _cells[x, y];
            }
            return null;
        }

        public void SetCell(int x, int y, bool isAlive)
        {
            if (x >= 0 && x < Height && y >= 0 && y < Width)
            {
                _cells[x, y].IsAlive = isAlive;
            }
        }

        public void UpdateGrid()
        {
            for (int x = 0; x < _height; x++)
            {
                for (int y = 0; y < _width; y++)
                {
                    ICell cell = _cells[x, y];
                    int aliveNeighors = CountAliveNeighbors(x, y);

                    if (cell.IsAlive)
                    {
                        cell.NextState = aliveNeighors == 2 || aliveNeighors == 3;
                    }
                    else
                    {
                        cell.NextState = aliveNeighors == 3;
                    }
                }
            }
            ReplaceGrid(_cells);
        }

        [ExcludeFromCodeCoverage]
        private void ReplaceGrid(ICell[,] cells)
        {
            foreach (ICell cell in cells)
            {
                cell.IsAlive = cell.NextState;
            }
        }

        [ExcludeFromCodeCoverage]
        private int CountAliveNeighbors(int x, int y)
        {
            int aliveNeighors = 0;

            int[] xCoordinate = { 1, 1, 1, 0, 0, -1, -1, -1 };
            int[] yCoordinate = { 1, 0, -1, 1, -1, 1, 0, -1 };

            for (int i = 0; i < 8; i++)
            {
                int xNeighbor = x + xCoordinate[i];
                int yNeighbor = y + yCoordinate[i];

                if (xNeighbor >= 0 && xNeighbor < _height && yNeighbor >= 0 && yNeighbor < _width)
                {
                    ICell neighborCell = _cells[xNeighbor, yNeighbor];

                    if (neighborCell.IsAlive)
                    {
                        aliveNeighors++;
                    }
                }
            }
            return aliveNeighors;
        }

        public void DisplayGrid(IGrid grid)
        {
            for (int i = 0; i < grid.Height; i++)
            {
                for (int j = 0; j < grid.Width; j++)
                {
                    ICell cell = grid.GetCell(i, j);
                    char cellChar = cell.IsAlive ? '*' : ' ';
                    Console.Write(cellChar);
                }
                Console.WriteLine();
            }
        }

        public int CountAliveCells(IGrid grid)
        {
            int cellsAlive = 0;
            for (int x = 0; x < grid.Height; x++)
            {
                for (int y = 0; y < grid.Width; y++)
                {
                    ICell cell = grid.GetCell(x, y);

                    if (cell.IsAlive)
                    {
                        cellsAlive++;
                    }
                }
            }
            return cellsAlive;
        }
    }
}

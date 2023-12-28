namespace GameOfLife
{
    public class PredefineGrid : IPredefineGrid
    {
        public void FillSmallestGrid(ICell[,] cells)
        {
            cells[0, 2] = new Cell(true);
            cells[1, 0] = new Cell(true);
            cells[1, 2] = new Cell(true);
            cells[2, 1] = new Cell(true);
            cells[2, 2] = new Cell(true);

            cells[1, 7] = new Cell(true);
            cells[2, 7] = new Cell(true);
            cells[2, 9] = new Cell(true);
            cells[3, 7] = new Cell(true);
            cells[3, 8] = new Cell(true);
        }

        public void FillSmallGrid(ICell[,] cells, int height, int width)
        {
            //left top
            cells[0, 2] = new Cell(true);
            cells[1, 0] = new Cell(true);
            cells[1, 2] = new Cell(true);
            cells[2, 1] = new Cell(true);
            cells[2, 2] = new Cell(true);

            // right top
            cells[1, width - 3] = new Cell(true);
            cells[2, width - 3] = new Cell(true);
            cells[2, width - 1] = new Cell(true);
            cells[3, width - 3] = new Cell(true);
            cells[3, width - 2] = new Cell(true);

            //left bottom
            cells[height - 4, 1] = new Cell(true);
            cells[height - 4, 2] = new Cell(true);
            cells[height - 3, 0] = new Cell(true);
            cells[height - 3, 2] = new Cell(true);
            cells[height - 2, 2] = new Cell(true);

            //right bottom
            cells[height - 1, width - 3] = new Cell(true);
            cells[height - 2, width - 3] = new Cell(true);
            cells[height - 2, width - 1] = new Cell(true);
            cells[height - 3, width - 3] = new Cell(true);
            cells[height - 3, width - 2] = new Cell(true);
        }

        public void FillMediumGrid(ICell[,] cells)
        {
            cells[9, 10] = new Cell(true);
            cells[10, 9] = new Cell(true);
            cells[10, 10] = new Cell(true);
            cells[10, 11] = new Cell(true);
            cells[11, 10] = new Cell(true);

            cells[10, 6] = new Cell(true);
            cells[9, 7] = new Cell(true);
            cells[8, 8] = new Cell(true);
            cells[7, 9] = new Cell(true);
            cells[6, 10] = new Cell(true);
            cells[7, 11] = new Cell(true);
            cells[8, 12] = new Cell(true);
            cells[9, 13] = new Cell(true);
            cells[10, 14] = new Cell(true);
            cells[11, 13] = new Cell(true);
            cells[12, 12] = new Cell(true);
            cells[13, 11] = new Cell(true);
            cells[14, 10] = new Cell(true);
            cells[11, 7] = new Cell(true);
            cells[12, 8] = new Cell(true);
            cells[13, 9] = new Cell(true);
        }

        public void FillLargeGrid(ICell[,] cells)
        {
            cells[5, 0] = new Cell(true);
            cells[6, 0] = new Cell(true);
            cells[5, 1] = new Cell(true);
            cells[6, 1] = new Cell(true);

            cells[3, 12] = new Cell(true);
            cells[3, 13] = new Cell(true);
            cells[4, 11] = new Cell(true);
            cells[4, 15] = new Cell(true);
            cells[5, 10] = new Cell(true);
            cells[5, 16] = new Cell(true);
            cells[6, 10] = new Cell(true);
            cells[6, 14] = new Cell(true);
            cells[6, 16] = new Cell(true);
            cells[6, 17] = new Cell(true);
            cells[7, 10] = new Cell(true);
            cells[7, 16] = new Cell(true);
            cells[8, 11] = new Cell(true);
            cells[8, 15] = new Cell(true);
            cells[9, 12] = new Cell(true);
            cells[9, 13] = new Cell(true);

            cells[1, 24] = new Cell(true);
            cells[2, 22] = new Cell(true);
            cells[2, 24] = new Cell(true);
            cells[3, 20] = new Cell(true);
            cells[3, 21] = new Cell(true);
            cells[4, 20] = new Cell(true);
            cells[4, 21] = new Cell(true);
            cells[5, 20] = new Cell(true);
            cells[5, 21] = new Cell(true);
            cells[6, 22] = new Cell(true);
            cells[6, 24] = new Cell(true);
            cells[7, 24] = new Cell(true);

            cells[3, 34] = new Cell(true);
            cells[3, 35] = new Cell(true);
            cells[4, 34] = new Cell(true);
            cells[4, 35] = new Cell(true);
        }

        public void FillDefaultGrid(ICell[,] cells)
        {
            cells[0, 2] = new Cell(true);
            cells[1, 2] = new Cell(true);
            cells[1, 0] = new Cell(true);
            cells[2, 1] = new Cell(true);
            cells[2, 2] = new Cell(true);
        }
    }
}

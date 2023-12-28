namespace GameOfLife
{
    public class Cell : ICell
    {
        public bool IsAlive { get; set; }
        public bool NextState { get; set; }

        public Cell(bool isAlive)
        {
            IsAlive = isAlive;
            NextState = false;
        }
    }
}
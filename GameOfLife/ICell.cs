namespace GameOfLife
{
    public interface ICell
    {
        bool IsAlive { get; set; }
        bool NextState { get; set; }
    }
}

namespace GameOfLife
{
    public interface IInputHandler
    {
        int GetOption();
        int GetHeight();
        int GetWidth();
        string GetFilePath();
        string GetSaveGameAnswer();
        bool PauseOrEnd(bool _isPaused, int iteration, int celllsAlive, IGrid grid);
    }
}

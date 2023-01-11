namespace SoundPlay.BLL.Interfaces
{
    public interface ILoggerAdapter<T>
    {
        void LogInformation(string message, params object[] args);
        void LogWarning(string message, params object[] args);
        void LogError(Exception exception, string? message, params object[] args);
    }
}

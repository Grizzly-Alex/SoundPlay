namespace SoundPlay.BLL.Interfaces
{
    public interface ILoggerAdapter<T>
    {
        public void LogInformation(string message, params object[] args);
        public void LogWarning(string message, params object[] args);
        public void LogError(Exception exception, string? message, params object[] args);
        public void LogError(string? message, params object[] args);
    }
}

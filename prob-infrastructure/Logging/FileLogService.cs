public class FileLogService : ILogService
{
    private readonly string _file = "logs.txt";

    public void Log(string message)
    {
        File.AppendAllText(_file, message + Environment.NewLine);
    }
}





public class FileLogService : ILogService
{
    private readonly string _filePath;

    public FileLogService()
    {
        var home = Environment.GetEnvironmentVariable("HOME") ?? "";
        _filePath = Path.Combine(home, "LogFiles", "logs.txt");
    }

    public void Log(string message)
    {
        Directory.CreateDirectory(Path.GetDirectoryName(_filePath)!);

        File.AppendAllText(_filePath,
            $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} | {message}{Environment.NewLine}");
    }
}

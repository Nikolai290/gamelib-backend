namespace gamelib_backend.Loggers; 

public class FileLogger : ILogger, IDisposable {

    private string filePath;
    private string file => string
        .Copy(filePath)
        .Replace("datetime", DateTime.Now.ToString("yyyyMMddHH"));
    
    private static object _lock = new object();

    public FileLogger(string path) {
        this.filePath = path;
    }
    
    public IDisposable BeginScope<TState>(TState state) {
        return this;
    }

    public bool IsEnabled(LogLevel logLevel) {
        return true;
    }

    public void Log<TState>(
        LogLevel logLevel,
        EventId eventId,
        TState state,
        Exception? exception,
        Func<TState, Exception?, 
        string> formatter
    ) {
        lock (_lock) {
            var path = Path.GetDirectoryName(filePath);
            
            Console.WriteLine(file);

            if (!Directory.Exists(path)) {
                Directory.CreateDirectory(filePath);
            }
            
            if (!File.Exists(file)) {
                File.CreateText(file);
            }
            
            File.AppendAllText(
                file, 
                formatter(state, exception) + Environment.NewLine
            );
        }
    }

    public void Dispose() { }
}
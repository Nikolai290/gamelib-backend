namespace gamelib_backend.Loggers; 

public class FileLoggerProvider : ILoggerProvider {
    private readonly string path;

    public FileLoggerProvider(string path) {
        this.path = path;
    }

    public void Dispose() { }

    public ILogger CreateLogger(string categoryName) {
        return new FileLogger(path);
    }
}
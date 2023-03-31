namespace Cloggy;

public class Logger
{
    private readonly IConsole console;
    private readonly bool includeDateTime;
    private readonly IDateTimeProvider _dateTimeProvider;

    public Logger(LoggerConfig loggerConfig)
    {
        this.console = loggerConfig.Console;
        this.includeDateTime = loggerConfig.IncludeDateTime;
        _dateTimeProvider = loggerConfig.DateTimeProvider;
    }

    public void Log(string? message)
    {
        if (includeDateTime)
        {
            message = $"[{_dateTimeProvider.Now().ToString("s")}] {message}";
        }
        
        console.WriteLine(message ?? string.Empty);
    }
}
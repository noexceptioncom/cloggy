namespace Cloggy;

public class Logger
{
    private readonly IConsole _console;
    private readonly bool _includeDateTime;
    private readonly IDateTimeProvider _dateTimeProvider;

    public Logger(LoggerConfig loggerConfig)
    {
        _console = loggerConfig.Console;
        _includeDateTime = loggerConfig.IncludeDateTime;
        _dateTimeProvider = loggerConfig.DateTimeProvider;
    }

    public void Log(string? message)
    {
        message = FormatMessage(message, null);
        _console.WriteLine(message ?? string.Empty);
    }

    public void LogInformation(string? message)
    {
        message = FormatMessage(message, "INF");
        
        _console.WriteLine(message ?? string.Empty);
    }

    public void LogWarning(string? message)
    {
        message = FormatMessage(message, "WRN");

        _console.WriteLine(message ?? string.Empty);
    }

    public void LogError(string message)
    {
        message = FormatMessage(message, "ERR");

        _console.WriteLine(message ?? string.Empty);
    }

    private string? FormatMessage(string? message, string? logLevel)
    {
        if (logLevel is null && !_includeDateTime)
        {
            return message;
        }
        
        var dateTime = string.Empty;
        if (_includeDateTime)
        {
            dateTime = _dateTimeProvider.Now().ToString("s");
        }

        var logLevelString = string.Empty;
        if (logLevel is not null)
        {
            logLevelString = $"{logLevel}";
        }

        var header = string.Join(' ', dateTime, logLevelString).Trim();
        return $"[{header}] {message}";
    }
}
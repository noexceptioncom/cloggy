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
        message = FormatMessage(message, LogLevel.INF);
        _console.WriteLine(message ?? string.Empty);
    }

    public void LogInformation(string? message)
    {
        message = FormatMessage(message, LogLevel.INF);

        _console.WriteLine(message ?? string.Empty);
    }

    public void LogWarning(string? message)
    {
        message = FormatMessage(message, LogLevel.WRN);

        _console.WriteLine(message ?? string.Empty);
    }

    public void LogError(string message)
    {
        message = FormatMessage(message, LogLevel.ERR);

        _console.WriteLine(message ?? string.Empty);
    }

    private string? FormatMessage(string? message, LogLevel logLevel)
    {
        var dateTime = string.Empty;
        if (_includeDateTime)
        {
            dateTime = _dateTimeProvider.Now().ToString("s");
        }


        var header = string.Join(' ', dateTime, $"{logLevel}").Trim();
        return $"[{header}] {message}";
    }
}
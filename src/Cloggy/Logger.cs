namespace Cloggy;

public class Logger
{
    private readonly IConsole _console;
    private readonly bool _includeDateTime;
    private readonly IDateTimeProvider _dateTimeProvider;

    public Logger(IConsole console, IDateTimeProvider dateTimeProvider, bool includeDateTime)
    {
        _console = console;
        _includeDateTime = includeDateTime;
        _dateTimeProvider = dateTimeProvider;
    }

    public static Logger CreateLoggerWithDateTime()
    {
        return new Logger(new SystemConsole(), new SystemDateProvider(), true);
    }

    public static Logger CreateLoggerWithoutDateTime()
    {
        return new Logger(new SystemConsole(), new SystemDateProvider(), false);
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
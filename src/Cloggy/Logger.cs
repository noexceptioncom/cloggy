namespace Cloggy;

public class Logger
{
    private readonly IConsole _console;
    private readonly IDateTimeProvider? _dateTimeProvider;

    public Logger(IConsole console, IDateTimeProvider? dateTimeProvider)
    {
        _console = console;
        _dateTimeProvider = dateTimeProvider;
    }

    public static Logger CreateLoggerWithDateTime()
    {
        return new Logger(new SystemConsole(), new SystemDateProvider());
    }

    public static Logger CreateLoggerWithoutDateTime()
    {
        return new Logger(new SystemConsole(), null);
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
        if (HasDateTime)
        {
            dateTime = _dateTimeProvider.Now().ToString("s");
        }


        var header = string.Join(' ', dateTime, $"{logLevel}").Trim();
        return $"[{header}] {message}";
    }
    
    private bool HasDateTime => _dateTimeProvider is not null;
}

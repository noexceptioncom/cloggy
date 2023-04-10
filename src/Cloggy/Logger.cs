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

    private void Log(string? message, LogLevel logLevel) => _console.WriteLine(FormatMessage(message, logLevel));

    public void LogInformation(string? message) => Log(message, LogLevel.INF);

    public void LogWarning(string? message) => Log(message, LogLevel.WRN);

    public void LogError(string? message) => Log(message, LogLevel.ERR);

    private string FormatMessage(string? message, LogLevel logLevel)
    {
        var dateTime = string.Empty;
        if (HasDateTime)
        {
            dateTime = _dateTimeProvider?.Now().ToString("s");
        }


        var header = string.Join(' ', dateTime, $"{logLevel}").Trim();
        return $"[{header}] {message}";
    }

    private bool HasDateTime => _dateTimeProvider is not null;
}
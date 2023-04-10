namespace Cloggy;

public class Logger
{
    private readonly IConsole _console;
    private readonly IDateTimeProvider? _dateTimeProvider;
    private readonly Category _category;

    public Logger(IConsole console, IDateTimeProvider? dateTimeProvider, Category category)
    {
        _console = console;
        _dateTimeProvider = dateTimeProvider;
        _category = category;
    }

    public static Logger CreateLoggerWithDateTime(string category)
    {
        return new Logger(new SystemConsole(), new SystemDateProvider(), new Category(category));
    }

    public static Logger CreateLoggerWithoutDateTime(string category)
    {
        return new Logger(new SystemConsole(), null, new Category(category));
    }

    private void Log(string? message, LogLevel logLevel) => _console.WriteLine(FormatMessage(message, logLevel));

    public void LogInformation(string? message) => Log(message, LogLevel.INF);

    public void LogWarning(string? message) => Log(message, LogLevel.WRN);

    public void LogError(string? message) => Log(message, LogLevel.ERR);

    private string FormatMessage(string? message, LogLevel logLevel)
    {
        var header = string.Join(' ', GetDateTimeFormat(), logLevel.ToString(), _category.ToString()).Trim();
        return $"[{header}] {message}";
    }

    private string GetDateTimeFormat() => HasDateTime ? _dateTimeProvider!.Now().ToString("s") : string.Empty;

    private bool HasDateTime => _dateTimeProvider is not null;
}
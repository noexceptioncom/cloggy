namespace Cloggy;

public class Logger
{
    private readonly IConsole _console;
    private readonly IDateTimeProvider? _dateTimeProvider;
    private readonly string? _category;

    public Logger(IConsole console, IDateTimeProvider? dateTimeProvider, string? category)
    {
        _console = console;
        _dateTimeProvider = dateTimeProvider;
        _category = category;
    }

    public static Logger CreateLoggerWithDateTime()
    {
        return new Logger(new SystemConsole(), new SystemDateProvider(), null);
    }

    public static Logger CreateLoggerWithoutDateTime()
    {
        return new Logger(new SystemConsole(), null, null);
    }

    public static Logger CreateLoggerWithDateTimeAndCategory(string category)
    {
        return new Logger(new SystemConsole(), new SystemDateProvider(), category);
    }

    public static Logger CreateLoggerWithCategory(string category)
    {
        return new Logger(new SystemConsole(), null, category);
    }

    private void Log(string? message, LogLevel logLevel) => _console.WriteLine(FormatMessage(message, logLevel));

    public void LogInformation(string? message) => Log(message, LogLevel.INF);

    public void LogWarning(string? message) => Log(message, LogLevel.WRN);

    public void LogError(string? message) => Log(message, LogLevel.ERR);

    private string FormatMessage(string? message, LogLevel logLevel)
    {
        
        var header = string.Join(' ', GetDateTimeFormat(), logLevel.ToString(), GetCategory()).Trim();
        return $"[{header}] {message}";
    }

    private string GetCategory()
    {
        return _category == null ? string.Empty : $"({_category})";
    }

    private string GetDateTimeFormat() => HasDateTime ? _dateTimeProvider!.Now().ToString("s") : string.Empty;

    private bool HasDateTime => _dateTimeProvider is not null;
}
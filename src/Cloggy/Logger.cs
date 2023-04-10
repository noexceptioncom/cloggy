namespace Cloggy;

public class Logger
{
    private readonly IConsole _console;
    private readonly IDateTimeProvider? _dateTimeProvider;
    private readonly string _category;

    public Logger(IConsole console, IDateTimeProvider? dateTimeProvider, string category)
    {
        if (string.IsNullOrWhiteSpace(category) || category.Contains('\n'))
        {
            throw new ArgumentNullException(nameof(category), "The category cannot be empty nor contain a new line char");
        }

        _console = console;
        _dateTimeProvider = dateTimeProvider;
        _category = category;
    }

    public static Logger CreateLoggerWithDateTime(string category)
    {
        return new Logger(new SystemConsole(), new SystemDateProvider(), category);
    }

    public static Logger CreateLoggerWithoutDateTime(string category)
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
        return $"({_category})";
    }

    private string GetDateTimeFormat() => HasDateTime ? _dateTimeProvider!.Now().ToString("s") : string.Empty;

    private bool HasDateTime => _dateTimeProvider is not null;
}
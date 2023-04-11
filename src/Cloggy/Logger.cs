namespace Cloggy;

public class Logger
{
    private readonly IConsole _console;
    private readonly IDateTimeProvider? _dateTimeProvider;
    private readonly Category _category;
    private readonly bool asJson;

    public Logger(IConsole console, IDateTimeProvider? dateTimeProvider, Category category, bool asJson)
    {
        _console = console;
        _dateTimeProvider = dateTimeProvider;
        _category = category;
        this.asJson = asJson;
    }
    
    public static Logger CreateJsonLoggerWithDateTime(string category)
    {
        return new Logger(new SystemConsole(), new SystemDateProvider(), new Category(category), true);
    }

    public static Logger CreateLoggerWithDateTime(string category)
    {
        return new Logger(new SystemConsole(), new SystemDateProvider(), new Category(category), false);
    }

    public static Logger CreateLoggerWithoutDateTime(string category)
    {
        return new Logger(new SystemConsole(), null, new Category(category), false);
    }

    private void Log(string? message, LogLevel logLevel) => _console.WriteLine(FormatMessage(message, logLevel));

    public void LogInformation(string? message) => Log(message, LogLevel.INF);

    public void LogWarning(string? message) => Log(message, LogLevel.WRN);

    public void LogError(string? message) => Log(message, LogLevel.ERR);

    private string FormatMessage(string? message, LogLevel logLevel)
    {
        if (asJson)
        {
            return
                $$"""{"timestamp":"{{GetDateTimeFormat()}}","loglevel":"{{logLevel.ToString()}}","category":"{{_category.ToString()}}","message":"{{message}}"}""";
        }
        
        var header = string.Join(' ', GetDateTimeFormat(), logLevel.ToString(), $"({_category})").Trim();
        return $"[{header}] {message}";
    }

    private string GetDateTimeFormat() => HasDateTime ? _dateTimeProvider!.Now().ToString("s") : string.Empty;

    private bool HasDateTime => _dateTimeProvider is not null;
}
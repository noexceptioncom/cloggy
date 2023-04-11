namespace Cloggy;

public class Logger
{
    private readonly IConsole _console;
    private readonly IDateTimeProvider _dateTimeProvider;
    private readonly Category _category;
    private readonly bool _asJson;

    public Logger(IConsole console, IDateTimeProvider dateTimeProvider, Category category, bool asJson)
    {
        _console = console;
        _dateTimeProvider = dateTimeProvider;
        _category = category;
        _asJson = asJson;
    }
    
    public static Logger CreateJsonLoggerWithDateTime(string category)
    {
        return new Logger(new SystemConsole(), new SystemDateProvider(), new Category(category), true);
    }

    public static Logger CreateLoggerWithDateTime(string category)
    {
        return new Logger(new SystemConsole(), new SystemDateProvider(), new Category(category), false);
    }

    private void Log(string? message, LogLevel logLevel) => _console.WriteLine(FormatMessage(message, logLevel));

    public void LogInformation(string? message) => Log(message, LogLevel.INF);

    public void LogWarning(string? message) => Log(message, LogLevel.WRN);

    public void LogError(string? message) => Log(message, LogLevel.ERR);

    private string FormatMessage(string? message, LogLevel logLevel)
    {
        if (_asJson)
        {
            return FormatMessageAsJson(message, logLevel);
        }

        return FormatMessageAsPlainText(message, logLevel);
    }

    private string FormatMessageAsPlainText(string? message, LogLevel logLevel)
    {
        var header = string.Join(' ', GetDateTimeFormat(), logLevel.ToString(), $"({_category})").Trim();
        return $"[{header}] {message}";
    }

    private string FormatMessageAsJson(string? message, LogLevel logLevel)
    {
        return
            $$"""{"timestamp":"{{GetDateTimeFormat()}}","loglevel":"{{logLevel}}","category":"{{_category.ToString()}}","message":"{{message}}"}""";
    }

    private string GetDateTimeFormat() => _dateTimeProvider.Now().ToString("s");
}
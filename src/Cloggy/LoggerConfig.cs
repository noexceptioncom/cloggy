namespace Cloggy;

public class LoggerConfig
{
    public LoggerConfig(IConsole console, IDateTimeProvider dateTimeProvider, bool includeDateTime)
    {
        Console = console;
        IncludeDateTime = includeDateTime;
        DateTimeProvider = dateTimeProvider;
    }

    public IConsole Console { get; private set; }
    public bool IncludeDateTime { get; private set; }
    public IDateTimeProvider DateTimeProvider { get; private set; }
}
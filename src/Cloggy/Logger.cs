namespace Cloggy;

public class Logger
{
    private readonly IConsole console;
    private readonly bool includeDateTime;
    private readonly IDateTimeProvider _dateTimeProvider;

    public Logger(IConsole console, bool includeDateTime, IDateTimeProvider dateTimeProvider)
    {
        this.console = console;
        this.includeDateTime = includeDateTime;
        _dateTimeProvider = dateTimeProvider;
    }

    public void Log(string? message)
    {
        if (includeDateTime)
        {
            message = $"[{_dateTimeProvider.Now().ToString("O")}] {message}";
        }
        
        console.WriteLine(message ?? string.Empty);
    }
}
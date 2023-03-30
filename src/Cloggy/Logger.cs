namespace Cloggy;

public class Logger
{
    private readonly IConsole console;
    private readonly bool includeDateTime;

    public Logger(IConsole console, bool includeDateTime)
    {
        this.console = console;
        this.includeDateTime = includeDateTime;
    }

    public void Log(string? message)
    {
        if (includeDateTime)
        {
            message = $"[2023-03-30T09:00:06] {message}";
        }
        
        console.WriteLine(message ?? string.Empty);
    }
}
namespace Cloggy;

public class Logger
{
    private readonly IConsole console;

    public Logger(IConsole console)
    {
        this.console = console;
    }

    public void Log(string message)
    {
        console.WriteLine(message);
    }
}
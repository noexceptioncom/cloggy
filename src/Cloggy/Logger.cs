namespace Cloggy;

public class Logger
{
    private readonly IConsole console;

    public Logger(IConsole console)
    {
        this.console = console;
    }

    public void Log(string empty)
    {
        console.WriteLine("");
    }
}
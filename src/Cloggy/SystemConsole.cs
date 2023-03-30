namespace Cloggy;

public class SystemConsole : IConsole
{
    public void WriteLine(string message)
    {
        Console.WriteLine(message);
    }
}
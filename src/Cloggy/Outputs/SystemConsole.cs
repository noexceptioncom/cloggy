namespace Cloggy.Outputs;

public class SystemConsole : IOutput
{
    public void WriteLine(string message)
    {
        Console.WriteLine(message);
    }
}
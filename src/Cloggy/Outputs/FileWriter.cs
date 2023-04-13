namespace Cloggy.Outputs;

public class FileWriter : IFileWriter
{
    private readonly string _filePath;

    public FileWriter(string filePath)
    {
        _filePath = filePath;
    }

    public void WriteLine(string message)
    {
        using var streamWriter = new StreamWriter(_filePath, true);
        streamWriter.WriteLine(message);
    }
}
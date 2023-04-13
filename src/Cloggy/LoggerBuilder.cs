using Cloggy.Formatters;
using Cloggy.Outputs;
using Cloggy.Providers;

namespace Cloggy;

public class LoggerBuilder
{
    private readonly string _category;
    private IFormatStrategy _formatStrategy;
    private IConsole? _systemConsole;
    private IFileWriter? _fileWriter;

    public LoggerBuilder(string category)
    {
        _category = category;
        _systemConsole = null;
        _fileWriter = null;
        _formatStrategy = new PlainTextFormatStrategy();
    }

    public Logger Build()
    {
        return new Logger(_systemConsole, new SystemDateProvider(), new Category(_category), _formatStrategy, _fileWriter);
    }

    public LoggerBuilder WithJsonFormat()
    {
        _formatStrategy = new JsonFormatStrategy();
        return this;
    }

    public LoggerBuilder ToConsole()
    {
        _systemConsole = new SystemConsole();
        return this;
    }

    public LoggerBuilder ToFile(string fullPath)
    {
        _fileWriter = new FileWriter(fullPath);
        return this;
    }
}
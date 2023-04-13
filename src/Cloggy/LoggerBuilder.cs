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
    private Memory? _memory;

    public LoggerBuilder(string category)
    {
        _category = category;
        _systemConsole = null;
        _fileWriter = null;
        _memory = null;
        _formatStrategy = new PlainTextFormatStrategy();
    }

    public Logger Build()
    {
        return new Logger(new SystemDateProvider(), _formatStrategy, new Category(_category), _memory, _systemConsole, _fileWriter);
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

    public LoggerBuilder ToMemory()
    {
        _memory = new Memory();
        return this;
    }

    public LoggerBuilder WithXmlFormat()
    {
        _formatStrategy = new XmlFormatStrategy();
        return this;
    }
}
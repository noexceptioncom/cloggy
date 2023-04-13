using Cloggy.Formatters;
using Cloggy.Outputs;
using Cloggy.Providers;

namespace Cloggy;

public class LoggerBuilder
{
    private readonly string _category;
    private IFormatStrategy _formatStrategy;
    private Memory? _memory;
    private readonly List<IOutput> _outputs;

    public LoggerBuilder(string category)
    {
        _category = category;
        _memory = null;
        _formatStrategy = new PlainTextFormatStrategy();
        _outputs = new List<IOutput>();
    }

    public Logger Build()
    {
        return new Logger(new SystemDateProvider(), _formatStrategy, new Category(_category), _memory, new OutputCollection(_outputs.ToArray()));
    }

    public LoggerBuilder WithJsonFormat()
    {
        _formatStrategy = new JsonFormatStrategy();
        return this;
    }

    public LoggerBuilder ToConsole()
    {
        _outputs.Add(new SystemConsole());
        return this;
    }

    public LoggerBuilder ToFile(string fullPath)
    {
        _outputs.Add(new FileWriter(fullPath));
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
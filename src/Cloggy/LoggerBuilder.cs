using Cloggy.Formatters;
using Cloggy.Outputs;
using Cloggy.Providers;

namespace Cloggy;

public class LoggerBuilder
{
    private readonly string _category;

    public LoggerBuilder(string category)
    {
        _category = category;
    }

    public Logger Build()
    {
        return new Logger(new SystemConsole(), new SystemDateProvider(), new Category(_category), new JsonFormatStrategy());
    }
}
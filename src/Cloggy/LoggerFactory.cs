using Cloggy.Formatters;
using Cloggy.Outputs;
using Cloggy.Providers;

namespace Cloggy;

public class LoggerFactory
{
    public static Logger CreateJsonLoggerToConsole(string category)
    {
        return new LoggerBuilder(category).WithJsonFormat().ToConsole().Build();
    }

    public static Logger CreatePlainTextLoggerToConsole(string category)
    {
        return new LoggerBuilder(category).ToConsole().Build();
    }

    public static Logger CreateJsonLoggerToFile(string category, string fullPath)
    {
        return new LoggerBuilder(category).WithJsonFormat().ToFile(fullPath).Build();
    }

    public static Logger CreatePlainTextLoggerToFile(string category, string fullPath)
    {
        return new LoggerBuilder(category).ToFile(fullPath).Build();
    }

    public static Logger CreateJsonLoggerToFileAndConsole(string category, string fullPath)
    {
        return new LoggerBuilder(category).WithJsonFormat().ToFile(fullPath).ToConsole().Build();
    }

    public static Logger CreatePlainTextLoggerToFileAndConsole(string category, string fullPath)
    {
        return new LoggerBuilder(category).ToFile(fullPath).ToConsole().Build();
    }
    
    public static Logger CreateLoggerInMemory(string category)
    {
        return new LoggerBuilder(category).ToMemory().Build();
    }

    public static Logger CreateXmlLoggerToFile(string category, string fullPath)
    {
        return new LoggerBuilder(category).WithXmlFormat().ToFile(fullPath).Build();
    }

    public static Logger CreateXmlLoggerToFileAndConsole(string category, string fullPath)
    {
        return new Logger(new SystemConsole(), new SystemDateProvider(), new Category(category), new XmlFormatStrategy(),
            new FileWriter(fullPath));
    }
}
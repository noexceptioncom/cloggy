namespace Cloggy;

public class LoggerFactory
{
    public static Logger CreateJsonLoggerToConsole(string category)
    {
        return new Logger(new SystemConsole(), new SystemDateProvider(), new Category(category), true);
    }

    public static Logger CreatePlainTextLoggerToConsole(string category)
    {
        return new Logger(new SystemConsole(), new SystemDateProvider(), new Category(category), false);
    }

    public static Logger CreateJsonLoggerToFile(string category, string fullPath)
    {
        return new Logger(null, new SystemDateProvider(), new Category(category), true,
            new FileWriter(fullPath));
    }

    public static Logger CreatePlainTextLoggerToFile(string category, string fullPath)
    {
        return new Logger(null, new SystemDateProvider(), new Category(category), false,
            new FileWriter(fullPath));
    }

    public static Logger CreateJsonLoggerToFileAndConsole(string category, string fullPath)
    {
        return new Logger(new SystemConsole(), new SystemDateProvider(), new Category(category), true,
            new FileWriter(fullPath));
    }

    public static Logger CreatePlainTextLoggerToFileAndConsole(string category, string fullPath)
    {
        return new Logger(new SystemConsole(), new SystemDateProvider(), new Category(category), false,
            new FileWriter(fullPath));
    }
    
    public static Logger CreateLoggerInMemory(string category)
    {
        return new Logger(null, new SystemDateProvider(), new Category(category), false,
            null, new Memory());
    }
}
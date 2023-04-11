namespace Cloggy;

public class Logger
{
    private readonly IConsole? _console;
    private readonly IDateTimeProvider _dateTimeProvider;
    private readonly Category _category;
    private readonly IFileWriter? _fileWriter;
    private readonly MessageFormatter _messageFormatter;

    public Logger(IConsole? console, IDateTimeProvider dateTimeProvider, Category category, bool asJson,
        IFileWriter? fileWriter = null)
    {
        _console = console;
        _dateTimeProvider = dateTimeProvider;
        _category = category;
        _fileWriter = fileWriter;
        _messageFormatter = new MessageFormatter(asJson);
    }

    private void Log(string? message, LogLevel logLevel)
    {
        var formattedMessage = _messageFormatter.FormatMessage(new Message(message, logLevel, _dateTimeProvider.Now(), _category));
        _fileWriter?.WriteLine(formattedMessage);
        _console?.WriteLine(formattedMessage);
    }

    public void LogInformation(string? message) => Log(message, LogLevel.INF);

    public void LogWarning(string? message) => Log(message, LogLevel.WRN);

    public void LogError(string? message) => Log(message, LogLevel.ERR);
}
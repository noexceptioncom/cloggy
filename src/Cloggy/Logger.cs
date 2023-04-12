namespace Cloggy;

public class Logger
{
    private readonly IConsole? _console;
    private readonly IDateTimeProvider _dateTimeProvider;
    private readonly Category _category;
    private readonly IFileWriter? _fileWriter;
    private readonly Memory? _memory;
    private readonly MessageFormatter _messageFormatter;

    public Logger(IConsole? console, IDateTimeProvider dateTimeProvider, Category category, bool asJson,
        IFileWriter? fileWriter = null, Memory? memory = null)
    {
        _console = console;
        _dateTimeProvider = dateTimeProvider;
        _category = category;
        _fileWriter = fileWriter;
        _memory = memory;
        _messageFormatter = new MessageFormatter(asJson, false);
    }

    private void Log(string? message, LogLevel logLevel)
    {
        var messageObject = new Message(message, logLevel, _dateTimeProvider.Now(), _category);
        var formattedMessage = _messageFormatter.FormatMessage(messageObject);
        _fileWriter?.WriteLine(formattedMessage);
        _console?.WriteLine(formattedMessage);
        _memory?.AddMessage(messageObject);
    }

    public void LogInformation(string? message) => Log(message, LogLevel.INF);

    public void LogWarning(string? message) => Log(message, LogLevel.WRN);

    public void LogError(string? message) => Log(message, LogLevel.ERR);
}
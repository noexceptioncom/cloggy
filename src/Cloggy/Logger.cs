using Cloggy.Formatters;
using Cloggy.Outputs;
using Cloggy.Providers;

namespace Cloggy;

public class Logger
{
    private readonly IConsole? _console;
    private readonly IDateTimeProvider _dateTimeProvider;
    private readonly Category _category;
    private readonly IFileWriter? _fileWriter;
    private readonly Memory? _memory;
    private readonly IFormatStrategy _formatStrategy;

    public Logger(IDateTimeProvider dateTimeProvider, IFormatStrategy formatStrategy,
        Category category, Memory? memory = null, IConsole? console = null, IFileWriter? fileWriter = null)
    {
        _console = console;
        _dateTimeProvider = dateTimeProvider;
        _category = category;
        _fileWriter = fileWriter;
        _memory = memory;
        _formatStrategy = formatStrategy;
    }

    private void Log(string? message, LogLevel logLevel)
    {
        var messageObject = new Message(message, logLevel, _dateTimeProvider.Now(), _category);
        var formattedMessage = _formatStrategy.FormatMessage(messageObject);
        _fileWriter?.WriteLine(formattedMessage);
        _console?.WriteLine(formattedMessage);
        _memory?.AddMessage(messageObject);
    }

    public void LogInformation(string? message) => Log(message, LogLevel.INF);

    public void LogWarning(string? message) => Log(message, LogLevel.WRN);

    public void LogError(string? message) => Log(message, LogLevel.ERR);
}
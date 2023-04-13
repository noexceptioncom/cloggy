using Cloggy.Formatters;
using Cloggy.Providers;

namespace Cloggy;

public class Logger
{
    private readonly IDateTimeProvider _dateTimeProvider;
    private readonly Category _category;
    private readonly Memory? _memory;
    private readonly IFormatStrategy _formatStrategy;
    private readonly OutputCollection _outputs;

    public Logger(IDateTimeProvider dateTimeProvider, IFormatStrategy formatStrategy,
        Category category, Memory? memory, OutputCollection outputCollection)
    {
        _dateTimeProvider = dateTimeProvider;
        _category = category;
        _outputs = outputCollection;
        _memory = memory;
        _formatStrategy = formatStrategy;
    }

    private void Log(string? message, LogLevel logLevel)
    {
        var messageObject = new Message(message, logLevel, _dateTimeProvider.Now(), _category);
        var formattedMessage = _formatStrategy.FormatMessage(messageObject);
        _outputs.Write(formattedMessage);
        _memory?.AddMessage(messageObject);
    }

    public void LogInformation(string? message) => Log(message, LogLevel.INF);

    public void LogWarning(string? message) => Log(message, LogLevel.WRN);

    public void LogError(string? message) => Log(message, LogLevel.ERR);
}
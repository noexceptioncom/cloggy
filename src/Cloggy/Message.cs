namespace Cloggy;

public class Message
{
    private string? _text;
    private LogLevel _logLevel;
    private DateTime _timestamp;
    private Category _category;

    public Message(string? message, LogLevel logLevel, DateTime timestamp, Category category)
    {
        _text = message;
        _logLevel = logLevel;
        _timestamp = timestamp;
        _category = category;
    }

    public string? Text => _text;

    public string LogLevel => _logLevel.ToString();

    public string Category => _category.ToString();

    public string Timestamp => _timestamp.ToString("s");
}
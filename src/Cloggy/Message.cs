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

    private bool Equals(Message other)
    {
        return _text == other._text && _logLevel == other._logLevel && _timestamp.Equals(other._timestamp) && _category.Equals(other._category);
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((Message)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(_text, (int)_logLevel, _timestamp, _category);
    }
}
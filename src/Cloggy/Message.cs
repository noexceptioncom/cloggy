namespace Cloggy;

public class Message
{
    public Message(string? message, LogLevel logLevel, DateTime timestamp, Category category)
    {
        Text = message;
        LogLevel = logLevel;
        Timestamp = timestamp;
        Category = category;
    }

    public string? Text { get; private set; }
    public LogLevel LogLevel { get; private set; }
    public DateTime Timestamp { get; private set; }
    public Category Category { get; private set; }
}
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

public class MessageFormatter
{
    private readonly bool _asJson;

    public MessageFormatter(bool asJson)
    {
        _asJson = asJson;
    }

    public string FormatMessage(Message message)
    {
        if (_asJson)
        {
            return FormatMessageAsJson(message);
        }

        return FormatMessageAsPlainText(message);
    }

    private string FormatMessageAsPlainText(Message message)
    {
        var header = string.Join(' ', GetDateTimeFormat(message.Timestamp), message.LogLevel.ToString(), $"({message.Category})").Trim();
        return $"[{header}] {message.Text}";
    }

    private string FormatMessageAsJson(Message message)
    {
        return
            $$"""{"timestamp":"{{GetDateTimeFormat(message.Timestamp)}}","logLevel":"{{message.LogLevel}}","category":"{{message.Category}}","message":"{{message.Text}}"}""";
    }

    private string GetDateTimeFormat(DateTime timestamp) => timestamp.ToString("s");
}
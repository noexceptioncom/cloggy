namespace Cloggy;

public class MessageFormatter
{
    private readonly bool _asJson;
    private readonly Category _category;

    public MessageFormatter(bool asJson, Category category)
    {
        _asJson = asJson;
        _category = category;
    }

    public string FormatMessage(string? message, LogLevel logLevel, DateTime timestamp)
    {
        if (_asJson)
        {
            return FormatMessageAsJson(message, logLevel, timestamp, _category);
        }

        return FormatMessageAsPlainText(message, logLevel, timestamp, _category);
    }

    private string FormatMessageAsPlainText(string? message, LogLevel logLevel, DateTime timestamp, Category category)
    {
        var header = string.Join(' ', GetDateTimeFormat(timestamp), logLevel.ToString(), $"({category})").Trim();
        return $"[{header}] {message}";
    }

    private string FormatMessageAsJson(string? message, LogLevel logLevel, DateTime timestamp, Category category)
    {
        return
            $$"""{"timestamp":"{{GetDateTimeFormat(timestamp)}}","logLevel":"{{logLevel}}","category":"{{category}}","message":"{{message}}"}""";
    }

    private string GetDateTimeFormat(DateTime timestamp) => timestamp.ToString("s");
}
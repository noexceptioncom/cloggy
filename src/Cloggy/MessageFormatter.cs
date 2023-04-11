namespace Cloggy;

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
        var header = string.Join(' ', message.Timestamp, message.LogLevel, $"({message.Category})").Trim();
        return $"[{header}] {message.Text}";
    }

    private string FormatMessageAsJson(Message message)
    {
        return
            $$"""{"timestamp":"{{message.Timestamp}}","logLevel":"{{message.LogLevel}}","category":"{{message.Category}}","message":"{{message.Text}}"}""";
    }
}
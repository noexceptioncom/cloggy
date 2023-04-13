namespace Cloggy;

public class FormatStrategy
{
    private MessageFormatter _messageFormatter;

    public FormatStrategy(MessageFormatter messageFormatter)
    {
        _messageFormatter = messageFormatter;
    }

    public string FormatMessageByStrategy(Message message)
    {
        if (_messageFormatter.Format == Format.Json)
        {
            return FormatMessageAsJson(message);
        }

        if (_messageFormatter.Format == Format.Xml)
        {
            return FormatMessageAsXML(message);
        }

        return FormatMessageAsPlainText(message);
    }

    private static string FormatMessageAsXML(Message message)
    {
        return
            $$"""<log timestamp="{{message.Timestamp}}" loglevel="{{message.LogLevel}}" category="{{message.Category}}" message="{{message.Text}}"></log>""";
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
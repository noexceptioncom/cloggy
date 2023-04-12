namespace Cloggy;

public class MessageFormatter
{
    private readonly bool _asJson;
    private readonly bool _asXml;

    public MessageFormatter(bool asJson, bool asXML)
    {
        _asJson = asJson;
        _asXml = asXML;
    }

    public string FormatMessage(Message message)
    {
        if (_asJson)
        {
            return FormatMessageAsJson(message);
        }

        if (_asXml)
        {
            return
                """<log timestamp="2023-03-04T21:30:06" loglevel="INF" category="category" message="mensaje"></log>""";
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
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
namespace Cloggy;

public class XmlFormatStrategy : IFormatStrategy
{
    public string FormatMessageByStrategy(Message message)
    {
        return
            $$"""<log timestamp="{{message.Timestamp}}" loglevel="{{message.LogLevel}}" category="{{message.Category}}" message="{{message.Text}}"></log>""";
    }
}
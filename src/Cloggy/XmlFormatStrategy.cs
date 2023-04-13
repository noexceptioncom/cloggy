namespace Cloggy;

public class XmlFormatStrategy : IFormatStrategy
{
    public string FormatMessage(Message message)
    {
        return
            $$"""<log timestamp="{{message.Timestamp}}" loglevel="{{message.LogLevel}}" category="{{message.Category}}" message="{{message.Text}}"></log>""";
    }
}
namespace Cloggy;

public abstract class FormatStrategy
{
    private Format _format;

    protected FormatStrategy(Format format)
    {
        _format = format;
    }

    public abstract string FormatMessageByStrategy(Message message);
}

public class PlainTextFormatStrategy : FormatStrategy
{
    public PlainTextFormatStrategy() : base(Format.PlainText)
    {
    }

    public override string FormatMessageByStrategy(Message message)
    {
        var header = string.Join(' ', message.Timestamp, message.LogLevel, $"({message.Category})").Trim();
        return $"[{header}] {message.Text}";
    }
}

public class JsonFormatStrategy : FormatStrategy
{
    public JsonFormatStrategy() : base(Format.Json)
    {
    }

    public override string FormatMessageByStrategy(Message message)
    {
        return
            $$"""{"timestamp":"{{message.Timestamp}}","logLevel":"{{message.LogLevel}}","category":"{{message.Category}}","message":"{{message.Text}}"}""";
    }
}

public class XmlFormatStrategy : FormatStrategy
{
    public XmlFormatStrategy() : base(Format.Xml)
    {
    }

    public override string FormatMessageByStrategy(Message message)
    {
        return
            $$"""<log timestamp="{{message.Timestamp}}" loglevel="{{message.LogLevel}}" category="{{message.Category}}" message="{{message.Text}}"></log>""";
    }
}
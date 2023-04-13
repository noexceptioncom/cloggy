namespace Cloggy;

public class MessageFormatter
{
    private readonly IFormatStrategy _formatStrategy;

    public MessageFormatter(Format format)
    {
        if (format == Format.Json)
        {
            _formatStrategy = new JsonFormatStrategy();
        }
        else if(format == Format.Xml)
        {
            _formatStrategy = new XmlFormatStrategy();
        }
        else
        {
            _formatStrategy = new PlainTextFormatStrategy();
        }
    }

    public string FormatMessage(Message message)
    {
        return _formatStrategy.FormatMessage(message);
    }
}
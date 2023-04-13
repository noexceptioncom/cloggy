namespace Cloggy;

public class MessageFormatter
{
    private readonly Format _format;
    private readonly FormatStrategy _formatStrategy;

    public MessageFormatter(Format format)
    {
        _format = format;
        _formatStrategy = new FormatStrategy(this);
    }

    public Format Format
    {
        get { return _format; }
    }

    public string FormatMessage(Message message)
    {
        return _formatStrategy.FormatMessageByStrategy(message);
    }
}
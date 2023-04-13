namespace Cloggy;

public class PlainTextFormatStrategy : IFormatStrategy
{
    public string FormatMessageByStrategy(Message message)
    {
        var header = string.Join(' ', message.Timestamp, message.LogLevel, $"({message.Category})").Trim();
        return $"[{header}] {message.Text}";
    }
}
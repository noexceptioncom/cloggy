namespace Cloggy.Formatters;

public class PlainTextFormatStrategy : IFormatStrategy
{
    public string FormatMessage(Message message)
    {
        var header = string.Join(' ', message.Timestamp, message.LogLevel, $"({message.Category})").Trim();
        return $"[{header}] {message.Text}";
    }
}
namespace Cloggy;

public class JsonFormatStrategy : IFormatStrategy
{
    public string FormatMessageByStrategy(Message message)
    {
        return
            $$"""{"timestamp":"{{message.Timestamp}}","logLevel":"{{message.LogLevel}}","category":"{{message.Category}}","message":"{{message.Text}}"}""";
    }
}
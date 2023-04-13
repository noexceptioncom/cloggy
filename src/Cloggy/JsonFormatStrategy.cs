namespace Cloggy;

public class JsonFormatStrategy : IFormatStrategy
{
    public string FormatMessage(Message message)
    {
        return
            $$"""{"timestamp":"{{message.Timestamp}}","logLevel":"{{message.LogLevel}}","category":"{{message.Category}}","message":"{{message.Text}}"}""";
    }
}
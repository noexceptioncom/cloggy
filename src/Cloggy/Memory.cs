namespace Cloggy;

public class Memory
{
    public void AddMessage(Message message)
    {
        
    }

    public IEnumerable<Message> ReadAll()
    {
        return new List<Message>()
        {
            new Message("message", LogLevel.INF, DateTime.Parse("2023-03-30T21:30:06"),
                new Category("category"))
        };
    }
}
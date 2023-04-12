namespace Cloggy;

public class Memory
{
    private readonly IList<Message> _messages;

    public Memory()
    {
        _messages = new List<Message>();
    }

    public void AddMessage(Message message)
    {
        _messages.Add(message);
    }

    public IEnumerable<Message> ReadAll()
    {
        return _messages;
    }
}
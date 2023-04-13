using Cloggy.Outputs;

namespace Cloggy;

public class OutputCollection
{
    private readonly IEnumerable<IOutput> _outputs;

    public OutputCollection(params IOutput[] outputs)
    {
        _outputs = outputs;
    }

    public void Write(string formattedMessage)
    {
        foreach (var output in _outputs)
        {
            output.WriteLine(formattedMessage);
        }
    }
}
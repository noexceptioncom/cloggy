namespace Cloggy;

public class Category
{
    private readonly string _name;

    public Category(string name)
    {
        ValidateName(name);
        _name = name;
    }

    private static void ValidateName(string name)
    {
        if (string.IsNullOrWhiteSpace(name) || name.Contains('\n'))
            throw new ArgumentNullException(nameof(name),
                "The category cannot be empty nor contain a new line char");
    }

    public override string ToString()
    {
        return $"({_name})";
    }
}
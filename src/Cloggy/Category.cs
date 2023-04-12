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
        return $"{_name}";
    }

    private bool Equals(Category other)
    {
        return _name == other._name;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((Category)obj);
    }

    public override int GetHashCode()
    {
        return _name.GetHashCode();
    }

}
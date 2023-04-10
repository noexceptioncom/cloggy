namespace Cloggy;

public class Category
{
    private readonly string _value;

    public Category(string value)
    {
        CheckCategoryIsValid(value);
        _value = value;
    }

    private static void CheckCategoryIsValid(string category)
    {
        if (string.IsNullOrWhiteSpace(category) || category.Contains('\n'))
            throw new ArgumentNullException(nameof(category),
                "The category cannot be empty nor contain a new line char");
    }

    public override string ToString()
    {
        return $"({_value})";
    }
}
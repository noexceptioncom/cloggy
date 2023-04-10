using FluentAssertions;

namespace Cloggy.Tests;

public class CategoryShould
{
    [TestCase("")]
    [TestCase("    ")]
    [TestCase("ca\ntegory")]
    public void NotBeConstructedWhenNameIsNotValid(string categoryName)
    {
        Action action = () => new Category(categoryName);
        
        action.Should().Throw<ArgumentNullException>();
    }
}
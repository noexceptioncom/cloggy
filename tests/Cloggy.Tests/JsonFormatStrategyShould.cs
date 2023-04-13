using FluentAssertions;

namespace Cloggy.Tests;

public class JsonFormatStrategyShould
{
    private IFormatStrategy _jsonFormatStrategy;

    [SetUp]
    public void SetUp()
    {
        _jsonFormatStrategy = new JsonFormatStrategy();
    }

    [Test]
    public void FormatMessageAsJson()
    {
        var result = _jsonFormatStrategy.FormatMessage(new Message("hola mundo", LogLevel.INF,
            DateTime.Parse("2023-03-30T21:30:06"), new Category("Acategory")));

        var expectedResult =
            """{"timestamp":"2023-03-30T21:30:06","logLevel":"INF","category":"Acategory","message":"hola mundo"}""";
        result.Should().Be(expectedResult);
    }

    [Test]
    public void FormatMessageAsJsonWithAnotherMessage()
    {
        var result = _jsonFormatStrategy.FormatMessage(new Message("otro mensaje", LogLevel.INF,
            DateTime.Parse("2023-03-30T21:30:06"), new Category("Acategory")));

        var expectedResult =
            """{"timestamp":"2023-03-30T21:30:06","logLevel":"INF","category":"Acategory","message":"otro mensaje"}""";
        result.Should().Be(expectedResult);
    }

    [Test]
    public void FormatMessageAsJsonWithAnotherCategory()
    {
        var result = _jsonFormatStrategy.FormatMessage(new Message("otro mensaje", LogLevel.INF,
            DateTime.Parse("2023-03-30T21:30:06"), new Category("AnotherCategory")));


        var expectedResult =
            """{"timestamp":"2023-03-30T21:30:06","logLevel":"INF","category":"AnotherCategory","message":"otro mensaje"}""";
        result.Should().Be(expectedResult);
    }

    [Test]
    public void FormatMessageAsJsonWithAnotherLogLevel()
    {
        var result = _jsonFormatStrategy.FormatMessage(new Message("otro mensaje", LogLevel.WRN,
            DateTime.Parse("2023-03-30T21:30:06"), new Category("AnotherCategory")));

        var expectedResult =
            """{"timestamp":"2023-03-30T21:30:06","logLevel":"WRN","category":"AnotherCategory","message":"otro mensaje"}""";
        result.Should().Be(expectedResult);
    }

    [Test]
    public void FormatMessageAsJsonWithCustomDate()
    {
        var result = _jsonFormatStrategy.FormatMessage(new Message("otro mensaje", LogLevel.WRN,
            DateTime.Parse("2023-03-04T21:30:06"), new Category("AnotherCategory")));

        var expectedResult =
            """{"timestamp":"2023-03-04T21:30:06","logLevel":"WRN","category":"AnotherCategory","message":"otro mensaje"}""";
        result.Should().Be(expectedResult);
    }
}
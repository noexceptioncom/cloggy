using Cloggy.Formatters;
using FluentAssertions;

namespace Cloggy.Tests;

public class PlainTextFormatStrategyShould
{
    private IFormatStrategy _plainTextFormatStrategy;

    [SetUp]
    public void SetUp()
    {
        _plainTextFormatStrategy = new PlainTextFormatStrategy();
    }

    [TestCase("", "[2023-03-30T21:30:06 INF (category)] ")]
    [TestCase("juanvi", "[2023-03-30T21:30:06 INF (category)] juanvi")]
    [TestCase(null, "[2023-03-30T21:30:06 INF (category)] ")]
    public void FormatAMessage(string messageInput, string expectedMessage)
    {
        var message = _plainTextFormatStrategy.FormatMessage(new Message(messageInput, LogLevel.INF,
            DateTime.Parse("2023-03-30T21:30:06"), new Category("category")));

        message.Should().Be(expectedMessage);
    }

    [TestCase("ACategory", "A message")]
    [TestCase("OtherCategory", "Other message")]
    [TestCase("AnotherCategory", "Another message")]
    public void FormatCategories(string category, string message)
    {
        var result = _plainTextFormatStrategy.FormatMessage(new Message(message, LogLevel.INF,
            DateTime.Parse("2023-03-30T21:30:06"), new Category(category)));

        result.Should().Be($"[2023-03-30T21:30:06 INF ({category})] {message}");
    }

    [TestCase(LogLevel.INF, "[2023-03-30T21:30:06 INF (category)] hola mundo")]
    [TestCase(LogLevel.WRN, "[2023-03-30T21:30:06 WRN (category)] hola mundo")]
    [TestCase(LogLevel.ERR, "[2023-03-30T21:30:06 ERR (category)] hola mundo")]
    public void FormatLogLevel(LogLevel logLevel, string expectedResult)
    {
        var result = _plainTextFormatStrategy.FormatMessage(new Message("hola mundo", logLevel,
            DateTime.Parse("2023-03-30T21:30:06"), new Category("category")));

        result.Should().Be(expectedResult);
    }

    [TestCase("2023-03-30T06:30:06", "[2023-03-30T06:30:06 INF (category)] hola mundo")]
    [TestCase("2023-03-30T14:30:06", "[2023-03-30T14:30:06 INF (category)] hola mundo")]
    [TestCase("2023-03-30T21:30:06", "[2023-03-30T21:30:06 INF (category)] hola mundo")]
    public void FormatTimestamp(string timestamp, string expectedResult)
    {
        var result = _plainTextFormatStrategy.FormatMessage(new Message("hola mundo", LogLevel.INF,
            DateTime.Parse(timestamp), new Category("category")));

        result.Should().Be(expectedResult);
    }
}
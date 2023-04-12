using FluentAssertions;

namespace Cloggy.Tests;

public class MessageFormatterShould
{
    private MessageFormatter _plainTextMessageFormatter;

    [SetUp]
    public void SetUp()
    {
        _plainTextMessageFormatter = new MessageFormatter(false);
    }

    [Test]
    public void FormatEmptyMessage()
    {
        var message = _plainTextMessageFormatter.FormatMessage(new Message(string.Empty, LogLevel.INF, DateTime.Parse("2023-03-30T21:30:06"), new Category("category")));

        message.Should().Be("[2023-03-30T21:30:06 INF (category)] ");
    }

    [Test]
    public void FormatOneWordMessage()
    {
        var message = _plainTextMessageFormatter.FormatMessage(new Message("juanvi", LogLevel.INF, DateTime.Parse("2023-03-30T21:30:06"), new Category("category")));
        
        message.Should().Be("[2023-03-30T21:30:06 INF (category)] juanvi");
    }

    [Test]
    public void FormatNullMessage()
    {
        var message = _plainTextMessageFormatter.FormatMessage(new Message(null, LogLevel.INF, DateTime.Parse("2023-03-30T21:30:06"), new Category("category")));

        message.Should().Be("[2023-03-30T21:30:06 INF (category)] ");
    }

    [TestCase("ACategory", "A message")]
    [TestCase("OtherCategory", "Other message")]
    [TestCase("AnotherCategory", "Another message")]
    public void FormatCategories(string category, string message)
    {
        var result = _plainTextMessageFormatter.FormatMessage(new Message(message, LogLevel.INF, DateTime.Parse("2023-03-30T21:30:06"), new Category(category)));

        result.Should().Be($"[2023-03-30T21:30:06 INF ({category})] {message}");
    }

    [TestCase(LogLevel.INF, "[2023-03-30T21:30:06 INF (category)] hola mundo")]
    [TestCase(LogLevel.WRN, "[2023-03-30T21:30:06 WRN (category)] hola mundo")]
    [TestCase(LogLevel.ERR, "[2023-03-30T21:30:06 ERR (category)] hola mundo")]
    public void FormatLogLevel(LogLevel logLevel, string expectedResult)
    {
        var result = _plainTextMessageFormatter.FormatMessage(new Message("hola mundo", logLevel, DateTime.Parse("2023-03-30T21:30:06"), new Category("category")));
        
        result.Should().Be(expectedResult);
    }

    [TestCase("2023-03-30T06:30:06", "[2023-03-30T06:30:06 INF (category)] hola mundo")]
    [TestCase("2023-03-30T14:30:06", "[2023-03-30T14:30:06 INF (category)] hola mundo")]
    [TestCase("2023-03-30T21:30:06", "[2023-03-30T21:30:06 INF (category)] hola mundo")]
    public void FormatTimestamp(string timestamp, string expectedResult)
    {
        var result = _plainTextMessageFormatter.FormatMessage(new Message("hola mundo", LogLevel.INF, DateTime.Parse(timestamp), new Category("category")));
        
        result.Should().Be(expectedResult);
    }
}
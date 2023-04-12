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
}
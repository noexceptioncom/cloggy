using FluentAssertions;

namespace Cloggy.Tests;

public class MessageFormatterShould
{
    private MessageFormatter _plainTextMessageFormatter;
    private MessageFormatter _jsonMessageFormatter;

    [SetUp]
    public void SetUp()
    {
        _plainTextMessageFormatter = new MessageFormatter(false,false);
        _jsonMessageFormatter = new MessageFormatter(true,false);
    }

    [TestCase("", "[2023-03-30T21:30:06 INF (category)] ")]
    [TestCase("juanvi", "[2023-03-30T21:30:06 INF (category)] juanvi")]
    [TestCase(null, "[2023-03-30T21:30:06 INF (category)] ")]
    public void FormatAMessage(string messageInput, string expectedMessage)
    {
        var message = _plainTextMessageFormatter.FormatMessage(new Message(messageInput, LogLevel.INF,
            DateTime.Parse("2023-03-30T21:30:06"), new Category("category")));

        message.Should().Be(expectedMessage);
    }

    [TestCase("ACategory", "A message")]
    [TestCase("OtherCategory", "Other message")]
    [TestCase("AnotherCategory", "Another message")]
    public void FormatCategories(string category, string message)
    {
        var result = _plainTextMessageFormatter.FormatMessage(new Message(message, LogLevel.INF,
            DateTime.Parse("2023-03-30T21:30:06"), new Category(category)));

        result.Should().Be($"[2023-03-30T21:30:06 INF ({category})] {message}");
    }

    [TestCase(LogLevel.INF, "[2023-03-30T21:30:06 INF (category)] hola mundo")]
    [TestCase(LogLevel.WRN, "[2023-03-30T21:30:06 WRN (category)] hola mundo")]
    [TestCase(LogLevel.ERR, "[2023-03-30T21:30:06 ERR (category)] hola mundo")]
    public void FormatLogLevel(LogLevel logLevel, string expectedResult)
    {
        var result = _plainTextMessageFormatter.FormatMessage(new Message("hola mundo", logLevel,
            DateTime.Parse("2023-03-30T21:30:06"), new Category("category")));

        result.Should().Be(expectedResult);
    }

    [TestCase("2023-03-30T06:30:06", "[2023-03-30T06:30:06 INF (category)] hola mundo")]
    [TestCase("2023-03-30T14:30:06", "[2023-03-30T14:30:06 INF (category)] hola mundo")]
    [TestCase("2023-03-30T21:30:06", "[2023-03-30T21:30:06 INF (category)] hola mundo")]
    public void FormatTimestamp(string timestamp, string expectedResult)
    {
        var result = _plainTextMessageFormatter.FormatMessage(new Message("hola mundo", LogLevel.INF,
            DateTime.Parse(timestamp), new Category("category")));

        result.Should().Be(expectedResult);
    }

    [Test]
    public void FormatMessageAsJson()
    {
        var result = _jsonMessageFormatter.FormatMessage(new Message("hola mundo", LogLevel.INF,
            DateTime.Parse("2023-03-30T21:30:06"), new Category("Acategory")));

        var expectedResult =
            """{"timestamp":"2023-03-30T21:30:06","logLevel":"INF","category":"Acategory","message":"hola mundo"}""";
        result.Should().Be(expectedResult);
    }

    [Test]
    public void FormatMessageAsJsonWithAnotherMessage()
    {
        var result = _jsonMessageFormatter.FormatMessage(new Message("otro mensaje", LogLevel.INF,
            DateTime.Parse("2023-03-30T21:30:06"), new Category("Acategory")));

        var expectedResult =
            """{"timestamp":"2023-03-30T21:30:06","logLevel":"INF","category":"Acategory","message":"otro mensaje"}""";
        result.Should().Be(expectedResult);
    }

    [Test]
    public void FormatMessageAsJsonWithAnotherCategory()
    {
        var result = _jsonMessageFormatter.FormatMessage(new Message("otro mensaje", LogLevel.INF,
            DateTime.Parse("2023-03-30T21:30:06"), new Category("AnotherCategory")));


        var expectedResult =
            """{"timestamp":"2023-03-30T21:30:06","logLevel":"INF","category":"AnotherCategory","message":"otro mensaje"}""";
        result.Should().Be(expectedResult);
    }

    [Test]
    public void FormatMessageAsJsonWithAnotherLogLevel()
    {
        var result = _jsonMessageFormatter.FormatMessage(new Message("otro mensaje", LogLevel.WRN,
            DateTime.Parse("2023-03-30T21:30:06"), new Category("AnotherCategory")));

        var expectedResult =
            """{"timestamp":"2023-03-30T21:30:06","logLevel":"WRN","category":"AnotherCategory","message":"otro mensaje"}""";
        result.Should().Be(expectedResult);
    }

    [Test]
    public void FormatMessageAsJsonWithCustomDate()
    {
        var result = _jsonMessageFormatter.FormatMessage(new Message("otro mensaje", LogLevel.WRN,
            DateTime.Parse("2023-03-04T21:30:06"), new Category("AnotherCategory")));

        var expectedResult =
            """{"timestamp":"2023-03-04T21:30:06","logLevel":"WRN","category":"AnotherCategory","message":"otro mensaje"}""";
        result.Should().Be(expectedResult);
    }

    [Test]
    public void FormatMessageAsXML()
    {
        var result = new MessageFormatter(false,true).FormatMessage(new Message("mensaje", LogLevel.INF,
            DateTime.Parse("2023-03-04T21:30:06"), new Category("category")));

        var expectedResult = """<log timestamp="2023-03-04T21:30:06" loglevel="INF" category="category" message="mensaje"></log>""";

        result.Should().Be(expectedResult);
    }

    [Test]
    public void FormatOtherMessageAsXML()
    {
        var result = new MessageFormatter(false,true).FormatMessage(new Message("otro mensaje", LogLevel.INF,
            DateTime.Parse("2023-03-04T21:30:06"), new Category("category")));

        var expectedResult = """<log timestamp="2023-03-04T21:30:06" loglevel="INF" category="category" message="otro mensaje"></log>""";

        result.Should().Be(expectedResult);
    }

    [Test]
    public void FormatAnotherCategoryAsXML()
    {
        var result = new MessageFormatter(false,true).FormatMessage(new Message("otro mensaje", LogLevel.INF,
            DateTime.Parse("2023-03-04T21:30:06"), new Category("ACategory")));

        var expectedResult = """<log timestamp="2023-03-04T21:30:06" loglevel="INF" category="ACategory" message="otro mensaje"></log>""";

        result.Should().Be(expectedResult);
    }
}
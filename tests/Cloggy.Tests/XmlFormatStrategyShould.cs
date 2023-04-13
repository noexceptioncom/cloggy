using Cloggy.Formatters;
using FluentAssertions;

namespace Cloggy.Tests;

public class XmlFormatStrategyShould
{
    private IFormatStrategy _xmlFormatStrategy;

    [SetUp]
    public void SetUp()
    {
        _xmlFormatStrategy = new XmlFormatStrategy();
    }

    [Test]
    public void FormatMessageAsXML()
    {
        var result = _xmlFormatStrategy.FormatMessage(new Message("mensaje", LogLevel.INF,
            DateTime.Parse("2023-03-04T21:30:06"), new Category("category")));

        var expectedResult = """<log timestamp="2023-03-04T21:30:06" loglevel="INF" category="category" message="mensaje"></log>""";

        result.Should().Be(expectedResult);
    }

    [Test]
    public void FormatOtherMessageAsXML()
    {
        var result = _xmlFormatStrategy.FormatMessage(new Message("otro mensaje", LogLevel.INF,
            DateTime.Parse("2023-03-04T21:30:06"), new Category("category")));

        var expectedResult = """<log timestamp="2023-03-04T21:30:06" loglevel="INF" category="category" message="otro mensaje"></log>""";

        result.Should().Be(expectedResult);
    }

    [Test]
    public void FormatAnotherCategoryAsXML()
    {
        var result = _xmlFormatStrategy.FormatMessage(new Message("otro mensaje", LogLevel.INF,
            DateTime.Parse("2023-03-04T21:30:06"), new Category("ACategory")));

        var expectedResult = """<log timestamp="2023-03-04T21:30:06" loglevel="INF" category="ACategory" message="otro mensaje"></log>""";

        result.Should().Be(expectedResult);
    }

    [Test]
    public void FormatAnotherLogLevelAsXML()
    {
        var result = _xmlFormatStrategy.FormatMessage(new Message("otro mensaje", LogLevel.WRN,
            DateTime.Parse("2023-03-04T21:30:06"), new Category("ACategory")));

        var expectedResult = """<log timestamp="2023-03-04T21:30:06" loglevel="WRN" category="ACategory" message="otro mensaje"></log>""";

        result.Should().Be(expectedResult);
    }

    [Test]
    public void FormatCustomDateAsXML()
    {
        var result = _xmlFormatStrategy.FormatMessage(new Message("otro mensaje", LogLevel.WRN,
            DateTime.Parse("2023-04-04T21:30:06"), new Category("ACategory")));

        var expectedResult = """<log timestamp="2023-04-04T21:30:06" loglevel="WRN" category="ACategory" message="otro mensaje"></log>""";

        result.Should().Be(expectedResult);
    }
}
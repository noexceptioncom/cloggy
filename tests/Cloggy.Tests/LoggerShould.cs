using FluentAssertions;
using NSubstitute;

namespace Cloggy.Tests;

public class LoggerShould
{
    private IConsole _console;
    private Logger _loggerWithDate;
    private IDateTimeProvider _dateTimeProvider;
    private IFileWriter _fileWriter;
    private readonly MessageFormatterShould _messageFormatterShould = new MessageFormatterShould();
    private const string Category = "category";

    [SetUp]
    public void SetUp()
    {
        _dateTimeProvider = Substitute.For<IDateTimeProvider>();
        _console = Substitute.For<IConsole>();
        _fileWriter = Substitute.For<IFileWriter>();
        _loggerWithDate = new Logger(_console, _dateTimeProvider, new Category(Category), false);
        _dateTimeProvider.Now().Returns(DateTime.Parse("2023-03-30T21:30:06"));
    }

    [Test]
    public void LogAMessageAsPlainTextToFile()
    {
        var logger = new Logger(null, _dateTimeProvider, new Category("AnotherCategory"), false, _fileWriter);

        logger.LogInformation("otro mensaje");

        _fileWriter.Received().WriteLine("[2023-03-30T21:30:06 INF (AnotherCategory)] otro mensaje");
    }

    [Test]
    public void LogAMessageAsPlainTextToFileAndConsole()
    {
        var logger = new Logger(_console, _dateTimeProvider, new Category("AnotherCategory"), false, _fileWriter);

        logger.LogInformation("otro mensaje");

        _fileWriter.Received().WriteLine("[2023-03-30T21:30:06 INF (AnotherCategory)] otro mensaje");
        _console.Received().WriteLine("[2023-03-30T21:30:06 INF (AnotherCategory)] otro mensaje");
    }
}
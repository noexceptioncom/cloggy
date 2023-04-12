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
    public void LogDateTimeWithEveryMessage()
    {
        _dateTimeProvider.Now().Returns(DateTime.Parse("2023-03-30T09:00:06"));
        _loggerWithDate.LogInformation("hola mundo");

        _console.Received().WriteLine("[2023-03-30T09:00:06 INF (category)] hola mundo");
    }

    [Test]
    public void LogDateTimeWithEveryMessageAtNight()
    {
        _loggerWithDate.LogInformation("hola mundo");

        _console.Received().WriteLine("[2023-03-30T21:30:06 INF (category)] hola mundo");
    }

    [Test]
    public void LogAnEntryWithInformationAslogLevel()
    {
        _loggerWithDate.LogInformation("hola mundo");

        _console.Received().WriteLine("[2023-03-30T21:30:06 INF (category)] hola mundo");
    }

    [Test]
    public void LogAnEntryWithWarningAsLogLevel()
    {
        _loggerWithDate.LogWarning("hola mundo");

        _console.Received().WriteLine("[2023-03-30T21:30:06 WRN (category)] hola mundo");
    }

    [Test]
    public void LogAnEntryWithErrorAsLogLevel()
    {
        _loggerWithDate.LogError("hola mundo");

        _console.Received().WriteLine("[2023-03-30T21:30:06 ERR (category)] hola mundo");
    }

    [Test]
    public void LogAMessageAsJson()
    {
        var logger = new Logger(_console, _dateTimeProvider, new Category("Acategory"), true);
        
        logger.LogInformation("hola mundo");
        
        _console.Received().WriteLine("""{"timestamp":"2023-03-30T21:30:06","logLevel":"INF","category":"Acategory","message":"hola mundo"}""");
    }
    
    [Test]
    public void LogAMessageAsJsonWithAnotherMessage()
    {
        var logger = new Logger(_console, _dateTimeProvider, new Category("Acategory"), true);
        
        logger.LogInformation("otro mensaje");
        
        _console.Received().WriteLine("""{"timestamp":"2023-03-30T21:30:06","logLevel":"INF","category":"Acategory","message":"otro mensaje"}""");
    }
    
    [Test]
    public void LogAMessageAsJsonWithAnotherCategory()
    {
        var logger = new Logger(_console, _dateTimeProvider, new Category("AnotherCategory"), true);
        
        logger.LogInformation("otro mensaje");
        
        _console.Received().WriteLine("""{"timestamp":"2023-03-30T21:30:06","logLevel":"INF","category":"AnotherCategory","message":"otro mensaje"}""");
    }
    
    [Test]
    public void LogAMessageAsJsonWithAnotherlogLevel()
    {
        var logger = new Logger(_console, _dateTimeProvider, new Category("AnotherCategory"), true);
        
        logger.LogWarning("otro mensaje");
        
        _console.Received().WriteLine("""{"timestamp":"2023-03-30T21:30:06","logLevel":"WRN","category":"AnotherCategory","message":"otro mensaje"}""");
    }
    
    [Test]
    public void LogAMessageAsJsonWithCustomDate()
    {
        _dateTimeProvider.Now().Returns(DateTime.Parse("2023-03-04T09:00:06"));
        var logger = new Logger(_console, _dateTimeProvider, new Category("AnotherCategory"), true);
        
        logger.LogWarning("otro mensaje");
        
        _console.Received().WriteLine("""{"timestamp":"2023-03-04T09:00:06","logLevel":"WRN","category":"AnotherCategory","message":"otro mensaje"}""");
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
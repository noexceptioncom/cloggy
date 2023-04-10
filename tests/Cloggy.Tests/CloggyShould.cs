using FluentAssertions;
using NSubstitute;

namespace Cloggy.Tests;

public class CloggyShould
{
    private IConsole _console;
    private Logger _loggerWithDate;
    private Logger _loggerWithoutDate;
    private IDateTimeProvider _dateTimeProvider;
    private const string Category = "category";

    [SetUp]
    public void SetUp()
    {
        _dateTimeProvider = Substitute.For<IDateTimeProvider>();
        _console = Substitute.For<IConsole>();
        _loggerWithoutDate = new Logger(_console, null, Category);
        _loggerWithDate = new Logger(_console, _dateTimeProvider, Category);
    }

    [Test]
    public void LogAnEntryInConsole()
    {
        _loggerWithoutDate.LogInformation(string.Empty);

        _console.Received().WriteLine("[INF (category)] ");
    }
    
    [Test]
    public void LogAnotherWordInConsole()
    {
        _loggerWithoutDate.LogInformation("juanvi");

        _console.Received().WriteLine("[INF (category)] juanvi");
    }
    
    [Test]
    public void LogEmptyWhenPassingNullMessage()
    {
        _loggerWithoutDate.LogInformation(null);

        _console.Received().WriteLine("[INF (category)] ");
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
        _dateTimeProvider.Now().Returns(DateTime.Parse("2023-03-30T21:30:06"));
        _loggerWithDate.LogInformation("hola mundo");

        _console.Received().WriteLine("[2023-03-30T21:30:06 INF (category)] hola mundo");
    }

    [Test]
    public void LogAnEntryWithInformationAsLoglevel()
    {
        _dateTimeProvider.Now().Returns(DateTime.Parse("2023-03-30T21:30:06"));
        
        _loggerWithDate.LogInformation("hola mundo");
        
        _console.Received().WriteLine("[2023-03-30T21:30:06 INF (category)] hola mundo");
    }

    [Test]
    public void LogAnEntryWithWarningAsLogLevel()
    {
        _dateTimeProvider.Now().Returns(DateTime.Parse("2023-03-30T21:30:06"));
        
        _loggerWithDate.LogWarning("hola mundo");
        
        _console.Received().WriteLine("[2023-03-30T21:30:06 WRN (category)] hola mundo");
    }

    [Test]
    public void LogAnEntryWithErrorAsLogLevel()
    {
        _dateTimeProvider.Now().Returns(DateTime.Parse("2023-03-30T21:30:06"));
        
        _loggerWithDate.LogError("hola mundo");
        
        _console.Received().WriteLine("[2023-03-30T21:30:06 ERR (category)] hola mundo");
    }

    [Test]
    public void LogAMessageWithCategory()
    {
        _dateTimeProvider.Now().Returns(DateTime.Parse("2023-03-30T21:30:06"));
        var category = "ACategory";
        var logger = new Logger(_console, _dateTimeProvider, category);
        
        logger.LogInformation("A message");
        
        _console.Received().WriteLine("[2023-03-30T21:30:06 INF (ACategory)] A message");
    }

    [Test]
    public void LogMessageWithOtherCategory()
    {
        _dateTimeProvider.Now().Returns(DateTime.Parse("2023-03-30T21:30:06"));
        var category = "OtherCategory";
        var logger = new Logger(_console, _dateTimeProvider, category);
        
        logger.LogInformation("Other message");
        
        _console.Received().WriteLine("[2023-03-30T21:30:06 INF (OtherCategory)] Other message");
    }

    [Test]
    public void LogMessageWithAnotherCategory()
    {
        _dateTimeProvider.Now().Returns(DateTime.Parse("2023-03-30T21:30:06"));
        var category = "AnotherCategory";
        var logger = new Logger(_console, _dateTimeProvider, category);
        
        logger.LogInformation("Another message");
        
        _console.Received().WriteLine("[2023-03-30T21:30:06 INF (AnotherCategory)] Another message");
    }

    [Test]
    public void ReportAErrorWhenCategoryIsEmpty()
    {
        Action action = () => new Logger(_console,_dateTimeProvider, string.Empty);
        action.Should().Throw<ArgumentNullException>();
    }
}
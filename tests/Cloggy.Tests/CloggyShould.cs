using NSubstitute;

namespace Cloggy.Tests;

public class CloggyShould
{
    private IConsole _console;
    private Logger logger;
    private IDateTimeProvider _dateTimeProvider;

    [SetUp]
    public void SetUp()
    {
        _dateTimeProvider = Substitute.For<IDateTimeProvider>();
        _console = Substitute.For<IConsole>();
        logger = new Logger(_console, _dateTimeProvider, false);
    }

    [Test]
    public void LogAnEntryInConsole()
    {
        logger.LogInformation(string.Empty);

        _console.Received().WriteLine("[INF] ");
    }
    
    [Test]
    public void LogAnotherWordInConsole()
    {
        logger.LogInformation("juanvi");

        _console.Received().WriteLine("[INF] juanvi");
    }
    
    [Test]
    public void LogEmptyWhenPassingNullMessage()
    {
        logger.LogInformation(null);

        _console.Received().WriteLine("[INF] ");
    }
    
    [Test]
    public void LogDateTimeWithEveryMessage()
    {
        logger = new Logger(_console, _dateTimeProvider, true);
        _dateTimeProvider.Now().Returns(DateTime.Parse("2023-03-30T09:00:06"));
        logger.LogInformation("hola mundo");

        _console.Received().WriteLine("[2023-03-30T09:00:06 INF] hola mundo");
    }
    
    [Test]
    public void LogDateTimeWithEveryMessageAtNight()
    {
        logger = new Logger(_console, _dateTimeProvider, true);
        _dateTimeProvider.Now().Returns(DateTime.Parse("2023-03-30T21:30:06"));
        logger.LogInformation("hola mundo");

        _console.Received().WriteLine("[2023-03-30T21:30:06 INF] hola mundo");
    }

    [Test]
    public void LogAnEntryWithInformationAsLoglevel()
    {
        logger = new Logger(_console, _dateTimeProvider, true);
        _dateTimeProvider.Now().Returns(DateTime.Parse("2023-03-30T21:30:06"));
        
        logger.LogInformation("hola mundo");
        
        _console.Received().WriteLine("[2023-03-30T21:30:06 INF] hola mundo");
    }

    [Test]
    public void LogAnEntryWithWarningAsLogLevel()
    {
        logger = new Logger(_console, _dateTimeProvider, true);
        _dateTimeProvider.Now().Returns(DateTime.Parse("2023-03-30T21:30:06"));
        
        logger.LogWarning("hola mundo");
        
        _console.Received().WriteLine("[2023-03-30T21:30:06 WRN] hola mundo");
    }

    [Test]
    public void LogAnEntryWithErrorAsLogLevel()
    {
        logger = new Logger(_console, _dateTimeProvider, true);
        _dateTimeProvider.Now().Returns(DateTime.Parse("2023-03-30T21:30:06"));
        
        logger.LogError("hola mundo");
        
        _console.Received().WriteLine("[2023-03-30T21:30:06 ERR] hola mundo");
    }
}
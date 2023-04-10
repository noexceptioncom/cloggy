using NSubstitute;

namespace Cloggy.Tests;

public class CloggyShould
{
    private IConsole console;
    private Logger logger;
    private IDateTimeProvider _dateTimeProvider;

    [SetUp]
    public void SetUp()
    {
        _dateTimeProvider = Substitute.For<IDateTimeProvider>();
        console = Substitute.For<IConsole>();
        logger = new Logger(new LoggerConfig(console, _dateTimeProvider, false));
    }

    [Test]
    public void LogAnEntryInConsole()
    {
        logger.LogInformation(string.Empty);

        console.Received().WriteLine("[INF] ");
    }
    
    [Test]
    public void LogAnotherWordInConsole()
    {
        logger.LogInformation("juanvi");

        console.Received().WriteLine("[INF] juanvi");
    }
    
    [Test]
    public void LogEmptyWhenPassingNullMessage()
    {
        logger.LogInformation(null);

        console.Received().WriteLine("[INF] ");
    }
    
    [Test]
    public void LogDateTimeWithEveryMessage()
    {
        logger = new Logger(new LoggerConfig(console, _dateTimeProvider, true));
        _dateTimeProvider.Now().Returns(DateTime.Parse("2023-03-30T09:00:06"));
        logger.LogInformation("hola mundo");

        console.Received().WriteLine("[2023-03-30T09:00:06 INF] hola mundo");
    }
    
    [Test]
    public void LogDateTimeWithEveryMessageAtNight()
    {
        logger = new Logger(new LoggerConfig(console, _dateTimeProvider, true));
        _dateTimeProvider.Now().Returns(DateTime.Parse("2023-03-30T21:30:06"));
        logger.LogInformation("hola mundo");

        console.Received().WriteLine("[2023-03-30T21:30:06 INF] hola mundo");
    }

    [Test]
    public void LogAnEntryWithInformationAsLoglevel()
    {
        logger = new Logger(new LoggerConfig(console, _dateTimeProvider, true));
        _dateTimeProvider.Now().Returns(DateTime.Parse("2023-03-30T21:30:06"));
        
        logger.LogInformation("hola mundo");
        
        console.Received().WriteLine("[2023-03-30T21:30:06 INF] hola mundo");
    }

    [Test]
    public void LogAnEntryWithWarningAsLogLevel()
    {
        logger = new Logger(new LoggerConfig(console, _dateTimeProvider, true));
        _dateTimeProvider.Now().Returns(DateTime.Parse("2023-03-30T21:30:06"));
        
        logger.LogWarning("hola mundo");
        
        console.Received().WriteLine("[2023-03-30T21:30:06 WRN] hola mundo");
    }

    [Test]
    public void LogAnEntryWithErrorAsLogLevel()
    {
        logger = new Logger(new LoggerConfig(console, _dateTimeProvider, true));
        _dateTimeProvider.Now().Returns(DateTime.Parse("2023-03-30T21:30:06"));
        
        logger.LogError("hola mundo");
        
        console.Received().WriteLine("[2023-03-30T21:30:06 ERR] hola mundo");
    }
}
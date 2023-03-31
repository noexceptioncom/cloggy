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
        logger.Log(string.Empty);

        console.Received().WriteLine(string.Empty);
    }
    
    [Test]
    public void LogAnotherWordInConsole()
    {
        logger.Log("juanvi");

        console.Received().WriteLine("juanvi");
    }
    
    [Test]
    public void LogEmptyWhenPassingNullMessage()
    {
        logger.Log(null);

        console.Received().WriteLine(string.Empty);
    }
    
    [Test]
    public void LogDateTimeWithEveryMessage()
    {
        logger = new Logger(new LoggerConfig(console, _dateTimeProvider, true));
        var expectedTime = _dateTimeProvider.Now().Returns(DateTime.Parse("2023-03-30T09:00:06"));
        logger.Log("hola mundo");

        console.Received().WriteLine("[2023-03-30T09:00:06] hola mundo");
    }
    
    [Test]
    public void LogDateTimeWithEveryMessageAtNight()
    {
        logger = new Logger(new LoggerConfig(console, _dateTimeProvider, true));
        var expectedTime = _dateTimeProvider.Now().Returns(DateTime.Parse("2023-03-30T21:30:06"));
        logger.Log("hola mundo");

        console.Received().WriteLine("[2023-03-30T21:30:06] hola mundo");
    }
}
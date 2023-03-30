using NSubstitute;

namespace Cloggy.Tests;

public class CloggyShould
{
    private IConsole console;
    private Logger logger;

    [SetUp]
    public void SetUp()
    {
        console = Substitute.For<IConsole>();
        logger = new Logger(console, false);
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
        logger = new Logger(console, true);
        
        logger.Log("hola mundo");

        console.Received().WriteLine("[2023-03-30T09:00:06] hola mundo");
    }
}

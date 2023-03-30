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
        logger = new Logger(console);
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
}
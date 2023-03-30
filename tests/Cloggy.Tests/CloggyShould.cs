using NSubstitute;

namespace Cloggy.Tests;

public class CloggyShould
{
    [Test]
    public void LogAnEntryInConsole()
    {
        var console = Substitute.For<IConsole>();
        var logger = new Logger(console);

        logger.Log("");

        console.Received().WriteLine("");
    }
    
    [Test]
    public void LogAnotherWordInConsole()
    {
        var console = Substitute.For<IConsole>();
        var logger = new Logger(console);

        logger.Log("juanvi");

        console.Received().WriteLine("juanvi");
    }
    
    [Test]
    public void LogEmptyWhenPassingNullMessage()
    {
        var console = Substitute.For<IConsole>();
        var logger = new Logger(console);

        logger.Log(null);

        console.Received().WriteLine("");
    }
}
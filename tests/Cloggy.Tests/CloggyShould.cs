using NSubstitute;

namespace Cloggy.Tests;

public class CloggyShould
{
    [Test]
    public void LogAnEntryInConsole()
    {
        IConsole console = Substitute.For<IConsole>();
        Logger logger = new Logger(console);
        
        logger.Log("");
        
        console.Received().WriteLine("");
    }
}
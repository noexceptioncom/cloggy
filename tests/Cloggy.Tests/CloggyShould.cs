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
        _loggerWithoutDate = new Logger(_console, null, new Category(Category));
        _loggerWithDate = new Logger(_console, _dateTimeProvider, new Category(Category));
        _dateTimeProvider.Now().Returns(DateTime.Parse("2023-03-30T21:30:06"));
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
        _loggerWithDate.LogInformation("hola mundo");

        _console.Received().WriteLine("[2023-03-30T21:30:06 INF (category)] hola mundo");
    }

    [Test]
    public void LogAnEntryWithInformationAsLoglevel()
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

    [TestCase("ACategory", "A message")]
    [TestCase("OtherCategory", "Other message")]
    [TestCase("AnotherCategory", "Another message")]
    public void LogMessagesWithCategory(string category, string message)
    {
        var logger = new Logger(_console, _dateTimeProvider, new Category(category));
        
        logger.LogInformation(message);
        
        _console.Received().WriteLine($"[2023-03-30T21:30:06 INF ({category})] {message}");
    }

    [TestCase("")]
    [TestCase("    ")]
    [TestCase("ca\ntegory")]
    public void ReportAErrorWhenCategoryIsNotValid(string categoryName)
    {
        Action action = () => new Logger(_console, _dateTimeProvider, new Category(categoryName));
        
        action.Should().Throw<ArgumentNullException>();
    }
}
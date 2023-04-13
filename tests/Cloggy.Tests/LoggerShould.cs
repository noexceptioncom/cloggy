using FluentAssertions;
using NSubstitute;

namespace Cloggy.Tests
{
    public class LoggerShould
    {
        private IConsole _console;
        private IDateTimeProvider _dateTimeProvider;
        private IFileWriter _fileWriter;
        private Category _category;
        private string _otroMensaje;
        private string _expectedMessage;
        private Memory _memory;
        private PlainTextFormatStrategy _plainTextFormatStrategy;


        [SetUp]
        public void SetUp()
        {
            _dateTimeProvider = Substitute.For<IDateTimeProvider>();
            _console = Substitute.For<IConsole>();
            _memory = new Memory();
            _fileWriter = Substitute.For<IFileWriter>();
            _dateTimeProvider.Now().Returns(DateTime.Parse("2023-03-30T21:30:06"));
            _category = new Category("AnotherCategory");
            _otroMensaje = "otro mensaje";
            _expectedMessage = "[2023-03-30T21:30:06 INF (AnotherCategory)] otro mensaje";
            _plainTextFormatStrategy = new PlainTextFormatStrategy();
        }

        [Test]
        public void LogAMessageAsPlainToConsole()
        {
            var logger = new Logger(_console, _dateTimeProvider, _category, _plainTextFormatStrategy, null, null);

            logger.LogInformation(_otroMensaje);

            _console.Received().WriteLine(_expectedMessage);
        }

        [Test]
        public void LogAMessageAsPlainTextToFile()
        {
            var logger = new Logger(null, _dateTimeProvider, _category, _plainTextFormatStrategy, _fileWriter,null);

            logger.LogInformation(_otroMensaje);

            _fileWriter.Received().WriteLine(_expectedMessage);
        }

        [Test]
        public void LogAMessageAsPlainTextToFileAndConsole()
        {
            var logger = new Logger(_console, _dateTimeProvider, _category, _plainTextFormatStrategy, _fileWriter,null);

            logger.LogInformation(_otroMensaje);

            _fileWriter.Received().WriteLine(_expectedMessage);
            _console.Received().WriteLine(_expectedMessage);
        }
        
        [Test]
        public void SaveAMessageInMemory()
        {
            var logger = new Logger(null, _dateTimeProvider, _category, _plainTextFormatStrategy, null, _memory);
            var expectedMessage = new Message("other message", LogLevel.WRN, DateTime.Parse("2023-03-30T21:30:06"),
                _category);
            logger.LogWarning("other message");

            var storedMessage = _memory.ReadAll().First();
            storedMessage.Should().Be(expectedMessage);
        }
    }
}
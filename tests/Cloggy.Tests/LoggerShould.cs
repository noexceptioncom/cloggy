using Cloggy.Formatters;
using Cloggy.Outputs;
using Cloggy.Providers;
using FluentAssertions;
using NSubstitute;

namespace Cloggy.Tests
{
    public class LoggerShould
    {
        private IOutput _output;
        private IDateTimeProvider _dateTimeProvider;
        private IFileWriter _fileWriter;
        private Category _category;
        private string _otherMessage;
        private string _expectedMessage;
        private Memory _memory;
        private PlainTextFormatStrategy _plainTextFormatStrategy;


        [SetUp]
        public void SetUp()
        {
            _dateTimeProvider = Substitute.For<IDateTimeProvider>();
            _output = Substitute.For<IOutput>();
            _memory = new Memory();
            _fileWriter = Substitute.For<IFileWriter>();
            _dateTimeProvider.Now().Returns(DateTime.Parse("2023-03-30T21:30:06"));
            _category = new Category("AnotherCategory");
            _otherMessage = "other message";
            _expectedMessage = "[2023-03-30T21:30:06 INF (AnotherCategory)] other message";
            _plainTextFormatStrategy = new PlainTextFormatStrategy();
        }

        [Test]
        public void LogAMessageAsPlainToConsole()
        {
            var logger = new Logger(_dateTimeProvider, _plainTextFormatStrategy, _category, null, null, _output);

            logger.LogInformation(_otherMessage);

            _output.Received().WriteLine(_expectedMessage);
        }

        [Test]
        public void LogAMessageAsPlainTextToFile()
        {
            var logger = new Logger(_dateTimeProvider, _plainTextFormatStrategy,_category, null, _fileWriter);

            logger.LogInformation(_otherMessage);

            _fileWriter.Received().WriteLine(_expectedMessage);
        }

        [Test]
        public void LogAMessageAsPlainTextToFileAndConsole()
        {
            var logger = new Logger(_dateTimeProvider, _plainTextFormatStrategy,_category, null, _fileWriter, _output);

            logger.LogInformation(_otherMessage);

            _fileWriter.Received().WriteLine(_expectedMessage);
            _output.Received().WriteLine(_expectedMessage);
        }
        
        [Test]
        public void SaveAMessageInMemory()
        {
            var logger = new Logger(_dateTimeProvider, _plainTextFormatStrategy, _category, _memory, null);
            var expectedMessage = new Message(_otherMessage, LogLevel.WRN, DateTime.Parse("2023-03-30T21:30:06"),
                _category);
            logger.LogWarning(_otherMessage);

            var storedMessage = _memory.ReadAll().First();
            storedMessage.Should().Be(expectedMessage);
        }
    }
}
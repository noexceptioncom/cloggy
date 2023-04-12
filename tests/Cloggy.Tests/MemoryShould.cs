using FluentAssertions;

namespace Cloggy.Tests
{
    public class MemoryShould
    {
        [Test]
        public void AddAMessage()
        {
            var message = new Message("message", LogLevel.INF, DateTime.Parse("2023-03-30T21:30:06"),
                new Category("category"));

            var memory = new Memory();

            memory.AddMessage(message);
            var result = memory.ReadAll().First();
            
            result.Should().Be(message);
        }
    }
}

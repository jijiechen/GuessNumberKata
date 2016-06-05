using GuessNumber.Tests.TestDouble;
using Xunit;

namespace GuessNumber.Tests
{
    public class GameFacadeFacts
    {
        [Fact]
        public void should_show_welcome_text()
        {
            using (var io = new FakeInputOutput())
            {
                io.In("7634");

                var facade = new GameFacade(io.InReader, io.OutWriter);
                facade.StartGame(new Game("1234"));

                Assert.Contains("please input your guess", io.Out());
            }
        }


        [Fact]
        public void should_guess_numbers()
        {
            using (var io = new FakeInputOutput())
            {
                io.In("7634");

                var facade = new GameFacade(io.InReader, io.OutWriter);
                facade.StartGame(new Game("1234"));

                Assert.Contains("2A0B", io.Out());
            }
        }
    }
}
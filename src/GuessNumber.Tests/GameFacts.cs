using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;



namespace GuessNumber.Tests
{
    public class GameFacts
    {

        [Fact]
        public void should_output_0A0B_when_no_number_matches()
        {
            var random = "1234";
            var guess = "5678";

            var game = new Game(random);


            var result = game.Guess(guess);
            Assert.Equal("0A0B", result);
        }



    }
}

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

        
        [Fact]
        public void should_output_0A1B_when_1_number_matches_value_only()
        {
            var random = "1234";
            var guess = "4678";

            var game = new Game(random);


            var result = game.Guess(guess);
            Assert.Equal("0A1B", result);
        }
        

        [Fact]
        public void should_output_0A2B_when_2_numbers_match_value_only()
        {
            var random = "1234";
            var guess = "4378";

            var game = new Game(random);


            var result = game.Guess(guess);
            Assert.Equal("0A2B", result);
        }

        
        [Fact]
        public void should_output_1A0B_when_1_number_matches_value_and_location_matches()
        {
            var random = "1234";
            var guess = "1678";

            var game = new Game(random);


            var result = game.Guess(guess);
            Assert.Equal("1A0B", result);
        }






    }
}

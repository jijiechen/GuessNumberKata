﻿using System.Collections.Generic;
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


        [Theory]
        [InlineData("1234", "4678", 1)]
        [InlineData("1234", "4378", 2)]
        [InlineData("1234", "4372", 3)]
        [InlineData("1234", "4123", 4)]
        public void should_output_numbers_of_value_match(string random, string guess, int countValueMatch)
        {
            var game = new Game(random);


            var result = game.Guess(guess);

            var expected = string.Format("0A{0}B", countValueMatch);
            Assert.Equal(expected, result);
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

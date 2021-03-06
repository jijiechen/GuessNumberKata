﻿using GuessNumber.Tests.TestDouble;
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

        [Theory]
        [InlineData("1234", "1678", 1)]
        [InlineData("1234", "1278", 2)]
        [InlineData("1234", "1934", 3)]
        [InlineData("1234", "0234", 3)]
        [InlineData("1234", "1234", 4)]
        public void should_output_numbers_of_value_and_position_matches(string random, string guess, int countMatches)
        {
            var game = new Game(random);


            var result = game.Guess(guess);
            var expected = string.Format("{0}A0B", countMatches);
            Assert.Equal(expected, result);
        }


        [Theory]
        [InlineData("1234", "1378", 1, 1)]
        [InlineData("1234", "2314", 1, 3)]
        [InlineData("1234", "1238", 3, 0)]
        [InlineData("1234", "4321", 0, 4)]
        [InlineData("1234", "1234", 4, 0)]
        public void should_output_matches_including_both_matches(string random, string guess, int countExactMatches, int countValueOnlyMatches)
        {
            var game = new Game(random);


            var result = game.Guess(guess);
            var expected = string.Format("{0}A{1}B", countExactMatches, countValueOnlyMatches);
            Assert.Equal(expected, result);
        }



        [Fact]
        public void should_use_random_generator()
        {
            var random = "1234";

            var numberGenerator = new StubRandomNumberGenerator(random);

            var game = new Game(numberGenerator);
            var result = game.Guess("1234");

            Assert.Equal("4A0B", result);
        }

        [Fact]
        public void should_process_guess_longer_than_random()
        {
            var game = new Game("1234");

            var result = game.Guess("12345");
            var expected = string.Format("{0}A{1}B", 4, 0);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void should_process_guess_shorter_than_random()
        {
            var game = new Game("1234");

            var result = game.Guess("423");
            var expected = string.Format("{0}A{1}B", 2, 1);
            Assert.Equal(expected, result);
        }
    
    }
}

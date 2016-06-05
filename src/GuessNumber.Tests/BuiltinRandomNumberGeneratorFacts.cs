using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Xunit;

namespace GuessNumber.Tests
{
    public class BuiltinRandomNumberGeneratorFacts
    {
        [Fact]
        public void should_generate_4_digits()
        {
            var generator = new BuiltinRandomNumberGenerator();
            var randomNumbers = generator.NextNumber();

            Assert.Equal(4, randomNumbers.Length);
            Assert.Matches(new Regex(@"^\d{4}$"), randomNumbers);
        }
        
        [Fact]
        public void should_generate_unrepeated_digits()
        {
            var generator = new BuiltinRandomNumberGenerator();
            var randomNumbers = generator.NextNumber();

            var chars = randomNumbers.ToCharArray();
            foreach (var ch in chars)
            {
                var index = Array.IndexOf(chars, ch);
                var lastIndex = Array.LastIndexOf(chars, ch);

                Assert.True(index == lastIndex);
            }
        }
        
        [Fact]
        public void should_generate_different_numbers_upon_multiple_invocations()
        {
            var generator = new BuiltinRandomNumberGenerator();
            var numbers = new List<string>();

            var times = new Random().Next(2, 100);
            for (int i = 0; i < times; i++)
            {
                numbers.Add(generator.NextNumber());
            }

            Assert.True(numbers.Distinct().Count().Equals(numbers.Count));
        }
    }
}
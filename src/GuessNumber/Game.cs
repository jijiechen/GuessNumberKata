using System;
using System.Linq;

namespace GuessNumber
{
    public class Game
    {
        private readonly char[] _random;

        public Game(string random)
        {
            _random = random.ToCharArray();
        }

        public string Guess(string guess)
        {
            var guesingChars = guess.ToCharArray();
            var countValueAndLocationMatches = guesingChars.Where((t, i) => _random[i] == t).Count();


            var countValueMatches = guesingChars.Count(guesingChar =>
            {
                var index = Array.IndexOf(_random, guesingChar);
                var valueMatched = index > -1;

                if (valueMatched)
                {
                    var locationMatched = guesingChars[index] == guesingChar;
                    return !locationMatched;
                }
                return valueMatched;
            });
            if (countValueAndLocationMatches > 0 || countValueMatches > 0)
            {
                return string.Format("{0}A{1}B", countValueAndLocationMatches, countValueMatches);
            }


            return "0A0B";
        }
    }
}
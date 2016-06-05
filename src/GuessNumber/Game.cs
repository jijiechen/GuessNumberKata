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
            if (countValueAndLocationMatches > 0)
            {
                return string.Format("{0}A0B", countValueAndLocationMatches);
            }


            var countValueMatches = guesingChars.Count(guesingChar => Array.IndexOf(_random, guesingChar) > -1);
            if (countValueMatches > 0)
            {
                return string.Format("0A{0}B", countValueMatches);
            }


            return "0A0B";
        }
    }
}
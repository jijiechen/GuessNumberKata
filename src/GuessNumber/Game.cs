using System;

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
            var countValueAndLocationMatches = 0;
            for (int i = 0; i < guesingChars.Length; i++)
            {
                if (_random[i] == guesingChars[i])
                {
                    countValueAndLocationMatches++;
                }
            }
            if (countValueAndLocationMatches > 0)
            {
                return string.Format("{0}A0B", countValueAndLocationMatches);
            }


            var countValueMatches = 0;
            foreach (var guesingChar in guesingChars)
            {
                if (Array.IndexOf(_random, guesingChar) > -1)
                {
                    countValueMatches++;
                }
            }
            if (countValueMatches > 0)
            {
                return string.Format("0A{0}B", countValueMatches);
            }


            return "0A0B";
        }
    }
}
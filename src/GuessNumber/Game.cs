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
            foreach (var guesingChar in guesingChars)
            {
                if (Array.IndexOf(_random, guesingChar) > -1)
                {
                    return "0A1B";
                }
            }



            return "0A0B";
        }
    }
}
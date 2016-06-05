﻿using System;
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

            var exactMatches = guesingChars.Where((t, i) => _random[i] == t).Count();
            var onlyValueMatches = guesingChars.Count(guesingChar => MatchValueOnly(guesingChar, guesingChars));

            return string.Format("{0}A{1}B", exactMatches, onlyValueMatches);
        }

        private bool MatchValueOnly(char guesingChar, char[] guesingChars)
        {
            var matchedIndex = Array.IndexOf(_random, guesingChar);
            var valueMatched = matchedIndex > -1;

            if (!valueMatched) 
                return false;

            var locationMatched = guesingChars[matchedIndex] == guesingChar;
            return !locationMatched;
        }
    }
}
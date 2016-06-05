using System;

namespace GuessNumber
{
    public class BuiltinRandomNumberGenerator: IRandomNumberGenerator
    {
        public string NextNumber()
        {
            string next;
            do
            {
                next = GenerateNext();
            } while (AnyCharRepeated(next));
            return next;
        }

        private static bool AnyCharRepeated(string next)
        {
            var charArray = next.ToCharArray();
            for (int i = 0; i < charArray.Length - 1; i++)
            {
                if (Array.IndexOf(charArray, charArray[i], i + 1) > -1)
                {
                    return true;
                }
            }

            return false;
        }

        private static string GenerateNext()
        {
            var random = new Random(Guid.NewGuid().GetHashCode());
            return random.Next(1000, 9999).ToString();
        }
    }
}
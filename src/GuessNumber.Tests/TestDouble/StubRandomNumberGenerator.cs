namespace GuessNumber.Tests.TestDouble
{
    public class StubRandomNumberGenerator : IRandomNumberGenerator
    {
        private readonly string _random;

        public StubRandomNumberGenerator(string random)
        {
            _random = random;
        }

        public string NextNumber()
        {
            return _random;
        }
    }
}
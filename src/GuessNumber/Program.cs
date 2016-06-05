using System;

namespace GuessNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Guess the number";
            var gameFacade = new GameFacade(Console.In, Console.Out);
            var game = new Game(new BuiltinRandomNumberGenerator());
            gameFacade.StartGame(game);

            Console.ReadLine();

        }
    }
}

using System.IO;
using System.Runtime.InteropServices;

namespace GuessNumber
{
    public class GameFacade
    {
        private readonly StreamReader _userInput;
        private readonly StreamWriter _gameOutput;

        public GameFacade(StreamReader userInput, StreamWriter gameOutput)
        {
            _userInput = userInput;
            _gameOutput = gameOutput;
        }

        public void StartGame(Game game)
        {
            _gameOutput.WriteLine("Welcome to the guess the number game.");
            _gameOutput.WriteLine("please input your guess:");
            _gameOutput.Flush();

            string input = _userInput.ReadLine();
            var result = game.Guess(input);
            _gameOutput.WriteLine(result);
            _gameOutput.Flush();

        }
    }
}
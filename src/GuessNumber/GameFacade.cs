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

            var timesTried = 0;
            string input;
            while (!_userInput.EndOfStream)
            {
                input = _userInput.ReadLine();
                if (!string.IsNullOrWhiteSpace(input))
                {
                    var result = game.Guess(input);
                    _gameOutput.WriteLine(result);
                    _gameOutput.Flush();

                    if (result == "4A0B")
                    {
                        _gameOutput.WriteLine("You win");
                        _gameOutput.Flush();
                    }


                    timesTried++;
                    if (timesTried >= 6)
                    {
                        _gameOutput.WriteLine("You lost");
                        _gameOutput.Flush();
                    }
                }

            }
        }
    }
}
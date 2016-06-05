using System.IO;
using System.Runtime.InteropServices;

namespace GuessNumber
{
    public class GameFacade
    {
        private readonly TextReader _userInput;
        private readonly TextWriter _gameOutput;

        public GameFacade(TextReader userInput, TextWriter gameOutput)
        {
            _userInput = userInput;
            _gameOutput = gameOutput;
        }

        public void StartGame(Game game)
        {
            Output("Welcome to the guess the number game.\r\nPlease input your guess:");

            var timesTried = 0;
            while (true)
            {
                var input = _userInput.ReadLine();
                if (input == null)
                {
                    break;
                }

                var result = game.Guess(input);
                Output(result);

                if (result == "4A0B")
                {
                    Output("You win");
                    break;
                }
                
                timesTried++;
                if (timesTried >= 6)
                {
                    Output("You lost");
                    break;
                }
            }
        }

        private void Output(string result)
        {
            _gameOutput.WriteLine(result);
            _gameOutput.Flush();
        }
    }
}
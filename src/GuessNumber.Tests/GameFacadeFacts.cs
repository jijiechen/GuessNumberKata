using System;
using System.IO;
using Xunit;

namespace GuessNumber.Tests
{
    public class GameFacadeFacts
    {
        [Fact]
        public void should_show_welcome_text()
        {
            var inputStream = new MemoryStream();
            var outputStream  = new MemoryStream();
            var userInput = new StreamReader(inputStream);
            var gameOutput = new StreamWriter(outputStream);

            var inputWriter = new StreamWriter(inputStream);
            var lastPosition = inputStream.Position;
            inputWriter.Write("7634");
            inputWriter.Flush();
            inputStream.Seek(lastPosition, SeekOrigin.Begin);

            var facade = new GameFacade(userInput, gameOutput);
            facade.StartGame(new Game("1234"));

            outputStream.Seek(0, SeekOrigin.Begin);
            var outputReader = new StreamReader(outputStream);
            var ouputContent = outputReader.ReadToEnd();
            Assert.Contains("please input your guess", ouputContent);
        }
        
        
        
        [Fact]
        public void should_guess_numbers()
        {
            var inputStream = new MemoryStream();
            var outputStream  = new MemoryStream();
            var userInput = new StreamReader(inputStream);
            var gameOutput = new StreamWriter(outputStream);

            var inputWriter = new StreamWriter(inputStream);
            var lastPosition = inputStream.Position;
            inputWriter.Write("7634");
            inputWriter.Flush();
            inputStream.Seek(lastPosition, SeekOrigin.Begin);


            var facade = new GameFacade(userInput, gameOutput);
            facade.StartGame(new Game("1234"));

            outputStream.Seek(0, SeekOrigin.Begin);
            var outputReader = new StreamReader(outputStream);
            var ouputContent = outputReader.ReadToEnd();
            Assert.Contains("2A0B", ouputContent);
        }

    }
}
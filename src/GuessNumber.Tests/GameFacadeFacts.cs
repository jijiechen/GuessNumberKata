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

            WriteLineTo(inputStream, "7634");

            var facade = new GameFacade(new StreamReader(inputStream), new StreamWriter(outputStream));
            facade.StartGame(new Game("1234"));

            var ouputContent = ReadAllFrom(outputStream);
            Assert.Contains("please input your guess", ouputContent);
        }


        [Fact]
        public void should_guess_numbers()
        {
            var inputStream = new MemoryStream();
            var outputStream  = new MemoryStream();

            WriteLineTo(inputStream, "7634");


            var facade = new GameFacade(new StreamReader(inputStream), new StreamWriter(outputStream));
            facade.StartGame(new Game("1234"));

            var ouputContent = ReadAllFrom(outputStream);
            Assert.Contains("2A0B", ouputContent);
        }

        private static void WriteLineTo(MemoryStream stream, string content)
        {
            var lastPosition = stream.Position;
            var inputWriter = new StreamWriter(stream);

            inputWriter.Write(content);
            inputWriter.Flush();
            stream.Seek(lastPosition, SeekOrigin.Begin);
        }

        private static string ReadAllFrom(MemoryStream outputStream)
        {
            outputStream.Seek(0, SeekOrigin.Begin);
            var outputReader = new StreamReader(outputStream);
            return outputReader.ReadToEnd();
        }
    }
}
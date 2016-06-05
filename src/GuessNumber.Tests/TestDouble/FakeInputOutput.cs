using System;
using System.IO;

namespace GuessNumber.Tests.TestDouble
{
    public class FakeInputOutput : IDisposable
    {
        private readonly Stream _inputStream; 
        private readonly Stream _outputStream;
        private StreamReader _inReader;
        private StreamWriter _outWriter;

        private StreamWriter _inWriter;
        private StreamReader _outReader;

        public FakeInputOutput()
        {
            _inputStream = new MemoryStream();
            _outputStream = new MemoryStream();
        }


        public void In(string content)
        {
            var lastPosition = _inputStream.Position;

            _inputStream.Seek(0, SeekOrigin.End);
            InWriter.WriteLine(content);
            InWriter.Flush();

            _inputStream.Seek(lastPosition, SeekOrigin.Begin);
        }

        public string Out()
        {
            _outputStream.Seek(0, SeekOrigin.Begin);
            return OutReader.ReadToEnd();
        }

        public StreamReader InReader
        {
            get { return _inReader ?? (_inReader = new StreamReader(_inputStream)); }
        }

        public StreamWriter OutWriter
        {
            get { return _outWriter ?? (_outWriter = new StreamWriter(_outputStream)); }
        }


        private StreamWriter InWriter
        {
            get { return _inWriter ?? (_inWriter = new StreamWriter(_inputStream)); }
        }

        private StreamReader OutReader
        {
            get { return _outReader ?? (_outReader = new StreamReader(_outputStream)); }
        }

        void IDisposable.Dispose()
        {
            _inputStream.Dispose();
            if (_inReader != null)
                _inReader.Dispose();
            if (_inWriter != null)
                _inWriter.Dispose();


            _outputStream.Dispose();
            if (_outReader != null)
                _outReader.Dispose();
            if(_outWriter != null)
                _outWriter.Dispose();
            
        }
    }
}
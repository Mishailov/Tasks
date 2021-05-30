using System;
using System.IO;

namespace SixthTask
{
    class DecoratedStream : Stream
    {
        private Stream _stream;

        private const int _password = 1234;

        public int Password { get; private set; }
        public DecoratedStream(Stream stream)
        {
                _stream = stream;
        }

        public override bool CanRead => _stream.CanRead;

        public override bool CanSeek => _stream.CanSeek;

        public override bool CanWrite => _stream.CanWrite;

        public override long Length => _stream.Length;

        public override long Position { get => _stream.Position; set => _stream.Position = value; }

        public override void Flush()
        {
            _stream.Flush();
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            int read = 0;
            int temp = 0;
            int tenPercent = 1;

            if (buffer.Length % 10 == 0)
            {
                tenPercent = (buffer.Length * 10) / 100;
            }

            for (int i = 0; i < buffer.Length; i += tenPercent)
            {
                if (i > buffer.Length)
                {
                    return read;
                }

                var newBuffer = buffer[temp..i];
                read = _stream.Read(newBuffer, offset, newBuffer.Length);
                temp = i;
                Console.WriteLine($"{10} Percent");
            }

            return read;
            //return _stream.Read(buffer, offset, count);
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            return _stream.Seek(offset, origin);
        }

        public override void SetLength(long value)
        {
            _stream.SetLength(value);
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            _stream.Write(buffer, offset, count);
        }

        public bool IsPasswordCorrect(int password)
        {
            Password = password;
            if (Password != _password)
                return false;

            return true;
        }
        
        public double PercentageOfRead(int length)
        {
            return (length * 100.0) / this.Length; 
        }
    }
}

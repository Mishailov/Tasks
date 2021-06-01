using System;
using System.IO;

namespace SixthTask
{
    class DecoratedStream : Stream
    {
        public delegate void DecStreamHandler(string message);
        public event DecStreamHandler TenPercent;
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
            int newOffset = 0;
            int tenPercent = 1;
            double counterTenTimes = 0;

            if (buffer.Length > 10)
            {
                tenPercent = buffer.Length / 10;
                double tenPercentDouble = buffer.Length / 10.0;
                counterTenTimes = (tenPercentDouble - tenPercent) * 10;
                tenPercent += 1;
            }

            int countInLoop = 0;
            for (int i = 0; i < buffer.Length; i += tenPercent)
            {
                if(countInLoop == (int)counterTenTimes)
                {
                    tenPercent -= 1;
                }

                countInLoop++;

                if (i > buffer.Length)
                {
                    return read;
                }

                read = _stream.Read(buffer, newOffset, tenPercent);
                newOffset += tenPercent;
                TenPercent?.Invoke($"{countInLoop * 10} percent");
            }

            return read;
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

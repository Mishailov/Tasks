using System;
using System.IO;

namespace SixthTask
{
    class DecoratedStream : Stream
    {
        public event EventHandler<EveryTenPercentEventArgs> EveryTenPercent;

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
            EveryTenPercentEventArgs args = new EveryTenPercentEventArgs();

            const int tenPercentConst = 10;
            int read = 0;
            int newOffset = 0;
            int step = 1;

            if (buffer.Length > tenPercentConst)
            {
                step = buffer.Length / tenPercentConst;
            }

            int countInLoop = 0;
            for (int i = 0; i < buffer.Length; i += step)
            {
                if (i > buffer.Length)
                {
                    return read;
                }

                if(countInLoop == (tenPercentConst - 1))
                {
                    step = buffer.Length - (step * countInLoop);
                }

                read = _stream.Read(buffer, newOffset, step);
                newOffset += step;
                
                countInLoop++;
                args.TenPercent = countInLoop * tenPercentConst;
                OnEveryTenPercent(args);
            }

            return read;
        }

        protected virtual void OnEveryTenPercent(EveryTenPercentEventArgs e)
        {
            EveryTenPercent?.Invoke(this, e);
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

    public class EveryTenPercentEventArgs : EventArgs
    {
        public int TenPercent { get; set; }
    }
}

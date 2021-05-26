using System;
using System.IO;

namespace SixthTask
{
    abstract class DecoratedStream : Stream
    {
        private Stream _stream;
        public DecoratedStream(Stream stream)
        {
            _stream = stream;
        }

        //Method for pass

        //Methos for part of the read
    }
}

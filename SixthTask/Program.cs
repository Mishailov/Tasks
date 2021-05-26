using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SixthTask
{
    class Program
    {
        static void Main()
        {
            Stream stream = new OverrideStream(new MemoryStream());

            DecoratedStream decoratedStream = new DecoratedStream(stream);

            //decStream.MethodPass();

            //decStream.MethodPartOfTheRead();
        }
    }
}

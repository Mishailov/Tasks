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
            Console.WriteLine("Write password \n");
            if(!Int32.TryParse(Console.ReadLine(), out int password))
            {
                Console.WriteLine("Uncorrect value");
                return;
            }

            Stream stream = new OverrideStream(new MemoryStream());

            DecoratedStream decoratedStream = new DecoratedStream(stream, password);

            if (!decoratedStream.IsPasswordCorrect())
            {
                Console.WriteLine("Uncorrect password");
                return;
            }

            //decStream.MethodPartOfTheRead();
        }
    }
}

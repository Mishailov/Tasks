using System;
using System.Collections.Generic;

namespace EighthTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Timer timer = new Timer(7);
            timer.StoppedTimer += delegate { Console.WriteLine("Time is over"); };
            timer.TimerStarted();
        }
    }
}

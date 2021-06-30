using System;
using System.Collections.Generic;

namespace EighthTask
{
    class Program
    {
        static void Main(string[] args)
        {
            List<uint> list = new List<uint>(4);
            list.Add(0);
            list.Add(0);
            list.Add(0);
            list.Add(4);
            Timer timer = new Timer(list);
            timer.StoppedTimer += c_StoppedTimer;
            timer.TimerStarted();
        }

        static void c_StoppedTimer(object sender, EventArgs e)
        {
            Console.WriteLine("Time is over");
            Environment.Exit(0);
        }
    }
}

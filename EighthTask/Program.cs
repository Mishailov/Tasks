﻿using System;
using System.Collections.Generic;

namespace EighthTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter seconds");
            if(!uint.TryParse(Console.ReadLine(), out uint value))
            {
                Console.WriteLine("uncorrect value");
                return;
            }

            Timer timer = new Timer(value);
            timer.StoppedTimer += (message) => Console.WriteLine(message);
            timer.TimerStarted();
        }
    }
}

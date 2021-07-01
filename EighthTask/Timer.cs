using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace EighthTask
{
    class Timer
    {
        private uint _seconds;

        public delegate void TimerHandler(string message);
        public event TimerHandler StoppedTimer;

        public Timer(uint seconds)
        {
            _seconds = seconds;
        }

        public void TimerStarted()
        {
            for (uint i = 0; i < _seconds; i++)
            {
                Thread.Sleep(1000);
            }

            StoppedTimer?.Invoke("Time is over");
        }
    }
}

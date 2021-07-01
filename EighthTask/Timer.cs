using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace EighthTask
{
    class Timer
    {
        private uint _seconds;

        public event EventHandler StoppedTimer;

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

            StoppedTimer?.Invoke(this, EventArgs.Empty);
        }
    }
}

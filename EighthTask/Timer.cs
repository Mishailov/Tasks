using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace EighthTask
{
    class Timer
    {
        private uint _day;
        private uint _hour;
        private uint _minuts;
        private uint _seconds;

        public event EventHandler StoppedTimer;

        public Timer(List<uint> times)
        {
            if (times.Count != 4)
                throw new ArgumentOutOfRangeException("more or less than four");

            _day = times[0];
            _hour = times[1];
            _minuts = times[2];
            _seconds = times[3];
        }

        public void TimerStarted()
        {
            for (uint i = 0; i < ConvertTimeToSeconds(); i++)
            {
                Thread.Sleep(1000);
            }

            StoppedTimer?.Invoke(this, EventArgs.Empty);
        }

        private uint ConvertTimeToSeconds()
        {
            return (((((_day * 24) + _hour) * 60) + _minuts) * 60) + _seconds;
        }
    }
}

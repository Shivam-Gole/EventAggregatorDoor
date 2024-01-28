using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace EventAggregator1.cs
{
    public class TimerManager
    {
        private Timer timer;
        private int countdownSeconds;

        public TimerManager(int seconds)
        {
            countdownSeconds = seconds;
            timer = new Timer(CountdownCallback, null, Timeout.Infinite, Timeout.Infinite);
        }

        public void StartCountdown()
        {
            timer.Change(0, 1000);
        }

        private void CountdownCallback(object state)
        {
            countdownSeconds--;

            if (countdownSeconds <= 0)
            {
                EventAggregator.Instance.Publish(new TimerElapsedEventArgs());
                timer.Change(Timeout.Infinite, Timeout.Infinite); // Stop the timer
            }
        }
    }

}

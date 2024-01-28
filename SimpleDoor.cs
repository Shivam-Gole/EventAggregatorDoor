using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventAggregator1.cs
{

    public class SimpleDoor : IDoor
    {
        private bool isOpen;
        private List<IDoorSubscriber> subscribers = new List<IDoorSubscriber>();
        private TimerManager timerManager;

        public event Action<DoorStateChangedEventArgs> DoorStateChanged;

        public void Open()
        {
            isOpen = true;
            OnDoorStateChanged("Door is opened.");
            StartTimer();
        }

        public void Close()
        {
            isOpen = false;
            OnDoorStateChanged("Door is closed.");
        }

        public bool IsOpen()
        {
            return isOpen;
        }

        public void AddSubscriber(IDoorSubscriber subscriber)
        {
            subscribers.Add(subscriber);
            EventAggregator.Instance.Subscribe<DoorStateChangedEventArgs>(subscriber, HandleDoorStateChanged);
        }

        public void RemoveSubscriber(IDoorSubscriber subscriber)
        {
            subscribers.Remove(subscriber);
            EventAggregator.Instance.Unsubscribe<DoorStateChangedEventArgs>(subscriber);
        }

        public void StartTimer()
        {
            timerManager = new TimerManager(20); // 20 seconds countdown
            timerManager.StartCountdown();
            EventAggregator.Instance.Subscribe<TimerElapsedEventArgs>(this, HandleTimerElapsed);
        }

        protected virtual void OnDoorStateChanged(string message)
        {
            DoorStateChanged?.Invoke(new DoorStateChangedEventArgs(message));
        }

        private void HandleDoorStateChanged(DoorStateChangedEventArgs e)
        {
            foreach (var subscriber in subscribers)
            {
                EventAggregator.Instance.Publish(e);
            }
        }

        private void HandleTimerElapsed(TimerElapsedEventArgs e)
        {
            Console.WriteLine("Alert: Door has been open for too long!");
            foreach (var subscriber in subscribers)
            {
                EventAggregator.Instance.Publish(new DoorStateChangedEventArgs("Alert: Door has been open for too long!"));
            }
        }
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventAggregator1.cs
{
    public class Buzzer : IDoorSubscriber
    {
        public Buzzer()
        {
            // Subscribe to the DoorStateChanged event
            EventAggregator.Instance.Subscribe<DoorStateChangedEventArgs>(this, HandleDoorStateChanged);
        }

        // Handle the DoorStateChanged event
        private void HandleDoorStateChanged(DoorStateChangedEventArgs e)
        {
            Console.WriteLine($"Buzzer: {e.Message}");
        }
    }

}

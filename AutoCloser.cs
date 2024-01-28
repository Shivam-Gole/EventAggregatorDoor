using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventAggregator1.cs
{
    public class AutoCloser : IDoorSubscriber
    {
        public AutoCloser()
        {
            // Subscribe to the DoorStateChanged event
            EventAggregator.Instance.Subscribe<DoorStateChangedEventArgs>(this, HandleDoorStateChanged);
        }

        // Handle the DoorStateChanged event
        private void HandleDoorStateChanged(DoorStateChangedEventArgs e)
        {
            if (e.IsOpen())
            {
                e.Close();
                Console.WriteLine("AutoClose: The door is not shut.");
            }
        }
    }

}

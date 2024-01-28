using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventAggregator1.cs
{

    public class DoorStateChangedEventArgs
    {
        public string Message { get; }

        public DoorStateChangedEventArgs(string message)
        {
            Message = message;
        }

        public void Close()
        {
            Console.WriteLine("Door is automatically closed.");
        }

        public bool IsOpen()
        {
            return Message.Contains("opened");
        }
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventAggregator1.cs
{
    // Generic event class
    public class Event<TEvent>
    {
        private static List<Action<TEvent, object>> handlers = new List<Action<TEvent, object>>();

        // Subscribe 
        public static void Subscribe(Action<TEvent> handler)
        {
            handlers.Add((e, s) => handler(e));
        }

        // Publish 
        public static void Publish(TEvent @event, object sender)
        {
            foreach (var handler in handlers)
            {
                handler(@event, sender);
            }
        }

        // Unsubscribe
        public static void Unsubscribe(object subscriber)
        {
            handlers.RemoveAll(h => h.Target == subscriber);
        }
    }

}

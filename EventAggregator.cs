using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventAggregator1.cs
{

    // Event Aggregator to facilitate communication between components
    public class EventAggregator
    {
        private static EventAggregator instance;

        private EventAggregator() { }

        public static EventAggregator Instance
        {
            get
            {
                //  Singleton Pattern
                instance = new EventAggregator();
                
                return instance;
            }
        }

        // Dictionary to store event subscribers
        private Dictionary<Type, List<object>> subscribers = new Dictionary<Type, List<object>>();

        // Subscribe a component to a specific event type
        public void Subscribe<TEvent>(object subscriber, Action<TEvent> handler)
        {
            Type eventType = typeof(TEvent);
            if (!subscribers.ContainsKey(eventType))
            {
                subscribers[eventType] = new List<object>();
            }

            subscribers[eventType].Add(subscriber);
            Event<TEvent>.Subscribe(handler);
        }

        // Publish an event to all subscribers
        public void Publish<TEvent>(TEvent @event)
        {
            Type eventType = typeof(TEvent);
            if (subscribers.ContainsKey(eventType))
            {
                foreach (var subscriber in subscribers[eventType])
                {
                    Event<TEvent>.Publish(@event, subscriber);
                }
            }
        }

        // Unsubscribe a component from a specific event type
        public void Unsubscribe<TEvent>(object subscriber)
        {
            Type eventType = typeof(TEvent);
            if (subscribers.ContainsKey(eventType))
            {
                subscribers[eventType].Remove(subscriber);
            }
            Event<TEvent>.Unsubscribe(subscriber);
        }
    }

}

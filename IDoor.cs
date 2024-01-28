using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventAggregator1.cs
{
    public interface IDoor
    {
        void Open();
        void Close();
        void AddSubscriber(IDoorSubscriber subscriber);
        void RemoveSubscriber(IDoorSubscriber subscriber);
        void StartTimer();
    }

}

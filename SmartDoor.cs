using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventAggregator1.cs
{
    public class SmartDoor : SimpleDoor
    {
        private bool buzzerEnabled;
        private bool pagerEnabled;
        private bool autoCloseEnabled;

        public SmartDoor(bool buzzer, bool pager, bool autoClose)
        {
            this.buzzerEnabled = buzzer;
            this.pagerEnabled = pager;
            this.autoCloseEnabled = autoClose;

            // Addon Features
            if (buzzerEnabled)
            {
                AddSubscriber(new Buzzer());
            }

            if (pagerEnabled)
            {
                AddSubscriber(new Pager());
            }

            if (autoCloseEnabled)
            {
                AddSubscriber(new AutoCloser());
            }
        }

        // smart door featuer configuration
        public void ConfigureFeatures(bool buzzer, bool pager, bool autoClose)
        {
            
            ConfigureBuzzer(buzzer);
            ConfigurePager(pager);
            ConfigureAutoClose(autoClose);
        }

        private void ConfigureBuzzer(bool enable)
        {
            if (enable && !buzzerEnabled)
            {
                AddSubscriber(new Buzzer());
            }
            else if (!enable && buzzerEnabled)
            {
                RemoveSubscriber(new Buzzer());
            }
            buzzerEnabled = enable;
        }

        private void ConfigurePager(bool enable)
        {
            if (enable && !pagerEnabled)
            {
                AddSubscriber(new Pager());
            }
            else if (!enable && pagerEnabled)
            {
                RemoveSubscriber(new Pager());
            }
            pagerEnabled = enable;
        }

        private void ConfigureAutoClose(bool enable)
        {
            if (enable && !autoCloseEnabled)
            {
                AddSubscriber(new AutoCloser());
            }
            else if (!enable && autoCloseEnabled)
            {
                RemoveSubscriber(new AutoCloser());
            }
            autoCloseEnabled = enable;
        }
    }

}

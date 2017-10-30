using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPublisher
{
    interface IEventContainer
    {
        void PublishEvent(string eventName, object parameter);

        void SubscribeEvent(string eventName, Action<object> eventHandler);
    }
}

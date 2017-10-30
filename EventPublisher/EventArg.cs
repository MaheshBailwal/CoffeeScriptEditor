using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPublisher
{
   public class EventArg
    {
       public EventArg(Guid eventId, object arg)
       {
           EventId = eventId;
           Arg = arg;
       }

       public Guid EventId { get; private set; }
      
       public object Arg { get; private set; }
        
    }
}

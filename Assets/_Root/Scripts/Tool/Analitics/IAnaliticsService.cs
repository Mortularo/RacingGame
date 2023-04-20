using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tool.Analitics
{
    internal interface  IAnaliticsService
    {
        void SendEvent(string eventName);
        void SendEvent(string eventName, Dictionary<string, object> eventData);
    }
}

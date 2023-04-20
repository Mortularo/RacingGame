using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tool.Analitics
{
    internal class UnityAnaliticsService : IAnaliticsService
    {
        public void SendEvent(string eventName) =>
            UnityEngine.Analytics.Analytics.CustomEvent(eventName);

        public void SendEvent(string eventName, Dictionary<string, object> eventData) =>
            UnityEngine.Analytics.Analytics.CustomEvent(eventName, eventData);
    }
}

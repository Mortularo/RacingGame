using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Tool.Analitics
{
    internal class AnaliticsManager : MonoBehaviour
    {
        private IAnaliticsService[] _services;
        private void Awake()
        {
            _services = new IAnaliticsService[]
            {
                new UnityAnaliticsService(),
                //new Dev2devAnaliticsService()
            };
        }
        public void SendMenuOpenedEvent() =>
            SendEvent("MainMenuOpened");
        private void SendEvent(string eventName)
        {
            foreach (IAnaliticsService service in _services)
                service.SendEvent(eventName);
        }
        private void SendEvent(string eventName, Dictionary<string, object> eventData)
        {
            foreach (IAnaliticsService service in _services)
                service.SendEvent(eventName, eventData);
        }
    }
}

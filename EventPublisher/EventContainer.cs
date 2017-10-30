using System;
using System.Collections.Generic;

namespace EventPublisher
{
    public static class EventContainer
    {
        public static Dictionary<string, List<Action<EventArg>>> dic = new Dictionary<string, List<Action<EventArg>>>();

        public static void SubscribeEvent(string eventName, Action<EventArg> eventHandler)
        {
            List<Action<EventArg>> evenHandlers = new List<Action<EventArg>>();

            if (dic.ContainsKey(eventName))
            {
                evenHandlers = dic[eventName];
            }

            evenHandlers.Add(eventHandler);
            dic[eventName] = evenHandlers;
        }

        public static void PublishEvent(string eventName, EventArg parameter)
        {
            if (dic.ContainsKey(eventName))
            {
               ExecuteHandlers(dic[eventName], parameter);
            }
        }

        private static void ExecuteHandlers(List<Action<EventArg>> evenHandlers, EventArg parameter)
        {
            foreach (var action in evenHandlers)
            {
                action(parameter);
            }
        }
    }
}

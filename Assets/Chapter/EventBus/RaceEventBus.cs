using System.Collections.Generic;
using UnityEngine.Events;

namespace Chapter.EventBus
{
	public enum RaceEventType
	{
		CountDown, Start, Restart, Pause, Stop, Finish, Quit
	}
	
	public static class RaceEventBus
	{
		static readonly IDictionary<RaceEventType, UnityEvent> events = new Dictionary<RaceEventType, UnityEvent>();

		public static void Subscribe(RaceEventType eventType, UnityAction listener) //listener -> callback
		{
			if (events.TryGetValue(eventType, out var thisEvent))
			{
				thisEvent.AddListener(listener);
			}
			else
			{
				thisEvent = new UnityEvent();
				thisEvent.AddListener(listener);
				events.Add(eventType, thisEvent);
			}
		}

		public static void UnSubscribe(RaceEventType eventType, UnityAction listener)
		{
			if (events.TryGetValue(eventType, out var thisEvent))
			{
				thisEvent.RemoveListener(listener);
			}
		}

		public static void Publish(RaceEventType eventType)
		{
			if (events.TryGetValue(eventType, out var thisEvent))
			{
				thisEvent.Invoke();
			}
		}
	}
}

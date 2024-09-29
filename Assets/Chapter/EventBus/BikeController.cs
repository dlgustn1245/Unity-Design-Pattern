using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Chapter.EventBus
{
	public class BikeController : MonoBehaviour
	{
		public string status;

		void OnEnable()
		{
			RaceEventBus.Subscribe(RaceEventType.Start, StartBike);
			RaceEventBus.Subscribe(RaceEventType.Stop, StopBike);
		}

		void OnDisable()
		{
			RaceEventBus.UnSubscribe(RaceEventType.Start, StartBike);
			RaceEventBus.UnSubscribe(RaceEventType.Stop, StopBike);
		}

		void StartBike()
		{
			status = "Started";
		}

		void StopBike()
		{
			status = "Stopped";
		}

		void OnGUI()
		{
			GUI.color = Color.green;
			GUI.Label(new Rect(10, 60, 200, 20), "BIKE STATUS: " + status);
		}
	}
}

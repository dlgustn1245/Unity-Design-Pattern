using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Chapter.EventBus
{
	public class HUDController : MonoBehaviour
	{
		bool isDisplayOn;

		void OnEnable()
		{
			RaceEventBus.Subscribe(RaceEventType.Start, DisplayHUD);
		}

		void OnDisable()
		{
			RaceEventBus.UnSubscribe(RaceEventType.Start, DisplayHUD);
		}

		void DisplayHUD()
		{
			isDisplayOn = true;
		}

		void OnGUI()
		{
			if (isDisplayOn)
			{
				if (GUILayout.Button("Stop Race"))
				{
					isDisplayOn = false;
					RaceEventBus.Publish(RaceEventType.Stop);
				}
			}
		}
	}
}

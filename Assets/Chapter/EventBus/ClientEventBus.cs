using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Chapter.EventBus
{
	public class ClientEventBus : MonoBehaviour
	{
		bool isButtonEnabled;

		void Start()
		{
			gameObject.AddComponent<HUDController>();
			gameObject.AddComponent<CountDownTimer>();
			gameObject.AddComponent<BikeController>();

			isButtonEnabled = true;
		}

		void OnEnable()
		{
			RaceEventBus.Subscribe(RaceEventType.Stop, Restart);
		}

		void OnDisable()
		{
			RaceEventBus.UnSubscribe(RaceEventType.Stop, Restart);
		}

		void Restart()
		{
			isButtonEnabled = true;
		}

		void OnGUI()
		{
			if (isButtonEnabled)
			{
				if (GUILayout.Button("Start CountDown"))
				{
					isButtonEnabled = false;
					RaceEventBus.Publish(RaceEventType.CountDown);
				}
			}
		}
	}
}

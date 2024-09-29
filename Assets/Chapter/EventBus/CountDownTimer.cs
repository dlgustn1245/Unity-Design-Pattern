using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Chapter.EventBus
{
	public class CountDownTimer : MonoBehaviour
	{
		int currTime;
		int duration = 3;

		void OnEnable()
		{
			RaceEventBus.Subscribe(RaceEventType.CountDown, StartTimer);
		}

		void OnDisable()
		{
			RaceEventBus.UnSubscribe(RaceEventType.CountDown, StartTimer);	
		}

		void StartTimer()
		{
			StartCoroutine(CountDown());
		}

		IEnumerator CountDown()
		{
			for (int i = duration; i > 0; i--)
			{
				currTime = i;
				yield return new WaitForSeconds(1.0f);
			}
			RaceEventBus.Publish(RaceEventType.Start);
		}

		void OnGUI()
		{
			GUI.color = Color.blue;
			GUI.Label(new Rect(126, 0, 100, 20), "COUNTDOWN: " + currTime);
		}
	}
}

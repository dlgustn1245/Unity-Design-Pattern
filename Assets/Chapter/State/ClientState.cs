using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Chapter.State
{
	public class ClientState : MonoBehaviour
	{
		BikeController bikeController;

		void Start()
		{
			bikeController = FindObjectOfType<BikeController>();
		}

		void OnGUI()
		{
			if (GUILayout.Button("Start Bike"))
			{
				bikeController.StartBike();
			}

			if (GUILayout.Button("Stop Bike"))
			{
				bikeController.StopBike();
			}

			if (GUILayout.Button("Turn Right"))
			{
				bikeController.TurnBike(Direction.Right);
			}
			
			if (GUILayout.Button("Turn Left"))
			{
				bikeController.TurnBike(Direction.Left);
			}
		}
	}
}

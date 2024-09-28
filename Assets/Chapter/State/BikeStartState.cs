using System;
using System.Collections;
using System.Collections.Generic;
using Chapter.State;
using UnityEngine;

namespace Chapter.State
{
	public class BikeStartState : MonoBehaviour, IBikeState
	{
		BikeController bikeController;
		
		public void Handle(BikeController controller)
		{
			if (controller is not null)
			{
				bikeController = controller;
				bikeController.currSpeed = bikeController.maxSpeed;
			}
		}

		void Update()
		{
			if (bikeController is not null)
			{
				if (bikeController.currSpeed > 0)
				{
					bikeController.transform.Translate(
						Vector3.forward * (bikeController.currSpeed * Time.deltaTime));
				}
			}
		}
	}
}

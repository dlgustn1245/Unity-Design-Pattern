using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Chapter.State
{
	public class BikeStopState : MonoBehaviour, IBikeState
	{
		BikeController bikeController;
		
		public void Handle(BikeController controller)
		{
			if (controller is not null)
			{
				bikeController = controller;
				controller.currSpeed = 0f;
			}
		}
	}
}

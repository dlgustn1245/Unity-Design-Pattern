using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Chapter.State
{
	public class BikeTurnState : MonoBehaviour, IBikeState
	{
		BikeController bikeController;
		Vector3 turnDir;
		
		public void Handle(BikeController controller)
		{
			if (controller is not null)
			{
				bikeController = controller;

				turnDir.x = (float)bikeController.currTurnDirection;

				if (bikeController.currSpeed > 0f)
				{
					transform.Translate(turnDir * bikeController.turnDistance);
				}
			}
		}
	}
}

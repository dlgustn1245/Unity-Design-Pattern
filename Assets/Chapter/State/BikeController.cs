using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Chapter.State
{
	public enum Direction
	{
		Left = -1,
		Right = 1
	}
	public class BikeController : MonoBehaviour
	{
		public float maxSpeed = 2.0f;
		public float turnDistance = 2.0f;

		public float currSpeed
		{
			get;
			set;
		}

		public Direction currTurnDirection
		{
			get;
			private set;
		}

		IBikeState startState, stopState, turnState;
		BikeStateContext bikeStateContext;

		void Start()
		{
			bikeStateContext = new BikeStateContext(this);

			startState = gameObject.AddComponent<BikeStartState>();
			stopState = gameObject.AddComponent<BikeStopState>();
			turnState = gameObject.AddComponent<BikeTurnState>();
			
			bikeStateContext.Transition(stopState);
		}

		public void StartBike()
		{
			bikeStateContext.Transition(startState);
		}

		public void StopBike()
		{
			bikeStateContext.Transition(stopState);
		}

		public void TurnBike(Direction dir)
		{
			currTurnDirection = dir;
			bikeStateContext.Transition(turnState);
		}
	}
}

namespace Chapter.State
{
	public class BikeStateContext
	{
		public IBikeState CurrState
		{
			get;
			set;
		}

		readonly BikeController bikeController;

		public BikeStateContext(BikeController controller)
		{
			bikeController = controller;
		}
		
		public void Transition()
		{
			CurrState.Handle(bikeController);
		}

		public void Transition(IBikeState state)
		{
			CurrState = state;
			CurrState.Handle(bikeController);
		}
	}
}

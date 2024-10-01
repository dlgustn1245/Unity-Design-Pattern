using UnityEngine;

namespace Chapter.Command
{
    public class TurnLeft : Command
    {
        BikeController controller;

        public TurnLeft(BikeController controller)
        {
            this.controller = controller;
        }

        public override void Execute()
        {
            controller.Turn(BikeController.Direction.Left);
        }
    }
}

using UnityEngine;

namespace Chapter.Command
{
    public class TurnRight : Command
    {
        BikeController controller;

        public TurnRight(BikeController controller)
        {
            this.controller = controller;
        }

        public override void Execute()
        {
            controller.Turn(BikeController.Direction.Right);
        }
    }
}

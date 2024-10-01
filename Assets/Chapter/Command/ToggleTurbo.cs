using UnityEngine;

namespace Chapter.Command
{
    public class ToggleTurbo : Command
    {
        BikeController controller;

        public ToggleTurbo(BikeController controller)
        {
            this.controller = controller;
        }

        public override void Execute()
        {
            controller.ToggleTurbo();
        }
    }
}

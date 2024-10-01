using UnityEngine;

namespace Chapter.Command
{
    public class BikeController : MonoBehaviour
    {
        public enum Direction
        {
            Left = -1,
            Right = 1
        }

        bool isTurboOn;
        float distance = 1.0f;
        
        public void ToggleTurbo()
        {
            isTurboOn = !isTurboOn;
            print("Turbo Active : " + isTurboOn);
        }

        public void Turn(Direction dir)
        {
            if (dir == Direction.Left)
            {
                transform.Translate(Vector3.left * distance);
            }

            if (dir == Direction.Right)
            {
                transform.Translate(Vector3.right * distance);
            }
        }

        public void ResetPosition()
        {
            transform.position = Vector3.zero;
        }
    }
}

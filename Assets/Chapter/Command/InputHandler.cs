using System;
using UnityEngine;

namespace Chapter.Command
{
    public class InputHandler : MonoBehaviour
    {
        Invoker invoker;
        bool isReplaying;
        bool isRecording;
        BikeController controller;
        Command btnA, btnD, btnW;

        void Start()
        {
            invoker = gameObject.AddComponent<Invoker>();
            controller = gameObject.AddComponent<BikeController>();

            btnA = new TurnLeft(controller);
            btnD = new TurnRight(controller);
            btnW = new ToggleTurbo(controller);
        }

        void Update()
        {
            if (!isReplaying && isRecording)
            {
                if (Input.GetKeyUp(KeyCode.A))
                {
                    invoker.ExecuteCommand(btnA);
                }

                if (Input.GetKeyUp(KeyCode.D))
                {
                    invoker.ExecuteCommand(btnD);
                }

                if (Input.GetKeyUp(KeyCode.W))
                {
                    invoker.ExecuteCommand(btnW);
                }
            }
        }

        void OnGUI()
        {
            if (GUILayout.Button("Start Recording"))
            {
                controller.ResetPosition();
                isReplaying = false;
                isRecording = true;
                invoker.Record();
            }

            if (GUILayout.Button("Stop Recording"))
            {
                controller.ResetPosition();
                isRecording = false;
            }

            if (!isRecording)
            {
                if (GUILayout.Button("Start Replay"))
                {
                    controller.ResetPosition();
                    isReplaying = true;
                    isRecording = false;
                    invoker.Replay();
                }
            }
        }
    }
}

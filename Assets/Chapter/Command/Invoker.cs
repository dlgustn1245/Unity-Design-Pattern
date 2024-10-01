using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Chapter.Command
{
    public class Invoker : MonoBehaviour
    {
        bool isRecording;
        bool isReplaying;
        float replayTime;
        float recordingTime;
        SortedList<float, Command> recordedCommands = new SortedList<float, Command>();
        
        public void ExecuteCommand(Command command)
        {
            command.Execute();

            if (isRecording)
            {
                recordedCommands.Add(recordingTime, command);
            }
            
            print("Recorded Time : " + recordingTime);
            print("Recorded Command : " + command);
        }

        public void Record()
        {
            recordingTime = 0f;
            isRecording = true;
        }

        public void Replay()
        {
            replayTime = 0f;
            isReplaying = true;

            if (recordedCommands.Count <= 0)
            {
                Debug.LogError("No commands to replay!");
            }
        }

        void FixedUpdate()
        {
            if (isRecording)
            {
                recordingTime += Time.fixedDeltaTime;
            }

            if (isReplaying)
            {
                replayTime += Time.deltaTime;

                if (recordedCommands.Any())
                {
                    if (Mathf.Approximately(replayTime, recordedCommands.Keys[0]))
                    {
                        print("Replay Time : " + replayTime);
                        print("Replay Command : " + recordedCommands.Values[0]);
                        
                        recordedCommands.Values[0].Execute();
                        recordedCommands.RemoveAt(0);
                    }
                }
                else
                {
                    isReplaying = false;
                }
            }
        }
    }
}

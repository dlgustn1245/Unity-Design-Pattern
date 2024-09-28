using System;
using System.Collections;
using System.Collections.Generic;
using Chapter.Singleton;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    DateTime sessionStartTime;
    DateTime sessionEndTime;
    
    // protected override void Awake()
    // {
    //     base.Awake();
    // }

    void Start()
    {
        sessionStartTime = DateTime.Now;
        print("Game session start @: " + DateTime.Now);
    }

    void OnApplicationQuit()
    {
        sessionEndTime = DateTime.Now;
        var timeDifference = sessionEndTime.Subtract(sessionStartTime);

        print("Game session ended @: " + DateTime.Now);
        print("Game session lasted: " + timeDifference);
    }

    void OnGUI()
    {
        if (GUILayout.Button("Next Scene"))
        {
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
using System;
using UnityEngine;

namespace Chapter.ObjectPool
{
    public class ClientObjectPool : MonoBehaviour
    {
        DroneObjectPool pool;

        void Start()
        {
            pool = gameObject.AddComponent<DroneObjectPool>();
        }

        void OnGUI()
        {
            if (GUILayout.Button("Spawn Drones"))
            {
                pool.Spawn();
            }
        }
    }
}

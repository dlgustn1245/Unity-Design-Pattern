using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

namespace Chapter.ObjectPool
{
    public class Drone : MonoBehaviour
    {
        public IObjectPool<Drone> pool { get; set; }
        
        public float currHealth;
        public float maxHealth = 100.0f;
        public float timeToSelfDestruct = 3.0f;

        void Start()
        {
            ResetDrone();
        }

        void OnEnable()
        {
            AttackPlayer();
            StartCoroutine(SelfDestruct());
        }

        void OnDisable()
        {
            ResetDrone();
        }

        IEnumerator SelfDestruct()
        {
            yield return new WaitForSeconds(timeToSelfDestruct);
            TakeDamage(maxHealth);
        }

        void ReturnToPool()
        {
            pool.Release(this);
        }

        void ResetDrone()
        {
            currHealth = maxHealth;
        }

        public void AttackPlayer()
        {
            print("Attack!");
        }

        public void TakeDamage(float amount)
        {
            currHealth -= amount;
            if (currHealth <= 0.0f)
            {
                ReturnToPool();
            }
        }
    }
}

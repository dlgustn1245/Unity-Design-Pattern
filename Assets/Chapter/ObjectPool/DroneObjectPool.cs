using UnityEngine;
using UnityEngine.Pool;

namespace Chapter.ObjectPool
{
    public class DroneObjectPool : MonoBehaviour
    {
        public int maxPoolSize = 10;
        public int stackDefaultCapacity = 10;

        IObjectPool<Drone> pool;
        public IObjectPool<Drone> Pool
        {
            get
            {
                if (pool is null)
                {
                    pool = new ObjectPool<Drone>(
                    CreatePooledItem,
                    OnTakeFromPool,
                    OnReturnedToPool,
                    OnDestroyPoolObject,
                    true,
                    stackDefaultCapacity,
                    maxPoolSize);
                }

                return pool;
            }
        }

        Drone CreatePooledItem()
        {
            var go = GameObject.CreatePrimitive(PrimitiveType.Cube);
            var drone = go.AddComponent<Drone>();

            go.name = "Drone";
            drone.pool = Pool;

            return drone;
        }

        void OnReturnedToPool(Drone drone)
        {
            drone.gameObject.SetActive(false);
        }

        void OnTakeFromPool(Drone drone)
        {
            drone.gameObject.SetActive(true);
        }

        void OnDestroyPoolObject(Drone drone)
        {
            Destroy(drone.gameObject);
        }

        public void Spawn()
        {
            var amount = Random.Range(1, 10);

            for (int i = 0; i < amount; i++)
            {
                var drone = Pool.Get();

                drone.transform.position = Random.insideUnitSphere * 10;
            }
        }
    }
}

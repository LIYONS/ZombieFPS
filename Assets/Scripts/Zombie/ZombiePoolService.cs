using UnityEngine;
using ZombieFPS.ObjectPool;

namespace ZombieFPS.Enemy
{
    public class ZombiePoolService : GenericPool<ZombieController>
    {
        private GameObject zombiePrefab;
        public void GetZombie(GameObject prefab,Transform spawnPoint)
        {
            zombiePrefab = prefab;
            ZombieController zombieController = GetItem();
            zombieController.transform.SetPositionAndRotation(spawnPoint.position, spawnPoint.rotation);
            zombieController.gameObject.SetActive(true);
        }

        public override ZombieController CreateItem()
        {
            ZombieController zombieController= Instantiate(zombiePrefab).GetComponent<ZombieController>();
            zombieController.transform.parent = null;
            return zombieController;
        }
    }
}

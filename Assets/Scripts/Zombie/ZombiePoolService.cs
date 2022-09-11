using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZombieFPS.ObjectPool;

namespace ZombieFPS.Enemy
{
    public class ZombiePoolService : GenericPool<ZombieController>
    {
        private GameObject zombiePreab;
        public void GetZombie(GameObject prefab,Transform spawnPoint)
        {
            zombiePreab = prefab;
            ZombieController zombieController = GetItem();
            zombieController.transform.SetPositionAndRotation(spawnPoint.position, spawnPoint.rotation);
            zombieController.gameObject.SetActive(true);
        }

        public override ZombieController CreateItem()
        {
            ZombieController zombieController= Instantiate(zombiePreab).GetComponent<ZombieController>();
            zombieController.transform.parent = null;
            return zombieController;
        }
    }
}

using UnityEngine;

namespace ZombieFPS.Enemy
{
    public class ZombieSpawner : MonoBehaviour
    {
        [SerializeField] private ZombieController zombiePreab;
        [SerializeField] private Transform[] spawnPoints;
        [SerializeField] private int initialSpawns;
        [SerializeField] private int maxSpawns;
        [SerializeField] private float timeBtwAutoSpawn;

        private int spawnIndex;
        private int zombieCount;
        private float spawnTimer;
        private void Start()
        {
            for (int i = 0; i < initialSpawns; i++)
            {
                SpawnZombie();
            }
        }
        private void Update()
        {
            if(spawnTimer<Time.time && zombieCount<maxSpawns)
            {
                SpawnZombie();
                spawnTimer += timeBtwAutoSpawn;
            }
        }
        private void SpawnZombie()
        {
            GenerateIndex();
            Instantiate(zombiePreab, spawnPoints[spawnIndex].position, spawnPoints[spawnIndex].rotation);
            zombieCount++;
        }

        private void GenerateIndex()
        {
            int index;
            do
            {
                index = Random.Range(0, spawnPoints.Length);
            }
            while (index == spawnIndex);
            spawnIndex = index;
        }
    }
}

using UnityEngine;
namespace ZombieFPS.Enemy
{
    public class ZombieSpawner : MonoBehaviour
    {
        [SerializeField] private ZombieController[] zombiePrefabs;
        [SerializeField] private Transform[] spawnPoints;
        [SerializeField] private int initialSpawns;
        [SerializeField] private int maxSpawns;
        [SerializeField] private float timeBtwAutoSpawn;

        private ZombiePoolService zombiePool;
        private int spawnIndex;
        private int zombieCount;
        private float spawnTimer;
        private int deadCount;

        private void Awake()
        {
            zombiePool = GetComponent<ZombiePoolService>();
        }

        private void Start()
        {
            EventHandler.Instance.OnEnemyDead += ReduceZombieCount;
            for (int i = 0; i < initialSpawns; i++)
            {
                SpawnZombie();
            }
            deadCount = 0;
        }
     
        private void Update()
        {
            if(spawnTimer<Time.time && zombieCount<maxSpawns)
            {
                SpawnZombie();
                spawnTimer =Time.time+timeBtwAutoSpawn;
            }
        }
        private void SpawnZombie()
        {
            GenerateSpawnPointIndex();
            int zombieIndex = Random.Range(0, zombiePrefabs.Length);
            zombiePool.GetZombie(zombiePrefabs[zombieIndex].gameObject, spawnPoints[spawnIndex]);
            zombieCount++;
        }

        private void GenerateSpawnPointIndex()
        {
            int index;
            do
            {
                index = Random.Range(0, spawnPoints.Length);
            }
            while (index == spawnIndex);
            spawnIndex = index;
        }

        private void ReduceZombieCount()
        {
            zombieCount--;
            deadCount++;
            SpawnZombie();
            if(deadCount%5==0)
            {
                maxSpawns++;
            }
        }

        private void OnDisable()
        {
            EventHandler.Instance.OnEnemyDead -= ReduceZombieCount;
        }
    }
}

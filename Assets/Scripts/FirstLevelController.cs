using System.Collections.Generic;
using UnityEngine;

public class FirstLevelController : MonoBehaviour
{
    EnemyFactory enemyFactory;
    new Camera camera;
    [SerializeField] private LevelSpawnsData levelSpawnsData;
    [SerializeField] private Queue<EnemiesWave> spawnPositionsY;

    void Start()
    {
        enemyFactory = GetComponent<EnemyFactory>();
        camera = Camera.main;
        spawnPositionsY = new();
        for (int i = 0; i < levelSpawnsData.enemiesWaves.Length; i++)
        {
            spawnPositionsY.Enqueue(levelSpawnsData.enemiesWaves[i]);
        }
    }

    void Update()
    {
        if (spawnPositionsY.Count > 0 && camera.transform.position.y >= spawnPositionsY.Peek().spawnYPosition)
        {
            EnemiesWave wave = spawnPositionsY.Dequeue();
            enemyFactory.InstantiateEnemies(wave.numberOfEnemies, wave.enemyType);
        }
    }


}

using System.Collections.Generic;
using UnityEngine;

public class FirstLevelController : MonoBehaviour
{
    EnemyFactory enemyFactory;
    new Camera camera;
    [SerializeField] private EnemiesWave[] spawnArray;
    [SerializeField] private Queue<EnemiesWave> spawnPositionsY;

    void Start()
    {
        enemyFactory = GetComponent<EnemyFactory>();
        camera = Camera.main;
        spawnPositionsY = new();
        for (int i = 0; i < spawnArray.Length; i++)
        {
            spawnPositionsY.Enqueue(spawnArray[i]);
        }
    }

    void Update()
    {
        if (spawnPositionsY.Count > 0 && camera.transform.position.y >= spawnPositionsY.Peek().spawnYPosition)
        {
            EnemiesWave wave = spawnPositionsY.Dequeue();
            Vector3 spawnPosition = new(0, camera.transform.position.y + 20, -9.4f);
            enemyFactory.InstantiateEnemies(wave.numberOfEnemies, wave.enemyType, spawnPosition);
        }
    }


}

using System.Collections.Generic;
using UnityEngine;

public class FirstLevelController : MonoBehaviour
{
    EnemyFactory enemyFactory;
    [SerializeField] private new GameObject camera;
    [SerializeField] private float[] spawnYPositionsArray;
    [SerializeField] private Queue<float> spawnPositionsY;

    void Start()
    {
        enemyFactory = GetComponent<EnemyFactory>();
        spawnPositionsY = new();
        for (int i = 0; i < spawnYPositionsArray.Length; i++)
        {
            spawnPositionsY.Enqueue(spawnYPositionsArray[i]);
        }
    }

    void Update()
    {
        if (spawnPositionsY.Count > 0 && camera.transform.position.y >= spawnPositionsY.Peek())
        {
            spawnPositionsY.Dequeue();
            Vector3 spawnPosition = new(0, camera.transform.position.y + 20, 0);
            enemyFactory.InstantiateEnemies(4, EnemyType.dron, spawnPosition);
        }
    }


}

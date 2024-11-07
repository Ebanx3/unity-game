using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    [SerializeField] private EnemiesToSpawn[] _enemiesToSpawn;
    [SerializeField] private BoxCollider2D _spawnArea;

    private Dictionary<GameObject, GameObject> _enemyToPrefabMap = new Dictionary<GameObject, GameObject>();

    private List <GameObject> _spawnedEnemies = new List<GameObject>();

    private void Start()
    {
        if (_spawnedEnemies.Count == 0)
        {
            for (int i = 0; i < _enemiesToSpawn.Length; i++)
            {
                for (int j = 0; j < _enemiesToSpawn[i].NumberToSpawn; j++)
                {
                    GameObject go = Instantiate(_enemiesToSpawn[i].EnemyPrefab, GetRandomPositionInBox(), Quaternion.identity);
                    _spawnedEnemies.Add(go);
                    _enemyToPrefabMap[go] = _enemiesToSpawn[i].EnemyPrefab;
                }
            }
        }
    }

    private Vector2 GetRandomPositionInBox()
    {
        Vector2 boxCenter = _spawnArea.bounds.center;
        Vector2 boxSize = _spawnArea.bounds.size;

        float randomX = Random.Range(boxCenter.x - boxSize.x / 2, boxCenter.x + boxSize.x / 2);
        float randomY = Random.Range(boxCenter.y - boxSize.y / 2, boxCenter.y + boxSize.y / 2);

        return new Vector2(randomX, randomY);
    }

    [System.Serializable]
    private class EnemiesToSpawn
    {
        public int NumberToSpawn;
        public GameObject EnemyPrefab;
    }

    #region Save and Load
    public void Save(ref SceneEnemyData data)
    {
        List<EnemySaveData> enemySaveDataList = new List<EnemySaveData>();

        for (int i = _spawnedEnemies.Count - 1; i >= 0; i--)
        {
            if (_spawnedEnemies[i] != null)
            {
                GameObject enemy = _spawnedEnemies[i];
                EnemySaveData saveData = new EnemySaveData()
                {
                    Position = enemy.transform.position,
                    EnemyPrefab = _enemyToPrefabMap[enemy]
                };

                enemySaveDataList.Add(saveData);
            }

            else
            {
                _spawnedEnemies.RemoveAt(i);
            }
        }

        data.Enemies = enemySaveDataList.ToArray();
    }

    public void Load(SceneEnemyData data)
    {
        //Clear existing enemies
        foreach (var enemy in _spawnedEnemies)
        {
            if (enemy != null)
                Destroy(enemy);
        }

        _spawnedEnemies.Clear();
        _enemyToPrefabMap.Clear();

        foreach (var enemyData in data.Enemies)
        {
            if (enemyData.EnemyPrefab != null)
            {
                GameObject spawnedEnemy = Instantiate(enemyData.EnemyPrefab, enemyData.Position, Quaternion.identity);
                _spawnedEnemies.Add(spawnedEnemy);
                _enemyToPrefabMap[spawnedEnemy] = enemyData.EnemyPrefab;
            }
        }
    }
    #endregion
}

[System.Serializable]
public struct SceneEnemyData
{
    public EnemySaveData[] Enemies;
}

[System.Serializable]
public struct EnemySaveData
{
    public Vector3 Position;
    public GameObject EnemyPrefab;
}

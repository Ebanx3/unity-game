using UnityEngine;

[CreateAssetMenu(fileName = "Level Spawn Data", menuName ="LevelSpawnData")]
public class LevelSpawnsData : ScriptableObject
{
    public EnemiesWave[] enemiesWaves;
}

[System.Serializable]
public class EnemiesWave 
{
    public float spawnYPosition;
    public int numberOfEnemies;
    public EnemyType enemyType;
}

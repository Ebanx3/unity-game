using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveSystem
{
    private static SaveData _saveData = new SaveData();

    [System.Serializable]
    public struct SaveData
    {
        public MovementSaveData MovementData;
        public PointData PointData;
        public SceneEnemyData EnemyData;
    }

    public static string SaveFileName()
    {
        string saveFile = Application.persistentDataPath + "/save" + ".save";
        return saveFile;
    }

    public static void Save()
    {
        HandleSaveData();

        File.WriteAllText(SaveFileName(), JsonUtility.ToJson(_saveData, true));
    }

    private static void HandleSaveData()
    {
        GameManager.Instance.Movement.Save(ref _saveData.MovementData);
        GameManager.Instance.PointManager.Save(ref _saveData.PointData);

        EnemySpawnManager spawnManager = GameManager.FindAnyObjectByType<EnemySpawnManager>();
        if (spawnManager != null)
        {
            spawnManager.Save(ref _saveData.EnemyData);
        }
    }

    public static void Load()
    {
        string saveContent = File.ReadAllText(SaveFileName());

        _saveData = JsonUtility.FromJson<SaveData>(saveContent);
        HandleLoadData();
    }

    private static void HandleLoadData()
    {
        GameManager.Instance.Movement.Load(_saveData.MovementData);
        GameManager.Instance.PointManager.Load(_saveData.PointData);

        EnemySpawnManager spawnManager = GameManager.FindAnyObjectByType<EnemySpawnManager>();
        if (spawnManager != null )
        {
            spawnManager.Load(_saveData.EnemyData);
        }
    }
}

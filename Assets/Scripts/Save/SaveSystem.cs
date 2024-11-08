using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Threading.Tasks;

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

        //File.WriteAllText(SaveFileName(), JsonUtility.ToJson(_saveData, true));

        string json = JsonUtility.ToJson(_saveData, true);
        string encryptedData = EncryptionUtility.EncryptString(json);

        File.WriteAllText(SaveFileName(), encryptedData);
    }

    #region Save Async
    //TODO Implement SceneData handling to include scene-specific data in the save process
    public static async Task SaveAsynchronously()
    {
        await SaveAsync();
    }

    private static async Task SaveAsync()
    {
        HandleSaveData();

        //await File.WriteAllTextAsync(SaveFileName(), JsonUtility.ToJson(_saveData, true));

        string json = JsonUtility.ToJson(_saveData, true);
        string encryptedData = EncryptionUtility.EncryptString(json);

        File.WriteAllText(SaveFileName(), encryptedData);
    }
    #endregion

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
        string decryptedContent = EncryptionUtility.DecryptString(saveContent);
        _saveData = JsonUtility.FromJson<SaveData>(decryptedContent);

        //_saveData = JsonUtility.FromJson<SaveData>(saveContent);
        HandleLoadData();
    }

    #region Load Async
    public static async Task LoadAsync()
    {
        string saveContent = File.ReadAllText(SaveFileName());
        string decryptedContent = EncryptionUtility.DecryptString(saveContent);
        _saveData = JsonUtility.FromJson<SaveData>(decryptedContent);

        //_saveData = JsonUtility.FromJson<SaveData>(saveContent);

        await HandleLoadDataAsync();
    }

    private static async Task HandleLoadDataAsync()
    {
        //TODO GameManager.Instance to wait for scene to be fully loaded

        GameManager.Instance.Movement.Load(_saveData.MovementData);
        GameManager.Instance.PointManager.Load(_saveData.PointData);

        EnemySpawnManager spawnManager = GameManager.FindAnyObjectByType<EnemySpawnManager>();
        if (spawnManager != null)
        {
            spawnManager.Load(_saveData.EnemyData);
        }
    }
    #endregion

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

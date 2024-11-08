using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointManager : MonoBehaviour
{
    public static PointManager instance;

    public int CurrentPoint { get; private set; }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        GameManager.Instance.PointManager = this;
    }

    public void IncrementPoint(int amount)
    {
        CurrentPoint += amount;

        HUDManager.instance.UpdateText(CurrentPoint);
    }

    #region Save and Load
    public void Save(ref PointData data)
    {
        data.PointAmount = CurrentPoint;
    }

    public void Load(PointData data)
    {
        CurrentPoint = data.PointAmount;
        HUDManager.instance.UpdateText(CurrentPoint);
    }
    #endregion
}

[System.Serializable]
public struct PointData
{
    public int PointAmount;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyType { dron, caza }

public class EnemyFactory : MonoBehaviour
{
    [SerializeField] private GameObject dronPrefab;
    [SerializeField] private GameObject cazaPrefab;

    [SerializeField] private List<GameObject> drons;
    [SerializeField] private List<GameObject> cazas;

    void Start()
    {
        for (int i = 0; i < 16; i++)
        {
            GameObject dron = Instantiate(dronPrefab);
            dron.SetActive(false);
            drons.Add(dron);
            dron.transform.parent = transform;
        }
        for (int i = 0; i < 16; i++)
        {
            GameObject caza = Instantiate(cazaPrefab);
            caza.SetActive(false);
            cazas.Add(caza);
            caza.transform.parent = transform;
        }
    }

    public void InstantiateEnemies(int amount, EnemyType enemyType, Vector3 position)
    {
        StartCoroutine(InstantiateEnemiesWave(amount, enemyType, position));
    }

    private IEnumerator InstantiateEnemiesWave(int amount, EnemyType enemyType, Vector3 position, float time = .6f)
    {
        int count = 0;
        int i = 0;
        while(i < drons.Count && count < amount)
        {
            if (!drons[i].activeSelf)
            {
                if (enemyType == EnemyType.dron)
                {
                    drons[i].SetActive(true);
                    drons[i].transform.position = position;
                }
                else
                {
                    cazas[i].SetActive(true);
                    cazas[i].transform.position = position;
                }
                yield return new WaitForSeconds(time);
                count++;
            }
            i++;
        }
    }
}

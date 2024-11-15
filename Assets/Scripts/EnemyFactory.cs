using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum EnemyType { dron, caza }

public class EnemyFactory : MonoBehaviour
{
    [SerializeField] private GameObject dronPrefab;
    [SerializeField] private GameObject cazaPrefab;

    [SerializeField] private List<GameObject> enemies;

    void Start()
    {
        for (int i = 0; i < 16; i++)
        {
            GameObject dron = Instantiate(dronPrefab);
            dron.SetActive(false);
            enemies.Add(dron);
            dron.transform.parent = transform;
        }
        for (int i = 0; i < 16; i++)
        {
            GameObject caza = Instantiate(cazaPrefab);
            caza.SetActive(false);
            enemies.Add(caza);
            caza.transform.parent = transform;
        }
    }

    public void InstantiateEnemies(int amount, EnemyType enemyType, Vector3 position)
    {
        StartCoroutine(InstantiateEnemiesWave(amount, enemyType, position));
    }

    private IEnumerator InstantiateEnemiesWave(int amount, EnemyType enemyType, Vector3 position, float time = .5f)
    {
        int count = 0;
        int i = 0;

        while (i < enemies.Count && count < amount)
        {
            if (!enemies[i].activeSelf && enemyType == enemies[i].GetComponent<Enemy>().enemyType)
            {
                enemies[i].SetActive(true);
                enemies[i].transform.position = position;
                yield return new WaitForSeconds(time);
                count++;
            }
            i++;
        }



    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum EnemyType { dron, caza }

public class EnemyFactory : MonoBehaviour
{
    [SerializeField] private GameObject dronPrefab;
    [SerializeField] private GameObject cazaPrefab;

    private new Camera camera;
    private Vector2 screenBounds;

    [SerializeField] private List<GameObject> enemies;

    void Start()
    {
        camera = Camera.main;
        screenBounds = camera.GetComponent<CameraMovement>().ScreenBounds;
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

    public void InstantiateEnemies(int amount, EnemyType enemyType)
    {
        StartCoroutine(InstantiateEnemiesWave(amount, enemyType));
    }

    private float getRandomXValue() {
        float x = Random.Range(-screenBounds.x,screenBounds.x);
        return x;
    }

    private IEnumerator InstantiateEnemiesWave(int amount, EnemyType enemyType, float time = .4f)
    {
        int count = 0;
        int i = 0;

        while (i < enemies.Count && count < amount)
        {
            if (!enemies[i].activeSelf && enemyType == enemies[i].GetComponent<Enemy>().enemyType)
            {
                enemies[i].SetActive(true);
                enemies[i].transform.position = new Vector3(getRandomXValue(), camera.transform.position.y + screenBounds.y , -9.5f);
                yield return new WaitForSeconds(time);
                count++;
            }
            i++;
        }



    }
}

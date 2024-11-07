using System.Collections.Generic;
using UnityEngine;

public class EnemiesBulletPool : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private List<GameObject> bullets;
    [SerializeField] private int bulletsPoolSize = 40;

    void Start()
    {
        AddBulletsToPool(bulletsPoolSize);
    }

    private void AddBulletsToPool(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.SetActive(false);
            bullets.Add(bullet);
            bullet.transform.parent = transform;
        }
    }

    public GameObject InstantiateBullet()
    {
        for (int i = 0; i < bullets.Count; i++)
        {
            if (!bullets[i].activeSelf)
            {
                bullets[i].SetActive(true);
                return bullets[i];
            }
        }
        return null;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [HideInInspector] public bool canShoot = false;
    [SerializeField] private float speed;

    private void Update()
    {
        transform.position = new Vector3(0,transform.position.y + speed * Time.deltaTime, 0);
    }
}

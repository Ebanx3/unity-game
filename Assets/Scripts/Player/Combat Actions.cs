using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class CombatActions : MonoBehaviour
{
    [Header("Sistema de Disparo")]
    private BulletPool BulletsPool;
    private bool isShotting = false;
    [SerializeField] private float fireRate;
    private float lastShootTime;

    [Header("Escudo")]

    [SerializeField] private float shieldTime;
    [HideInInspector] public bool activeShield = false;
    [SerializeField] private GameObject shield;

    [Header("Shoot audio")]
    [SerializeField] private AudioClip audioClip;
    private AudioSource audioSource;

    private void Start()
    {
        BulletsPool = GameObject.Find("BulletsPool").GetComponent<BulletPool>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (lastShootTime >= fireRate)
        {
            Shoot();
            lastShootTime = 0;
        }

        lastShootTime += Time.deltaTime;
    }

    public void Shoot(InputAction.CallbackContext callback)
    {
        if (callback.performed)
        {
            isShotting = true;
        }
        else if (callback.canceled)
        {
            isShotting = false;
        }
    }

    public void Shoot()
    {
        if (isShotting)
        {
            GameObject bullet = BulletsPool.InstantiateBullet();
            bullet.transform.position = transform.position + Vector3.up;
            audioSource.Play();
        }
    }

    //Mecanismo de Escudo/////////////////////////////////////////////

    public void Activate_Shield(InputAction.CallbackContext callback)
    {
        if (callback.performed) StartCoroutine(ShieldAction());
    }

    public IEnumerator ShieldAction()
    {
        shield.SetActive(true);
        activeShield = true;
        yield return new WaitForSeconds(shieldTime);
        activeShield = false;
        shield.SetActive(false);
    }

}

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

    private AudioSource audioSource;
    private Player player;

    private void Start()
    {
        BulletsPool = GameObject.Find("BulletsPool").GetComponent<BulletPool>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
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
        if (callback.performed && player.GetShields() > 0) StartCoroutine(ShieldAction());
    }

    public IEnumerator ShieldAction()
    {
        shield.SetActive(true);
        player.UseShield();
        activeShield = true;
        yield return new WaitForSeconds(shieldTime);
        activeShield = false;
        shield.SetActive(false);
    }

}

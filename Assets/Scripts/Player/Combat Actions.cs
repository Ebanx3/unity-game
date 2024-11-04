using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class CombatActions : MonoBehaviour
{
    [Header("Sistema de Disparo")]
    [SerializeField] private BulletPool BulletsPool;
    private bool isShotting = false;
    [SerializeField] private float fireRate;
    private float lastShootTime;

    [Header("Escudo")]

    [SerializeField] private float shieldTime;
    [SerializeField] private float shieldCoolDown;
    [HideInInspector] public bool activeShield = false;
    private float sTimer;
    [SerializeField] private GameObject shield;

    private void Start()
    {
        sTimer = shieldCoolDown;
        BulletsPool = GameObject.Find("BulletsPool").GetComponent<BulletPool>();
    }

    private void Update()
    {
        if (lastShootTime >= fireRate)
        {
            Shoot();
            lastShootTime = 0;
        }

        //Shield Cooldown...
        lastShootTime += Time.deltaTime;
        sTimer += Time.deltaTime;
    }

    //Mecanismo de Disparo///////////////////////////////////////////

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
            bullet.transform.position = transform.position + Vector3.up * 2;
        }
    }

    //Mecanismo de Escudo/////////////////////////////////////////////

    public void Activate_Shield(InputAction.CallbackContext callback)
    {
        if (callback.performed)
        {
            if (sTimer >= shieldCoolDown)
            {
                StartCoroutine(ShieldAction());
            }
        }
    }

    public IEnumerator ShieldAction()
    {
        shield.SetActive(true);
        activeShield = true;
        yield return new WaitForSeconds(shieldTime);
        activeShield = false;
        shield.SetActive(false);
        sTimer = 0f;
    }

}

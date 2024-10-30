using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class CombatActions : MonoBehaviour
{
    [Header("Sistema de Disparo")]

    [SerializeField] private GameObject bullet;
    // private List<GameObject> bullets = new List<GameObject>();
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
        // bullets.Add()
    }

    private void Update()
    {
        if (lastShootTime > fireRate)
        {
            Vector3 position = transform.position;
            Shoot(position);
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

    public void Shoot(Vector3 position)
    {
        if (isShotting)
        {
            Instantiate(bullet, position, Quaternion.identity);
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class CombatActions : MonoBehaviour
{
    [Header("Sistema de Disparo")]

    [SerializeField] private GameObject bullet;
    private List<Bullet> bullets = new List<Bullet>();
    [SerializeField] private float fireRange;
    private bool isShotting = false;

    [Header("Escudo")]

    [SerializeField] private float shieldTime;
    [SerializeField] private float shieldCoolDown;
    [HideInInspector] public bool activeShield = false;
    private float sTimer;
    [SerializeField] private GameObject shield;

    private void Start()
    {
        sTimer = shieldCoolDown;
    }

    private void Update()
    {
        Shoot();

        //Shield Cooldown...

        sTimer += Time.deltaTime;
    }

    //Mecanismo de Disparo///////////////////////////////////////////

    public void Shoot(InputAction.CallbackContext callback)
    {
        //Debug.Log(callback.phase);
        if(callback.performed)
        {
            isShotting = true;
        }
        else if(callback.canceled)
        {
            isShotting= false;
        }
    }

    public void Shoot()
    {
        if(isShotting)
        {

        }
    }

    //Mecanismo de Escudo/////////////////////////////////////////////

    public void Activate_Shield(InputAction.CallbackContext callback)
    {
        //Debug.Log("Antes if");
        if(callback.performed)
        {
            if(sTimer >= shieldCoolDown)
            {
                Debug.Log("Entro");
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

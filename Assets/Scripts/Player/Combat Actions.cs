using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class CombatActions : MonoBehaviour
{
    [Header("Sistema de Disparo")]
    [SerializeField] private GameObject bullet;
    [SerializeField] private float fireRange;

    [Header("Escudo")]

    [SerializeField] private float shieldTime;
    [SerializeField] private float shieldCoolDown;
    private float sTimer;
    [SerializeField] private GameObject shield;

    private void Start()
    {
        sTimer = shieldCoolDown;
    }

    private void Update()
    {
        //Shield Cooldown
        sTimer += Time.deltaTime;
    }

    //Mecanismo de Disparo

    public void Shoot(InputAction.CallbackContext callback)
    {
        if(callback.performed)
        {

        }
    }

    //Mecanismo de Escudo...

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
        Debug.Log("Se Activo Escudo");
        yield return new WaitForSeconds(shieldTime);
        Debug.Log("Se desactivo Escudo");
        shield.SetActive(false);
        sTimer = 0f;
    }

}

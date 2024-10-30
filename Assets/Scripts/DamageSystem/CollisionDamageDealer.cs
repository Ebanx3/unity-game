using UnityEngine;

public class CollisionDamageDealer : DamageDealer
{
    private void Start()
    {
        // damageType = DamageType.Collision;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        IDamageable damageable = other.GetComponent<IDamageable>();

        if (damageable != null)
        {
            Debug.Log("Colisi�n con el jugador. Aplicando da�o.");
            DealDamage(damageable);
        }
        else
        {
            Debug.Log("Colisi�n con un objeto que no puede recibir da�o.");
        }
    }

    protected override void HandleCollision(Collider2D collider)
    {
        // L�gica personalizada de colisi�n, si es necesario
    }
}

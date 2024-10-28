using UnityEngine;

public class CollisionDamageDealer : DamageDealer
{
    private void Start()
    {
        damageType = DamageType.Collision;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        IDamageable damageable = other.GetComponent<IDamageable>();

        if (damageable != null)
        {
            Debug.Log("Colisión con el jugador. Aplicando daño.");
            DealDamage(damageable);
        }
        else
        {
            Debug.Log("Colisión con un objeto que no puede recibir daño.");
        }
    }

    protected override void HandleCollision(Collider2D collider)
    {
        // Lógica personalizada de colisión, si es necesario
    }
}

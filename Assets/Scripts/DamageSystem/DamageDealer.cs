using UnityEngine;

public abstract class DamageDealer : MonoBehaviour
{
    public int damageAmount = 10;
    public DamageType damageType;

    // Método para aplicar daño a un objeto que implemente IDamageable
    protected void DealDamage(IDamageable target)
    {
        target.TakeDamage(damageAmount, damageType);
    }

    // Método abstracto para manejar colisiones o detección de daño
    protected abstract void HandleCollision(Collider2D collider);
}

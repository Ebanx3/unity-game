using UnityEngine;

public abstract class DamageDealer : MonoBehaviour
{
    public int damageAmount = 10;
    // public DamageType damageType;

    // M�todo para aplicar da�o a un objeto que implemente IDamageable
    protected void DealDamage(IDamageable target)
    {
        target.TakeDamage(damageAmount);
    }

    // M�todo abstracto para manejar colisiones o detecci�n de da�o
    protected abstract void HandleCollision(Collider2D collider);
}

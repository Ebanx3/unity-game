public interface IDamageable
{
    void TakeDamage(int amount, DamageType damageType);
}

public enum DamageType
{
    Collision,
    Bullet
}

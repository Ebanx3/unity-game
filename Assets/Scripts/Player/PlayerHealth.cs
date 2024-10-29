using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    public int maxHealth = 100;
    private int currentHealth;

    public Slider healthSlider;

    // Atributo público para mostrar la salud actual
    public int CurrentHealth => currentHealth; // Propiedad para obtener la salud actual

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthUI();
    }

    public void TakeDamage(int damage, DamageType damageType)
    {
        // Aquí puedes agregar lógica adicional basada en el tipo de daño si es necesario
        switch (damageType)
        {
            case DamageType.Collision:
                Debug.Log($"Daño por colisión recibido: {damage}");
                break;
            case DamageType.Bullet:
                Debug.Log($"Daño por bala recibido: {damage}");
                break;
        }

        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateHealthUI();

        Debug.Log($"Salud actual: {currentHealth}/{maxHealth}");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("El jugador ha muerto.");
        gameObject.SetActive(false);
    }

    public void Heal(int amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateHealthUI();
    }

    private void UpdateHealthUI()
    {
        if (healthSlider != null)
        {
            healthSlider.value = currentHealth;
        }
    }
}

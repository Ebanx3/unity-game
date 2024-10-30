using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    public Slider healthSlider;

    // Atributo p�blico para mostrar la salud actual
    public int CurrentHealth => currentHealth; // Propiedad para obtener la salud actual

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthUI();
    }

    // public void TakeDamage(int damage, DamageType damageType)
    // {
    //     // Aqu� puedes agregar l�gica adicional basada en el tipo de da�o si es necesario
    //     switch (damageType)
    //     {
    //         case DamageType.Collision:
    //             Debug.Log($"Da�o por colisi�n recibido: {damage}");
    //             break;
    //         case DamageType.Bullet:
    //             Debug.Log($"Da�o por bala recibido: {damage}");
    //             break;
    //     }

    //     currentHealth -= damage;
    //     currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
    //     UpdateHealthUI();

    //     Debug.Log($"Salud actual: {currentHealth}/{maxHealth}");

    //     if (currentHealth <= 0)
    //     {
    //         Die();
    //     }
    // }

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

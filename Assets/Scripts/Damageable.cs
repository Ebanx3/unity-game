using UnityEngine;

/// <summary>
/// This class will add the lifePoints variable to handle de health of an object, and the methods TakeDamage and Die.
/// </summary>
public class Damageable : MonoBehaviour
{
    [SerializeField]private int lifePoints;
    private bool isPlayer;

    void Start(){
        isPlayer = gameObject.CompareTag("Player");
    }

    public void TakeDamage(int amount){
        if(isPlayer && GetComponent<CombatActions>().activeShield) return;

        lifePoints -= amount;
        if(lifePoints <= 0){
            Die();
        }   
    }

    private void Die(){
        gameObject.SetActive(false);    
    }
}

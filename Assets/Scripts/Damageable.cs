using UnityEngine;

/// <summary>
/// This class will add the lifePoints variable to handle de health of an object, and the methods TakeDamage and Die.
/// </summary>
public class Damageable : MonoBehaviour
{
    [SerializeField]private int lifePoints;

    /// <summary>
    /// Method to receive damage 
    /// </summary>
    /// <param name="amount">The amount of damage that the object will receive</param>
    public void TakeDamage(int amount){
        if(gameObject.tag == "Player"){
            if(GetComponent<CombatActions>().activeShield){
                return;
            }
        }

        lifePoints -= amount;
        if(lifePoints <= 0){
            Die();
        }   
    }

    private void Die(){
        Destroy(this.gameObject);        
    }
}

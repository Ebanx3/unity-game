
using UnityEngine;

public class Life : MonoBehaviour
{
    [SerializeField] private int life;
    private CombatActions combatActions;

    void Start()
    {
        combatActions = GetComponent<CombatActions>();
    }

    public void ReceiveDamage (int amount){
        if(combatActions.activeShield)
        life -= amount;
        if(life <= 0){
            Debug.Log("Ah me mueroo");
        }
    }
}

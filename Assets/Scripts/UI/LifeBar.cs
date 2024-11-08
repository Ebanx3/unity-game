using UnityEngine;
using UnityEngine.UI;

public class LifeBar : MonoBehaviour
{
    private Image lifeBar;
    private Damageable playerLifePoints;

    void Start(){
        playerLifePoints = GameObject.FindGameObjectWithTag("Player").GetComponent<Damageable>();
        lifeBar = GetComponent<Image>();
    } 

    void Update(){
        lifeBar.fillAmount = playerLifePoints.RelationTotalActualLP();
    }
}

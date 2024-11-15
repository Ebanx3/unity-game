using UnityEngine;
using UnityEngine.UI;

public class LifeBar : MonoBehaviour
{
    private Image lifeBar;
    private Player playerLifePoints;

    void Start(){
        playerLifePoints = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        lifeBar = GetComponent<Image>();
    } 

    void Update(){
        lifeBar.fillAmount = playerLifePoints.RelationTotalActualLP();
    }
}

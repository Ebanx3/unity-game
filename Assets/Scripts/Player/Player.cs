using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
    [SerializeField] private int totalLifePoints;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject controllersPanel;
    private SpriteRenderer sprite;
    private int actualLifePoints;
    private int actualShields;
    private Animator animator;
    private bool invulnerable = false;

    [SerializeField] private GameObject lifeBarGO;
    private LifeBar lifeBar;

    void Start()
    {
        lifeBar = lifeBarGO.GetComponent<LifeBar>();
        animator = GetComponent<Animator>();
        actualLifePoints = totalLifePoints;
        actualShields = 2;
        sprite = GetComponent<SpriteRenderer>();
    }

    public void TakeDamage(int amount)
    {
        if (invulnerable || GetComponent<CombatActions>().activeShield) return;

        actualLifePoints -= amount;
        lifeBar.UpdateLife(totalLifePoints,actualLifePoints);
        StartCoroutine(ChangeColorByDamage());
        if (actualLifePoints <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        StartCoroutine(DieCoroutine());
        
    }

    IEnumerator ChangeColorByDamage()
    {
        sprite.color = Color.red;
        invulnerable = true;
        yield return new WaitForSeconds(.2f);
        invulnerable = false;
        sprite.color = Color.white;
    }

    IEnumerator DieCoroutine()
    {
        animator.SetBool("explosion", true);
        Time.timeScale = .5f;
        yield return new WaitForSeconds(.5f);
        gameOverPanel.SetActive(true);
        controllersPanel.SetActive(false);
        gameObject.SetActive(false);
        
    }

    public float RelationTotalActualLP()
    {
        return (float)actualLifePoints / (float)totalLifePoints;
    }

    public int GetShields(){
        return actualShields;
    }

    public void UseShield(){
        actualShields -= 1;
        lifeBar.UpdateShields(actualShields);
    }

    public void AddShield(){
        actualShields = 2;
        lifeBar.UpdateShields(actualShields);
    }
}

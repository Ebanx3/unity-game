using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Damageable : MonoBehaviour
{
    [SerializeField] private int totalLifePoints;
    [SerializeField] private int score;
    private int actualLifePoints;
    private Animator animator;
    private bool isPlayer;

    private Score scoreManager = null;
    
    void Start()
    {
        isPlayer = gameObject.CompareTag("Player");
        animator = GetComponent<Animator>();
        actualLifePoints = totalLifePoints;

        if (!isPlayer) scoreManager = GameObject.Find("scoreText").GetComponent<Score>();
    }

    public void TakeDamage(int amount)
    {
        if (isPlayer && GetComponent<CombatActions>().activeShield) return;

        actualLifePoints -= amount;
        if (actualLifePoints <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        if (!isPlayer)
        {
            StartCoroutine(DieCoroutine());
            scoreManager.UpdateScore(score);
        }
        else
        {
            // scoreManager.EndGame();
            Debug.Log("Ah me muero");
        }
    }

    IEnumerator DieCoroutine()
    {
        animator.SetBool("explosion", true);
        gameObject.tag = "Defeated";
        yield return new WaitForSeconds(.3f);
        animator.SetBool("explosion", false);
        gameObject.tag = "Enemy";
        actualLifePoints = totalLifePoints;
        gameObject.SetActive(false);
    }

    public float RelationTotalActualLP()
    {
        return (float)actualLifePoints / (float)totalLifePoints;
    }
}

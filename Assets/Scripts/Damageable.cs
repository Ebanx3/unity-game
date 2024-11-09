using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Damageable : MonoBehaviour
{
    [SerializeField] private int totalLifePoints;
    private int actualLifePoints;
    private Animator animator;
    private bool isPlayer;

    void Start()
    {
        isPlayer = gameObject.CompareTag("Player");
        animator = GetComponent<Animator>();
        actualLifePoints = totalLifePoints;
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
        }
        else
        {
            Debug.Log("Ah me muero");
        }
    }

    IEnumerator DieCoroutine()
    {
        animator.SetBool("explosion", true);
        yield return new WaitForSeconds(.3f);
        animator.SetBool("explosion", false);
        actualLifePoints = totalLifePoints;
        gameObject.SetActive(false);
    }

    public float RelationTotalActualLP()
    {
        return (float)actualLifePoints / (float)totalLifePoints;
    }
}

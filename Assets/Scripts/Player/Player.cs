using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
    [SerializeField] private int totalLifePoints;
    private SpriteRenderer sprite;
    private int actualLifePoints;
    private Animator animator;
    private bool invulnerable = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        actualLifePoints = totalLifePoints;
        sprite = GetComponent<SpriteRenderer>();
    }

    public void TakeDamage(int amount)
    {
        if (invulnerable || GetComponent<CombatActions>().activeShield) return;

        actualLifePoints -= amount;
        StartCoroutine(ChangeColorByDamage());
        if (actualLifePoints <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        StartCoroutine(DieCoroutine());
        Debug.Log("Ah me muero");
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
        yield return new WaitForSeconds(.3f);
        gameObject.SetActive(false);
    }

    public float RelationTotalActualLP()
    {
        return (float)actualLifePoints / (float)totalLifePoints;
    }
}

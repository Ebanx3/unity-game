using System.Collections;
using UnityEngine;


/// <summary>
/// This class will add the lifePoints variable to handle the health of an object, and the methods TakeDamage and Die.
/// </summary>
[RequireComponent(typeof(Animator))]
public class Damageable : MonoBehaviour
{
    [SerializeField] private int lifePoints;
    private Animator animator;
    private bool isPlayer;

    void Start()
    {
        isPlayer = gameObject.CompareTag("Player");
        animator = GetComponent<Animator>();
    }

    public void TakeDamage(int amount)
    {
        if (isPlayer && GetComponent<CombatActions>().activeShield) return;

        lifePoints -= amount;
        if (lifePoints <= 0)
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
        animator.SetTrigger("explosion");
        yield return new WaitForSeconds(.3f);
        gameObject.SetActive(false);

    }
}

using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Enemy : MonoBehaviour
{
    [Header("Enemy stats")]
    [SerializeField] private int totalLifePoints;
    [SerializeField] private int scoreValue;
    private SpriteRenderer sprite;
    private int actualLifePoints;
    private Animator animator;
    public EnemyType enemyType;

    private AudioSource audioSource;

    private Score scoreManager = null;

    void Start()
    {
        animator = GetComponent<Animator>();
        actualLifePoints = totalLifePoints;
        sprite = GetComponent<SpriteRenderer>();
        scoreManager = GameObject.Find("scoreText").GetComponent<Score>();
        audioSource = GetComponent<AudioSource>();
    }

    public void TakeDamage(int amount)
    {
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
        scoreManager.UpdateScore(scoreValue);
    }

    IEnumerator DieCoroutine()
    {
        animator.SetBool("explosion", true);
        gameObject.tag = "Defeated";
        audioSource.Play();
        yield return new WaitForSeconds(.3f);
        animator.SetBool("explosion", false);
        gameObject.tag = "Enemy";
        actualLifePoints = totalLifePoints;
        gameObject.SetActive(false);
    }

    IEnumerator ChangeColorByDamage()
    {
        sprite.color = Color.red;
        yield return new WaitForSeconds(.2f);
        sprite.color = Color.white;
    }
}

using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 20f;
    [SerializeField] private int damage = 10;
    [SerializeField] private float lifetime = 2f;
    private Animator animator;
    private float timer = 0f;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (timer >= lifetime)
        {
            timer = 0;
            gameObject.SetActive(false);

        }

        timer += Time.deltaTime;

        transform.position = new Vector3(transform.position.x, transform.position.y + speed * Time.deltaTime, -9.5f);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Enemy"))
        {
            collider.GetComponent<Enemy>().TakeDamage(damage);
            animator.SetTrigger("Collision");
            StartCoroutine(SetInactive());
        }
    }

    IEnumerator SetInactive()
    {
        yield return new WaitForSeconds(.08f);
        gameObject.SetActive(false);
    }
}


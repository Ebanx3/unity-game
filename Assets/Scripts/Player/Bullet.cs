using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 20f;
    [SerializeField] private int damage = 10;
    [SerializeField] private float lifetime = 2f;
    private float timer = 0f;

    private void Update()
    {
        if (timer >= lifetime){
            timer = 0;
            gameObject.SetActive(false);

        }

        timer += Time.deltaTime;

        transform.position = new Vector3(transform.position.x, transform.position.y + speed * Time.deltaTime, 0);
    }

    void OnTriggerEnter2D (Collider2D collider)
    {
        if(collider.gameObject.CompareTag("Enemy"))
        {
            collider.GetComponent<Damageable>().TakeDamage(damage);
        }
        gameObject.SetActive(false);
    }
}


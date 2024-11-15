using UnityEngine;

public class DronIA : MonoBehaviour
{
    private Vector2 screenBounds;
    private bool movingToRight = true;
    private EnemiesBulletPool bulletsPool;
    [SerializeField] private float movementSpeed;
    [SerializeField] private float fireRate = 3f;
    [SerializeField] private int damageByCollision;
    float timer = 0f;

    private AudioSource audioSource;
    [SerializeField] private AudioClip shootSound;

    void Start()
    {
        screenBounds = Camera.main.GetComponent<CameraMovement>().ScreenBounds;
        bulletsPool = GameObject.Find("EnemiesBulletsPool").GetComponent<EnemiesBulletPool>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (movingToRight) transform.Translate(new Vector3(movementSpeed, 1, 0) * Time.deltaTime);
        else transform.Translate(new Vector3(-movementSpeed, 1, 0) * Time.deltaTime);

        if (transform.position.x >= screenBounds.x) movingToRight = false;
        if (transform.position.x <= -screenBounds.x) movingToRight = true;

        if(timer >= fireRate){
            timer = 0;
            GameObject bullet = bulletsPool.InstantiateBullet();
            audioSource.PlayOneShot(shootSound);
            bullet.transform.position = transform.position + Vector3.down;
        }

        timer += Time.deltaTime;
    }

    void OnTriggerEnter2D (Collider2D collider){
        if(collider.gameObject.CompareTag("Player")){
            collider.GetComponent<Player>().TakeDamage(damageByCollision);
        }
    }
}

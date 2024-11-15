using UnityEngine;

public class CazaIA : MonoBehaviour
{
    private GameObject player;
    private EnemiesBulletPool bulletsPool;
    [SerializeField] private float movementSpeed;
    [SerializeField] private float fireRate = 4f;
    [SerializeField] private int damageByCollision;
    private float timer = 0f;
    
    private AudioSource audioSource;
    [SerializeField] private AudioClip shootSound;

    Vector2 DirectionToPlayer => (player.transform.position - transform.position).normalized;
    
    void Start(){
        player = GameObject.Find("plane");
        bulletsPool = GameObject.Find("EnemiesBulletsPool").GetComponent<EnemiesBulletPool>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {   
        if(player.transform.position.y + 1 > transform.position.y) transform.Translate(movementSpeed * Time.deltaTime * Vector3.down);
        else transform.Translate(movementSpeed * Time.deltaTime * DirectionToPlayer);    
        
        if(timer >= fireRate){
            timer = 0;
            GameObject bullet = bulletsPool.InstantiateBullet();
            audioSource.PlayOneShot(shootSound);
            bullet.transform.position = transform.position + Vector3.down;
        }
        if(transform.position.y < player.transform.position.y - 15) gameObject.SetActive(false);
        timer += Time.deltaTime;
    }

    void OnTriggerEnter2D (Collider2D collider){
        if(collider.gameObject.CompareTag("Player")){
            collider.GetComponent<Player>().TakeDamage(damageByCollision);
        }
    }
}

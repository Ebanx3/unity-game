using UnityEngine;

public class CazaIA : MonoBehaviour
{
    // private Vector2 screenBounds;
    private GameObject player;
    private EnemiesBulletPool bulletsPool;
    [SerializeField] private float movementSpeed;
    [SerializeField] private float fireRate = 4f;
    private float timer = 0f;

    Vector2 directionToPlayer => (player.transform.position - transform.position).normalized;
    
    void Start(){
        player = GameObject.Find("plane");
        bulletsPool = GameObject.Find("EnemiesBulletsPool").GetComponent<EnemiesBulletPool>();
    }

    void Update()
    {   
        transform.Translate(movementSpeed * Time.deltaTime * directionToPlayer);    
        if(timer >= fireRate){
            timer = 0;
            GameObject bullet = bulletsPool.InstantiateBullet();
            bullet.transform.position = transform.position + Vector3.down;
        }

        timer += Time.deltaTime;
    }
}

using UnityEngine;

public class DronIA : MonoBehaviour
{
    private Vector2 screenBounds;
    private bool movingToRight = true;
    private EnemiesBulletPool bulletsPool;
    [SerializeField] private float movementSpeed;
    [SerializeField] private float fireRate = 3f;
    float timer = 0f;

    void Start()
    {
        screenBounds = Camera.main.GetComponent<CameraMovement>().ScreenBounds;
        bulletsPool = GameObject.Find("EnemiesBulletsPool").GetComponent<EnemiesBulletPool>();
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
            bullet.transform.position = transform.position + Vector3.down;
        }

        timer += Time.deltaTime;
    }
}

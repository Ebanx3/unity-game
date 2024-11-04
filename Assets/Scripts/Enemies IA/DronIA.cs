using UnityEngine;

public class DronIA : MonoBehaviour
{
    private Vector2 screenBounds;
    private bool movingToRight = true;
    [SerializeField] private float movementSpeed;

    void Start()
    {
        screenBounds = Camera.main.GetComponent<CameraMovement>().ScreenBounds;
    }

    void Update()
    {
        if (movingToRight) transform.Translate(new Vector3(movementSpeed, 1, 0) * Time.deltaTime);
        else transform.Translate(new Vector3(-movementSpeed, 1, 0) * Time.deltaTime);

        if (transform.position.x >= screenBounds.x) movingToRight = false;
        if (transform.position.x <= -screenBounds.x) movingToRight = true;
    }
}

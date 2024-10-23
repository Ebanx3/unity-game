using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    private PlayerInput playerInput;
    private Vector2 input;
    [SerializeField] private float movementSpeed = 5f;

    // Vars for screen boundaries and object size
    private Vector2 screenBounds;
    private float halfObjectWidth;
    private float halfObjectHeight;

    void Start()
    {
        playerInput = GetComponent<PlayerInput>();

        // Calculate screen bounds in world space based on the camera position
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        halfObjectWidth = transform.GetComponent<SpriteRenderer>().bounds.extents.x;
        halfObjectHeight = transform.GetComponent<SpriteRenderer>().bounds.extents.y;
    }

    void Update()
    {
        input = playerInput.actions["Movement"].ReadValue<Vector2>();

        Vector3 displacement = new Vector3(input.x, input.y, 0) * movementSpeed * Time.deltaTime;
        transform.Translate(displacement);

        Vector3 currentPosition = transform.position + displacement;

        // Recalculate screen bounds (only needed if the camera or screen size changes dynamically)
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

        currentPosition.x = Mathf.Clamp(currentPosition.x, -screenBounds.x + halfObjectWidth, screenBounds.x - halfObjectWidth);
        currentPosition.y = Mathf.Clamp(currentPosition.y, -screenBounds.y + halfObjectHeight, screenBounds.y - halfObjectHeight);

        transform.position = currentPosition;
    }
}

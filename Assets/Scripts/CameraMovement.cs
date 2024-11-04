using UnityEngine;

public class CameraMovement : MonoBehaviour
{   
    public float cameraSpeed = 4f;
    private Camera mainCamera;
    private Vector2 screenBounds;
    public Vector2 ScreenBounds { get { return screenBounds; } }

    void Start(){
        mainCamera = GetComponent<Camera>();
        screenBounds = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z));
    }

    void Update()
    {
        transform.Translate(Vector2.up * Time.deltaTime * cameraSpeed);
    }
}

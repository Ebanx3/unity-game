using UnityEngine;

public class CameraMovement : MonoBehaviour
{   
    public float cameraSpeed = 4f;
    void Update()
    {
        transform.Translate(Vector2.up * Time.deltaTime * cameraSpeed);
    }
}

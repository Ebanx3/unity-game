using UnityEngine;

public class Parallax : MonoBehaviour
{
    public Camera cam;
    public Transform player;

    float startPosition;
    float startZ;

    float travel => (float)cam.transform.position.y - startPosition;

    float distanceFromSubject => transform.position.z - player.position.z;
    float clippingPlane => cam.transform.position.z + (distanceFromSubject > 0 ? cam.farClipPlane : cam.nearClipPlane);

    float parallaxFactor => Mathf.Abs(distanceFromSubject) / clippingPlane;

    void Start()
    {
        startPosition = transform.position.y;
        startZ = transform.position.z;
    }

    void Update()
    {
        float newPos = startPosition + travel * parallaxFactor;
        transform.position = new Vector3(transform.position.x, newPos, startZ);
    }
}

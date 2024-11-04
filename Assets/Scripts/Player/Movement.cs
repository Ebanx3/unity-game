using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    private PlayerInput playerInput;
    private Vector2 input;

    private Vector2 screenBounds;

    [SerializeField] private float movementSpeed = 5f;
    [SerializeField]private bool invertedMovement = false;

    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        screenBounds = GetComponentInParent<CameraMovement>().ScreenBounds;
    }

    void Update()
    {
        input = playerInput.actions["Movement"].ReadValue<Vector2>();
        if(invertedMovement){
            transform.Translate(movementSpeed * Time.deltaTime * -input);
        }
        else{
            transform.Translate(movementSpeed * Time.deltaTime * input);
        }

        Vector3 viewPos = transform.localPosition;
        viewPos.x = Mathf.Clamp(viewPos.x, -screenBounds.x, screenBounds.x);
        viewPos.y = Mathf.Clamp(viewPos.y, -screenBounds.y, screenBounds.y);
        transform.localPosition = viewPos;
    }

    public void InvertMovement () {
        StartCoroutine(InvertMovementCoroutine());
    }

    private IEnumerator InvertMovementCoroutine(){
        invertedMovement = true;
        yield return new WaitForSeconds(3f);
        invertedMovement = false;
    }
}

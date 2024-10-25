using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    private PlayerInput playerInput;
    private Vector2 input;
    [SerializeField] private float movementSpeed = 5f;

    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
    }

    void Update()
    {
        input = playerInput.actions["Movement"].ReadValue<Vector2>();
        transform.Translate(input * Time.deltaTime * movementSpeed);
    }
}

using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    private PlayerInput playerInput;
    private Vector2 input;
    [SerializeField] private float movementSpeed = 5f;
    [SerializeField]private bool invertedMovement = false;

    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
    }

    void Update()
    {
        input = playerInput.actions["Movement"].ReadValue<Vector2>();
        if(invertedMovement){
            transform.Translate(-input * Time.deltaTime * movementSpeed);
        }
        else{
            transform.Translate(input * Time.deltaTime * movementSpeed);
        }
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

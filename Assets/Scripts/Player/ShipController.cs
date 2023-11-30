using UnityEngine;
using UnityEngine.InputSystem;

public class ShipController : MonoBehaviour
{
    
    [Header("Movement Values")]
    [SerializeField] private float forwardSpeed;
    [SerializeField] private float lookSpeed;

    [Header("Acceleration Values")]
    [SerializeField] private float forwardAcceleration;
    [SerializeField] private float turnAcceleration;

    float activeForwardSpeed, activeTurnSpeed;

    float movementY;
    float lookX;

    private void Start()
    {
        //Cursor.lockState = CursorLockMode.Confined;
        //Cursor.visible = false;
    }

    private void Update()
    {
        Look();
        Movement();
    }

    private void Look()
    {
        // creating a float to applying the look speed
        float horizontalRotation = lookX * lookSpeed * Time.deltaTime;

        // lerping for rotation
        activeTurnSpeed = Mathf.Lerp(activeTurnSpeed, horizontalRotation, turnAcceleration * Time.deltaTime);

        // applying that rotation
        transform.Rotate(Vector3.up, activeTurnSpeed);
    }

    private void Movement()
    {
        // forward movement
        activeForwardSpeed = Mathf.Lerp(activeForwardSpeed, movementY * forwardSpeed, forwardAcceleration * Time.deltaTime);

        // applying both of those movements
        transform.position += activeForwardSpeed * Time.deltaTime * transform.forward;
    }

    // setting the global variables to the correct input value
    private void OnMove(InputValue value)
    {
        Vector2 moveVector = value.Get<Vector2>();

        movementY = moveVector.y;
    }

    // setting the global variables to the correct input value
    private void OnLook(InputValue value)
    {
        Vector2 input = value.Get<Vector2>();

        lookX = input.x;
    }
}

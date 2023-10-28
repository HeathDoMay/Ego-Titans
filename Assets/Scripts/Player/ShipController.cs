using UnityEditor.Rendering.LookDev;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class ShipController : MonoBehaviour
{
    
    [Header("Movement Values")]
    [SerializeField] private float forwardSpeed;
    [SerializeField] private float strafeSpeed;
    [SerializeField] private float lookSpeed;

    [Header("Acceleration Values")]
    [SerializeField] private float forwardAcceleration;
    [SerializeField] private float strafeAcceleration;
    [SerializeField] private float turnAcceleration;

    float activeForwardSpeed, activeStrafeSpeed, activeTurnSpeed;

    float movementX, movementY;
    float lookX;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
    }

    private void Update()
    {
        Look();
        Movement();
    }

    private void Look()
    {
        float horizontalRotation = lookX * lookSpeed * Time.deltaTime;
        activeTurnSpeed = Mathf.Lerp(activeTurnSpeed, horizontalRotation, turnAcceleration * Time.deltaTime);
        transform.Rotate(Vector3.up, activeTurnSpeed);
    }

    private void Movement()
    {
        activeForwardSpeed = Mathf.Lerp(activeForwardSpeed, movementY * forwardSpeed, forwardAcceleration * Time.deltaTime);
        activeStrafeSpeed = Mathf.Lerp(activeStrafeSpeed, movementX * strafeSpeed, strafeAcceleration * Time.deltaTime);

        transform.position += activeForwardSpeed * Time.deltaTime * transform.forward;
        transform.position += activeStrafeSpeed * Time.deltaTime * transform.right;
    }

    private void OnMove(InputValue value)
    {
        Vector2 moveVector = value.Get<Vector2>();

        movementX = moveVector.x;
        movementY = moveVector.y;
    }

    private void OnLook(InputValue value)
    {
        Vector2 input = value.Get<Vector2>();

        lookX = input.x;

        // Debug.Log(lookX);
    }
}

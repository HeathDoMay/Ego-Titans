using UnityEngine;
using UnityEngine.InputSystem;

public class ShipController : MonoBehaviour
{
    [SerializeField]
    private float forwardSpeed, strafeSpeed;

    [SerializeField]
    private float forwardAcceleration, strafeAcceleration;

    [SerializeField]
    private float lookSpeed;

    private float activeForwardSpeed, activeStrafeSpeed;

    float movementX, movementY;
    float lookX, lookY;

    Vector2 lookInput;
    Vector2 screenCenter, mouseDistance;

    private void Start()
    {
        screenCenter.x = Screen.width * 0.5f;
        screenCenter.y = Screen.height * 0.5f;

        Cursor.lockState = CursorLockMode.Confined;
    }

    private void Update()
    {
        Look();
        Movement();
    }

    private void Look()
    {
        mouseDistance.x = (lookX - screenCenter.x) / screenCenter.x;
        mouseDistance.y = (lookY - screenCenter.y) / screenCenter.y;

        // -mouseDistance.y * lookSpeed * Time.deltaTime

        mouseDistance = Vector2.ClampMagnitude(mouseDistance, 1f);
        transform.Rotate(0f, mouseDistance.x * lookSpeed * Time.deltaTime, 0f, Space.Self);
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
        Vector2 lookVector = value.Get<Vector2>();

        lookX = lookVector.x;
        lookY = lookVector.y;

        Debug.Log(lookVector);
    }
}

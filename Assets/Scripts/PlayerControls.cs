using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Transform cam;
    [Space]
    [Header("Speed of Player")]
    [SerializeField] private float speed;
    [SerializeField] private float maxSpeed;

    Rigidbody rb;
    float movemnetX;
    float movemnetY;

    float turnSmoothTime = 20f;
    float turnSmoothVelocity;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       Movement();
    }

    private void OnMove(InputValue value)
    {
        Vector2 moveVector = value.Get<Vector2>();

        movemnetX = moveVector.x;
        movemnetY = moveVector.y;
    }

    void Movement()
    {
        Vector3 move = new(movemnetX, 0f, movemnetY);

        if (move.magnitude >= 0.1f)
        {
            // allows the camera to change the direction at which the player is moving
            float targetAngle = Mathf.Atan2(move.x, move.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            // clamps the max amounct of force added to the rigidbody
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
            rb.AddForce(moveDirection * speed);
        }
    }
}

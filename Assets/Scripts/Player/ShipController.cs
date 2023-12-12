using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.VFX;

public class ShipController : MonoBehaviour
{
    [Header("Movement Values")]
    [SerializeField] private float forwardSpeed;
    [SerializeField] private float lookSpeed;

    float activeForwardSpeed, activeTurnSpeed;

    [Header("Acceleration Values")]
    [SerializeField] private float forwardAcceleration;
    [SerializeField] private float turnAcceleration;

    [Header("For Tilting")]
    [SerializeField] private GameObject parentModel;
    [SerializeField] private Transform model;

    PlayVFX vfx;

    float movementY;
    public float lookX;

    bool isMoving = false;
    public AudioSource engineFiring;

    private void Awake()
    {
        engineFiring = GetComponent<AudioSource>();
        vfx = GetComponent<PlayVFX>();
        engineFiring.Pause();
    }

    private void FixedUpdate()
    {
        Look();
        Movement();
    }

    #region Look and Movement

    private void Look()
    {
        // creating a float to applying the look speed
        float horizontalRotation = lookX * lookSpeed * Time.deltaTime;

        if(isMoving == true )
        {
            // lerping for rotation
            activeTurnSpeed = Mathf.Lerp(activeTurnSpeed, horizontalRotation, turnAcceleration * Time.deltaTime);
            
            
            // applying that rotation
            transform.Rotate(Vector3.up, activeTurnSpeed);
        }
    }

    private void Movement()
    {
        // forward movement
        activeForwardSpeed = Mathf.Lerp(activeForwardSpeed, movementY * forwardSpeed, forwardAcceleration * Time.deltaTime);
        

        if (movementY > 0 || movementY < 0)
        {
            // applying both of those movements
            transform.position += activeForwardSpeed * Time.deltaTime * transform.forward;
            isMoving = true;

            vfx.StartVFX();
            engineFiring.UnPause();
        }
        else
        {
            isMoving = false;

            vfx.StopVFX();
            engineFiring.Pause();
        }
    }

    #endregion

    #region Setting Input Values

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

    #endregion

    private void Update()
    {
        // if the player is inside the angle we want them in let them tilt
        if ((parentModel.transform.rotation.eulerAngles.z <= 15 && parentModel.transform.rotation.eulerAngles.z >= -5) || (parentModel.transform.rotation.eulerAngles.z <= 370 && parentModel.transform.rotation.eulerAngles.z >= 345) || parentModel.transform.rotation.eulerAngles.z == 0)
        {
            if (lookX > 0)
            {
                parentModel.transform.Rotate(0.0f, 0.0f, -0.5f, Space.Self);
            }
            else if (lookX < 0)
            {
                parentModel.transform.Rotate(0.0f, 0.0f, 0.5f, Space.Self);
            }
            
            
        }
        // if they are on the left boundary angle, allow them to tilt right
        else if (lookX > 0 && (parentModel.transform.rotation.eulerAngles.z >= 15 && parentModel.transform.rotation.eulerAngles.z <= 20))
        {
            parentModel.transform.Rotate(0.0f, 0.0f, -0.5f, Space.Self);
        }
        // if they are on the right boundary angle, allow them to tilt left
        else if (lookX < 0 && (parentModel.transform.rotation.eulerAngles.z <= 345 && parentModel.transform.rotation.eulerAngles.z >= 335))
        {
            parentModel.transform.Rotate(0.0f, 0.0f, 0.5f, Space.Self);
        }

        //if no keys are pressed, center ship
        if ((parentModel.transform.rotation.eulerAngles.z <= 18 && parentModel.transform.rotation.eulerAngles.z >= 0) && lookX == 0)
        {
            parentModel.transform.Rotate(0.0f, 0.0f, -0.4f, Space.Self);
        }
        else if ((parentModel.transform.rotation.eulerAngles.z <= 360 && parentModel.transform.rotation.eulerAngles.z >= 335)  && lookX == 0)
        {
            parentModel.transform.Rotate(0.0f, 0.0f, 0.4f, Space.Self);
        }
    }
}

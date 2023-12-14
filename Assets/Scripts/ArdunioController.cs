using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO.Ports;
using System.Diagnostics.Eventing.Reader;
using System.Runtime.InteropServices;
using System.Linq;

public class ArdunioController : MonoBehaviour
{
    [Header("Movement Values")]
    [SerializeField] private float speed;
    [SerializeField] private float lookSpeed;

    [Header("Acceleration Values")]
    [SerializeField] private float forwardAcceleration;
    [SerializeField] private float turnAcceleration;

    [Header("Gavity and Delay")]
    [SerializeField] private float gravity;
    [SerializeField] private float delay;

    PlayVFX playVFX;

    float activeForwardSpeed, activeTurnSpeed;

    Rigidbody rb;
    bool isGravityUp = true;
    bool canUseGravity = true;

    bool canMoveForward = false;
    bool canMoveBackward = false;
    bool canTurnLeft = false;
    bool canTurnRight = false;

    [SerializeField] private GameObject parentModel;
    bool gravTilt = false;

    string method;
    int data;

    IEnumerator Rotate(float rotationAmount)
    {
        yield return new WaitForSeconds(0.25f);
        transform.Rotate(0f, 0f, rotationAmount);
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        playVFX = GetComponent<PlayVFX>();
    }

    SerialPort sp = new SerialPort("COM3", 9600, Parity.None, 8, StopBits.One);
    // Start is called before the first frame update
    void Start()
    {
        sp.Open();
        /*
            Set the read timeout low so unity doesn't freeze,
            and catch the exception below in update that unity will throw
            when the port isn't open and unity tries to check it
        */
        sp.ReadTimeout = 1;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        IsOpen();
    }

    private void Update()
    {
        if(canMoveForward)
        {
            activeForwardSpeed = Mathf.Lerp(activeForwardSpeed, speed, forwardAcceleration * Time.deltaTime);
            transform.position += activeForwardSpeed * Time.deltaTime * transform.forward;

            playVFX.StartVFX();
        }
        else
        {
            playVFX.StopVFX();
        }

        if(canMoveBackward)
        {
            activeForwardSpeed = Mathf.Lerp(activeForwardSpeed, speed, forwardAcceleration * Time.deltaTime);
            transform.position += activeForwardSpeed * Time.deltaTime * -transform.forward;

            playVFX.StartVFX();
        }
        else
        {
            playVFX.StopVFX();
        }

        if(canTurnLeft)
        {
            float horizontalRotation = lookSpeed * Time.deltaTime;

            // lerping for rotation
            activeTurnSpeed = Mathf.Lerp(activeTurnSpeed, horizontalRotation, turnAcceleration * Time.deltaTime);

            // applying that rotation
            transform.Rotate(-Vector3.up, activeTurnSpeed);
        }

        if(canTurnRight)
        {
            float horizontalRotation = lookSpeed * Time.deltaTime;

            // lerping for rotation
            activeTurnSpeed = Mathf.Lerp(activeTurnSpeed, horizontalRotation, turnAcceleration * Time.deltaTime);

            // applying that rotation
            transform.Rotate(Vector3.up, activeTurnSpeed);
        }

        if (gravTilt == true)
        {
            TiltingGrav();
        }



        // if the player is inside the angle we want them in let them tilt
        if ((parentModel.transform.rotation.eulerAngles.z <= 15 && parentModel.transform.rotation.eulerAngles.z >= -5) || (parentModel.transform.rotation.eulerAngles.z <= 370 && parentModel.transform.rotation.eulerAngles.z >= 345) || parentModel.transform.rotation.eulerAngles.z == 0)
        {
            if (canTurnRight)
            {
                parentModel.transform.Rotate(0.0f, 0.0f, -1f, Space.Self);
            }
            else if (canTurnLeft)
            {
                parentModel.transform.Rotate(0.0f, 0.0f, 1f, Space.Self);
            }
        }
        // if they are on the left boundary angle, allow them to tilt right
        else if (canTurnRight && (parentModel.transform.rotation.eulerAngles.z >= 15 && parentModel.transform.rotation.eulerAngles.z <= 20))
        {
            parentModel.transform.Rotate(0.0f, 0.0f, -1f, Space.Self);
        }
        // if they are on the right boundary angle, allow them to tilt left
        else if (canTurnLeft && (parentModel.transform.rotation.eulerAngles.z <= 345 && parentModel.transform.rotation.eulerAngles.z >= 335))
        {
            parentModel.transform.Rotate(0.0f, 0.0f, 1f, Space.Self);
        }

        //if no keys are pressed, center ship
        if ((parentModel.transform.rotation.eulerAngles.z <= 18 && parentModel.transform.rotation.eulerAngles.z >= 0) && (!canTurnLeft && !canTurnRight))
        {
            parentModel.transform.Rotate(0.0f, 0.0f, -0.4f, Space.Self);
        }
        else if ((parentModel.transform.rotation.eulerAngles.z <= 360 && parentModel.transform.rotation.eulerAngles.z >= 335) && (!canTurnLeft && !canTurnRight))
        {
            parentModel.transform.Rotate(0.0f, 0.0f, 0.4f, Space.Self);
        }




    }

    private void ButtonPressed()
    {
        // if bool is true then flip gravity
        if (canUseGravity)
        {
            if (isGravityUp)
            {
                // adding gravity and the rotation
                rb.AddForce(Vector3.up * gravity);
                StartCoroutine(Rotate(180));

                // setting bool back to flase then calling a function setting it to true with a delay
                gravTilt = true;
                canUseGravity = false;
                
                Invoke(nameof(EnableInput), delay);
            }
            else
            {
                // adding gravity and the rotation
                rb.AddForce(Vector3.down * gravity);
                StartCoroutine(Rotate(-180));

                // setting bool back to flase then calling a function setting it to true with a delay
                gravTilt = false;
                canUseGravity = false;
                
                Invoke(nameof(EnableInput), delay);
            }

            isGravityUp = !isGravityUp;
        }

        Debug.Log("The button was pressed");
    }

    bool EnableInput()
    {
        return canUseGravity = true;
    }



    void TiltingGrav()
    {
        if (parentModel.transform.rotation.eulerAngles.z <= 195 && parentModel.transform.rotation.eulerAngles.z >= 165)
        {
            if (canTurnRight)
            {
                parentModel.transform.Rotate(0.0f, 0.0f, -1f, Space.Self);
            }
            else if (canTurnLeft)
            {
                parentModel.transform.Rotate(0.0f, 0.0f, 1f, Space.Self);
            }
        }
        // if they are on the left boundary angle, allow them to tilt right
        else if (canTurnRight && (parentModel.transform.rotation.eulerAngles.z >= 195 && parentModel.transform.rotation.eulerAngles.z <= 200))
        {
            parentModel.transform.Rotate(0.0f, 0.0f, -1f, Space.Self);
        }
        // if they are on the right boundary angle, allow them to tilt left
        else if (canTurnLeft && (parentModel.transform.rotation.eulerAngles.z <= 165 && parentModel.transform.rotation.eulerAngles.z >= 160))
        {
            parentModel.transform.Rotate(0.0f, 0.0f, 1f, Space.Self);
        }

        //if no keys are pressed, center ship
        if ((parentModel.transform.rotation.eulerAngles.z <= 200 && parentModel.transform.rotation.eulerAngles.z >= 180) && (!canTurnLeft && !canTurnRight))
        {
            parentModel.transform.Rotate(0.0f, 0.0f, -0.4f, Space.Self);
        }
        else if ((parentModel.transform.rotation.eulerAngles.z <= 180 && parentModel.transform.rotation.eulerAngles.z >= 160) && (!canTurnLeft && !canTurnRight))
        {
            parentModel.transform.Rotate(0.0f, 0.0f, 0.4f, Space.Self);
        }
    }

    private void ButtonReleased()
    {
        Debug.Log("The button was released");
    }

    private void MoveForward()
    {
        canMoveBackward = false;
        canMoveForward = true;

       // Debug.Log("The joystick has been moved forward");
    }

    private void MoveBackward()
    {
        canMoveBackward = true;
        canMoveForward = false;

        //Debug.Log("The joystick has been moved backward");
    }

    private void StopFowardOrBackwardMovement()
    {
        canMoveBackward = false;
        canMoveForward = false;
       // Debug.Log("The joystick is no longer moving forward or backward");
    }

    private void MoveLeft()
    {
        canTurnLeft = true;
        canTurnRight = false;

        //Debug.Log("The joystick has been moved to the left");
    }
    private void MoveRight()
    {
        canTurnRight = true;
        canTurnLeft = false;

        

        //Debug.Log("The joystick has been moved to the right");
    }

    private void StopLeftOrRightMovement()
    {
        canTurnLeft = false;
        canTurnRight = false;

        // Debug.Log("The joystick is no longer moving left or right");
    }

    private void IsOpen()
    {
        if (sp.IsOpen)
        {
            try
            {
                switch (sp.ReadByte())
                {
                    case 66: // Button Press
                        InputMethod("BUTTON");
                        break;
                    case 88: // X axis
                        InputMethod("xAXIS");
                        break;
                    case 89: // Y axis
                        InputMethod("yAXIS");
                        break;
                    case 0:
                        InputValue(0);
                        break;
                    case 1:
                        InputValue(1);
                        break;
                    case 4:
                        InputValue(4);
                        break;
                    case 8:
                        InputValue(8);
                        break;
                }
            }
            catch (System.Exception)
            {

            }
        }
    }

    private void InputMethod(string type)
    {
        method = type;
    }

    private void InputValue(int value)
    {
        data = value;
        ProcessData();
    }

    private void ProcessData()
    {
        if (method == "BUTTON")
        {
            switch (data)
            {
                case 0:
                    ButtonPressed();
                    break;
                case 1:
                    ButtonReleased();
                    break;
            }
        }

        if (method == "xAXIS")
        {
            switch (data)
            {
                case 0:
                    MoveForward();
                    break;
                case 4:
                    StopFowardOrBackwardMovement();
                    break;
                case 8:
                    MoveBackward();
                    break;
            }
        }

        if (method == "yAXIS")
        {
            switch (data)
            {
                case 0:
                    MoveRight();
                    break;
                case 4:
                    StopLeftOrRightMovement();
                    break;
                case 8:
                    MoveLeft();
                    break;
            }
        }
    }
}
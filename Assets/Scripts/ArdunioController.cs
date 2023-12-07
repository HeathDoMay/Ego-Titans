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

    float activeForwardSpeed, activeTurnSpeed;

    Rigidbody rb;
    bool isGravityUp = true;
    bool canUseGravity = true;

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
                canUseGravity = false;
                Invoke(nameof(EnableInput), delay);
            }
            else
            {
                // adding gravity and the rotation
                rb.AddForce(Vector3.down * gravity);
                StartCoroutine(Rotate(-180));

                // setting bool back to flase then calling a function setting it to true with a delay
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

    private void ButtonReleased()
    {
        Debug.Log("The button was released");
    }

    private void MoveForward()
    {
        activeForwardSpeed = Mathf.Lerp(activeForwardSpeed, speed, forwardAcceleration * Time.deltaTime);
        transform.position += activeForwardSpeed * Time.deltaTime * transform.forward;


       // Debug.Log("The joystick has been moved forward");
    }

    private void MoveBackward()
    {
        activeForwardSpeed = Mathf.Lerp(activeForwardSpeed, speed, forwardAcceleration * Time.deltaTime);
        transform.position += activeForwardSpeed * Time.deltaTime * -transform.forward;

        //Debug.Log("The joystick has been moved backward");
    }

    private void StopFowardOrBackwardMovement()
    {
       // Debug.Log("The joystick is no longer moving forward or backward");
    }

    private void MoveLeft()
    {
        float horizontalRotation = lookSpeed * Time.deltaTime;

        // lerping for rotation
        activeTurnSpeed = Mathf.Lerp(activeTurnSpeed, horizontalRotation, turnAcceleration * Time.deltaTime);

        // applying that rotation
        transform.Rotate(-Vector3.up, activeTurnSpeed);


        //Debug.Log("The joystick has been moved to the left");
    }
    private void MoveRight()
    {
        float horizontalRotation = lookSpeed * Time.deltaTime;

        // lerping for rotation
        activeTurnSpeed = Mathf.Lerp(activeTurnSpeed, horizontalRotation, turnAcceleration * Time.deltaTime);

        // applying that rotation
        transform.Rotate(Vector3.up, activeTurnSpeed);



        //Debug.Log("The joystick has been moved to the right");
    }

    private void StopLeftOrRightMovement()
    {
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
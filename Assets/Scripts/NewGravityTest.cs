using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class NewGravityTest : MonoBehaviour
{
   // private new ConstantForce constantForce;
    Rigidbody rb;
    Vector3 forceDirection;
    bool gravitySwitch;

    float speed = 5f;
    float maxSpeed = 10f;

    private void Awake()
    {
        //constantForce = GetComponent<ConstantForce>();
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        // constantForce.force = forceDirection;
        forceDirection = new Vector3(0, 0, 0);
    }

    private void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            gravitySwitch = true;
        }

        //if (gravitySwitch)
        //{
        //    forceDirection = new Vector3(0, 9.86f, 0);
        //    rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
        //    rb.AddForce(forceDirection * speed);
        //}
        //else
        //{
        //    forceDirection = new Vector3(0, -9.86f, 0);
        //    rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
        //    rb.AddForce(forceDirection * speed);
        //}

        Debug.Log(gravitySwitch);
    }

    private void FixedUpdate()
    {
        SwitchGravity(gravitySwitch);
    }

    void SwitchGravity(bool gravitySwitch)
    {
        if (gravitySwitch == true)
        {
            forceDirection = new Vector3(0, 9.86f, 0);
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
            rb.AddForce(forceDirection * speed * Time.deltaTime);
        }
        else
        {
            forceDirection = new Vector3(0, -9.86f, 0);
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
            rb.AddForce(forceDirection * speed * Time.deltaTime);
        }
    }
}

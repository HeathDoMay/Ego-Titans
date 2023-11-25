using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    [Header("Gravity Speed")]
    [SerializeField] private float gravity;

    [Header("Delay in Seconds")]
    [SerializeField] private float delay;

    Rigidbody rb;
    bool isGravityUp = true;
    bool canUseGravity = true;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    private void Start()
    {
        rb.useGravity = false;

        // setting the initial rotation
        transform.Rotate(0, 0, 0);
    }

    // Interface to calculate the rotation of the ship with a delay
    IEnumerator Rotate(float rotationAmount)
    {
        yield return new WaitForSeconds(0.25f);
        transform.Rotate(0f, 0f, rotationAmount);
    }

    private void OnGravity()
    {
        // if bool is true then flip gravity
        if(canUseGravity)
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
    }

    // function setting a bool to true
    bool EnableInput()
    {
        return canUseGravity = true;
    }
}
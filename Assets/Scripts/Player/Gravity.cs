using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class Gravity : MonoBehaviour
{
    [Header("Gravity Speed")]
    [SerializeField] private float gravity;

    Rigidbody rb;
    bool isGravityUp = true;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        rb.useGravity = false;

        transform.Rotate(0f, 0f, 0f);
    }

    private void OnGravity()
    {
        if (isGravityUp)
        {
            rb.AddForce(Vector3.up * gravity);
            transform.Rotate(0f, 0f, 180f);
        }
        else
        {
            rb.AddForce(Vector3.down * gravity);
            transform.Rotate(0f, 0f, -180f);
        }

        isGravityUp = !isGravityUp;
    }
}
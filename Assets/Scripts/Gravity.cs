using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class Gravity : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera virtualCamera;

    private Rigidbody rb;
    private float gravity = 500f;

    bool isGravityUp = true;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        rb.useGravity = false;
    }

    private void OnPlayerOneGravity()
    {
        var transposer = virtualCamera.GetCinemachineComponent<CinemachineTransposer>();
        
        if(isGravityUp)
        {
            rb.AddForce(transform.up * gravity);
            transposer.m_FollowOffset = new Vector3(0, -3, -10);
        }
        else
        {
            rb.AddForce(transform.up * -gravity);
            transposer.m_FollowOffset = new Vector3(0, 3, -10);
        }

        isGravityUp = !isGravityUp;

        Debug.Log($"Bool: {isGravityUp}");
    }
}
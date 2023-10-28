using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class Gravity : MonoBehaviour
{
    [Header("Cinemachine Camera")]
    [SerializeField] private CinemachineVirtualCamera virtualCamera;

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
    }

    private void OnPlayerOneGravity()
    {
        var transposer = virtualCamera.GetCinemachineComponent<CinemachineTransposer>();
        
        if(isGravityUp)
        {
            rb.AddForce(Vector3.up * gravity);
            transposer.m_FollowOffset = new Vector3(0, -3, -10);
        }
        else
        {
            rb.AddForce(Vector3.down * gravity);
            transposer.m_FollowOffset = new Vector3(0, 3, -10);
        }

        isGravityUp = !isGravityUp;

        //Debug.Log($"Bool: {isGravityUp}");
    }
}
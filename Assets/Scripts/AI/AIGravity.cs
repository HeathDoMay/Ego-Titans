using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class AIGravity : MonoBehaviour
{
    [Header("AI Player")]
    [SerializeField] private Transform ai;
    [SerializeField] private Rigidbody aiRigidbody;

    [Header("AI Path Transforms")]
    public Transform aiPath;
    public Transform defaultPathPosition;
    public Transform pointToMovePath;

    private void Start()
    {
        aiPath.position = defaultPathPosition.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("AI"))
        {
            aiPath.position = pointToMovePath.position;

            aiRigidbody.AddForce(Vector3.up * 2000);

            DebugMessages("Hit");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("AI"))
        {
            aiPath.position = defaultPathPosition.position;

            aiRigidbody.AddForce(Vector3.down * 2000);

            DebugMessages("Leave");
        }
    }

    private void DebugMessages(string message)
    {
        Debug.Log(message);
    }
}

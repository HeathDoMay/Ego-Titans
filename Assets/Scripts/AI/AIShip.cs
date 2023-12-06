using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIShip : MonoBehaviour
{
    [Header("Path to Follow")]
    [SerializeField] private Transform aiPath;

    [Header("Values to Add Speed")]
    [SerializeField] private float speed;
    [SerializeField] private float accelerationSpeed;
    [SerializeField] private float maxSteerAngle;

    float activeForwardSpeed;

    List<Transform> nodes = new List<Transform>();

    PlayVFX playVFX;

    int currentNode = 0;

    private void Awake()
    {
        playVFX = GetComponent<PlayVFX>();
    }

    // Start is called before the first frame update
    void Start()
    {
        // grabbing all the nodes in our Path Transform
        Transform[] pathTransform = aiPath.GetComponentsInChildren<Transform>();
        nodes = new List<Transform>();

        for (int i = 0; i < pathTransform.Length; i++)
        {
            if (pathTransform[i] != aiPath.transform)
            {
                nodes.Add(pathTransform[i]);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        ApplySteer();

        Drive(speed, accelerationSpeed);

        CheckWaypointDistance();
    }

    // checking the distance between both nodes and the if the distance is less than 0.5f, continue to the next node
    private void CheckWaypointDistance()
    {
        if (Vector3.Distance(transform.position, nodes[currentNode].position) < 5f)
        {
            if (currentNode == nodes.Count - 1)
            {
                currentNode = 0;
            }
            else
            {
                currentNode++;
            }
        }
    }

    // adding force to the AI ship
    private void Drive(float forwardSpeed, float accelerationSpeed)
    {
        activeForwardSpeed = Mathf.Lerp(activeForwardSpeed, forwardSpeed, accelerationSpeed * Time.deltaTime);

        transform.position += activeForwardSpeed * Time.deltaTime * transform.forward;

        playVFX.StartVFX();
    }

    // turning the ship
    private void ApplySteer()
    {
        Vector3 relativeVector = transform.InverseTransformPoint(nodes[currentNode].position);
        float newSteer = (relativeVector.x / relativeVector.magnitude) * maxSteerAngle;

        transform.Rotate(Vector3.up * newSteer);
    }
}

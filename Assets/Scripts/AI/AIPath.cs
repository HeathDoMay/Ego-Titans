using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPath : MonoBehaviour
{
    [SerializeField] private Color lineColor;

    [Header("Size of Sphere")]
    [SerializeField] private float radius;

    private List<Transform> nodes = new List<Transform>();

    private void OnDrawGizmos()
    {
        // setting the color of our line to draw
        Gizmos.color = lineColor;

        // creating an array of transfroms inside of our Path GameObject
        Transform[] pathTransform = GetComponentsInChildren<Transform>();

        // create a new list
        nodes = new List<Transform>();

        // loop through the arry to grab all the childeren
        for (int i = 0; i < pathTransform.Length; i++)
        {
            if (pathTransform[i] != transform)
            {
                // add the childeren to the list
                nodes.Add(pathTransform[i]);
            }
        }

        // drawing the line between each point
        for (int i = 0; i < nodes.Count; i++)
        {
            // holds the current node
            Vector3 currentNode = nodes[i].position;

            // holds the previous node
            Vector3 previousNode = Vector3.zero;

            if (i > 0)
            {
                // setting the previous node
                previousNode = nodes[i - 1].position;
            }
            else if (i == 0 && nodes.Count > 1)
            {
                // make sure we are looping through all of the nodes
                previousNode = nodes[nodes.Count - 1].position;
            }

            // draw the line and setting a radius for each node
            Gizmos.DrawLine(previousNode, currentNode);
            Gizmos.DrawWireSphere(currentNode, radius);

            // Debug.Log(nodes.Count);
        }
    }
}

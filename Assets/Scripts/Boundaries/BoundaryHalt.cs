using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryHalt : MonoBehaviour
{
    public Transform[] spawnPoints;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //Debug.Log("Touched the butt");

            ResetPlayerPosition(other.gameObject);
        }
    }

    private void ResetPlayerPosition(GameObject player)
    {
        //player.transform.position = new Vector3(0f, 1f, 0f); no worky

        Transform closestSpawnPoint = FindClosestSpawnPoint(player.transform.position);

        player.transform.position = closestSpawnPoint.position;
    }

    private Transform FindClosestSpawnPoint(Vector3 playerPosition)
    {
        Transform closestSpawnPoint = null;
        float closestDistance = float.MaxValue;

        foreach (Transform spawnPoint in spawnPoints)
        {
            float distance = Vector3.Distance(playerPosition, spawnPoint.position);

            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestSpawnPoint = spawnPoint;
            }
        }

        return closestSpawnPoint;
    }
}

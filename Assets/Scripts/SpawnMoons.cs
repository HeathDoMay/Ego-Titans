using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMoons : MonoBehaviour
{
    [SerializeField] private GameObject moon;
    [SerializeField] private int maxMoons = 10;

    bool canSpawn;
    int objectsSpawned = 0;

    private void Start()
    {
        canSpawn = true;
    }

    void Update()
    {
        // spawning left and right
        GenerateMoons(500f, 1000f, -500f, 500f);
        GenerateMoons(-500f, -1000f, -500f, 500f);

        // spawning forward and backward
        GenerateMoons(-1000f, 1000f, -500f, -1000f);
        GenerateMoons(-1000f, 1000f, 500f, 1000f);
    }

    private void GenerateMoons(float minX, float maxX, float minZ, float maxZ)
    {
        // creating random values
        float randomX = Random.Range(minX, maxX);
        float randomZ = Random.Range(minZ, maxZ);

        // random spawn position
        Vector3 spawnPos = new Vector3(randomX, Random.Range(100f, 500f), randomZ);

        if (canSpawn == true)
        {
            // instantiate the moon and increment an int
            Instantiate(moon, spawnPos, Quaternion.identity);
            objectsSpawned++;

            if (objectsSpawned == maxMoons)
            {
                canSpawn = false;
            }
        }
    }
}

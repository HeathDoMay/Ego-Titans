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
        //Vector3 spawnPos = new Vector3(Random.Range(500, 1000), Random.Range(100, 500), Random.Range(-500, 500));

        //if(canSpawn == true)
        //{
        //    Instantiate(moon, spawnPos, Quaternion.identity);
        //    objectsSpawned++;

        //    if (objectsSpawned == maxMoons)
        //    {
        //        canSpawn = false;
        //    }
        //}

        // spawning left and right
        GenerateMoons(500f, 1000f, -500f, 500f);
        GenerateMoons(-500f, -1000f, -500f, 500f);

        // spawning forward and backward
        GenerateMoons(-1000f, 1000f, -500f, -1000f);
        GenerateMoons(-1000f, 1000f, 500f, 1000f);
    }

    private void GenerateMoons(float minX, float maxX, float minZ, float maxZ)
    {
        float randomX = Random.Range(minX, maxX);
        float randomZ = Random.Range(minZ, maxZ);

        Vector3 spawnPos = new Vector3(randomX, Random.Range(100f, 500f), randomZ);

        if (canSpawn == true)
        {
            Instantiate(moon, spawnPos, Quaternion.identity);
            objectsSpawned++;

            if (objectsSpawned == maxMoons)
            {
                canSpawn = false;
            }
        }
    }
}

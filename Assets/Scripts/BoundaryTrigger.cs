using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryTrigger : MonoBehaviour
{
    //force applied to push player back on track
    public float pushForce = 5.0f;

    //tag to identify the track GameObject
    public string trackTag = "Track";

    //delay between applying forces (in frames)
    public int framesBetweenForces = 10;
    private int frameCounter = 0;

    private Transform trackReference;

    private void Start()
    {
        GameObject[] trackObjects = GameObject.FindGameObjectsWithTag(trackTag);
        float shortestDistance = float.MaxValue;

        foreach (GameObject trackObject in trackObjects)
        {
            float distance = Vector3.Distance(transform.position, trackObject.transform.position);
            if (distance < shortestDistance)
            {
                shortestDistance = distance;
                trackReference = trackObject.transform;
            }
        }
    }

    // Update is called once per frame
    void OnTriggerStay(Collider other)
    {
        //checks to see if colliding with player
        if (other.CompareTag("Player"))
        {
            frameCounter++;

            //checks time to apply force (having it play every frame was too much force pushed back on player --- it sent them TO THE MOON)
            if (frameCounter >= framesBetweenForces)
            {
                //resets frame counter
                frameCounter = 0;

                Rigidbody playerRigidbody = other.GetComponent<Rigidbody>();

                if (playerRigidbody != null)
                {
                    //calculate direction from player to track
                    Vector3 pushDirection = trackReference.position - other.transform.position;
                    pushDirection.Normalize();

                    //apply force in pushDirection to move player back on track
                    playerRigidbody.AddForce(pushDirection * pushForce, ForceMode.Impulse);
                }
            }

            

            
        }
    }

  
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovementSound : MonoBehaviour
{
    public AudioClip moveSound;
    private AudioSource audioSource;
    private Rigidbody rb;

    //doppler effect
    public float maxDistance = 10f;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        //Ensure there is an AudioSource component attached
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        //Check for movement input
        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");

        //assuming player moves with rigidbody
        if (Mathf.Abs(horizontalMovement) > 0.1f || Mathf.Abs(verticalMovement) > 0.1f)
        {
            //doppler effect
            //distance b/w player and camera (listener)
            float distanceToListener = Vector3.Distance(transform.position, Camera.main.transform.position);

            //calculate volume based on dist
            float volume = Mathf.Clamp01(1f - (distanceToListener / maxDistance));

            //set volume and play movement sound
            audioSource.volume = volume;

            //play movement sound if it's not already playing
            if (!audioSource.isPlaying)
            {
                if (!audioSource.isPlaying)
                {
                    audioSource.clip = moveSound;
                    audioSource.Play();
                }
            }
            else
            {
                //stop sound when player is not moving
                audioSource.Stop();
            }
        }
    }
}

//thanks chat gpt
//https://chat.openai.com/c/0f39997d-fa14-4bd6-b856-2400f0513f70

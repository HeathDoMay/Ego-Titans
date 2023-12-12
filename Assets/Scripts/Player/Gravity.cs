using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    [Header("Gravity Speed")]
    [SerializeField] private float gravity;

    [Header("Delay in Seconds")]
    [SerializeField] private float delay;

    [Header("SFX When Gravity Changes")]
    [SerializeField] private AudioClip gravitySFX;

    [SerializeField] private GameObject parentModel;

    float movementY;
    float lookX;
    private ShipController lookXscript;
    public GameObject ShipObject;

    AudioSource audioSource;
    Rigidbody rb;
    bool isGravityUp = true;
    bool canUseGravity = true;
    bool gravTilt = false;


    
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = rb.GetComponent<AudioSource>();
        lookXscript = ShipObject.GetComponent<ShipController>();
    }

    // Start is called before the first frame update
    private void Start()
    {
        rb.useGravity = false;
        

        // setting the initial rotation
        transform.Rotate(0, 0, 0);
    }

    // Interface to calculate the rotation of the ship with a delay
    IEnumerator Rotate(float rotationAmount)
    {
        yield return new WaitForSeconds(0.25f);
        transform.Rotate(0f, 0f, rotationAmount);
    }

    private void Update() 
    {
        if (gravTilt == true)
        {
            TiltingGrav();
        }
    }
    private void OnGravity()
    {
        // if bool is true then flip gravity
        if(canUseGravity)
        {
            if (isGravityUp)
            {
                // adding gravity and the rotation
                rb.AddForce(Vector3.up * gravity);
                audioSource.PlayOneShot(gravitySFX);

                StartCoroutine(Rotate(180));

                // setting bool back to flase then calling a function setting it to true with a delay
                canUseGravity = false;
                gravTilt = true;
                Invoke(nameof(EnableInput), delay);
                
            }
            else
            {
                // adding gravity and the rotation
                rb.AddForce(Vector3.down * gravity);
                audioSource.PlayOneShot(gravitySFX);

                StartCoroutine(Rotate(-180));

                // setting bool back to flase then calling a function setting it to true with a delay
                canUseGravity = false;
                gravTilt = false;
                Invoke(nameof(EnableInput), delay);
            }

            isGravityUp = !isGravityUp;
        }
    }

    // function setting a bool to true
    bool EnableInput()
    {
        return canUseGravity = true;
    }

    void TiltingGrav()  
    {
        Debug.Log(parentModel.transform.rotation.eulerAngles.z);
        // if the player is inside the angle we want them in let them tilt
        if ((parentModel.transform.rotation.eulerAngles.z <= 195 && parentModel.transform.rotation.eulerAngles.z >= 165))
        {
            Debug.Log(lookX);
            if (lookXscript.lookX > 0)
            {
                parentModel.transform.Rotate(0.0f, 0.0f, -0.5f, Space.Self);
            }
            else if (lookXscript.lookX < 0)
            {
                parentModel.transform.Rotate(0.0f, 0.0f, 0.5f, Space.Self);
            }
            
            
        }
        // if they are on the left boundary angle, allow them to tilt right
        else if (lookXscript.lookX > 0 && (parentModel.transform.rotation.eulerAngles.z >= 195 && parentModel.transform.rotation.eulerAngles.z <= 200))
        {
            parentModel.transform.Rotate(0.0f, 0.0f, -0.5f, Space.Self);
        }
        // if they are on the right boundary angle, allow them to tilt left
        else if (lookXscript.lookX < 0 && (parentModel.transform.rotation.eulerAngles.z <= 165 && parentModel.transform.rotation.eulerAngles.z >= 160))
        {
            parentModel.transform.Rotate(0.0f, 0.0f, 0.5f, Space.Self);
        }

        //if no keys are pressed, center ship
        if ((parentModel.transform.rotation.eulerAngles.z <= 200 && parentModel.transform.rotation.eulerAngles.z >= 180) && lookXscript.lookX == 0)
        {
            parentModel.transform.Rotate(0.0f, 0.0f, -0.4f, Space.Self);
        }
        else if ((parentModel.transform.rotation.eulerAngles.z <= 180 && parentModel.transform.rotation.eulerAngles.z >= 160)  && lookXscript.lookX == 0)
        {
            parentModel.transform.Rotate(0.0f, 0.0f, 0.4f, Space.Self);
        }
    }
}
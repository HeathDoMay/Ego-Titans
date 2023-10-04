using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] public float speed = 5;

    private Rigidbody rb;
    private float gravity = 5f;
    private float gravFix = 0f;
    private Quaternion rot;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rot = transform.rotation;
        rb.useGravity = false;

        //transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        gravity = -5f;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        rb.AddForce(Physics.gravity, ForceMode.Acceleration);
    }

    private void OnFire(InputValue fireValue)
    {
        if (gravity > 0 && gravFix == 1f)
        {
            Debug.Log(gravFix);
            gravFix += 1f;
            gravity = -5f;
            //transform.Rotate(0f, rot.y * 180f - 180, 180f);
        }
        else if (gravity > 0 && gravFix == 3f)
        {
            Debug.Log(gravFix);
            gravFix = 0f;
            gravity = -5f;
            //transform.Rotate(0f, rot.y * 180f - 180, 180f);
        }
        else if (gravity < 0 && gravFix == 0f)
        {
            Debug.Log(gravFix);
            gravFix += 1f;
            gravity = 5f;
            //transform.Rotate(0f, rot.y * 180f - 180, 180f);
        }
        else if (gravity < 0 && gravFix == 2f)
        {
            Debug.Log(gravFix);
            gravFix += 1f;
            gravity = 5f;
            //transform.Rotate(0f, rot.y * 180f - 180, 180f);
        }

        Physics.gravity = new Vector3(0, gravity, 0);
    }
}
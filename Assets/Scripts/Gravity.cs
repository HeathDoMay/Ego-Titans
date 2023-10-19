using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class Gravity : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera virtualCamera;

    private Rigidbody rb;
    private float gravity = 5f;
    private float gravFix = 0f;

    bool isGravityUp = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;

        transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        gravity = -5f;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        rb.AddForce(Physics.gravity, ForceMode.Acceleration);
    }

    private void OnPlayerOneGravity()
    {
        var transposer = virtualCamera.GetCinemachineComponent<CinemachineTransposer>();

        if (gravity > 0 && gravFix == 1f)
        {
            Debug.Log(gravFix);
            gravFix += 1f;
            gravity = -5f;
            //transform.Rotate(0f, rot.y * 180f - 180, 180f);
            transposer.m_FollowOffset = new Vector3(0, 3, -10);

        }
        else if (gravity > 0 && gravFix == 3f)
        {
            Debug.Log(gravFix);
            gravFix = 0f;
            gravity = -5f;
            //transform.Rotate(0f, rot.y * 180f - 180, 180f);
            transposer.m_FollowOffset = new Vector3(0, 3, -10);
        }
        else if (gravity < 0 && gravFix == 0f)
        {
            Debug.Log(gravFix);
            gravFix += 1f;
            gravity = 5f;
            //transform.Rotate(0f, rot.y * 180f - 180, 180f);
            transposer.m_FollowOffset = new Vector3(0, -3f, -10);
        }
        else if (gravity < 0 && gravFix == 2f)
        {
            Debug.Log(gravFix);
            gravFix += 1f;
            gravity = 5f;
            //transform.Rotate(0f, rot.y * 180f - 180, 180f);
            transposer.m_FollowOffset = new Vector3(0, -3f, -10);
        }

        Physics.gravity = new Vector3(0, gravity, 0);
    }

    //    USING UNITY EVENTS TO CALL

    //    public void GravityToggle(InputAction.CallbackContext context)
    //    {
    //        var transposer = virtualCamera.GetCinemachineComponent<CinemachineTransposer>();

    //        if (context.performed)
    //        {
    //            isGravityUp = !isGravityUp;

    //            Physics.gravity = isGravityUp ? new Vector3(0, -9.81f, 0) : new Vector3(0, 9.81f, 0);
    //        }

    //        if (isGravityUp)
    //        {
    //            transposer.m_FollowOffset = new Vector3(0, 3, -10);
    //        }
    //        else
    //        {
    //            transposer.m_FollowOffset = new Vector3(0, -3, -10);
    //        }
    //    }
}
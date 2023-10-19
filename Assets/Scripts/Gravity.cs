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

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;

        //transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        gravity = -5f;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        rb.AddForce(Physics.gravity, ForceMode.Acceleration);
    }

    private void Update()
    {
        Test();
    }

    //private void OnGravityToggle()
    //{
    //    var transposer = virtualCamera.GetCinemachineComponent<CinemachineTransposer>();

    //    if (gravity > 0 && gravFix == 1f)
    //    {
    //        Debug.Log(gravFix);
    //        gravFix += 1f;
    //        gravity = -5f;
    //        //transform.Rotate(0f, rot.y * 180f - 180, 180f);
    //        transposer.m_FollowOffset = new Vector3(0, 3, -10);

    //    }
    //    else if (gravity > 0 && gravFix == 3f)
    //    {
    //        Debug.Log(gravFix);
    //        gravFix = 0f;
    //        gravity = -5f;
    //        //transform.Rotate(0f, rot.y * 180f - 180, 180f);
    //        transposer.m_FollowOffset = new Vector3(0, 3, -10);
    //    }
    //    else if (gravity < 0 && gravFix == 0f)
    //    {
    //        Debug.Log(gravFix);
    //        gravFix += 1f;
    //        gravity = 5f;
    //        //transform.Rotate(0f, rot.y * 180f - 180, 180f);
    //        transposer.m_FollowOffset = new Vector3(0, -3f, -10);
    //    }
    //    else if (gravity < 0 && gravFix == 2f)
    //    {
    //        Debug.Log(gravFix);
    //        gravFix += 1f;
    //        gravity = 5f;
    //        //transform.Rotate(0f, rot.y * 180f - 180, 180f);
    //        transposer.m_FollowOffset = new Vector3(0, -3f, -10);
    //    }

    //    Physics.gravity = new Vector3(0, gravity, 0);
    //}

    private void Test()
    {
        var transposer = virtualCamera.GetCinemachineComponent<CinemachineTransposer>();

        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
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

        if (Gamepad.current.buttonSouth.wasPressedThisFrame)
        {
            Debug.Log("Pressed");
        }
    }
}
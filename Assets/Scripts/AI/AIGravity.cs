using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIGravity : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("AI"))
        {
            Debug.Log("HIT");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("AI"))
        {
            Debug.Log("LEAVE");
        }
    }
}

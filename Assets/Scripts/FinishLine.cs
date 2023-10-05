using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "PlayerOne")
        {
            Debug.Log("Player One Wins!");
            Destroy(gameObject);
        }

        if(other.gameObject.name == "PlayerTwo")
        {
            Debug.Log("Player Two Wins!");
            Destroy(gameObject);
        }
    }
}

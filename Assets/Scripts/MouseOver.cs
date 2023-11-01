using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseOver : MonoBehaviour
{
    void OnMouseOver()
    {
        Debug.Log("Mouse is over object");
    }

    private void OnMouseExit()
    {
        Debug.Log("Mouse is no longer over object");s
    }
}

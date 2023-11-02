using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseOver : MonoBehaviour
{
    Color m_MouseColor = Color.red;

    Color m_OriginalColor;

    MeshRenderer m_Renderer;

    private void Start()
    {
        m_Renderer = GetComponent<MeshRenderer>();
        m_OriginalColor = m_Renderer.material.color;
    }

    void OnMouseOver()
    {
        //Debug.Log("Mouse is over object");
        m_Renderer.material.color = m_MouseColor;
    }

    private void OnMouseExit()
    {
        //Debug.Log("Mouse is no longer over object");
        m_Renderer.material.color = m_OriginalColor;
    }

    //https://docs.unity3d.com/ScriptReference/MonoBehaviour.OnMouseOver.html 
}

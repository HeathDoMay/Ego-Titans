using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnFinishLine : MonoBehaviour
{
    [SerializeField] private float seconds;
    [SerializeField] private MeshRenderer finishLineRenderer;
    [SerializeField] private MeshCollider finsihLineCollider;


    IEnumerator waiter()
    {
        yield return new WaitForSeconds(seconds);
        finishLineRenderer.enabled = true;
        finsihLineCollider.enabled = true;
    }

    private void Start()
    {
        StartCoroutine(waiter());
        finishLineRenderer.enabled = false;
        finsihLineCollider.enabled = false;
    }
}

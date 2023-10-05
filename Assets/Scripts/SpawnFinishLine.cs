using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFinishLine : MonoBehaviour
{
    [SerializeField] private float seconds;
    [SerializeField] private GameObject finishLine;

    IEnumerator waiter()
    {
        yield return new WaitForSeconds(seconds);
        finishLine.SetActive(true);
    }

    private void Start()
    {
        StartCoroutine(waiter());
    }
}

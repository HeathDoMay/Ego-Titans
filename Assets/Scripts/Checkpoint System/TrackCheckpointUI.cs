using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackCheckpointUI : MonoBehaviour
{
    [SerializeField] private TrackCheckpoints trackCheckpoints;

    private void Start()
    {
        trackCheckpoints.OnCorrectCheckpoint += TrackCheckpoints_OnCorrectCheckpoint;
        trackCheckpoints.OnWrongCheckpoint += TrackCheckpoints_OnWrongCheckpoint;

        Hide();
    }
    private void TrackCheckpoints_OnCorrectCheckpoint(object sender, EventArgs e)
    {
        Hide();
    }

    private void TrackCheckpoints_OnWrongCheckpoint(object sender, EventArgs e)
    {
        Show();
    }

    void Hide()
    {
        gameObject.SetActive(false);
    }

    void Show()
    {
        gameObject.SetActive(true);
    }
}

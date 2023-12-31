using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointSingle : MonoBehaviour
{
    // script reference
    private TrackCheckpoints trackCheckpoints;
    private MeshRenderer meshRenderer;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Start()
    {
        Hide();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "PlayerOne")
        {
            // checking each checkpoint the player goes through
            trackCheckpoints.RacerThroughCheckpoint(this, other.transform);
        }

        if (other.gameObject.name == "PlayerTwo")
        {
            // checking each checkpoint the player goes through
            trackCheckpoints.RacerThroughCheckpoint(this, other.transform);
        }
    }

    public void SetTrackCheckpoints(TrackCheckpoints trackCheckpoints)
    {
        this.trackCheckpoints = trackCheckpoints;
    }

    public void Show()
    {
        meshRenderer.enabled = true;
    }

    public void Hide()
    {
        meshRenderer.enabled = false;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackCheckpoints : MonoBehaviour
{
    // Players
    [SerializeField] private List<Transform> racerTransformList;

    // Checkpoint list
    private List<CheckpointSingle> checkpointSingleList;

    // Next checkpoint list
    private List<int> nextCheckpointSingleIndexList;

    public int laps = 1;

    private void Awake()
    {
        // finding the container object with the checkpoints inside of it
        Transform checkpointsTransform = transform.Find("Checkpoints");
        checkpointSingleList = new List<CheckpointSingle>();

        // grabbing all of the transforms inside of the Checkpoints transform
        foreach (Transform checkpointSingleTransform in checkpointsTransform)
        {
            CheckpointSingle checkpointSingle = checkpointSingleTransform.GetComponent<CheckpointSingle>();
            checkpointSingle.SetTrackCheckpoints(this);
            checkpointSingleList.Add(checkpointSingle);
        }

        nextCheckpointSingleIndexList = new List<int>();

        foreach (Transform racerTransfrom in racerTransformList)
        {
            nextCheckpointSingleIndexList.Add(0);
        }
    }


    // grabbing the checkpoint the player goes through
    public void RacerThroughCheckpoint(CheckpointSingle checkpointSingle, Transform racerTransform)
    {
        int nextCheckpointSingleIndex = nextCheckpointSingleIndexList[racerTransformList.IndexOf(racerTransform)];

        // checking if the index of the list is equal to the next checkpoint, EX: index 0 == 0, index 1 == 1
        if (checkpointSingleList.IndexOf(checkpointSingle) == nextCheckpointSingleIndex)
        {
            // correct checkpoint
            // % returns the remainder of the divsison
            // next checkpoint is equal to the index plus 1 and the remainder of the list of checkpoints
            // loops back to zero after going through all the checkpoints
            nextCheckpointSingleIndexList[racerTransformList.IndexOf(racerTransform)] = (nextCheckpointSingleIndex + 1) % checkpointSingleList.Count;

            if(nextCheckpointSingleIndex == checkpointSingleList.Count - 1)
            {
                laps++;
                Debug.Log("Lap number: " + laps);
            }

            Debug.Log("Correct: " + racerTransform);
        }
        else
        {
            // wrong checkpoint
            Debug.Log("Wrong");
        }
    }
}

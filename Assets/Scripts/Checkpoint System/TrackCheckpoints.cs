using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackCheckpoints : MonoBehaviour
{
    // Players
    [SerializeField] private List<Transform> racerTransformList;

    // lists
    private List<CheckpointSingle> CheckpointSingleList;
    private List<int> nextCheckpointSingleIndexList;

    // C# events
    public event EventHandler OnCorrectCheckpoint;
    public event EventHandler OnWrongCheckpoint;

    private void Awake()
    {
        // finding the container object with the checkpoints inside of it
        Transform checkpointsTransform = transform.Find("Checkpoints");
        CheckpointSingleList = new List<CheckpointSingle>();

        // grabbing all of the transforms inside of the Checkpoints transform
        foreach (Transform checkpointSingleTransform in checkpointsTransform)
        {
            CheckpointSingle checkpointSingle = checkpointSingleTransform.GetComponent<CheckpointSingle>();
            checkpointSingle.SetTrackCheckpoints(this);
            CheckpointSingleList.Add(checkpointSingle);
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
        if (CheckpointSingleList.IndexOf(checkpointSingle) == nextCheckpointSingleIndex)
        {
            // correct checkpoint
            // % returns the remainder of the divsison
            // next checkpoint is equal to the index plus 1 and the remainder of the list of checkpoints
            // loops back to zero after going through all the checkpoints
            nextCheckpointSingleIndexList[racerTransformList.IndexOf(racerTransform)] = (nextCheckpointSingleIndex+ 1) % CheckpointSingleList.Count;
            OnCorrectCheckpoint?.Invoke(this, EventArgs.Empty);

            //CheckpointSingle correctCheckpointSingle = CheckpointSingleList[nextCheckpointSingleIndex];
            //correctCheckpointSingle.Hide();

            Debug.Log("Correct: " + racerTransform);
        }
        else
        {
            // wrong checkpoint
            Debug.Log("Wrong");
            OnWrongCheckpoint?.Invoke(this, EventArgs.Empty);

            //CheckpointSingle correctCheckpointSingle = CheckpointSingleList[nextCheckpointSingleIndex];
            //correctCheckpointSingle.Show();
        }
    }
}

using UnityEngine;
using UnityEngine.Events;

public class LapBehaviour : MonoBehaviour
{
    public int numberOfLaps = 1;
    [Space]
    [SerializeField] private UnityEvent CheckLaps;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("FinalCheckpoint"))
        {
            numberOfLaps++;

            if (numberOfLaps == 4)
            {
                CheckLaps.Invoke();
            }
        }
    }
}

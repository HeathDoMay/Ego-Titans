using UnityEngine;

public class SpawnFinishLine : MonoBehaviour
{
    [SerializeField] private MeshCollider finishLineCollider;
    [SerializeField] private MeshRenderer finishLineRender;

    [SerializeField] private TrackCheckpoints trackCheckpoints;

    private void Start()
    {
        finishLineCollider.enabled = false;
        finishLineRender.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(trackCheckpoints.laps == 3)
        {
            if (other.gameObject.name == "PlayerOne")
            {
                finishLineCollider.enabled = true;
                finishLineRender.enabled = true;
            }

            if (other.gameObject.name == "PlayerTwo")
            {
                finishLineCollider.enabled = true;
                finishLineRender.enabled = true;
            }
        }
    }
}

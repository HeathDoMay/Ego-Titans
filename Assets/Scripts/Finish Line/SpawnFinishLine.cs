using UnityEngine;

public class SpawnFinishLine : MonoBehaviour
{
    [SerializeField] private BoxCollider finishLineCollider;

    private void Start()
    {
        finishLineCollider.enabled = false;
    }

    public void InstantiateFinishLine()
    {
        finishLineCollider.enabled = true;
    }
}

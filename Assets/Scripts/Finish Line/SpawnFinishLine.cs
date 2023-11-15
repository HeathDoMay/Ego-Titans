using UnityEngine;

public class SpawnFinishLine : MonoBehaviour
{
    [SerializeField] private MeshCollider finishLineCollider;
    [SerializeField] private MeshRenderer finishLineRender;

    private void Start()
    {
        finishLineCollider.enabled = false;
        finishLineRender.enabled = false;
    }

    public void InstantiateFinishLine()
    {
        finishLineCollider.enabled = true;
        finishLineRender.enabled = true;
    }
}

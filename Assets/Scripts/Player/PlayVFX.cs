using UnityEngine;

public class PlayVFX : MonoBehaviour
{
    [Tooltip("All vxf should be a child of an empty game object. That empty should be assigned to this variable.")]
    [SerializeField] private GameObject vfxToPlay;

    private void Start()
    {
        StopVFX();
    }

    public void StartVFX()
    {
        vfxToPlay.SetActive(true);
    }

    public void StopVFX()
    {
        vfxToPlay.SetActive(false);
    }
}

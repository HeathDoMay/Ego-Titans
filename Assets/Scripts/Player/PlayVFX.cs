using UnityEngine;

public class PlayVFX : MonoBehaviour
{
    [SerializeField] private GameObject[] vfxToPlay;

    private void Start()
    {
        StopVFX();
    }

    public void StartVFX()
    {
        for( int i = 0;i < vfxToPlay.Length;i++)
        {
            vfxToPlay[i].SetActive(true);
        }
    }

    public void StopVFX()
    {
        for (int i = 0; i < vfxToPlay.Length; i++)
        {
            vfxToPlay[i].SetActive(false);
        }
    }
}

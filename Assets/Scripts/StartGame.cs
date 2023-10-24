using UnityEngine;

public class StartGame : MonoBehaviour
{
    [SerializeField] private PlayerMovement[] playerMovement;

    public void StartRace()
    {
        for (int i = 0; i < playerMovement.Length; i++)
        {
            playerMovement[i].enabled = true;
        }
    }
}

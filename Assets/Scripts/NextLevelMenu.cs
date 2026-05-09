using UnityEngine;

public class NextLevelMenu : MonoBehaviour
{
    public Vector3 targetPosition;
    public GameObject MenuLevel;
    public PlayerMovement Player;
    public MonoBehaviour MovementScript;
    public void PlayNextGame()
    {
        MenuLevel.SetActive(false);
        Player.Init();
        Player.transform.position = targetPosition;
        if (MovementScript != null)
            {
                MovementScript.enabled = true;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }

    }
}

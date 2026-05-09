using UnityEngine;

public class TeleportOnTrigger : MonoBehaviour
{
    public GameObject CanvasNextGame;
    public MonoBehaviour MovementScript;
    public MonoBehaviour AnimatorScript;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (MovementScript != null && AnimatorScript != null)
            {
                MovementScript.enabled = false;
                AnimatorScript.enabled = false;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            CanvasNextGame.SetActive(true);

        }
    }
}
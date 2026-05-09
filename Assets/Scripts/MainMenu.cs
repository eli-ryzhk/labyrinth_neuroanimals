using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject Menu;
    public PlayerMovement Player;
    
    public CameraAnimations Camera;
    public void PlayGame()
    {
        Menu.SetActive(false);
        Camera.Init();
        Player.Init();


    }
}
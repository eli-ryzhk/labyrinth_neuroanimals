using UnityEngine;

public class CameraAnimations : MonoBehaviour
{
    public Animator CamAnim;
    public void Init()
    {
        CamAnim.SetTrigger("Fly");
    }
}

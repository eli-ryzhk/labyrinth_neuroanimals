using UnityEngine;

public class DoorController : MonoBehaviour
{
    public float openAngle = 90f;
    public float closeAngle = 0f;
    public float speed = 2f;
    public bool isOpen = false;

    private Quaternion targetRotation;

    void Start()
    {
        
    targetRotation = Quaternion.Euler(0, closeAngle, 0);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            isOpen = !isOpen; 
            targetRotation = Quaternion.Euler(0, isOpen ? openAngle : closeAngle, 0);
        }

        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * speed);
    }
}
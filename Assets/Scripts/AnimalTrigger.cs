using UnityEngine;

public class AnimalTrigger : MonoBehaviour
{
    public GameObject objectToHide; 
    public GameObject uiImage; 
    private bool hasTriggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            if (objectToHide != null)
            {
                //Destroy(objectToHide); 
                objectToHide.SetActive(false);
            }
            if (!hasTriggered)
            {
                uiImage.SetActive(true); 
                hasTriggered = true;     
            }
        }
    }

}

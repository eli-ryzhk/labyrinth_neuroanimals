using UnityEngine;
using UnityEngine.UI;

public class LockedTrigger : MonoBehaviour
{
    public Image lockIcon; // UI-элемент
    public Collider triggerCollider; // Тот самый барьер, у которого проверяем isTrigger
    public Sprite lockedSprite;
    public Sprite unlockedSprite;

    private void Start()
    {
        // Скрываем иконку при старте
        if (lockIcon != null)
            lockIcon.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        // Проверяем, что вошел игрок
        if (other.CompareTag("Player"))
        {
            UpdateLockIcon();
            lockIcon.enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            lockIcon.enabled = false;
        }
    }

    void UpdateLockIcon()
    {
        if (triggerCollider != null && lockIcon != null)
        {
            if (triggerCollider.isTrigger)
            {
                lockIcon.sprite = unlockedSprite;
            }
            else
            {
                lockIcon.sprite = lockedSprite;
            }
        }
    }
}
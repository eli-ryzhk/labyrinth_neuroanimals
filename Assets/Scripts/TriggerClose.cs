using UnityEngine;

public class TriggerCLose : MonoBehaviour
{
    public GameObject[] controlObjects;
    private Collider barrierCollider;

    private bool isSolid = false; // Состояние "твёрдости" барьера

    void Start()
    {
        barrierCollider = GetComponent<Collider>();
    }

    void Update()
    {
        if (!isSolid && AllObjectsActive())
        {
            // Делаем барьер твёрдым
            barrierCollider.isTrigger = false;
            isSolid = true;
        }
        else if (isSolid && AllObjectsInactive())
        {
            // Возвращаем барьер в триггер
            barrierCollider.isTrigger = true;
            isSolid = false;
        }
    }

    bool AllObjectsActive()
    {
        foreach (GameObject obj in controlObjects)
        {
            if (!obj.activeInHierarchy)
                return false;
        }
        return true;
    }

    bool AllObjectsInactive()
    {
        foreach (GameObject obj in controlObjects)
        {
            if (obj.activeInHierarchy)
                return false;
        }
        return true;
    }
}
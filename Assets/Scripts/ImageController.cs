using UnityEngine;

public class ImageController : MonoBehaviour
{
    public RectTransform[] images;
    public float spacing = 100f; // Расстояние между центрами изображений
    public float yPosition = 0f; // Позиция по Y

    void Start()
    {
        for (int i = 0; i < images.Length; i++)
        {
            float x = i * spacing;
            images[i].anchoredPosition = new Vector2(x, yPosition);
        }
    }
}
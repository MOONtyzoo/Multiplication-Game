using System;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundScroller : MonoBehaviour
{
    [SerializeField, Range(0.0f, 360.0f)] private float scrollAngle = 0f;
    [SerializeField, Range(0.0f, 10.0f)] private float scrollSpeed = 1.0f;

    private Image image;
    private Material shaderMaterial;

    private float scrollAmount = 0.0f;

    private void Awake()
    {
        image = GetComponent<Image>();
        shaderMaterial = image.material;
    }

    private void Update()
    {
        scrollAmount = scrollAmount + scrollSpeed * Time.deltaTime;

        Vector2 scrollDirection = new Vector2(Mathf.Cos(scrollAngle * Mathf.Deg2Rad), Mathf.Sin(scrollAngle * Mathf.Deg2Rad));
        Vector2 scrollVal = scrollAmount/20.0f * scrollDirection;
        shaderMaterial.SetVector("_Scroll", scrollVal);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CustomSlider : MonoBehaviour
{
    public float maxValue;
    public float minValue;
    public float currentValue;
    public Vector2 backgroundSize;
    [SerializeField] GameObject fill;
    public Transform fillTransform;
    public Transform backgroundTransform;
    public bool updateBackgroundAtRuntime;

    void Start()
    {
        UpdateBackground();
    }

    public void UpdateBackground()
    {
        backgroundTransform.localScale = new Vector3(backgroundSize.x, backgroundSize.y, 1);
    }

    void Update()
    {
        UpdateSlider();

        if(updateBackgroundAtRuntime)
        {
            UpdateBackground();
        }
    }

    public void UpdateSlider()
    {
        if(currentValue <= maxValue && currentValue >= minValue)
        {
            fillTransform.localScale = new Vector3(((currentValue - minValue) / (maxValue - minValue)) * backgroundSize.x, backgroundSize.y, 1);
        }
        else if(currentValue > maxValue)
        {
            currentValue = maxValue;
        }
        else if(fill.activeInHierarchy == true && currentValue < minValue)
        {
            fill.SetActive(false);
        }
        
        if(fill.activeInHierarchy == false && currentValue > minValue)
        {
            fill.SetActive(true);
        }
    }

    void OnValidate()
    {
        UpdateSlider();
        UpdateBackground();
    }
}

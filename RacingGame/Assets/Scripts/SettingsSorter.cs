using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Rendering;

public class SettingsSorter : MonoBehaviour
{
    [SerializeField] private Slider sensitivityXSlider;
    [SerializeField] private Slider sensitivityYSlider;
    [SerializeField] private TMP_InputField sensitivityXInputField;
    [SerializeField] private TMP_InputField sensitivityYInputField;
    [SerializeField] private float maxSensitivity = 1000f;

    // Start is called before the first frame update
    void Start()
    {
        sensitivityXSlider.maxValue = maxSensitivity;
        sensitivityYSlider.maxValue = maxSensitivity;
        sensitivityXSlider.value = PlayerStats.cameraSensitivityX;
        sensitivityYSlider.value = PlayerStats.cameraSensitivityY;

        sensitivityXInputField.text = sensitivityXSlider.value.ToString();
        sensitivityYInputField.text = sensitivityYSlider.value.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (sensitivityXInputField.isFocused)
        {
            sensitivityXSlider.value = float.Parse(sensitivityXInputField.text);
        }
        else
        {
            sensitivityXInputField.text = sensitivityXSlider.value.ToString();
        }

        if (sensitivityYInputField.isFocused)
        {
            sensitivityYSlider.value = float.Parse(sensitivityYInputField.text);
        }
        else
        {
            sensitivityYInputField.text = sensitivityYSlider.value.ToString();
        }

        PlayerStats.cameraSensitivityX = sensitivityXSlider.value;
        PlayerStats.cameraSensitivityY = sensitivityYSlider.value;

    }
}

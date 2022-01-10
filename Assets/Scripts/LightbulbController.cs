using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightbulbController : MonoBehaviour
{

    public Text brightnessText;
    public Button colorButton;
    public Text colorHexCode;
    public GameObject colorPicker;

    [HideInInspector] public bool lighted = false;
    [HideInInspector] public double brightness = 0.0;
    [HideInInspector] public Color color;

    private bool isPickerOpen = false;

    private GameObject pickerOpen = null;

    public void UpdateLighted(Toggle toggle)
    {
        lighted = toggle.isOn;
    }

    public void UpdateBrightness(Slider slider)
    {
        brightness = slider.value;
        if (brightnessText != null)
        {
            brightnessText.text = brightness.ToString("0.00");
        }
    }

    public void UpdateColor(Color pickerColor)
    {
        color = pickerColor;
        if (colorButton != null)
        {
            Debug.Log("a");
            colorButton.GetComponent<Image>().color = color;
        }
        if (colorHexCode != null)
        {
            Debug.Log("b");
            colorHexCode.text = "#" + ColorUtility.ToHtmlStringRGB(color);
        }
    }

    public void ShowHideColorPicker()
    {
        if (!isPickerOpen)
        {
            pickerOpen = Instantiate(colorPicker,GetComponent<Transform>());
            isPickerOpen = true;
            FlexibleColorPicker fcp = pickerOpen.GetComponent<FlexibleColorPicker>();
            fcp.color = color;
            fcp.onColorChange.AddListener((color) => UpdateColor(color));
        }
        else
        {
            Destroy(pickerOpen);
            isPickerOpen = false;
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public string buttonText;

    private Text buttonTextArea;
    private Button button;

    // Start is called before the first frame update
    void Start()
    {
        buttonTextArea = GetComponentInChildren<Text>();
        button = GetComponent<Button>();
       
    }

    public void UpdateButtonText(string name)
    {
        buttonText = name;
        if (buttonTextArea != null)
        {
            buttonTextArea.text = buttonText;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeaderController : MonoBehaviour
{
    public string headerText;

    private Text headerTextArea;

    // Start is called before the first frame update
    void Start()
    {
        headerTextArea = GetComponentInChildren<Text>();
    }

    public void UpdateHeaderText(string name)
    {
        headerText = name;
        if (headerTextArea != null)
        {
            headerTextArea.text = headerText;
        }
    }


}

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [Header("User References")]

    [Header("Window References")]
    public Text tittleComponent;
    public Window currentWindow;

    public Button[] addButtons;

    [HideInInspector] public SliderMenuAnim sliderAnim;
    [HideInInspector] public SlideAddButtonsAnim addAnim;


    private string addedCategory = "";
    private Dictionary<string, string> addedArguments = new Dictionary<string, string>();
    private Dictionary<string, Button> usedAddButtons = new Dictionary<string, Button>();

    private Dictionary<string, Button> nameToAddButton = new Dictionary<string, Button>();
    private Button currentAddButton;

    // Start is called before the first frame update
    void Start()
    {
        sliderAnim = GetComponent<SliderMenuAnim>();
        addAnim = GetComponent<SlideAddButtonsAnim>();
        foreach (var button in addButtons)
        {
            Argument arg = button.GetComponent<Argument>();
            if (arg != null) nameToAddButton.Add(arg.category, button);
        }
    }

    void Update()
    {
        if (addedCategory != "" && currentAddButton != null)
        {
            if (addedArguments.Count == 2)
                currentAddButton.interactable = true;
            else
                currentAddButton.interactable = false;
        }

    }
    public void StartToAdd(string whatToAdd)
    {
        addedArguments.Clear();
        usedAddButtons.Clear();
        addedCategory = whatToAdd;
        currentAddButton = nameToAddButton[whatToAdd];
        Debug.Log(whatToAdd);
    }

    public void SumbitAdding()
    {
        foreach(var addedValue in addedArguments)
        {
            Debug.Log(addedValue.Value);
        }
    }

    public void AddToForm(Button buttonPressed)
    {
        
        if (buttonPressed != null)
        {
            Argument arg = buttonPressed.GetComponent<Argument>();
            if (arg != null && arg.category == addedCategory)
            {
                Text argText = buttonPressed.GetComponentInChildren<Text>();
                if (argText != null)
                {
                    addedArguments[arg.argumentName] = argText.text; 
                    if (usedAddButtons.ContainsKey(arg.argumentName))
                    {
                        usedAddButtons[arg.argumentName].interactable = true;
                    }
                    usedAddButtons[arg.argumentName] = buttonPressed;
                    usedAddButtons[arg.argumentName].interactable = false;
                }
            }
        }
    }

}

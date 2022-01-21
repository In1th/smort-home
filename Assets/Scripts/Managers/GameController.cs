using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class GameController : MonoBehaviour
{

    public static GameObject buttonOptionPrefab;
    public static GameObject headerPrefab;

    [Header("Window References")]
    public Text tittleComponent;
    public Window currentWindow;


    [Header("Button Adding New Elements")]
    public Button[] addButtons;

    [Header("Testing Buttons")]
    public Button deviceSypialniaButton;
    public Button deviceKuchniaButton;
    public Button routineButton;

    [HideInInspector] public SliderMenuAnim sliderAnim;
    [HideInInspector] public SlideAddButtonsAnim addAnim;
    [HideInInspector] public WindowManager windowManager;

    private string addedCategory = "";
    public Dictionary<string, string> addedArguments = new Dictionary<string, string>();
    private Dictionary<string, Button> usedAddButtons = new Dictionary<string, Button>();

    private Dictionary<string, Button> nameToAddButton = new Dictionary<string, Button>();
    private Button currentAddButton;

    private string previousWindowName;

    // Start is called before the first frame update
    void Start()
    {
        sliderAnim = GetComponent<SliderMenuAnim>();
        addAnim = GetComponent<SlideAddButtonsAnim>();
        windowManager = GetComponent<WindowManager>();
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
            if (addedArguments.Count == 3)
                currentAddButton.interactable = true;
            else if (addedArguments.Count == 1 && addedCategory == "Dodaj pokój")
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
    }

    public void SumbitAdding()
    {
        foreach(var addedValue in addedArguments)
        {
            Debug.Log(addedValue.Value);
        }
        if (addedCategory == "Dodaj urz¹dzenie")
            AddDeviceToButton();
        else if (addedCategory == "Dodaj rutynê")
            AddRoutineToButton();
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

    public void AddToForm(Dropdown optionChoosen)
    {

        if (optionChoosen != null)
        {
            Argument arg = optionChoosen.GetComponent<Argument>();
            if (arg != null && arg.category == addedCategory)
            {
                String argText = optionChoosen.options[optionChoosen.value].text;
                if (argText != null)
                {
                    addedArguments[arg.argumentName] = argText;
                }
            }
        }
    }

    public void AddToForm(InputField name)
    {
        if (name != null)
        {
            Argument arg = name.GetComponent<Argument>();
            if (arg != null && arg.category == addedCategory)
            {
            addedArguments[arg.argumentName] = name.text;
            }
        }
    }

    public List<string> GetMissingValues(List<string> argList)
    {
        List<string> result = new List<string>();

        foreach(string arg in argList)
        {
            if (!addedArguments.ContainsKey(arg))
                result.Add(arg);
        }

        return result;
    }

    public void ResetUsedButtons()
    {
        foreach (var arg in usedAddButtons)
        {
            arg.Value.interactable = true;
        }
    }

    public void AddDeviceToButton()
    {
        string roomName = addedArguments["DeviceRoom"];
        Button buttonUsed = null;

        switch (roomName)
        {
            case "Kuchnia": buttonUsed = deviceKuchniaButton; break;
            case "Sypialnia 1": buttonUsed = deviceSypialniaButton; break;
        }
        if (buttonUsed != null)
        {

            Text text = buttonUsed.GetComponentInChildren<Text>();
            text.text = addedArguments["Name"];
        }
    }

    public void AddRoutineToButton()
    {
        if (routineButton != null)
        {
            Text text = routineButton.GetComponentInChildren<Text>();
            text.text = addedArguments["Name"];
        }
    }



    public void OnExitButtonChanged(bool isPrevious)
    {
        string newCharacter;
        UnityAction call;

        if (isPrevious)
        {
            newCharacter = sliderAnim.openChar;
            previousWindowName = currentWindow.windowName;
            call = delegate { windowManager.UpdateWindow(previousWindowName); };
        }
        else
        {
            newCharacter = sliderAnim.closedChar;
            call = sliderAnim.ShowHideMenu;
        }

        Text buttonText = sliderAnim.menuButton.GetComponentInChildren<Text>();
        buttonText.text = newCharacter;

        sliderAnim.menuButton.onClick.RemoveAllListeners();
        sliderAnim.menuButton.onClick.AddListener(call);
    }

}

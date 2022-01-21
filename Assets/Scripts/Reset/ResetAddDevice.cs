using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResetAddDevice : Reset
{
    public InputField inputBox;
    public addDevice manager;

    public override void ResetThis()
    {
        inputBox.text = "";
        foreach(var _object in manager.initializedDevices.Values)
        {
            Button button = _object.GetComponent<Button>();
            if (button != null)
            {
                button.interactable = true;
            }
        }
        foreach (var _object in manager.initializedRooms.Values)
        {
            Button button = _object.GetComponent<Button>();
            if (button != null)
            {
                button.interactable = true;
            }
        }
    }
}

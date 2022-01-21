using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResetAddRoutine : Reset
{
    public InputField inputBox;
    public AddRoutine manager;

    public override void ResetThis()
    {
        inputBox.text = "";
        foreach (var routine in manager.dropdowns.Values) 
        {
            Destroy(routine);
            manager.IFpos = 1;
            manager.THENpos = 3;
        }
    }
}

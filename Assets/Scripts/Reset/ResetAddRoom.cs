using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResetAddRoom : Reset
{
    public InputField inputBox;

    public override void ResetThis()
    {
        inputBox.text = "";
    }
}

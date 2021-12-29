using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Window : ScriptableObject
{
    public new string name;
    public Canvas windowCanvas;

    public abstract void constructWindow(GameController gameController);
}

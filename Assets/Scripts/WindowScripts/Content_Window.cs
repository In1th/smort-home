using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Window/Content Window")]
public class Content_Window : Window
{
    public override void WindowButtonClick(GameController controller)
    {
        if (controller.currentWindow.windowName != windowName)
        {
            controller.currentWindow.ShowHideWindow();
            ShowHideWindow();
            controller.currentWindow = this;
            controller.tittleComponent.text = windowName;   
        }
        
    }
}

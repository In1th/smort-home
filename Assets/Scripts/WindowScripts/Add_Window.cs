using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Window/Adding Window")]
public class Add_Window : Window
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
        if (controller.addAnim.IsShown())
        {
            controller.addAnim.ShowHideAddButtons();
        }
        controller.StartToAdd(windowName);
        windowReference.GetComponent<Reset>().ResetThis();

        //przygotuj siê do przyjmowania danych
    }

}

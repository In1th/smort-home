using UnityEngine;

[CreateAssetMenu(menuName ="Window/Regular Window")]
public class Regular_Window : Window
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
        if (controller.sliderAnim.IsSliderOpen())
        {
            controller.sliderAnim.ShowHideMenu();
        }
    }
}

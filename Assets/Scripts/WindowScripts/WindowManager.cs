using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WindowManager : MonoBehaviour
{
    [Header("Window References")]
    public Window[] windows;
    public GameObject[] windowPanels;

    private GameController controller;
    private Dictionary<string, Window> windowMap = new Dictionary<string,Window>();

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<GameController>();
        for (int i = 0; i < windows.Length; i++)
        {
            var window = windows[i]; 
            var panel = windowPanels[i];

            windowMap[window.windowName] = window;

            window.giveWindowReference(panel);
        }

        Debug.Log("setup");
    }

    public void UpdateWindow(string name)
    {
        if (windowMap.ContainsKey(name))
        {
            controller.OnExitButtonChanged(windowMap[name].hasToReturn);
            windowMap[name].WindowButtonClick(controller);
            controller.addAnim.ShowHideMainButton(windowMap[name].hidePlusButton);
        }
    }

    public Window GetWindowByName(string name)
    {
        if (windowMap.ContainsKey(name)) return windowMap[name];
        return null;
    }

}

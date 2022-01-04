using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowManager : MonoBehaviour
{

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
            windowMap[name].WindowButtonClick(controller);

    }
}

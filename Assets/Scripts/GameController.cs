using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    //ustawiamy sb okno z edytora
    public Window currentWindow;

    //wstawiamy w edytorze wszystkie okna
    public Window[] widows;

    /* pomys� jest taki, by przyciski do zmiany pokoju mia�y t� sam� nazw� i by wywo�ywa�y
     * setCurrentWindow ze swoj� nazw�
     */
    Dictionary<string, Window> windowTransition = new Dictionary<string, Window>();

    // Start is called before the first frame update
    void Start()
    {
        foreach (var window in widows)
            windowTransition.Add(window.name, window);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //zmiana na nowe okno
    void setCurrentWindow(string windowName)
    {
        if (windowTransition.ContainsKey(windowName))
            currentWindow = windowTransition[windowName];
        //windowUpdate();
    }
}

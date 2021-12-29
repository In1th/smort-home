using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    //ustawiamy sb okno z edytora
    public Window currentWindow;

    //wstawiamy w edytorze wszystkie okna
    public Window[] widows;

    /* pomys³ jest taki, by przyciski do zmiany pokoju mia³y t¹ sam¹ nazwê i by wywo³ywa³y
     * setCurrentWindow ze swoj¹ nazw¹
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

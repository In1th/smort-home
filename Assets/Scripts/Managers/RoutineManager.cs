using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoutineManager : MonoBehaviour
{

    public GameObject buttonPrefab;

    public GameObject content;

    public List<string> currentRoutines = new List<string>();

    public Dictionary<string, GameObject> routines = new Dictionary<string,GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        foreach(var routine in currentRoutines)
        {
            routines[routine] = Instantiate(buttonPrefab, content.transform);
            routines[routine].GetComponentInChildren<Text>().text = routine;
        }
    }
   
    public void AddRoutine(GameController controller)
    {
        Dictionary<string, string> args = controller.addedArguments;
        routines[args["Name"]] = Instantiate(buttonPrefab, content.transform);
        routines[args["Name"]].GetComponentInChildren<Text>().text = args["Name"];
    }
}

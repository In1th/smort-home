using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddRoutine : MonoBehaviour
{

    public GameObject dropdownIF;
    public GameObject dropdownTHEN;

    public GameObject content;

    [HideInInspector] public int IFpos = 1;
    [HideInInspector] public int THENpos = 3;

    public Dictionary<int, GameObject> dropdowns = new Dictionary<int, GameObject>();

    public void AddIFdropdown()
    {
        Debug.Log("a");
        dropdowns[IFpos] = Instantiate(dropdownIF, content.transform);
        dropdowns[IFpos].transform.SetSiblingIndex(IFpos);
        dropdowns[IFpos].GetComponent<Argument>().argumentName = "RoutineIF" + IFpos;
        IFpos++;
        THENpos++;
    }

    public void AddTHENdropdown()
    {
        Debug.Log("b");
        dropdowns[THENpos] = Instantiate(dropdownTHEN, content.transform);
        dropdowns[THENpos].transform.SetSiblingIndex(THENpos);
        dropdowns[THENpos].GetComponent<Argument>().argumentName = "RoutineTHEN" + (THENpos - 2);
        THENpos++;
    }
}

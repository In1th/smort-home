using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArgumentList : Argument
{
    public List<string> argumentList = new List<string>();
    public List<string> argumentNames = new List<string>();

    [HideInInspector] public Dictionary<string,string> argCodeToName = new Dictionary<string,string>();

    private void Start()
    {
        for (int i = 0; i < argumentList.Count; i++)
        {
            var (arg, name) = (argumentList[i],argumentNames[i]);
            argCodeToName[arg] = name;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class addDevice : MonoBehaviour
{
    public GameObject buttonPrefab;

    public GameObject devicesBox;
    public GameObject roomBox;

    public DeviceManager manager;
    public GameController controller;  

    public List<string> names = new List<string> ();

    public Dictionary<string,GameObject> initializedDevices = new Dictionary<string,GameObject> ();
    public Dictionary<string, GameObject> initializedRooms = new Dictionary<string, GameObject>();

    private void Start()
    {
        foreach (string name in names) 
        {
            GameObject newDevice = Instantiate (buttonPrefab, devicesBox.transform);
            newDevice.GetComponentInChildren<Text>().text = name;
            newDevice.AddComponent<Argument>();
            newDevice.GetComponent<Button>().onClick.AddListener(delegate { controller.AddToForm(newDevice.GetComponent<Button>()); });
            Argument arg = newDevice.GetComponent<Argument>();
            arg.category = "Dodaj urz¹dzenie";
            arg.argumentName = "DeviceName";
            initializedDevices.Add (name, newDevice);
        }
        List<string> rooms = manager.currentRooms;
        foreach(var room in rooms)
        {
            GameObject newDevice = Instantiate(buttonPrefab, roomBox.transform);
            newDevice.GetComponentInChildren<Text>().text = room;
            newDevice.AddComponent<Argument>();
            newDevice.GetComponent<Button>().onClick.AddListener(delegate { controller.AddToForm(newDevice.GetComponent<Button>()); });
            Argument arg = newDevice.GetComponent<Argument>();
            arg.category = "Dodaj urz¹dzenie";
            arg.argumentName = "DeviceRoom";
            initializedRooms.Add (room, newDevice);
        }
    }

    public void Add(GameController controller)
    {
        Dictionary<string, string> map = controller.addedArguments;
        Destroy(initializedDevices[map["DeviceName"]]);
        initializedDevices.Remove(map["DeviceName"]);
        manager.AddButton(map["DeviceRoom"], map["Name"]);
    }

    public void UpdateRooms(string newRoom)
    {
        GameObject newDevice = Instantiate(buttonPrefab, roomBox.transform);
        newDevice.GetComponentInChildren<Text>().text = newRoom;
        newDevice.AddComponent<Argument>();
        newDevice.GetComponent<Button>().onClick.AddListener(delegate { controller.AddToForm(newDevice.GetComponent<Button>()); });
        Argument arg = newDevice.GetComponent<Argument>();
        arg.category = "Dodaj urz¹dzenie";
        arg.argumentName = "DeviceRoom";
        initializedRooms.Add(newRoom, newDevice);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeviceManager : MonoBehaviour
{

    public GameObject buttonPrefab;
    public GameObject headerPrefab;

    public WindowManager winManager;
    public GameObject content;
    public GameObject newHeader;

    public addDevice add;
    public AlertBox alertBox;
    public GameController controller;

    public List<string> currentRooms = new List<string>();
    public List<DeviceInWindow> presetDeviceList = new List<DeviceInWindow>();

    private Dictionary<string, int> deviceMap = new Dictionary<string,int>();
    private Dictionary<string, int> headerMap = new Dictionary<string, int>();

    private Dictionary<string, int> roomLastIndex = new Dictionary<string, int>();

    [HideInInspector] public List<GameObject> objects = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        Dictionary<string, List<DeviceInWindow>> map = new Dictionary<string, List<DeviceInWindow>>();

        foreach(var room in currentRooms)
        {
            map[room] = new List<DeviceInWindow>();   
        }

        foreach (var device in presetDeviceList)
        {
            map[device.room].Add(device);
           
        }
        int i = 0;
        foreach (var key in currentRooms)
        {
            headerMap[key] = i;
            var temp = Instantiate(headerPrefab,content.transform);
            temp.GetComponentInChildren<Text>().text = key;
            objects.Add(temp);
            foreach (var device in map[key])
            {
                i++;
                if (device.Device == null)
                {
                    device.Device = Instantiate(buttonPrefab, content.transform);
                    device.Device.GetComponent<Button>().onClick.AddListener(delegate { winManager.UpdateWindow(device.name); });
                    device.Device.GetComponentInChildren<Text>().text = device.name;
                }
                deviceMap[device.name] = i;
                objects.Add(device.Device);
            }
            roomLastIndex[key] = i;
            i++;
        }
        newHeader.transform.SetAsLastSibling();
    }

    public void AddHeader(string name)
    {
        var temp = Instantiate(headerPrefab, content.transform);
        temp.GetComponentInChildren<Text>().text = name;
        deviceMap[name] = objects.Count;
        objects.Add(temp);
        newHeader.transform.SetAsLastSibling();
        currentRooms.Add(name);
    }

    public void AddButton(string room, string name)
    {
        var temp = Instantiate(buttonPrefab, content.transform);
        temp.GetComponentInChildren<Text>().text = name;
        deviceMap[name] = ++roomLastIndex[room];
        temp.transform.SetSiblingIndex(deviceMap[name]);
        objects.Insert(deviceMap[name], temp);
        newHeader.transform.SetAsLastSibling();
    }

    public void AddRoom(InputField field)
    {
        if (!currentRooms.Contains(field.text))
        {
            alertBox.ShowSuccess("Pomyœlnie dodano pokój!");
            AddHeader(field.text);
            add.UpdateRooms(field.text);
            controller.windowManager.UpdateWindow("Urz¹dzenia");

        }
        else
        {
            alertBox.ShowFailure("Taki pokój ju¿ istnieje!");
        }
    }

}

[System.Serializable]
public class DeviceInWindow
{
    public string name;
    public string room;
    public GameObject Device;
}

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Text tittle;

    public Window currentWindow;

    [HideInInspector] public SliderMenuAnim sliderAnim;

    // Start is called before the first frame update
    void Start()
    {
        sliderAnim = GetComponent<SliderMenuAnim>();
    }

    

}

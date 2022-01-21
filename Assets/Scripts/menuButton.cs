using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuButton : MonoBehaviour
{

    public SliderMenuAnim sliderMenu;

    // Start is called before the first frame update
    void Start()
    {
        sliderMenu.menuButton.onClick.AddListener(sliderMenu.ShowHideMenu);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderMenuAnim : MonoBehaviour
{
    public GameObject PanelMenu;
    public GameObject DimingScreen;
    public Button menuButton;

    public string sliderBool = "show";
    public string dimBool = "dim";

    public string closedChar = "☰";
    public string openChar = "X";

    public void ShowHideMenu(){
    
        if (PanelMenu != null && DimingScreen != null){
            Animator animator = PanelMenu.GetComponent<Animator>();
            Animator dimingAnimator = DimingScreen.GetComponent<Animator>();
            
            if (animator != null){
                bool isOpen = animator.GetBool(sliderBool);
                animator.SetBool(sliderBool,!isOpen);
                if (dimingAnimator != null) dimingAnimator.SetBool(dimBool, !isOpen);

                if (menuButton != null){
                    Text buttonText = menuButton.GetComponentInChildren<Text>();
                    if (!isOpen)
                        buttonText.text = openChar;
                    else
                        buttonText.text = closedChar;
         }
            }
        }
    
    }

    public bool IsSliderOpen()
    {
        if (PanelMenu != null)
        {
            Animator animator = PanelMenu.GetComponent<Animator>();
            if (animator != null)
            {
                return animator.GetBool(sliderBool);
            }
        }
        return false;
    }

   
}

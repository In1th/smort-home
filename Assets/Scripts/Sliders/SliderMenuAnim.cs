using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderMenuAnim : MonoBehaviour
{
    public GameObject PanelMenu;
    public GameObject DimingScreen;
    public Button menuButton;

    public void ShowHideMenu(){
    
        if (PanelMenu != null && DimingScreen != null){
            Animator animator = PanelMenu.GetComponent<Animator>();
            Animator dimingAnimator = DimingScreen.GetComponent<Animator>();
            
            if (animator != null){
                bool isOpen = animator.GetBool("show");
                animator.SetBool("show",!isOpen);
                if (dimingAnimator != null) dimingAnimator.SetBool("dim",!isOpen);

                if (menuButton != null){
                    Text buttonText = menuButton.GetComponentInChildren<Text>();
                    if (!isOpen)
                        buttonText.text = "X";
                    else 
                        buttonText.text = "☰";
         }
            }
        }
    
    }

    
}

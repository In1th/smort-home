using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderMenuAnim : MonoBehaviour
{
    public GameObject PanelMenu;
    public Button menuButton;


    public void ShowHideMenu(){
    
        if (PanelMenu != null){
            Animator animator = PanelMenu.GetComponent<Animator>();
            if (animator != null){
                bool isOpen = animator.GetBool("show");
                animator.SetBool("show",!isOpen);

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

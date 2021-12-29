using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderMenuAnim : MonoBehaviour
{
    public GameObject PanelMenu;
    public GameObject DimingScreen;
    public GameObject AddButtons;
    public Button menuButton;


    public void ShowHideMenu(){
    
        if (PanelMenu != null){
            Animator animator = PanelMenu.GetComponent<Animator>(),
                dimingAnim = DimingScreen.GetComponent<Animator>(),
                buttonsAnim = AddButtons.GetComponent<Animator>();
            bool isOpen;
            if (animator != null){
                isOpen = animator.GetBool("show");
                animator.SetBool("show",!isOpen);
                if (dimingAnim != null) dimingAnim.SetBool("show", !isOpen);
                if (buttonsAnim != null) 
                    if (buttonsAnim.GetBool("show") == true)
                        buttonsAnim.SetBool("show", false);

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

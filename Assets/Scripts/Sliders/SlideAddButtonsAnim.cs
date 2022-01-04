using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlideAddButtonsAnim : MonoBehaviour
{

    public GameObject slider;
    public Button plusButton;


   public void ShowHideAddButtons(){
        if (slider != null)
        {
            Animator animator = slider.GetComponent<Animator>();
            if (animator != null)
            {
                bool isShown = animator.GetBool("show");
                animator.SetBool("show", !isShown);

                if (plusButton != null)
                {
                    Text buttonText = plusButton.GetComponentInChildren<Text>();
                    if (!isShown)
                    {
                        buttonText.text = "✓";
                    }
                    else
                        buttonText.text = "+";
                }
            }
        }
   }
}

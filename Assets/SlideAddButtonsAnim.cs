using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlideAddButtonsAnim : MonoBehaviour
{
   private Animator animator;
   public Button plusButton;

   void Start()
   {
      animator = GetComponent<Animator>();
   }

   public void ShowHideAddButtons(){
      if (animator != null){
         bool isShown = animator.GetBool("show");
         animator.SetBool("show",!isShown);

         if (plusButton != null){
            Text buttonText = plusButton.GetComponentInChildren<Text>();
            if (!isShown){
               buttonText.text = "✓";
            }
            else 
               buttonText.text = "+";
         }
      }
   }
}

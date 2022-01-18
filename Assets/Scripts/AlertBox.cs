using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlertBox : MonoBehaviour
{

    public GameObject outline;
    public Text notificationText;
    public Animator animator;

    public void ShowSuccess(string message)
    {
        ShowAlertBox(message, Color.green);
    }

    public void ShowFailure(string message)
    {
        ShowAlertBox(message, Color.red);
    }

    private void ShowAlertBox(string message, Color color)
    {
        Image outlineImage = null;
        if (outline != null) 
        {
            outlineImage = outline.GetComponent<Image>(); 
        }
        if (outlineImage != null) 
        {
            outlineImage.color = color;
        }

        if (notificationText != null)
            notificationText.text = message;

        if (animator != null)
            animator.SetBool("show", true);
    }
}

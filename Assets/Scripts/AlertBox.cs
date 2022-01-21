using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class AlertBox : MonoBehaviour
{

    public GameObject outline;
    public Text notificationText;
    public Animator animator;

    private bool isAlert = false;

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

        StartCoroutine(Coroutine());
        
    }
    
    public void ErrorMissingArguments(Button button)
    {
        if (!button.interactable) 
        {
            ArgumentList argList = button.GetComponent<ArgumentList>();
            GameController controller = GetComponent<GameController>();
            List<string> args = controller.GetMissingValues(argList.argumentList);
            IEnumerable<string> values = args;
            List<string> names = values.Select(arg => argList.argCodeToName[arg]).ToList();
            string message = "Proszê podaæ: ";
            message += string.Join(", ", names);
            ShowFailure(message);
        }
    }

    public void SkipButtonClicked()
    {
        animator.SetBool("show", false);
        int hash = Animator.StringToHash("HideAlertBox");
        animator.Play(hash, 0, 0);
    }

    IEnumerator Coroutine()
    {
        yield return new WaitForSeconds(2);
        animator.SetBool("show", false);
        Debug.Log("Time skipped");
    }
}

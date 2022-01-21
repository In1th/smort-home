using UnityEngine;
using UnityEngine.UI;

public class SlideAddButtonsAnim : MonoBehaviour
{

    public GameObject slider;
    public Button plusButton;

    public string menuBool = "show";

    public string closedChar = "+";
    public string openChar = "X";

    private void Start()
    {
        if (plusButton != null)
        {
            plusButton.GetComponentInChildren<Text>().text = closedChar;
        }
    }

    public void ShowHideAddButtons()
    {
        if (slider != null)
        {
            Animator animator = slider.GetComponent<Animator>();
            if (animator != null)
            {
                bool isShown = animator.GetBool(menuBool);
                animator.SetBool(menuBool, !isShown);

                if (plusButton != null)
                {
                    Text buttonText = plusButton.GetComponentInChildren<Text>();
                    buttonText.text = GetButtonText(isShown);
                }
            }
        }
    }

    public void ShowHideMainButton(bool hide)
    {
        if (slider != null)
        {
            Animator animator = slider.GetComponent<Animator>();
            if (animator != null)
            {
                animator.SetBool("hide", hide);

            }
        }
    }

    string GetButtonText(bool isShown)
    {
        return (isShown) ? closedChar: openChar;
    }

    public bool IsShown()
    {
        if (slider != null) 
        {
            Animator animator = slider.GetComponent<Animator>();
            if (animator != null) return animator.GetBool(menuBool);
        }
        return false;
    }
}

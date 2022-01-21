using UnityEngine;


public abstract class Window :ScriptableObject
{
    
    public string windowName;
    public bool hidePlusButton;
    public bool hasToReturn;
    protected GameObject windowReference;


    public abstract void WindowButtonClick(GameController controller);
    
    public void giveWindowReference(GameObject winRef)
    {
        windowReference = winRef;
    }
    
    public void ShowHideWindow()
    {
        if (windowReference != null)
        {
            Animator windowAnimator = windowReference.GetComponent<Animator>();
            if (windowAnimator != null)
            {
                bool isClosed = windowAnimator.GetBool("closed");
                windowAnimator.SetBool("closed", !isClosed);
            }
        }
    }

}

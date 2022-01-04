using UnityEngine;

public abstract class Window :ScriptableObject
{
    public string windowName;
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
                Debug.Log(isClosed);
                windowAnimator.SetBool("closed", !isClosed);
            }
        }
    }

}

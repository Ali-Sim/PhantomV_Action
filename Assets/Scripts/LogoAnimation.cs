using UnityEngine;

public class LogoAnimation : MonoBehaviour
{

    // A public boolean variable that you want to set to true
    public bool animationHasFinished = false;

    // A public method to be called by the Animation Event
    public void SetAnimationFinishedTrue()
    {
        animationHasFinished = true;
        Debug.Log("Animation finished event triggered. Boolean set to true.");
    }
}

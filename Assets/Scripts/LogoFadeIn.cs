using UnityEngine;

public class LogoFadeIn : LogoAnimation
{
    public Animator animator;
    private void Update()
    {
        if (animationHasFinished) { animator.SetBool("Ended", true); }
    }
}

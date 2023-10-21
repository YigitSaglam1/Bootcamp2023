using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationDetection : MonoBehaviour
{
    public bool isAnimation = true;

    public void AnimationStart()
    {
        isAnimation = true;
    }
    public void AnimationEnd()
    {
        isAnimation = false;
    }
    public bool IsAnimationEnd()
    {
        if (isAnimation)
        {
            return false;
        }
        else
        {
            return true;
        }
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public void AnimationEndTrigger()
    {
        this.GetComponent<Animator>().SetTrigger("trigger");
    }
}
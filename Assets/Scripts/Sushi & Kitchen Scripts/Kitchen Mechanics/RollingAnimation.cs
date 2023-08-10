using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollingAnimation : MonoBehaviour
{
    [SerializeField] private Animator animator;
    private void Awake()
    {
        animator.speed = 0;
    }

    public void ChangeAnimationState(float t)
    {
        animator.playbackTime = t;
    }
}
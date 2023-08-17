using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollingAnimation: MonoBehaviour
{
    [SerializeField] private SeaweedWrap _seaweedWrap;
    [SerializeField] private Animator _seaweedWrapAnimator;
    [SerializeField] private Animator _maskObjectAnimator;

    private bool _isRolling;

    public bool IsRolling { get => _isRolling; }

    public void StartRolling()
    {
        SetRoll(1);
    }
    public void StopRolling()
    {
        SetRoll(0);
        _seaweedWrap.InstantiateSushi();
    }
    private void SetRoll(int i)
    {
        _seaweedWrapAnimator.SetBool("isRolling", i != 0);
        _maskObjectAnimator.SetBool("isMasking", i != 0);
        _isRolling = i != 0;
    }
}
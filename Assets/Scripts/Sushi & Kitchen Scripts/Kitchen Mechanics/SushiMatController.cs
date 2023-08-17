using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SushiMatController : MonoBehaviour
{
    [SerializeField] private Animator _sushiMatAnimator;

    private bool _isRolling;

    public bool IsRolling { get => _isRolling; }

    public void StartRolling()
    {
        SetRoll(1);
    }
    public void StopRolling()
    {
        SetRoll(0);
    }
    private void SetRoll(int i)
    {
        _sushiMatAnimator.SetBool("isRolling", i != 0);
        _isRolling = i != 0;
    }
}

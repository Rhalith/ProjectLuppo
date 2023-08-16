using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingAnimation : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private SushiSlicer _sushiSlicer;

    public bool IsCutting;
    public void StartCutting()
    {
        SetCut(1);
    }

    public void StopCutting() 
    {  
        SetCut(0);
        _sushiSlicer.ResetHullList();
    }


    private void SetCut(int i)
    {
        _animator.SetBool("startCut", i != 0);
        IsCutting = i != 0;
    }
}

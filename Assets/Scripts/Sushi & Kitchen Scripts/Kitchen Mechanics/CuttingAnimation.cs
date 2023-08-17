using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingAnimation : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private SushiSlicer _sushiSlicer;
    [SerializeField] private GameObject _knifeIndicator;

    public bool IsCutting;
    public void StartCutting()
    {
        SetCut(1);
        _knifeIndicator.SetActive(false);
    }

    public void StopCutting() 
    {  
        SetCut(0);
        _sushiSlicer.ResetHullList();
        _knifeIndicator.SetActive(true);
    }


    private void SetCut(int i)
    {
        _animator.SetBool("startCut", i != 0);
        IsCutting = i != 0;
    }
}

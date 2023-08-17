using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeAnimation : MonoBehaviour
{
    [SerializeField] private Animator _knifeAnimator;
    [SerializeField] private GameObject _knifeHolder;
    [SerializeField] private MeshRenderer _meshRenderer;

    public void StartMovement()
    {
        SetMovement(1);
    }
    public void ResetPosition()
    {
        _knifeHolder.SetActive(false);
        _meshRenderer.enabled = true;
        SetMovement(0);
    }

    public void ChangeKnife()
    {
        _knifeHolder.SetActive(true);
        _meshRenderer.enabled = false;
    }
    private void SetMovement(int i)
    {
        _knifeAnimator.SetBool("isCuttingStarted", i != 0);
    }
}

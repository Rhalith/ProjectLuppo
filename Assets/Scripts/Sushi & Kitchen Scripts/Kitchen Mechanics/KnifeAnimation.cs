using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeAnimation : MonoBehaviour
{
    [SerializeField] private Animator _knifeAnimator;
    [SerializeField] private GameObject _knifeHolder;
    [SerializeField] private GameObject _stopCuttingButton;
    [SerializeField] private MeshRenderer _meshRenderer;

    public void StartMovement()
    {
        SetMovement(1);
    }
    public void ResetPosition()
    {
        SFXContainer.Instance.PlayMenuClickSFX();

        _knifeHolder.SetActive(false);
        _meshRenderer.enabled = true;
        IngredientController.Instance.IsCuttingActive = false;
        SetMovement(0);
        _stopCuttingButton.SetActive(false);
    }

    public void ChangeKnife()
    {
        _knifeHolder.SetActive(true);
        _meshRenderer.enabled = false;
        _stopCuttingButton.SetActive(true);
        IngredientController.Instance.IsCuttingActive = true;
    }
    private void SetMovement(int i)
    {
        _knifeAnimator.SetBool("isCuttingStarted", i != 0);
    }
}

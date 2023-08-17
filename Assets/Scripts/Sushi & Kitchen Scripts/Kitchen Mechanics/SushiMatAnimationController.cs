using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SushiMatAnimationController : MonoBehaviour
{
    [SerializeField] private Animator _sushiMatAnimator;

    public void FinishRolling()
    {
        _sushiMatAnimator.speed = 1;
        IngredientController.Instance.StopRolling();
    }
}

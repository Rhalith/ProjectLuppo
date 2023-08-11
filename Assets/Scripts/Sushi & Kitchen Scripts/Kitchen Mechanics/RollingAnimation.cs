using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollingAnimation : MonoBehaviour
{
    [SerializeField] private SkinnedMeshRenderer _skinnedRenderer;

    public void RollSeaweed(float rollAmount)
    {
        if(rollAmount > 0 && rollAmount <= 100)
        {
            _skinnedRenderer.SetBlendShapeWeight(0, 100-rollAmount);
        }
        else if (rollAmount > 100 && rollAmount <= 200)
        {
            _skinnedRenderer.SetBlendShapeWeight(1, rollAmount-100);
        }
        else if (rollAmount > 200 && rollAmount <= 300)
        {
            if(_skinnedRenderer.GetBlendShapeWeight(1) > 0) _skinnedRenderer.SetBlendShapeWeight(1, 300 - rollAmount);
            _skinnedRenderer.SetBlendShapeWeight(2, rollAmount-200);
        }
    }
}
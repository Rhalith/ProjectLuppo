using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollingAnimation : MonoBehaviour
{
    [SerializeField] private SkinnedMeshRenderer _skinnedRenderer;

    private void Start()
    {
        StartCoroutine(nameof(RollSeaweed));
    }

    private IEnumerator RollSeaweed()
    {
        float _startValue = 1;
        while (_startValue <= 100)
        {
            _skinnedRenderer.SetBlendShapeWeight(0, 100-_startValue);
            _startValue +=1f;
            yield return new WaitForSeconds(0.01f);
        }
        _startValue = 1;
        while(_startValue <= 100)
        {
            _skinnedRenderer.SetBlendShapeWeight(1, _startValue);
            _startValue +=1f;
            yield return new WaitForSeconds(0.01f);
        }
        _startValue = 1;
        while(_startValue <= 100)
        {
            _skinnedRenderer.SetBlendShapeWeight(1, 100 - _startValue);
            _skinnedRenderer.SetBlendShapeWeight(2, _startValue);
            _startValue +=1f;
            yield return new WaitForSeconds(0.01f);
        }
        //_startValue = 1;
        //while (_startValue <= 100)
        //{
        //    _skinnedRenderer.SetBlendShapeWeight(2, _startValue);
        //    _startValue += 1f;
        //    yield return new WaitForSeconds(0.01f);
        //}

    }
}
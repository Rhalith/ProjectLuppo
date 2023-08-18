using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EzySlice;
using Unity.VisualScripting;

public class SushiSlicer : MonoBehaviour
{
    private List<GameObject> _hullList = new();
    public GameObject[] SlicedObject;
    [SerializeField] private CuttingAnimation _cuttingAnimation;
    [SerializeField] private BoxCollider _boxCollider;
    [SerializeField] private Transform _parentTransform;
    [SerializeField] private GameObject _parentOfHulls;
    [SerializeField] private GameObject _maskObject;
    [SerializeField] private GameObject _parentOfMaskObjects;
    [SerializeField] private Transform _indicatorTransform;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(_hullList.Count == 0)
            {
                _cuttingAnimation.StartCutting();
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("MaskObject"))
        {
            _boxCollider.isTrigger = false;
        }
        else if (other.gameObject.CompareTag("Sushi") && !_hullList.Contains(other.gameObject))
        {
            GameObject[] slicedHull = CutSushi(other.gameObject, transform.right);
            SlicedObject = slicedHull;
            GameObject upperHull = slicedHull[0];
            GameObject lowerHull = slicedHull[1];
            Destroy(other.gameObject);
            PrepapeHull(upperHull);
            PrepapeHull(lowerHull);
            GameObject maskOjbect = Instantiate(_maskObject, _parentOfMaskObjects.transform);
            maskOjbect.transform.position = new Vector3(_indicatorTransform.position.x, _indicatorTransform.position.y-0.05f, _indicatorTransform.position.z);
            maskOjbect.transform.rotation = Quaternion.Euler(0,90,0);
        }
    }
    private GameObject[] CutSushi(GameObject obj, Vector3 transformVector, Material mat = null)
    {
        return obj.SliceInstantiate(transform.position, transformVector, mat);
    }
    private void PrepapeHull(GameObject hull)
    {
        _hullList.Add(hull);
        hull.transform.parent = _parentOfHulls.transform;
        MeshCollider collider = hull.AddComponent<MeshCollider>();
        collider.convex = false;
        hull.tag = "Sushi";
        hull.layer = LayerMask.NameToLayer("TransparentFX");
    }

    //Call it in the end of knife animation
    public void ResetHullList()
    {
        _hullList.Clear();
        _boxCollider.isTrigger = true;
    }
}

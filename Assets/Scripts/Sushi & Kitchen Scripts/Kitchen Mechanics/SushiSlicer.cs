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
    [SerializeField] private MeshCollider _meshCollider;
    [SerializeField] private Transform _parentTransform;
    [SerializeField] private GameObject _parentOfHulls;
    [SerializeField] private GameObject _maskObject;
    [SerializeField] private GameObject _parentOfMaskObjects;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(_hullList.Count == 0)
            {
                _cuttingAnimation.StartCutting();
            }
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            _parentTransform.position = new Vector3(_parentTransform.position.x, _parentTransform.position.y, _parentTransform.position.z - 0.1f);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            _parentTransform.position = new Vector3(_parentTransform.position.x, _parentTransform.position.y, _parentTransform.position.z + 0.1f);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("MaskObject"))
        {
            _meshCollider.isTrigger = false;
        }
        else if (other.gameObject.CompareTag("Sushi") && !_hullList.Contains(other.gameObject))
        {
            GameObject[] slicedHull = CutSushi(other.gameObject);
            SlicedObject = slicedHull;
            GameObject upperHull = slicedHull[0];
            GameObject lowerHull = slicedHull[1];
            Destroy(other.gameObject);
            PrepapeHull(upperHull);
            PrepapeHull(lowerHull);
            GameObject maskOjbect = Instantiate(_maskObject, _parentOfMaskObjects.transform);
            maskOjbect.transform.position = new Vector3(maskOjbect.transform.position.x, maskOjbect.transform.position.y+0.015f, _parentTransform.position.z);
        }
    }

    private GameObject[] CutSushi(GameObject obj, Material mat = null)
    {
        return obj.SliceInstantiate(transform.position, transform.up, mat);
    }

    private void PrepapeHull(GameObject hull)
    {
        _hullList.Add(hull);
        hull.transform.parent = _parentOfHulls.transform;
        MeshCollider collider = hull.AddComponent<MeshCollider>();
        Rigidbody rb = hull.AddComponent<Rigidbody>();
        collider.convex = false;
        rb.isKinematic = true;
        hull.tag = "Sushi";
    }

    //Call it in the end of knife animation
    public void ResetHullList()
    {
        _hullList.Clear();
        _meshCollider.isTrigger = true;
    }
}

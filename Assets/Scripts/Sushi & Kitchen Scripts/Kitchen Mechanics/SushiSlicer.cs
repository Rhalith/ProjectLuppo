using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EzySlice;
using Unity.VisualScripting;

public class SushiSlicer : MonoBehaviour
{
    private List<GameObject> _hullList = new();
    [SerializeField] private CuttingAnimation _cuttingAnimation;
    [SerializeField] private Transform _parentTransform;
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
        if (other.gameObject.CompareTag("Sushi") && !_hullList.Contains(other.gameObject))
        {
            SlicedHull slicedHull = CutSushi(other.gameObject);
            GameObject upperHull = slicedHull.CreateUpperHull(other.gameObject);
            //This may need to change depending on main scene sushi position
            //upperHull.transform.position = new(upperHull.transform.position.x, upperHull.transform.position.y, upperHull.transform.position.z - 0.02f);
            GameObject lowerHull = slicedHull.CreateLowerHull(other.gameObject);
            other.gameObject.SetActive(false);
            PrepapeHull(upperHull);
            PrepapeHull(lowerHull);
        }
    }

    private SlicedHull CutSushi(GameObject obj, Material mat = null)
    {
        return obj.Slice(transform.position, transform.up, mat);
    }

    private void PrepapeHull(GameObject hull)
    {
        _hullList.Add(hull);
        MeshCollider collider = hull.AddComponent<MeshCollider>();
        Rigidbody rb = hull.AddComponent<Rigidbody>();
        collider.convex = true;
        collider.isTrigger = false;
        rb.isKinematic = false;
        rb.useGravity = true;
        hull.tag = "Sushi";
        rb.AddExplosionForce(15f, transform.position, 3f);
    }

    //Call it in the end of knife animation
    public void ResetHullList()
    {
        _hullList.Clear();
    }
}

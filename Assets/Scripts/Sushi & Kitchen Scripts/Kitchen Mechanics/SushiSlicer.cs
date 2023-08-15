using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EzySlice;
using Unity.VisualScripting;

public class SushiSlicer : MonoBehaviour
{
    private List<GameObject> _hullList = new ();
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Sushi") && !_hullList.Contains(other.gameObject))
        {
            SlicedHull slicedHull = CutSushi(other.gameObject, other.GetComponent<MeshRenderer>().material);
            GameObject upperHull = slicedHull.CreateUpperHull(other.gameObject, other.GetComponent<MeshRenderer>().material);
            //This may need to change depending on main scene sushi position
            upperHull.transform.position = new(upperHull.transform.position.x, upperHull.transform.position.y, upperHull.transform.position.z - 0.02f);
            GameObject lowerHull = slicedHull.CreateLowerHull(other.gameObject, other.GetComponent<MeshRenderer>().material);
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
        collider.convex = true;
        collider.isTrigger = true;
        hull.tag = "Sushi";
    }

    //Call it in the end of knife animation
    public void ResetHullList()
    {
        _hullList.Clear();
    }
}

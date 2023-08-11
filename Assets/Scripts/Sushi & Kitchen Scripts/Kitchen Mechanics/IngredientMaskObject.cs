using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientMaskObject : MonoBehaviour
{
    [SerializeField] private List<MeshRenderer> _objects = new ();
    void Start()
    {
        foreach (MeshRenderer item in _objects)
        {
            //Because mask shader material render queue is 3001
            item.material.renderQueue = 3002;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

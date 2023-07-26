using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NigiriPlate : MonoBehaviour
{
    [SerializeField] GameObject nigiriPlate;
    Vector3 position;
    int count = 0;

    private void Start()
    {
        position = nigiriPlate.transform.position;
        GameEventsManager.instance.OnServingAdded += OnServingAdded;
    }


    public void OnMouseDown()
    {
            Instantiate(nigiriPlate, position, nigiriPlate.transform.rotation);
            GameEventsManager.instance.ServingAdded();
    }

    public void OnServingAdded()
    {
       count++;
       position.x =+ 1.5f * count;
    }
}


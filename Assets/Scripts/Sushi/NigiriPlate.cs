using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NigiriPlate : MonoBehaviour
{
    [SerializeField] GameObject nigiriPlate;
    Vector3 position;

    private void Start()
    {
        position = nigiriPlate.transform.position;
        GameEventsManager.instance.OnServingAdded += OnServingAdded;
        GameEventsManager.instance.OnServingServed += OnServingServed;

    }


    public void OnMouseDown()
    {
            Instantiate(nigiriPlate, position, nigiriPlate.transform.rotation);
            GameEventsManager.instance.ServingAdded();
    }

    public void OnServingAdded()
    {
       position.x -= 1.5f;
    }

    public void OnServingServed()
    {
        position.x += 1.5f;
    }
}


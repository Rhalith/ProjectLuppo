using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SashimiPlate : MonoBehaviour
{
    [SerializeField] GameObject sashimiPlate;
    Vector3 position;

    private void Start()
    {
        position = sashimiPlate.transform.position;
        GameEventsManager.instance.OnServingAdded += OnServingAdded;
        GameEventsManager.instance.OnServingServed += OnServingServed;
    }


    public void OnMouseDown()
    {
        Instantiate(sashimiPlate, position, sashimiPlate.transform.rotation);
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

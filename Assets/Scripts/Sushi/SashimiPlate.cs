using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SashimiPlate : MonoBehaviour
{
    [SerializeField] GameObject sashimiPlate;
    Vector3 position;
    int count = 0;

    private void Start()
    {
        position = sashimiPlate.transform.position;
        GameEventsManager.instance.onServingAdded += OnServingAdded;
    }


    public void OnMouseDown()
    {
        Instantiate(sashimiPlate, position, sashimiPlate.transform.rotation);
        GameEventsManager.instance.ServingAdded();
    }

    public void OnServingAdded()
    {
        count++;
        position.x = +1.5f * count;
    }
}

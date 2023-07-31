using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SashimiPlate : MonoBehaviour
{
    GameObject Container1;
    GameObject Container2;
    GameObject Container3;
    Vector3 position;

    //Must Check, this will be unusable
    private void Start()
    {
        Container1 = GameObject.Find("Container_1");
        Container2 = GameObject.Find("Container_2");
        Container3 = GameObject.Find("Container_3");
        GameEventsManager.instance.OnServingAdded += OnServingAdded;
        GameEventsManager.instance.OnServingServed += OnServingServed;
    }


    public void OnMouseDown()
    {
 
        Debug.Log("Pressed");
        //if(Container1.transform.childCount = 0)
        //gameObject.transform.parent = sashimiPlate.transform;
        gameObject.transform.localPosition = new Vector3(0, 3f,0);
        
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

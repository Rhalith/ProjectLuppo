using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class FollowMouse : MonoBehaviour
{
    RaycastHit hit;
    Vector3 movePoint;
    public GameObject prefab;
    GameObject hitObject;
    GameObject instObj;

    private void Start()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 50000.0f))
        {
            transform.position = hit.point;
            
        }
    }
    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 50000.0f))
        {
            transform.position = hit.point;
            hitObject = hit.transform.gameObject;
            
        }

        if(Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit, 50000.0f))
            {
                if (hit.collider.CompareTag("ServingSet"))
                {
                    
                    instObj = Instantiate(prefab, transform.position, Quaternion.identity);
                    prefab.tag = "Ingredient";
                    instObj.transform.parent = hitObject.transform;
                }

                if(hit.collider.CompareTag("Ingredient"))
                {

                    instObj = Instantiate(prefab, transform.position, Quaternion.identity);
                    prefab.tag = "Ingredient";
                    instObj.transform.parent = hitObject.transform;
                }
            }
        }

    }
}


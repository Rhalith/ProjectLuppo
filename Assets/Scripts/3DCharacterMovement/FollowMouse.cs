using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class FollowMouse : MonoBehaviour
{
    RaycastHit hit;
    Vector3 movePoint;
    public GameObject prefab;

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
        }

        if(Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit, 50000.0f))
            {
                if (hit.collider.CompareTag("Ingredient"))
                {
                    Instantiate(prefab, transform.position, Quaternion.identity);
                    prefab.tag = "Ingredient";
                }
            }
        }

    }
}


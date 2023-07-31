using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    private GameObject selectedObject;
    [SerializeField] GameObject thisObject;

    private void Update()
    {
        if (!GameObject.FindWithTag("Instantiated"))
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (selectedObject == null)
                {
                    RaycastHit hit = CastRay();

                    if (hit.collider != null)
                    {
                        if (!hit.collider.CompareTag("ServingSet"))
                        {
                            return;
                        }

                        selectedObject = hit.collider.gameObject;
                    }
                }
                else
                {
                    Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.WorldToScreenPoint(selectedObject.transform.position).z);
                    Vector3 worldPosition = Camera.main.ScreenToWorldPoint(position);
                    selectedObject.transform.position = new Vector3(worldPosition.x, 3.2f, worldPosition.z);
                    if (selectedObject.transform.position.x > 520) 
                    {
                        selectedObject.transform.position = new Vector3(520f, 3.2f, worldPosition.z);
                    }

                    if (selectedObject.transform.position.x < 508)
                    {
                        selectedObject.transform.position = new Vector3(508, 3.2f, worldPosition.z);
                    }

                    if (selectedObject.transform.position.z > 166)
                    {
                        selectedObject.transform.position = new Vector3(worldPosition.x, 3.2f, 166f);
                    }

                    if (selectedObject.transform.position.z < 163.5)
                    {
                        selectedObject.transform.position = new Vector3(worldPosition.x, 3.2f, 163.5f);
                    }

                    selectedObject = null;
                }
            }
        

        if(selectedObject != null)
        {
            Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.WorldToScreenPoint(selectedObject.transform.position).z);
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(position);
            selectedObject.transform.position = new Vector3(worldPosition.x, 4f, worldPosition.z);
        }
        }

    }

    private RaycastHit CastRay()
    {
        Vector3 screenMousePosFar = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.farClipPlane);
        Vector3 screenMousePosNear = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane);
        Vector3 worldMousePosFar = Camera.main.ScreenToWorldPoint(screenMousePosFar);
        Vector3 worldMousePosNear = Camera.main.ScreenToWorldPoint(screenMousePosNear);
        RaycastHit hit;
        Physics.Raycast(worldMousePosNear, worldMousePosFar - worldMousePosNear, out hit);

        return hit;
    }
}

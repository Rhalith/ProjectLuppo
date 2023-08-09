using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    private GameObject _selectedObject;
    Vector3 _zoneOffset = new Vector3(0, 0.1f, 0);
    [SerializeField] GameObject[] _prepareZones;


    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_selectedObject == null)
            {
                RaycastHit hit = CastRay();
                if (hit.collider != null)
                {
                    if (!hit.collider.CompareTag("ServingSet") && !hit.collider.CompareTag("Sushi"))
                    {
                        return;
                    }
                    _selectedObject = hit.collider.gameObject;
                }
            }
            else
            {
                Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.WorldToScreenPoint(_selectedObject.transform.position).z);
                Vector3 worldPosition = Camera.main.ScreenToWorldPoint(position);
                _selectedObject.transform.position = new Vector3(worldPosition.x, 3.3f, worldPosition.z);
                if (_selectedObject.transform.position.x < -9)
                {
                    _selectedObject.transform.position = new Vector3(-9f, 3.3f, worldPosition.z);

                    if (_selectedObject.transform.position.z > 0.2)
                    {
                        _selectedObject.transform.position = new Vector3(-9f, 3.3f, 0.2f);
                    }

                    if (_selectedObject.transform.position.z < -2)
                    {
                        _selectedObject.transform.position = new Vector3(-9f, 3.3f, -2f);
                    }
                }



                else if (_selectedObject.transform.position.x > 2.1)
                {
                    _selectedObject.transform.position = new Vector3(2.1f, 3.3f, worldPosition.z);

                    if (_selectedObject.transform.position.z < -2)
                    {
                        _selectedObject.transform.position = new Vector3(2.1f, 3.3f, -2f);
                    }

                    if (_selectedObject.transform.position.z > 0.2)
                    {
                        _selectedObject.transform.position = new Vector3(2.1f, 3.3f, 0.2f);
                    }
                }
                else
                {
                    if (_selectedObject.transform.position.z > 0.2)
                    {
                        _selectedObject.transform.position = new Vector3(worldPosition.x, 3.3f, 0.2f);
                    }

                    if (_selectedObject.transform.position.z < -2)
                    {
                        _selectedObject.transform.position = new Vector3(worldPosition.x, 3.3f, -25f);
                    }
                }

                _selectedObject = null;
            }

        }
        if (_selectedObject != null)
        {
            Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.WorldToScreenPoint(_selectedObject.transform.position).z);
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(position);
            _selectedObject.transform.position = new Vector3(worldPosition.x, 4f, worldPosition.z);
        }

    }

    private void PlaceObjectInZone(GameObject objectToPlace)
    {
        foreach (GameObject prepareZone in _prepareZones)
        {
            if(Vector3.Distance(objectToPlace.transform.position, prepareZone.transform.position) < 1.0f)
            {
                objectToPlace.transform.position = prepareZone.transform.position;
                return;
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

    private void OnMouseUp()
    {
        if(_selectedObject !=null)
        {
            PlaceObjectInZone(_selectedObject);
            _selectedObject = null;
        }
    }
}

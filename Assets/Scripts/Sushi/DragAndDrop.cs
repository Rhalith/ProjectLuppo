using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    private GameObject _selectedObject;
    Vector3 _zoneOffset = new Vector3(0, 0.1f, 0);
    [SerializeField] GameObject[] _prepareZones;

    //TODO: Make it must dropped specific points, otherwise turns to original position. also if that point is full, can't put this in there.


    private void Update()
    {
        if (!GameObject.FindWithTag("Instantiated"))
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (_selectedObject == null)
                {
                    RaycastHit hit = CastRay();

                    if (hit.collider != null)
                    {
                        if (!hit.collider.CompareTag("ServingSet"))
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
                    if (_selectedObject.transform.position.x > 520)
                    {
                        _selectedObject.transform.position = new Vector3(520f, 3.3f, worldPosition.z);
                    }

                    if (_selectedObject.transform.position.x < 508)
                    {
                        _selectedObject.transform.position = new Vector3(508, 3.3f, worldPosition.z);
                    }

                    if (_selectedObject.transform.position.z > 166)
                    {
                        _selectedObject.transform.position = new Vector3(worldPosition.x, 3.3f, 166f);
                    }

                    if (_selectedObject.transform.position.z < 163.5)
                    {
                        _selectedObject.transform.position = new Vector3(worldPosition.x, 3.3f, 163.5f);
                    }

                    _selectedObject = null;
                }
            }
        

        if(_selectedObject != null)
        {
            Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.WorldToScreenPoint(_selectedObject.transform.position).z);
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(position);
            _selectedObject.transform.position = new Vector3(worldPosition.x, 4f, worldPosition.z);
        }
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
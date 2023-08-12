using System;
using UnityEngine;

public class DragAndDropManager : MonoBehaviour
{
    [SerializeField] GameObject[] _prepareZones;
    private GameObject _selectedObject;
    [Header("Drag and Drop Borders")]
    [SerializeField] float minX = -9.13f; [SerializeField] float minZ = -1.8f; [SerializeField] float maxX = 2.14f; [SerializeField] float maxZ = 0.15f;


    private void Start()
    {
        InputManager.Instance.OnLeftMouseButtonDown += OnLeftMouseButtonDown;
        InputManager.Instance.OnLeftMouseButtonUp += OnLeftMouseButtonUp; ;
    }

    private void OnDestroy()
    {
        InputManager.Instance.OnLeftMouseButtonDown -= OnLeftMouseButtonDown;
        InputManager.Instance.OnLeftMouseButtonUp -= OnLeftMouseButtonUp; ;
    }

    private void Update()
    {
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

    // Yeni input sisteminde bunlar yok.
    private void OnMouseUp()
    {
        if(_selectedObject !=null)
        {
            PlaceObjectInZone(_selectedObject);
            _selectedObject = null;
        }
    }

    private void OnLeftMouseButtonDown()
    {
        if(!InstantiatedController.Instance.InstantiatedObject)
        {
            //Knowing issue: Because of not checking if there is any instantiated object, it is selecting cutting board when you put seawed on the cutting board.
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

                if (_selectedObject.transform.position.x < minX)
                {
                    _selectedObject.transform.position = new Vector3(minX, 3.3f, worldPosition.z);

                    if (_selectedObject.transform.position.z > maxZ)
                    {
                        _selectedObject.transform.position = new Vector3(minX, 3.3f, maxZ);
                    }

                    if (_selectedObject.transform.position.z < minZ)
                    {
                        _selectedObject.transform.position = new Vector3(minX, 3.3f, minZ);
                    }
                }
                else if (_selectedObject.transform.position.x > maxX)
                {
                    _selectedObject.transform.position = new Vector3(maxX, 3.3f, worldPosition.z);

                    if (_selectedObject.transform.position.z < minZ)
                    {
                        _selectedObject.transform.position = new Vector3(maxX, 3.3f, minZ);
                    }

                    if (_selectedObject.transform.position.z > maxZ)
                    {
                        _selectedObject.transform.position = new Vector3(maxX, 3.3f, maxZ);
                    }
                }
                else
                {
                    if (_selectedObject.transform.position.z > maxZ)
                    {
                        _selectedObject.transform.position = new Vector3(worldPosition.x, 3.3f, maxZ);
                    }

                    if (_selectedObject.transform.position.z < minZ)
                    {
                        _selectedObject.transform.position = new Vector3(worldPosition.x, 3.3f, minZ);
                    }
                }

                _selectedObject = null;
            }
        }
    }


    private void OnLeftMouseButtonUp()
    {

    }
}

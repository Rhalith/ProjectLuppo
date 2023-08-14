using System;
using UnityEngine;

public class DragAndDropManager : MonoBehaviour
{
    [SerializeField] GameObject[] _prepareZones;
    private GameObject _selectedObject;
    [Header("Drag and Drop Borders")]
    [SerializeField] float minX = -9.13f; 
    [SerializeField] float minZ = -1.8f; 
    [SerializeField] float maxX = 2.14f; 
    [SerializeField] float maxZ = 0.15f;


    private void Start()
    {
        InputManager.Instance.OnLeftMouseDownOver += OnLeftMouseButtonDownOver;
        InputManager.Instance.OnLeftMouseUpOver += OnLeftMouseButtonUpOver;
    }

    private void OnDestroy()
    {
        InputManager.Instance.OnLeftMouseDownOver -= OnLeftMouseButtonDownOver;
        InputManager.Instance.OnLeftMouseUpOver -= OnLeftMouseButtonUpOver;
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

    private void OnLeftMouseButtonDownOver(RaycastHit hit)
    {
        // Checks if player holding any ingredient
        if(!InstantiatedController.Instance.InstantiatedObject)
        {
            if (_selectedObject == null)
            {
                if (hit.collider != null)
                {
                    if (!hit.collider.CompareTag("CuttingBoard") && !hit.collider.CompareTag("Sushi"))
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

    // OnMouseUp, þu anlýk sýkýntý olmaz her þey tag'ler ile ayrýlacaðý için, ama ilerde ayný tagde birden fazla obje olursa sýkýntý çýkarýr.
    private void OnLeftMouseButtonUpOver(RaycastHit hit)
    {
        if(hit.collider.CompareTag(gameObject.tag))
        {
            if (_selectedObject != null)
            {
                PlaceObjectInZone(_selectedObject);
                _selectedObject = null;
            }
        }
    }
}

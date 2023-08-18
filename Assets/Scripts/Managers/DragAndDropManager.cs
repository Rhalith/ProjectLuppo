using System;
using UnityEngine;

public class DragAndDropManager : MonoBehaviour
{
    [SerializeField] GameObject[] _prepareZones;
    [SerializeField] private KnifeAnimation _knifeAnimation;
    [SerializeField] private Cinemachine.CinemachineVirtualCamera _camera;
    [SerializeField] private Vector3 _cuttingBoardSushiPlace;
    private GameObject _selectedObject;
    [Header("Drag and Drop Borders")]
    [SerializeField] float minX = -7.7f; 
    [SerializeField] float minZ = 0.4f; 
    [SerializeField] float maxX = 0.5f; 
    [SerializeField] float maxZ = 2.72f;


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
            _selectedObject.transform.position = new Vector3(worldPosition.x, 16f, worldPosition.z);
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
        if(!InstantiatedController.Instance.InstantiatedObject && !IngredientController.Instance.IsRolling && !IngredientController.Instance.IsCutting)
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
                    if (_selectedObject.CompareTag("Sushi"))
                    {
                        _selectedObject.GetComponent<MeshCollider>().enabled = false;
                    }
                }
            }
            else if (_selectedObject.CompareTag("Sushi"))
            {
                if (hit.collider != null)
                {
                    if (hit.collider.CompareTag("CuttingBoard"))
                    {
                        _selectedObject.transform.position = _cuttingBoardSushiPlace;
                        _selectedObject.transform.rotation = Quaternion.Euler(-90f, 90f, 0f);
                        _selectedObject.GetComponent<MeshCollider>().enabled = true;
                        _knifeAnimation.StartMovement();
                        _camera.Priority = 11;
                        InputManager.Instance.IsCutting = true;
                        _selectedObject = null;
                    }
                    else
                    {
                        Debug.Log(hit.collider.tag);
                    }
                }
            }
            else
            {
                Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.WorldToScreenPoint(_selectedObject.transform.position).z);
                Vector3 worldPosition = Camera.main.ScreenToWorldPoint(position);
                _selectedObject.transform.position = new Vector3(worldPosition.x, 15.5f, worldPosition.z);

                if (_selectedObject.transform.position.x < minX)
                {
                    _selectedObject.transform.position = new Vector3(minX, 15.5f, worldPosition.z);

                    if (_selectedObject.transform.position.z > maxZ)
                    {
                        _selectedObject.transform.position = new Vector3(minX, 15.5f, maxZ);
                    }

                    if (_selectedObject.transform.position.z < minZ)
                    {
                        _selectedObject.transform.position = new Vector3(minX, 15.5f, minZ);
                    }
                }
                else if (_selectedObject.transform.position.x > maxX)
                {
                    _selectedObject.transform.position = new Vector3(maxX, 15.5f, worldPosition.z);

                    if (_selectedObject.transform.position.z < minZ)
                    {
                        _selectedObject.transform.position = new Vector3(maxX, 15.5f, minZ);
                    }

                    if (_selectedObject.transform.position.z > maxZ)
                    {
                        _selectedObject.transform.position = new Vector3(maxX, 15.5f, maxZ);
                    }
                }
                else
                {
                    if (_selectedObject.transform.position.z > maxZ)
                    {
                        _selectedObject.transform.position = new Vector3(worldPosition.x, 15.5f, maxZ);
                    }

                    if (_selectedObject.transform.position.z < minZ)
                    {
                        _selectedObject.transform.position = new Vector3(worldPosition.x, 15.5f, minZ);
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeaweedWrap : MonoBehaviour
{
    private Vector3 _startPosition;
    private Vector3 _endPosition;
    private bool _isBeingDragged = false;
    public GameObject hosomakiPrefab;
    public GameObject chumaki2Prefab;
    public GameObject chumaki3Prefab;
    public GameObject futomakiPrefab;
    Vector3 sushiPos;
    IngredientController ingredientController;

    private void OnMouseDown()
    {
        _startPosition = GetMouseWorldPosition();
        _isBeingDragged = true;
        Vector3 _offset = new Vector3(-0.8f, 0.1f, 0);
        sushiPos = gameObject.transform.position + _offset;
    }

    private void OnMouseDrag()
    {
        if (_isBeingDragged)
        {

            _endPosition = GetMouseWorldPosition();
            Debug.Log(_endPosition);
            // Calculate the distance between the start position and the end position
            float distanceDragged = Vector3.Distance(_startPosition, _endPosition);

            // If the dragged distance is greater than 1 unit, create sushi
            if (distanceDragged >= 0.07f)
            {
                InstantiateSushi();
                _isBeingDragged = false;
                Destroy(gameObject);
            }
        }
    }

    private Vector3 GetMouseWorldPosition()
    {
        Vector3 screenMousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane);
        return Camera.main.ScreenToWorldPoint(screenMousePos);
    }

    private void InstantiateSushi()
    {
        if (ingredientController.differentIngredientCount == 1)
        {
            Vector3 sushiPosition = _endPosition;
            Instantiate(hosomakiPrefab, sushiPos, Quaternion.identity);
        }

        else if (ingredientController.differentIngredientCount == 2)
        {
            Vector3 sushiPosition = _endPosition;
            Instantiate(chumaki2Prefab, sushiPos, Quaternion.identity);
        }

        else if (ingredientController.differentIngredientCount == 3)
        {
            Vector3 sushiPosition = _endPosition;
            Instantiate(chumaki3Prefab, sushiPos, Quaternion.identity);
        }

        else
        {
            Vector3 sushiPosition = _endPosition;
            Instantiate(futomakiPrefab, sushiPos, Quaternion.identity);
        }
    }
}
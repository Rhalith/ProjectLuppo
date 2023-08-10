using System.Collections.Generic;
using UnityEngine;

public class SeaweedWrap : MonoBehaviour
{
    private Vector3 _startPosition;
    private Vector3 _endPosition;
    private bool _isBeingDragged = false;
    //TODO: all of the sushi prefabs should be in different class
    public GameObject hosomakiPrefab;
    public GameObject chumaki2Prefab;
    public GameObject chumaki3Prefab;
    public GameObject futomakiPrefab;
    private GameObject _instObj;
    //TODO: sushiPos will be assigned in rolling animations end.
    Vector3 sushiPos;
    private List<SushiIngredient> _sushiIngredients = new ();
    public int salmonCounter;
    public int cucumberCounter;

    public List<SushiIngredient> DifferentIngredients { get => _sushiIngredients; set => _sushiIngredients = value; }

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
            //Debug.Log(_endPosition);
            // Calculate the distance between the start position and the end position
            float distanceDragged = Vector3.Distance(_startPosition, _endPosition);

            // If the dragged distance is greater than 1 unit, create sushi
            if (distanceDragged >= 0.07f)
            {
                InstantiateSushi();
                _isBeingDragged = false;
                Destroy(GameObject.Find("Seaweed(Clone)"));
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
        //TODO: Must change scriptable object based on their ingredient (mostly done)
        if (InstantiatedController.Instance.InstantiatedIngredientCount.Equals(1))
        {
            SaveSushiIngredients();
            _instObj = Instantiate(hosomakiPrefab, sushiPos, Quaternion.identity);
            //_instObj.GetComponent<HosomakiDisplay>().sushiName = _sushiMaterial + "Hosomaki";
        }
        else if (InstantiatedController.Instance.InstantiatedIngredientCount.Equals(2))
        {
            SaveSushiIngredients();
            _instObj = Instantiate(chumaki2Prefab, sushiPos, Quaternion.identity);
            _instObj.GetComponent<ChumakiDisplay>().CheckIngredientList(_sushiIngredients);
        }
        else if (InstantiatedController.Instance.InstantiatedIngredientCount.Equals(3))
        {
            SaveSushiIngredients();
            _instObj = Instantiate(chumaki3Prefab, sushiPos, Quaternion.identity);
        }

        else
        {
            SaveSushiIngredients();
            _instObj = Instantiate(futomakiPrefab, sushiPos, Quaternion.identity);
        }
    }

    public void SaveSushiIngredients()
    {
        foreach(SushiIngredient t in IngredientController.Instance.Ingredients)
        {
            if(t != null)
            {
                if (t.Equals("Salmon"))
                {
                    salmonCounter++;
                }

                if (t.Equals("Cucumber"))
                {
                    cucumberCounter++;
                }
            }
        }

        
        //TODO: SalmonCounter and CucumberCounter is not using, so I comment it out
        //IngredientController.Instance.SalmonCounter = salmonCounter;
        //IngredientController.Instance.CucumberCounter = cucumberCounter;
    }
}
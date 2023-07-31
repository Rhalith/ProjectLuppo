using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MaterialCreator : MonoBehaviour
{
    [Header("Ingredient to Instantiate")]
    [SerializeField] GameObject _createPrefab;
    GameObject instObj;
    [SerializeField] GameObject _nigiriRice;
    public bool check = false;
    [SerializeField] GameObject _cuttingBoard;

    private void OnMouseDown()
    {
        if (!GameObject.FindWithTag("Instantiated"))
        {
            InstantiateIngredientObject();
        }

        else if (!instObj)
        {
            DestroySushiObjectIfExists();
            InstantiateIngredientObject();
        }

        else
        {
            DestroySushiObjectIfExists();
        }

    }

        //TODO: please ask about this
        public void InstantiateIngredientObject()
    {

            this.instObj = Object.Instantiate(_createPrefab);
            instObj.gameObject.tag = "Instantiated";

    }

    public void DestroySushiObjectIfExists()
    {

        Object.Destroy(GameObject.FindWithTag("Instantiated"));

    }
}

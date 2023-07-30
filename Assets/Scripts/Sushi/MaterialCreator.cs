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
        if (!check)
        {
             InstantiateIngredientObject();
        } 

        else
        {
            return;
        }
    }
    //TODO: please ask about this
    public void InstantiateIngredientObject()
    {
        if (gameObject.name == "Rice Cooker" && GameObject.FindWithTag("NigiriPlate"))
        {
            this.instObj = Object.Instantiate(_nigiriRice);
            instObj.gameObject.tag = "Ingredient";
            instObj.transform.parent = GameObject.Find("NigiriPlate(Clone)").transform;
            instObj.transform.localPosition = Vector3.zero;
            check = true;
        }

        else if(!GameObject.FindWithTag("Instantiated") && _cuttingBoard.activeInHierarchy == true)
        {
            this.instObj = Object.Instantiate(_createPrefab);
            instObj.gameObject.tag = "Ingredient";
            foreach (Transform t in instObj.transform)
            {
                t.gameObject.tag = "Ingredient";
            }
            check = true;
        }
        

        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MaterialCreator : MonoBehaviour
{
    [Header("Ingredient to Instantiate")]
    [SerializeField] GameObject createPrefab;
    GameObject instObj;
    public bool check = false;

    private void OnMouseDown()
    {
        if (!check)
        {
            InstantiateIngredientObject(createPrefab);
            check = true;
        }

        else
        {
            return;
        }
    }

    public void InstantiateIngredientObject(GameObject sushiIngredientPrefab)
    {
        this.instObj = Object.Instantiate(sushiIngredientPrefab);
        instObj.gameObject.tag = "Ingredient";
        foreach(Transform t in instObj.transform)
        {
            t.gameObject.tag = "Ingredient";
        }

        
    }
}

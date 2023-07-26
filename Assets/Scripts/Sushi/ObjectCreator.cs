using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCreator : MonoBehaviour 
{
    [SerializeField] GameObject sushiObject;
    GameObject instObj;

    public void OnMouseDown()
    {
        if (!GameObject.FindWithTag("Instantiated"))
        {
            InstantiateIngredientObject(sushiObject);
        }

        else if (!instObj)
        {
            DestroySushiObjectIfExists();
            InstantiateIngredientObject(sushiObject);
        }

        else
        {
            DestroySushiObjectIfExists();
        }

    }

    public void InstantiateIngredientObject(GameObject sushiIngredientPrefab)
    {
        this.instObj = Object.Instantiate(sushiIngredientPrefab);
        instObj.gameObject.tag = "Instantiated";
        foreach (Transform t in instObj.transform)
        {
            t.gameObject.tag = "Instantiated";
        }
    }

    public void DestroySushiObjectIfExists()
    {
     
            Object.Destroy(GameObject.FindWithTag("Instantiated"));
     
    }
}

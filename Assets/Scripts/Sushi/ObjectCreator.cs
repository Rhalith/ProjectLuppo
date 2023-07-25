using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCreator : MonoBehaviour 
{
    [SerializeField] GameObject sushiObject;
    GameObject instObj;
    private bool check = false;

    public void OnMouseDown()
    {
        if (!check)
        {
            InstantiateIngredientObject(sushiObject);
        }

        else
        {
            DestroySushiObjectIfExists();
        }

        check = !check;
    }

    public void InstantiateIngredientObject(GameObject sushiIngredientPrefab)
    {
        this.instObj = Object.Instantiate(sushiIngredientPrefab);
    }

    public void DestroySushiObjectIfExists()
    {
        if (instObj != null)
        {
            Object.Destroy(instObj.gameObject);
        }
    }
}

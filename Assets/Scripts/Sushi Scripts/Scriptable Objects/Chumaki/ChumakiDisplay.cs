using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ChumakiDisplay : MonoBehaviour
{
    public ChumakiObject chumaki;
    Renderer _fillingRend;
    public string sushiName;
    IngredientController controller;

    public GameObject[] filling;
    public Dictionary<string, int> ingredients;
    void Start()
    {
        //TODO: bad design, must properly assigned
        controller = GameObject.FindWithTag("CustomerManager").GetComponent<IngredientController>();

        if (sushiName == "Cucumber Salmon Chumaki")
        {
            chumaki = Resources.Load<ChumakiObject>("Scriptable Objects/Chumaki/Salmon Cucumber Chumaki");
            gameObject.name = "Salmon Cucumber Chumaki";
        }
        else
        {
            chumaki = Resources.Load<ChumakiObject>("Scriptable Objects/Chumaki/" + sushiName);
            gameObject.name = sushiName;
        }

        foreach (GameObject go in filling)
        {
            _fillingRend = go.GetComponent<MeshRenderer>();
            _fillingRend.enabled = true;
            int index = System.Array.IndexOf(filling, go);
            _fillingRend.material = chumaki.filling[index];
        }

        ingredients = new Dictionary<string, int>();
        FillingCount();

        controller.ClearIngredient();
    }

    private void FillingCount()
    {
        ingredients.Add("Salmon", GameObject.FindWithTag("CustomerManager").GetComponent<IngredientController>().SalmonCounter);
        ingredients.Add("Cucumber", GameObject.FindWithTag("CustomerManager").GetComponent<IngredientController>().CucumberCounter);
    }
}

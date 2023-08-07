using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.VersionControl;
using UnityEngine;

public class HosomakiDisplay : MonoBehaviour
{
    public HosomakiObject hosomaki;
    Renderer _fillingRend;

    public IngredientController controller;
    public GameObject filling;
    public GameObject filling2;
    public string[] ingredients;
    public int count = 0;
    public string sushiName;
    void Start()
    {

        gameObject.name = sushiName;
        #region Sample assigner
        hosomaki = Resources.Load<HosomakiObject>("Assets/Hosomaki/" + sushiName);
        #endregion

        _fillingRend = filling.GetComponent<MeshRenderer>();
        _fillingRend.enabled = true;
        _fillingRend.material = hosomaki.filling;

        _fillingRend = filling2.GetComponent<MeshRenderer>();
        _fillingRend.enabled = true;
        _fillingRend.material = hosomaki.filling;

        controller = GameObject.FindWithTag("CustomerManager").GetComponent<IngredientController>();

        if(gameObject.name == "Salmon Hosomaki")
        {
            count = controller.SalmonCounter;
        }
        else if(gameObject.name == "Cucumber Hosomaki")
        {
            count = controller.CucumberCounter;
        }
        controller.ClearIngredient();
    }
}

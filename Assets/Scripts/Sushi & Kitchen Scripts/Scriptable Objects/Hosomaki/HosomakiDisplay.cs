using System.Collections.Generic;
using UnityEngine;

public class HosomakiDisplay : MonoBehaviour
{
    [SerializeField] private HosomakiObject _salmonHosomaki;
    [SerializeField] private HosomakiObject _cucumberHosomaki;

    private List<SushiIngredient> _ingredients;

    [SerializeField] private MeshRenderer _fillingObject;
    public List<SushiIngredient> Ingredients { get => _ingredients; set => _ingredients = new(value); }

    public void CheckIngredientList(OrderedSushiType sushiType)
    {
        if (sushiType == OrderedSushiType.CucumberHosomaki)
        {
            gameObject.name = "Cucumber Hosomaki";
        }
        else if (sushiType == OrderedSushiType.SalmonHosomaki)
        {
            gameObject.name = "Salmon Hosomaki";
        }
    }
}

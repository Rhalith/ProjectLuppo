using System.Collections.Generic;
using UnityEngine;

public class HosomakiDisplay : MonoBehaviour
{
    [SerializeField] private HosomakiObject _salmonHosomaki;
    [SerializeField] private HosomakiObject _cucumberHosomaki;

    private HosomakiObject _hosomaki;
    private List<SushiIngredient> _ingredients;

    [SerializeField] private MeshRenderer _fillingObject;
    public List<SushiIngredient> Ingredients { get => _ingredients; set => _ingredients = new(value); }
    public void CheckIngredientList(List<SushiIngredient> ingredients)
    {
        if (ingredients.Contains(SushiIngredient.cucumber))
        {
            gameObject.name = "Cucumber Hosomaki";
            OrderController.Instance.SushiType = OrderedSushiType.CucumberHosomaki;
        }
        else if (ingredients.Contains(SushiIngredient.salmon))
        {
            gameObject.name = "Salmon Hosomaki";
            OrderController.Instance.SushiType = OrderedSushiType.SalmonHosomaki;
        }
        OrderController.Instance.Ingredients = _ingredients;
        IngredientController.Instance.ClearIngredient();
    }
}

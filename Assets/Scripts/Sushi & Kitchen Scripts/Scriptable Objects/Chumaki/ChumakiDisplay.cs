using System.Collections.Generic;
using UnityEngine;

public class ChumakiDisplay : MonoBehaviour
{
    private ChumakiObject _chumaki;
    private List<SushiIngredient> _ingredients;

    [SerializeField] private List<MeshRenderer> _fillingObjects = new();
    [SerializeField] private ChumakiObject _salmonCucumberChumaki;
    public List<SushiIngredient> Ingredients { get => _ingredients; set => _ingredients = new(value); }

    //TODO: now works with only cucumber and salmon, needs to be changed
    public void CheckIngredientList(List<SushiIngredient> ingredients)
    {
        if (ingredients.Count == 2)
        {
            if (ingredients.Contains(SushiIngredient.cucumber))
            {
                if(ingredients.Contains(SushiIngredient.salmon))
                {
                    gameObject.name = "Salmon Cucumber Chumaki";
                }
            }
        }

        for (int i = 0; i < _fillingObjects.Count; i++)
        {
            _fillingObjects[i].material = _chumaki.filling[i];
        }
    }
}

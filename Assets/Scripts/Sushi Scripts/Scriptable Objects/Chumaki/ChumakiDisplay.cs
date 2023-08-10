using System.Collections.Generic;
using UnityEngine;

public class ChumakiDisplay : MonoBehaviour
{
    private ChumakiObject _chumaki;
    public string sushiName;

    [SerializeField] private List<MeshRenderer> _fillingObjects = new();
    [SerializeField] private ChumakiObject _salmonCucumberChumaki;

    //TODO: now works with only cucumber and salmon, needs to be changed
    public void CheckIngredientList(List<SushiIngredient> ingredients)
    {
        if (ingredients.Count == 2)
        {
            if (ingredients.Contains(SushiIngredient.cucumber))
            {
                if(ingredients.Contains(SushiIngredient.salmon))
                {
                    _chumaki = _salmonCucumberChumaki;
                    gameObject.name = "Salmon Cucumber Chumaki";
                }
            }
        }
        for (int i = 0; i < _fillingObjects.Count; i++)
        {
            _fillingObjects[i].material = _chumaki.filling[i];
        }
        IngredientController.Instance.ClearIngredient();
        InstantiatedController.Instance.InstantiatedIngredientCount = 0;
    }
}

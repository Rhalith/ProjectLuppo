using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Sushi
{
    List<SushiIngredient> ingredients = new();
    SushiType sushiType;

    public Sushi(SushiType sushiType, params SushiIngredient[] ingredients)
    {
        foreach (var item in ingredients)
        {
            this.ingredients.Add(item);
        }
        this.sushiType = sushiType;
    }
    public SushiType SushiType { get => sushiType;}

    public bool CheckIngredients(List<SushiIngredient> availableIngredients)
    {
        if(ingredients.Count == 0)
        {
            Debug.Log("Sushi is empty");
            return false;
        }
        else if (availableIngredients.All(item => ingredients.Contains(item)))
        {
            return true;
        }
        return false;
    }
}

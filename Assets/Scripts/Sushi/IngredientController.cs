
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class IngredientController : MonoBehaviour
{
    public string[] ingredients;
    public int count = 0;
    public int differentIngredientCount = 0;
    bool has = false;
    public Material[] material;
    public void AddIngredient(string ingredient)
    {
        ingredients[count] = ingredient;
        count++;
        
        foreach (string t in ingredients) 
        {
            if(t.Equals(ingredient))
            {
                has = true;
                break;
            }
        }

        if (!has)
        {
            differentIngredientCount++;
        }

        else
        {
            has = false;
        }
    }
}


using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class IngredientController : MonoBehaviour
{
    public string[] ingredients;
    public int count = 0;
    public int differentIngredientCount = 0;
    bool has = false;
    public string[] material;

    //TODO: Get rid of Array, Use List instead. Much more effective and easy.
    private void Start()
    {
      ingredients = new string[100];
      material = new string[100];
    }
    public void AddIngredient(string ingredient)
    {
        if(count > 0)
        {
            if (ingredients[count-1] != null)
            {
                foreach (string t in ingredients)
                {
                    if(t != null)
                    {
                        if (t.Equals(ingredient))
                        {
                            has = true;
                            break;
                        }
                    }
                    

                    else
                    {
                        //empty
                    }
                }
            }
        }

        ingredients[count] = ingredient;
        count++;
        

        if (!has)
        {
            material[differentIngredientCount] = ingredient;
            Debug.Log("ingredients: " + material[differentIngredientCount]);
            differentIngredientCount++;
        }

        else
        {
            has = false;
        }
    }

    public void ServeSushi()
    {
        //TODO: Serving time
        System.Array.Sort(material);
    }

    public void ClearIngredient()
    {
        ingredients = new string[10];
        material = new string[10];
    }
}

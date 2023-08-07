using System.Collections.Generic;
using System.Collections;
using System;
using UnityEngine;
using TMPro;

public class IngredientController : MonoBehaviour
{
    public string[] ingredients;
    public int count = 0;
    public int differentIngredientCount = 0;
    bool has = false;
    public string[] material;

    [SerializeField] GameObject _seaweed;

    SeaweedWrap _wrap;

    public int SalmonCounter;
    public int CucumberCounter;

    private int _cucumber;
    private int _salmon;

    [SerializeField] TextMeshProUGUI _text;

    public static IngredientController Instance;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    //TODO: Get rid of Array, Use List instead. Much more effective and easy.
    private void Start()
    {
        ingredients = new string[100];
        material = new string[100];
    }

    #region Ingredients

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Chumaki"))
        {
            ChumakiDisplay chumaki = other.GetComponent<ChumakiDisplay>();
            GameObject chumakiGO = other.gameObject;

            if (chumakiGO.name == "Salmon Cucumber Chumaki")
            {
                foreach (KeyValuePair<string, int> s in chumaki.ingredients)
                {
                    if (s.Key == "Salmon")
                    {
                        _salmon = s.Value;
                    }

                    if (s.Key == "Cucumber")
                    {
                        _cucumber = s.Value;
                    }
                }
            }

            if (OrderManager.Instance.orderedSushi != OrderSushiType.SalmonCucumberChumaki)
            {
                _text.text = "Ben bu yeme�i istememi�tim!";
            }
            else if (_cucumber < 3)
            {
                _text.text = "Salatal��� az olmu�.";
            }
            else if (_cucumber > 3)
            {
                _text.text = "Salatal��� fazla olmu�.";
            }
            else if (_salmon < 3)
            {
                _text.text = "Somonu az olmu�.";
            }
            else if (_salmon > 3)
            {
                _text.text = "Somonu fazla olmu�.";
            }
            else
            {
                _text.text = "Yedi�im en g�zel sushiydi. Sanki bu d�nyadan de�il!";
            }
        }
        else if (other.CompareTag("Hosomaki"))
        {
            HosomakiDisplay hosomaki = other.GetComponent<HosomakiDisplay>();
            GameObject hosomakiGO = other.gameObject;

            if (OrderManager.Instance.orderedSushi == OrderSushiType.SalmonHosomaki)
            {
                if (hosomakiGO.name == "Salmon Hosomaki")
                {
                    if (hosomaki.count < 3)
                    {
                        _text.text = "Somonu az olmu�.";
                    }
                    else if (hosomaki.count > 3)
                    {
                        _text.text = "Somonu fazla olmu�.";
                    }
                    else
                    {
                        _text.text = "Yedi�im en g�zel sushiydi. Sanki bu d�nyadan de�il!";
                    }
                }
            }
            else if (OrderManager.Instance.orderedSushi == OrderSushiType.CucumberHosomaki)
            {
                if (hosomakiGO.name == "Cucumber Hosomaki")
                {
                    if (hosomaki.count < 3)
                    {
                        _text.text = "Salatal��� az olmu�.";
                    }

                    else if (hosomaki.count > 3)
                    {
                        _text.text = "Salatal��� fazla olmu�.";
                    }

                    else
                    {
                        _text.text = "Yedi�im en g�zel sushiydi. Sanki bu d�nyadan de�il!";
                    }
                }
            }
            else
            {
                _text.text = "Ben sizden bunu istememi�tim!";
            }
        }

        Destroy(other.gameObject);

        GameEventsManager.Instance.ServingAdded();
    }
    #endregion

    public void AddIngredient(string ingredient)
    {
        if (count > 0)
        {
            if (ingredients[count - 1] != null)
            {
                foreach (string t in ingredients)
                {
                    if (t != null)
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
            _wrap = GameObject.Find("Seaweed(Clone)").GetComponentInChildren<SeaweedWrap>();
            material[differentIngredientCount] = ingredient;
            _wrap._sushiMaterial = _wrap._sushiMaterial + material[differentIngredientCount] + " ";
            Debug.Log("ingredients: " + material[differentIngredientCount]);
            differentIngredientCount++;
        }
        else
        {
            has = false;
        }
    }

    public void ClearIngredient()
    {
        ingredients = new string[100];
        material = new string[100];
        differentIngredientCount = 0;
        count = 0;
    }
}

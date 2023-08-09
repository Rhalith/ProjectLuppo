using System.Collections.Generic;
using System.Collections;
using System;
using UnityEngine;
using TMPro;

public class IngredientController : MonoBehaviour
{
    [SerializeField] private GameObject _seaweed;
    [SerializeField] TextMeshProUGUI _text;

    private int _count;
    private int _differentIngredientCount;

    private List<string> _ingredients = new();
    private List<string> _material = new();

    private bool _has;

    private SeaweedWrap _wrap;

    private int _cucumber;
    private int _salmon;

    public static IngredientController Instance;

    public List<string> Ingredients { get => _ingredients;}
    public List<string> Material { get => _material;}
    public int DifferentIngredientCount { get => _differentIngredientCount; }

    //TODO: SalmonCounter and CucumberCounter is not using, so I comment it out
    //public int SalmonCounter;
    //public int CucumberCounter;

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

            if (OrderManager.Instance.GetOrder() != OrderedSushiType.SalmonCucumberChumaki)
            {
                _text.text = "Ben bu yemeði istememiþtim!";
            }
            else if (_cucumber < 3)
            {
                _text.text = "Salatalýðý az olmuþ.";
            }
            else if (_cucumber > 3)
            {
                _text.text = "Salatalýðý fazla olmuþ.";
            }
            else if (_salmon < 3)
            {
                _text.text = "Somonu az olmuþ.";
            }
            else if (_salmon > 3)
            {
                _text.text = "Somonu fazla olmuþ.";
            }
            else
            {
                _text.text = "Yediðim en güzel sushiydi. Sanki bu dünyadan deðil!";
            }
        }
        else if (other.CompareTag("Hosomaki"))
        {
            HosomakiDisplay hosomaki = other.GetComponent<HosomakiDisplay>();
            GameObject hosomakiGO = other.gameObject;

            if (OrderManager.Instance.GetOrder() == OrderedSushiType.SalmonHosomaki)
            {
                if (hosomakiGO.name == "Salmon Hosomaki")
                {
                    if (hosomaki.count < 3)
                    {
                        _text.text = "Somonu az olmuþ.";
                    }
                    else if (hosomaki.count > 3)
                    {
                        _text.text = "Somonu fazla olmuþ.";
                    }
                    else
                    {
                        _text.text = "Yediðim en güzel sushiydi. Sanki bu dünyadan deðil!";
                    }
                }
            }
            else if (OrderManager.Instance.GetOrder() == OrderedSushiType.CucumberHosomaki)
            {
                if (hosomakiGO.name == "Cucumber Hosomaki")
                {
                    if (hosomaki.count < 3)
                    {
                        _text.text = "Salatalýðý az olmuþ.";
                    }

                    else if (hosomaki.count > 3)
                    {
                        _text.text = "Salatalýðý fazla olmuþ.";
                    }

                    else
                    {
                        _text.text = "Yediðim en güzel sushiydi. Sanki bu dünyadan deðil!";
                    }
                }
            }
            else
            {
                _text.text = "Ben sizden bunu istememiþtim!";
            }
        }

        Destroy(other.gameObject);

        GameEventsManager.Instance.ServingAdded();
    }
    #endregion

    public void AddIngredient(string ingredient)
    {
        if (_count > 0)
        {
            if(_ingredients.Contains(ingredient))
            {
                _has = true;
            }
            else
            {
                _has = false;
            }
        }
        _ingredients.Add(ingredient);
        _count++;
        //please explain this part
        if (!_has)
        {
            //TODO: Connect it to a manager or controller to get the instantiated object
            _wrap = GameObject.Find("Seaweed(Clone)").GetComponentInChildren<SeaweedWrap>();
            _material[_differentIngredientCount] = ingredient;
            _wrap._sushiMaterial = _wrap._sushiMaterial + _material[_differentIngredientCount] + " ";
            Debug.Log("ingredients: " + _material[_differentIngredientCount]);
            _differentIngredientCount++;
        }
        else
        {
            _has = false;
        }
    }

    public void ClearIngredient()
    {
        _ingredients.Clear();
        _material.Clear();
        _differentIngredientCount = 0;
        _count = 0;
    }
}

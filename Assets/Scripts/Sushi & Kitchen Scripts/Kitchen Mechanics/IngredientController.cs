using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class IngredientController : MonoBehaviour
{
    [SerializeField] private GameObject _seaweed;
    [SerializeField] TextMeshProUGUI _text;

    private List<SushiIngredient> _ingredients = new();

    private SeaweedWrap _wrap;

    private int _cucumber;
    private int _salmon;

    public static IngredientController Instance;

    public List<SushiIngredient> Ingredients { get => _ingredients;}

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

    //void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("Chumaki"))
    //    {
    //        ChumakiDisplay chumaki = other.GetComponent<ChumakiDisplay>();

    //        if (OrderManager.Instance.GetOrder() != OrderedSushiType.SalmonCucumberChumaki)
    //        {
    //            _text.text = "Ben bu yemeði istememiþtim!";
    //        }
    //        else if (_cucumber < 3)
    //        {
    //            _text.text = "Salatalýðý az olmuþ.";
    //        }
    //        else if (_cucumber > 3)
    //        {
    //            _text.text = "Salatalýðý fazla olmuþ.";
    //        }
    //        else if (_salmon < 3)
    //        {
    //            _text.text = "Somonu az olmuþ.";
    //        }
    //        else if (_salmon > 3)
    //        {
    //            _text.text = "Somonu fazla olmuþ.";
    //        }
    //        else
    //        {
    //            _text.text = "Yediðim en güzel sushiydi. Sanki bu dünyadan deðil!";
    //        }
    //    }
    //    else if (other.CompareTag("Hosomaki"))
    //    {
    //        HosomakiDisplay hosomaki = other.GetComponent<HosomakiDisplay>();
    //        GameObject hosomakiGO = other.gameObject;

    //        if (OrderManager.Instance.GetOrder() == OrderedSushiType.SalmonHosomaki)
    //        {
    //            if (hosomakiGO.name == "Salmon Hosomaki")
    //            {
    //                if (hosomaki.count < 3)
    //                {
    //                    _text.text = "Somonu az olmuþ.";
    //                }
    //                else if (hosomaki.count > 3)
    //                {
    //                    _text.text = "Somonu fazla olmuþ.";
    //                }
    //                else
    //                {
    //                    _text.text = "Yediðim en güzel sushiydi. Sanki bu dünyadan deðil!";
    //                }
    //            }
    //        }
    //        else if (OrderManager.Instance.GetOrder() == OrderedSushiType.CucumberHosomaki)
    //        {
    //            if (hosomakiGO.name == "Cucumber Hosomaki")
    //            {
    //                if (hosomaki.count < 3)
    //                {
    //                    _text.text = "Salatalýðý az olmuþ.";
    //                }

    //                else if (hosomaki.count > 3)
    //                {
    //                    _text.text = "Salatalýðý fazla olmuþ.";
    //                }

    //                else
    //                {
    //                    _text.text = "Yediðim en güzel sushiydi. Sanki bu dünyadan deðil!";
    //                }
    //            }
    //        }
    //        else
    //        {
    //            _text.text = "Ben sizden bunu istememiþtim!";
    //        }
    //    }

    //    Destroy(other.gameObject);

    //    GameEventsManager.Instance.ServingAdded();
    //}
    #endregion

    public void AddIngredient(SushiIngredient ingredient)
    {
        if (!_ingredients.Contains(ingredient))
        {
            _wrap = InstantiatedController.Instance.SeaweedWrap;
            _wrap.DifferentIngredients.Add(ingredient);
            InstantiatedController.Instance.InstantiatedIngredientCount++;
        }
        _ingredients.Add(ingredient);
    }

    public void ClearIngredient()
    {
        _ingredients.Clear();
        InstantiatedController.Instance.InstantiatedIngredientCount = 0;
    }
}

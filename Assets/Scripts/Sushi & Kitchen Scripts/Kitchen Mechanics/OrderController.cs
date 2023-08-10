using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class OrderController : MonoBehaviour
{
    [SerializeField] TMP_Text _text;

    private List<SushiIngredient> _ingredients;
    private OrderedSushiType _sushiType;
    private GameObject _instantiatedSushi;

    public List<SushiIngredient> Ingredients { get => _ingredients; set => _ingredients = new(value); }
    public OrderedSushiType SushiType { get => _sushiType; set => _sushiType = value; }
    public GameObject InstantiatedSushi { get => _instantiatedSushi; set => _instantiatedSushi = value; }

    public static OrderController Instance;
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

    public void CheckOrder()
    {
        // Empty olduðuna dair bir uyarý verilebilir.
        if(_sushiType.Equals(OrderedSushiType.Empty))
        {
            return;
        }
        else
        {
            if (_sushiType.Equals(OrderedSushiType.SalmonCucumberChumaki))
            {
                CheckSalmonCucumberChumaki();
            }

            _ingredients.Clear();
            Destroy(_instantiatedSushi);

            // Trigger serving event
            GameEventsManager.Instance.ServingAdded();
        }
    }

    private void CheckSalmonCucumberChumaki()
    {
        if (OrderManager.Instance.GetOrder() != _sushiType)
        {
            _text.text = "Ben bu yemeði istememiþtim!";
        }
        else if (_ingredients.Count(n => n.Equals(SushiIngredient.cucumber)) < 3)
        {
            _text.text = "Salatalýðý az olmuþ.";
        }
        else if (_ingredients.Count(n => n.Equals(SushiIngredient.cucumber)) > 3)
        {
            _text.text = "Salatalýðý fazla olmuþ.";
        }
        else if (_ingredients.Count(n => n.Equals(SushiIngredient.salmon)) < 3)
        {
            _text.text = "Somonu az olmuþ.";
        }
        else if (_ingredients.Count(n => n.Equals(SushiIngredient.salmon)) > 3)
        {
            _text.text = "Somonu fazla olmuþ.";
        }
        else
        {
            _text.text = "Yediðim en güzel sushiydi. Sanki bu dünyadan deðil!";
        }
    }
}

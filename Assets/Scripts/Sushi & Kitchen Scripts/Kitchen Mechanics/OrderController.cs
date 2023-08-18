using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class OrderController : MonoBehaviour
{
    [SerializeField] private GameObject _hullHolder;
    [SerializeField] private GameObject _maskHolder;
    [SerializeField] private SushiSlicer _sushiSlicer;

    private List<SushiIngredient> _ingredients = new List<SushiIngredient>();
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
        SFXContainer.Instance.PlayMenuClickSFX();

        // Empty olduðuna dair bir uyarý verilebilir.
        if (_sushiType.Equals(OrderedSushiType.Empty))
        {
            return;
        }
        else
        {
            if (_sushiType.Equals(OrderedSushiType.CucumberHosomaki))
            {
                CheckCucumberHosomaki();
            }
            else if (_sushiType.Equals(OrderedSushiType.SalmonHosomaki))
            {
                CheckSalmonHosomaki();
            }
            else if (_sushiType.Equals(OrderedSushiType.SalmonCucumberChumaki))
            {
                CheckSalmonCucumberChumaki();
            }

            _ingredients.Clear();
            if(_hullHolder.transform.childCount > 0)
            {
                for (int i = 0; i < _hullHolder.transform.childCount; i++)
                {
                    Destroy(_hullHolder.transform.GetChild(i).gameObject);
                }
                for (int i = 0; i < _maskHolder.transform.childCount; i++)
                {
                    Destroy(_maskHolder.transform.GetChild(i).gameObject);
                }
                _sushiSlicer.ResetHullList();
            }
            else
            {
                Destroy(_instantiatedSushi);
            }
            // Trigger serving event
            GameEventsManager.Instance.ServeOrder();
            
            // Para miktarlarýnýn nasýl alýnacaðý konuþulacak. 
            MoneyManager.Instance.AddMoney(5);
        }
    }

    public void DestroyOrder()
    {
        // Empty olduðuna dair bir uyarý verilebilir.
        if (_sushiType.Equals(OrderedSushiType.Empty))
        {
            return;
        }
        else
        {
            _ingredients.Clear();
            Destroy(_instantiatedSushi);
        }
    }

    private void CheckSalmonCucumberChumaki()
    {
        if (OrderManager.Instance.GetOrder() != _sushiType)
        {
            CustomerDialogManager.Instance.ChangeText("Ben bu yemeði istememiþtim!");
        }
        else if (_ingredients.Count(n => n.Equals(SushiIngredient.cucumber)) < 3)
        {
            CustomerDialogManager.Instance.ChangeText("Salatalýðý az olmuþ.");
        }
        else if (_ingredients.Count(n => n.Equals(SushiIngredient.cucumber)) > 3)
        {
            CustomerDialogManager.Instance.ChangeText("Salatalýðý fazla olmuþ.");
        }
        else if (_ingredients.Count(n => n.Equals(SushiIngredient.salmon)) < 3)
        {
            CustomerDialogManager.Instance.ChangeText("Somonu az olmuþ.");
        }
        else if (_ingredients.Count(n => n.Equals(SushiIngredient.salmon)) > 3)
        {
            CustomerDialogManager.Instance.ChangeText("Somonu fazla olmuþ.");
        }
        else
        {
            CustomerDialogManager.Instance.ChangeText("Yediðim en güzel sushiydi. Sanki bu dünyadan deðil!");
        }
    }

    private void CheckSalmonHosomaki()
    {
        if (OrderManager.Instance.GetOrder() != _sushiType)
        {
            CustomerDialogManager.Instance.ChangeText("Ben bu yemeði istememiþtim!");
        }
        else if (_ingredients.Count(n => n.Equals(SushiIngredient.salmon)) < 3)
        {
            CustomerDialogManager.Instance.ChangeText("Somonu az olmuþ.");
        }
        else if (_ingredients.Count(n => n.Equals(SushiIngredient.salmon)) > 3)
        {
            CustomerDialogManager.Instance.ChangeText("Somonu fazla olmuþ.");
        }
        else
        {
            CustomerDialogManager.Instance.ChangeText("Yediðim en güzel sushiydi. Sanki bu dünyadan deðil!");
        }
    }

    private void CheckCucumberHosomaki()
    {
        if (OrderManager.Instance.GetOrder() != _sushiType)
        {
            CustomerDialogManager.Instance.ChangeText("Ben bu yemeði istememiþtim!");
        }
        else if (_ingredients.Count(n => n.Equals(SushiIngredient.cucumber)) < 3)
        {
            CustomerDialogManager.Instance.ChangeText("Salatalýðý az olmuþ.");
        }
        else if (_ingredients.Count(n => n.Equals(SushiIngredient.cucumber)) > 3)
        {
            CustomerDialogManager.Instance.ChangeText("Salatalýðý fazla olmuþ.");
        }
        else
        {
            CustomerDialogManager.Instance.ChangeText("Yediðim en güzel sushiydi. Sanki bu dünyadan deðil!");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class OrderController : MonoBehaviour
{
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

        // Empty oldu�una dair bir uyar� verilebilir.
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
            Destroy(_instantiatedSushi);

            // Trigger serving event
            GameEventsManager.Instance.ServeOrder();
            
            // Para miktarlar�n�n nas�l al�naca�� konu�ulacak. 
            MoneyManager.Instance.AddMoney(5);
        }
    }

    public void DestroyOrder()
    {
        // Empty oldu�una dair bir uyar� verilebilir.
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
            CustomerDialogManager.Instance.ChangeText("Ben bu yeme�i istememi�tim!");
        }
        else if (_ingredients.Count(n => n.Equals(SushiIngredient.cucumber)) < 3)
        {
            CustomerDialogManager.Instance.ChangeText("Salatal��� az olmu�.");
        }
        else if (_ingredients.Count(n => n.Equals(SushiIngredient.cucumber)) > 3)
        {
            CustomerDialogManager.Instance.ChangeText("Salatal��� fazla olmu�.");
        }
        else if (_ingredients.Count(n => n.Equals(SushiIngredient.salmon)) < 3)
        {
            CustomerDialogManager.Instance.ChangeText("Somonu az olmu�.");
        }
        else if (_ingredients.Count(n => n.Equals(SushiIngredient.salmon)) > 3)
        {
            CustomerDialogManager.Instance.ChangeText("Somonu fazla olmu�.");
        }
        else
        {
            CustomerDialogManager.Instance.ChangeText("Yedi�im en g�zel sushiydi. Sanki bu d�nyadan de�il!");
        }
    }

    private void CheckSalmonHosomaki()
    {
        if (OrderManager.Instance.GetOrder() != _sushiType)
        {
            CustomerDialogManager.Instance.ChangeText("Ben bu yeme�i istememi�tim!");
        }
        else if (_ingredients.Count(n => n.Equals(SushiIngredient.salmon)) < 3)
        {
            CustomerDialogManager.Instance.ChangeText("Somonu az olmu�.");
        }
        else if (_ingredients.Count(n => n.Equals(SushiIngredient.salmon)) > 3)
        {
            CustomerDialogManager.Instance.ChangeText("Somonu fazla olmu�.");
        }
        else
        {
            CustomerDialogManager.Instance.ChangeText("Yedi�im en g�zel sushiydi. Sanki bu d�nyadan de�il!");
        }
    }

    private void CheckCucumberHosomaki()
    {
        if (OrderManager.Instance.GetOrder() != _sushiType)
        {
            CustomerDialogManager.Instance.ChangeText("Ben bu yeme�i istememi�tim!");
        }
        else if (_ingredients.Count(n => n.Equals(SushiIngredient.cucumber)) < 3)
        {
            CustomerDialogManager.Instance.ChangeText("Salatal��� az olmu�.");
        }
        else if (_ingredients.Count(n => n.Equals(SushiIngredient.cucumber)) > 3)
        {
            CustomerDialogManager.Instance.ChangeText("Salatal��� fazla olmu�.");
        }
        else
        {
            CustomerDialogManager.Instance.ChangeText("Yedi�im en g�zel sushiydi. Sanki bu d�nyadan de�il!");
        }
    }
}

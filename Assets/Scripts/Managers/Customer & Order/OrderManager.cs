using Cinemachine;
using TMPro;
using UnityEngine;

public enum OrderedSushiType
{
    Empty,
    SalmonHosomaki,
    CucumberHosomaki,
    SalmonCucumberChumaki,
}

public class OrderManager : MonoBehaviour
{
    [SerializeField] CinemachineBrain cinemachineBrain;

    private OrderedSushiType _orderedSushi;
    public CinemachineBrain CinemachineBrain { get => cinemachineBrain; }

    public static OrderManager Instance;

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

    public OrderedSushiType GetOrder()
    {
        return _orderedSushi;
    }

    public void UpdateOrder(OrderedSushiType orderedSushi)
    {
        if(_orderedSushi == OrderedSushiType.Empty)
        {
            _orderedSushi = orderedSushi;

            CustomerDialogManager.Instance.ChangeText("Selamlar, ben bir adet " + GetFoodName(_orderedSushi) + " alabilir miyim?");
        }
    }

    public void EmptyOrder()
    {
        _orderedSushi = OrderedSushiType.Empty;
        CustomerDialogManager.Instance.ChangeText("Sipari� Yok.");
    }

    public string GetFoodName(OrderedSushiType orderedSushi)
    {
        string sushiName = "Somon Salatal�k Chumaki";

        if (orderedSushi == OrderedSushiType.CucumberHosomaki)
        {
            sushiName = "Salatal�k Hosomaki";
        }
        else if (orderedSushi == OrderedSushiType.SalmonHosomaki)
        {
            sushiName = "Somon Hosomaki";
        }
        else if (orderedSushi == OrderedSushiType.SalmonCucumberChumaki)
        {
            sushiName = "Somon Salatal�k Chumaki";
        }

        return sushiName;
    }
}

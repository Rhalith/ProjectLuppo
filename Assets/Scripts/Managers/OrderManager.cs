using UnityEngine;

public class OrderManager : MonoBehaviour
{
    public static OrderManager Instance;
    private OrderedSushiType _orderedSushi;

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
        }
    }

    public void EmptyOrder()
    {
        _orderedSushi = OrderedSushiType.Empty;
    }
}

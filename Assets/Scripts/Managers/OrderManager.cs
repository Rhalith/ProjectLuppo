using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderManager : MonoBehaviour
{
    public static OrderManager Instance;
    public OrderSushiType orderedSushi;

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

    public void UpdateOrder(OrderSushiType orderedSushi)
    {
        if(this.orderedSushi == OrderSushiType.Empty)
        {
            this.orderedSushi = orderedSushi;
        }
    }

    public void EmptyOrder()
    {
        orderedSushi = OrderSushiType.Empty;
    }
}

using UnityEngine;

public class Customer
{
    GameObject customerObj;
    OrderSushiType wantedSushi;

    public Customer(GameObject customerObj, OrderSushiType wantedSushi)
    {
        this.customerObj = customerObj;
        this.wantedSushi = wantedSushi;
    }

    public GameObject GetCustomerObj 
    { 
        get => customerObj; 
    }

    public OrderSushiType GetOrderedSushi 
    { 
        get => wantedSushi; 
    }
}

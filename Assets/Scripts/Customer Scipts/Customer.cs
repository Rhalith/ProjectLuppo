using UnityEngine;

public class Customer
{
    GameObject _customerObj;
    OrderedSushiType _orderedSushi;

    public Customer(GameObject customerObj, OrderedSushiType orderedSushi)
    {
        _customerObj = customerObj;
        _orderedSushi = orderedSushi;
    }

    public GameObject GetCustomerObj 
    { 
        get => _customerObj; 
    }

    public OrderedSushiType GetOrderedSushi 
    { 
        get => _orderedSushi; 
    }
}

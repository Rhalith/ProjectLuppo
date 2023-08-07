using UnityEngine;

public class Customer : MonoBehaviour
{
    GameObject customerObj;
    WantedSushi wantedSushi;

    public Customer(GameObject customerObj, WantedSushi wantedSushi)
    {
        this.customerObj = customerObj;
        this.wantedSushi = wantedSushi;
    }

    public GameObject GetCustomerObj 
    { 
        get => customerObj; 
    }

    public WantedSushi GetWantedSushi 
    { 
        get => wantedSushi; 
    }
}

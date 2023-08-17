using System;
using UnityEngine;

public class GameEventsManager : MonoBehaviour
{
    public static GameEventsManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("Found more than one Game Events Manager in the scene.");
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    // Button Activation/Scene Change to Kitchen
    public event Action OnReturnToKitchen;

    public void ReturnKitchen()
    {
        if (OnReturnToKitchen != null)
        {
            OnReturnToKitchen();
        }
    }

    // Button Activation/Scene Change to Customer
    public event Action OnReturnToCustomer;

    public void ReturnCustomer()
    {
        if (OnReturnToCustomer != null)
        {
            OnReturnToCustomer();
        }
    }

    public event Action OnOrderServed;

    public void ServeOrder()
    {
        if (OnOrderServed != null)
        { 
            OnOrderServed(); 
        }
    }

    //Example event(Also day end event)
    public event Action OnDayEnded;

    public void DayEnded()
    {
        if (OnDayEnded != null)
        {
            OnDayEnded();
        }
    }
}

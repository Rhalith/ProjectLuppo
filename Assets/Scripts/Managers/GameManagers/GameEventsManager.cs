using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEventsManager : MonoBehaviour
{
    public static GameEventsManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("Found more than one Game Events Manager in the scene.");
        }
        Instance = this;
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

    // Button Activation/Scene Change to Kitchen
    public event Action OnKitchenActivated;

    public void KitchenActivated()
    {
        if (OnKitchenActivated != null)
        {
            OnKitchenActivated();
        }
    }

    // Button Activation/Scene Change to Restaurant
    public event Action OnRestaurantActivated;

    public void RestaurantActivated()
    {
        if (OnRestaurantActivated != null)
        {
            OnRestaurantActivated();
        }
    }

    public event Action OnServingAdded;

    public void ServingAdded()
    {
        if (OnServingAdded != null)
        { OnServingAdded(); }
    }

    public event Action OnServingServed;

    public void ServingServed()
    {
        if (OnServingServed != null)
        {
            OnServingServed();
        }
    }
}

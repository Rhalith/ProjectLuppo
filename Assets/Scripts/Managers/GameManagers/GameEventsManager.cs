using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEventsManager : MonoBehaviour
{
    public static GameEventsManager instance { get; private set; }

    private void Awake()
    {
        if
            (instance != null)
        {
            Debug.LogError("Found more than one Game Events Manager in the scene.");
        }
        instance = this;
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
}

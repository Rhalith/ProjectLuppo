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
    public event Action onDayEnded;

    public void DayEnded()
    {
        if (onDayEnded != null)
        {
            onDayEnded();
        }
    }

    // Button Activation/Scene Change to Kitchen
    public event Action onKitchenActivated;

    public void KitchenActivated()
    {
        if (onKitchenActivated != null)
        {
            onKitchenActivated();
        }
    }

    // Button Activation/Scene Change to Restaurant
    public event Action onRestaurantActivated;

    public void RestaurantActivated()
    {
        if (onRestaurantActivated != null)
        {
            onRestaurantActivated();
        }
    }
}

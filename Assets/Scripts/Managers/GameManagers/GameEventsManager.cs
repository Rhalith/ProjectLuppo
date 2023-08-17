using System;
using UnityEngine;

public class GameEventsManager : MonoBehaviour
{

    // Game event delegate and events
    public delegate void GameEventHandler();
    public event GameEventHandler OnReturnToKitchen;
    public event GameEventHandler OnReturnToCustomer;
    public event GameEventHandler OnDayEnded;
    public event GameEventHandler OnOrderServed;

    public static GameEventsManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Debug.LogError("Found more than one Game Events Manager in the scene.");
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public void ReturnKitchen() => OnReturnToKitchen?.Invoke();

    public void ReturnCustomer() => OnReturnToCustomer?.Invoke();

    public void ServeOrder() => OnOrderServed?.Invoke();

    public void DayEnded() => OnDayEnded?.Invoke();
}

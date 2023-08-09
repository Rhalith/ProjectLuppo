
using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class InGameManager : MonoBehaviour
{
    [SerializeField] GameObject RestaurantUI;
    [SerializeField] GameObject KitchenUI;
    [SerializeField] GameObject CustomerUI;
    bool animate = false;
    bool kitchenActive = false;
    bool restaurantActive = true;
    public Animator anim;


    public void Start()
    {
        GameEventsManager.Instance.OnKitchenActivated += OnKitchenActivated;
        GameEventsManager.Instance.OnRestaurantActivated += OnRestaurantActivated;
        GameEventsManager.Instance.OnServingAdded += OnServingAdded;
        StartCoroutine(DayStart());
    }

    public void OnDestroy()
    {
        GameEventsManager.Instance.OnKitchenActivated -= OnKitchenActivated;
        GameEventsManager.Instance.OnRestaurantActivated -= OnRestaurantActivated;
    }

    public void ActivateRestaurant()
    {
        GameEventsManager.Instance.RestaurantActivated();
    }

    public void ActivateKitchen()
    {
        GameEventsManager.Instance.KitchenActivated();
    }

    private void OnKitchenActivated()
    {
        StartCoroutine(KitchenActivated());
    }

    private void OnRestaurantActivated()
    {
        StartCoroutine(RestaurantActivated());
    }

    void OnServingAdded()
    {
        OpenCustomerUI();

        StartCoroutine(RestaurantActivated());
    }

    private void OpenCustomerUI()
    {
        CustomerUI.SetActive(true);
    }

    public void CloseCustomerUI()
    {
        CustomerUI.SetActive(false);
    }

    private void OpenRestaurantUI()
    {
        CustomerUI.SetActive(true);
    }

    public void CloseRestaurantUI()
    {
        CustomerUI.SetActive(false);
    }

    IEnumerator RestaurantActivated()
    {
        KitchenUI.SetActive(false);

        yield return new WaitForSeconds(0.5f);

        OpenRestaurantUI();
    }

    IEnumerator KitchenActivated()
    {
        CloseRestaurantUI();

        yield return new WaitForSeconds(0.5f);

        KitchenUI.SetActive(true);

        //firstmethod();
        //invoke(secondmethod(), 0.5f);
        
    }

    IEnumerator DayStart()
    {
        yield return new WaitForSeconds(3f);

        OpenCustomerUI();

        OpenRestaurantUI();
    }
}

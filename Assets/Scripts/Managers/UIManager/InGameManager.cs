
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
    bool animate = false;
    bool kitchenActive = false;
    bool restaurantActive = true;
    public Animator anim;


    public void Start()
    {
        GameEventsManager.instance.OnKitchenActivated += OnKitchenActivated;
        GameEventsManager.instance.OnRestaurantActivated += OnRestaurantActivated;
        anim.GetComponent<Animator>();
    }

    public void OnDestroy()
    {
        GameEventsManager.instance.OnKitchenActivated -= OnKitchenActivated;
        GameEventsManager.instance.OnRestaurantActivated -= OnRestaurantActivated;
    }

    public void ActivateRestaurant()
    {
        GameEventsManager.instance.RestaurantActivated();
    }

    public void ActivateKitchen()
    {
        GameEventsManager.instance.KitchenActivated();
    }

    private void OnKitchenActivated()
    {
        StartCoroutine(KitchenActivated());
    }

    private void OnRestaurantActivated()
    {
        StartCoroutine(RestaurantActivated());
    }

    IEnumerator RestaurantActivated()
    {
        KitchenUI.SetActive(false);

        yield return new WaitForSeconds(0.5f);

        RestaurantUI.SetActive(true);
    }

    IEnumerator KitchenActivated()
    {
        
        
        RestaurantUI.SetActive(false);

        yield return new WaitForSeconds(0.5f);

        KitchenUI.SetActive(true);

        //firstmethod();
        //invoke(secondmethod(), 0.5f);
        
    }
}

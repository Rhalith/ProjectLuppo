
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class InGameManager : MonoBehaviour
{
    [SerializeField] GameObject restaurantUI;
    [SerializeField] GameObject kitchenUI;

    //TODO: remove unused variables
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
        kitchenUI.SetActive(false);

        yield return new WaitForSeconds(0.5f);

        restaurantUI.SetActive(true);
    }

    IEnumerator KitchenActivated()
    {
        
        
        restaurantUI.SetActive(false);
        
        yield return new WaitForSeconds(0.5f);

        kitchenUI.SetActive(true);

        //firstmethod();
        //invoke(secondmethod(), 0.5f);
        
    }
}

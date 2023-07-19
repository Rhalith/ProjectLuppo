
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
        GameEventsManager.instance.onKitchenActivated += OnKitchenActivated;
        GameEventsManager.instance.onRestaurantActivated += OnRestaurantActivated;
        anim.GetComponent<Animator>();
    }

    public void OnDestroy()
    {
        GameEventsManager.instance.onKitchenActivated -= OnKitchenActivated;
        GameEventsManager.instance.onRestaurantActivated += OnRestaurantActivated;
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
        
        kitchenActive = false;
        restaurantActive = true;
        animate = true;
        anim.SetBool("KitchenActive", kitchenActive);
        anim.SetBool("RestaurantActive", restaurantActive);
        anim.SetBool("Animate", animate);
        KitchenUI.SetActive(false);

        yield return new WaitForSeconds(0.5f);

        animate = false;
        anim.SetBool("Animate", animate);
        RestaurantUI.SetActive(true);
    }

    IEnumerator KitchenActivated()
    {
        
        
        RestaurantUI.SetActive(false);
        kitchenActive = true;
        restaurantActive = false;
        animate = true;
        anim.SetBool("KitchenActive", kitchenActive);
        anim.SetBool("RestaurantActive", restaurantActive);
        anim.SetBool("Animate", animate);
        

        yield return new WaitForSeconds(0.5f);

        animate = false;
        anim.SetBool("Animate", animate);
        KitchenUI.SetActive(true);
        
    }
}

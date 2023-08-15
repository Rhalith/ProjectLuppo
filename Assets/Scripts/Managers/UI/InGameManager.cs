using System.Collections;
using UnityEngine;

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
        GameEventsManager.Instance.OnOrderServed += OnOrderServed;
        StartCoroutine(DayStart());
    }

    public void OnDestroy()
    {
        GameEventsManager.Instance.OnKitchenActivated -= OnKitchenActivated;
        GameEventsManager.Instance.OnRestaurantActivated -= OnRestaurantActivated;
        GameEventsManager.Instance.OnOrderServed -= OnOrderServed;
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

    void OnOrderServed()
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

    private void OpenKitchenUI()
    {
        KitchenUI.SetActive(true);
    }

    public void CloseKitchenUI()
    {
        KitchenUI.SetActive(false);
    }

    IEnumerator RestaurantActivated()
    {
        CloseKitchenUI();

        yield return new WaitForSeconds(0.25f);

        OpenRestaurantUI();
    }

    IEnumerator KitchenActivated()
    {
        CloseRestaurantUI();

        yield return new WaitForSeconds(0.25f);

        OpenKitchenUI();
    }

    IEnumerator DayStart()
    {
        yield return new WaitForSeconds(3f);

        OpenCustomerUI();

        OpenRestaurantUI();
    }
}
